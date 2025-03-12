using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        //To hash password for encryption
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

        // Record Validation
        public bool RecordExists(string query, params OleDbParameter[] parameters)
        {
            try
            {
                if (myConn == null)
                    throw new NullReferenceException();

                myConn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                {
                    cmd.Parameters.AddRange(parameters);
                    object? result = cmd.ExecuteScalar();
                    return result != null;
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

        //Update Password
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

