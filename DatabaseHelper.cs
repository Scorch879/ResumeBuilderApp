using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;

namespace FinalProjectOOP2
{
    public class DatabaseHelper
    {
        private readonly string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\C# Codes\\FinalProjectOOP2\\Accounts.accdb";
        OleDbDataAdapter? da;
        DataSet? ds;
        private OleDbConnection? myConn;

        public DatabaseHelper()
        {
            myConn = new OleDbConnection(connectionString);
        }

        public string GetUserNameByEmail(string email)
        {
            string userName = "User";
            string query = "SELECT Username FROM UserQuery WHERE Email = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", email);

                        object? result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            userName = result.ToString()!;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching user name: {ex.Message}");
                }
            }
            return userName;
        }

        public void TestConnection()
        {
            OleDbConnection myConn = new OleDbConnection(connectionString);
                try
                {
                    myConn.Open();
                    ds = new DataSet();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            myConn.Close();
            MessageBox.Show("Successfully Connected!", "Information", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
        }

        public bool RegisterUser(string username, string password, string role, string email)
        {
            string existMessage = UserExists(username, email); //checks if user or email or both already exists

            if (!string.IsNullOrEmpty(existMessage))
            {
                MessageBox.Show(existMessage, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }

            string query = "INSERT INTO UserQuery (Username, [Password], Role, Email) VALUES (@Username, @Password, @role, @email)";
            
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {

                string hashedPassword = HashPassword(password); 

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@email", email);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // will return true if insertion was successful
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool LoginUser(string username, string password)
        {
            string query = "SELECT [Password] FROM UserQuery WHERE Username = @Username";
            bool isAuthenticated = false;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
          
                try
                {
                    conn.Open();
                    object? result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string? storedHashedPassword = result.ToString();

                        if (storedHashedPassword == null)
                            throw new Exception();

                        return VerifyPassword(password, storedHashedPassword);
                    }
                }
                catch (Exception)
                {
                    return isAuthenticated;
                }
            }

            return isAuthenticated;
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(inputPassword);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                string hashedInput = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                return hashedInput == storedHash;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                string result = BitConverter.ToString(hash).Replace("-", "").ToLower();

                return result;
            }
        }

        // For execution of INSERT, UPDATE, DELETE commands
        public bool ExecuteNonQuery(string query, params OleDbParameter[] parameters)
        {
            try
            {
                if (myConn == null)
                    throw new NullReferenceException();

                myConn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                {
                    cmd.Parameters.AddRange(parameters);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (myConn != null)
                {
                    myConn.Close();
                }
            }
        }

        public string UserExists(string username, string email)
        {
            string usernameQuery = "SELECT COUNT(*) FROM UserQuery WHERE Username = @Username";
            string emailQuery = "SELECT COUNT(*) FROM UserQuery WHERE Email = @Email";

            bool usernameExists = false;
            bool emailExists = false;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Username checker
                    using (OleDbCommand cmdUsername = new OleDbCommand(usernameQuery, conn))
                    {
                        cmdUsername.Parameters.AddWithValue("@Username", username);
                        object? result = cmdUsername.ExecuteScalar();
                        int count = Convert.ToInt32(result);
                        usernameExists = count > 0;
                    }

                    // Email checker
                    using (OleDbCommand cmdEmail = new OleDbCommand(emailQuery, conn))
                    {
                        cmdEmail.Parameters.AddWithValue("@Email", email);
                        object? result = cmdEmail.ExecuteScalar();
                        int count = Convert.ToInt32(result);
                        emailExists = count > 0;
                    }

            
                    if (usernameExists && emailExists)
                        return "Username and Email already exist.";
                    else if (usernameExists)
                        return "Username already exists.";
                    else if (emailExists)
                        return "Email already exists.";
                    else
                        return ""; 
                }
                catch (Exception ex)
                {
                    return "An error occurred: " + ex.Message;
                }
            }
        }

        public bool UpdatePass(string username, string newPassword)
        {
            bool isUpdated = false;
            string querySelect = "SELECT COUNT(*) FROM UserQuery WHERE Username = ?";
            string queryUpdate = "UPDATE UserQuery SET [Password] = ? WHERE Username = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    //checker if the user exists
                    using (OleDbCommand cmdSelect = new OleDbCommand(querySelect, conn))
                    {
                        cmdSelect.Parameters.AddWithValue("?", username);

                        int userCount = Convert.ToInt32(cmdSelect.ExecuteScalar());

                        if (userCount == 0)
                        {
                            MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    string hashedPassword = HashPassword(newPassword);

                    using (OleDbCommand cmdUpdate = new OleDbCommand(queryUpdate, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("?", hashedPassword);
                        cmdUpdate.Parameters.AddWithValue("?", username);

                        int rowsAffected = cmdUpdate.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            isUpdated = true;
                            MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Failed to update password.", "Error", MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating password: {ex.Message}", "Error", MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
            return isUpdated;
        }
    }
}