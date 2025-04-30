using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using Windows.Networking;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;

namespace FinalProjectOOP2
{
    public interface ICurrentUsername
    {
        public string? CurrentUsername { get; set; }
    }

    public class DatabaseHelper
    {
        protected readonly string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\C# Codes\\FinalProjectOOP2\\Accounts.accdb";
        OleDbDataAdapter? da;
        DataSet? ds;
        private OleDbConnection? myConn;

        public DatabaseHelper()
        {
            myConn = new OleDbConnection(connectionString);
        }

        //Testing Section
        public bool TestConnection()
        {
            bool isSuccees = false;
            OleDbConnection myConn = new OleDbConnection(connectionString);
            try
            {
                myConn.Open();
                ds = new DataSet();
                isSuccees = true;
            }
            catch (Exception)
            {
                isSuccees = false;
            }
            myConn.Close();

            return isSuccees;
        }

        //Login & Register Methods
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

                        UpdateLastLogin(username);
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

        //Retrieve Operations
        public Image GetProfilePic(int userId)
        {
            string query = "SELECT ProfilePic FROM UserQuery WHERE ID = @UserId";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        byte[] imageData = (byte[])result;
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            return Image.FromStream(ms);  // Convert byte array back to Image
                        }
                    }
                    else
                    {
                        return null;  // No profile picture
                    }
                }
            }
        }

        public (string username, string email, string fullName, byte[] profilePic, string description) GetUserDetailsByUsername(string username)
        {
            string? userName = "User";
            string? userEmail = "user@example.com";
            string? fullName = "Full Name";
            byte[]? profilePic = null;
            string? description = "No Description";

            string query = "SELECT Username, Email, FullName, ProfilePic, Description FROM UserQuery WHERE Username = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", username);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userName = reader["Username"].ToString();
                                userEmail = reader["Email"].ToString();
                                fullName = reader["FullName"].ToString();
                                profilePic = reader["ProfilePic"] as byte[]; // cast to byte[] if profile picture exists
                                description = reader["Description"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching user details: {ex.Message}");
                }
            }

            return (userName, userEmail, fullName, profilePic, description);
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

        public string GetLastLogin(string username)
        {
            string lastLogin = "Never"; //Default value

            string query = "SELECT LastLogin FROM UserQuery WHERE Username = ?";

            using (OleDbConnection con = new OleDbConnection(connectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, con))
            {
                cmd.Parameters.AddWithValue("?", username);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();

                if (result != DBNull.Value && result != null)
                    lastLogin = Convert.ToDateTime(result).ToString("dd/MM/yyyy");
            }

            return lastLogin;
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

        public int GetCurrentUserID(string username)
        {
            int currentUserID = 0; //default value 

            string query = "SELECT ID FROM UserQuery WHERE Username = ?";

            using (OleDbConnection con = new OleDbConnection(connectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, con))
            {
                cmd.Parameters.AddWithValue("?", username);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
            }

            return currentUserID;
        }


        //Update Operations
        public bool UpdateUsername(string newUsername, string currentUsername)
        {
            string query = "UPDATE UserQuery SET Username = ? WHERE Username = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", newUsername);
                        cmd.Parameters.AddWithValue("?", currentUsername); // Current username for verification

                        int rowsAffected = cmd.ExecuteNonQuery();
                      
                        return rowsAffected > 0; // Return true if the update is successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating username: {ex.Message}");
                    return false;
                }
            }
        }
        

        public bool UpdateEmail(string newEmail, string currentUsername)
        {
            // Ensure correct table name
            string query = "UPDATE UserQuery   SET Email = @Email WHERE Username = @Username";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Use named parameters
                        cmd.Parameters.AddWithValue("@Email", newEmail);
                        cmd.Parameters.AddWithValue("@Username", currentUsername); // Use username to identify the user

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0; // Return true if the update is successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating email: {ex.Message}");
                    return false;
                }
            }
        }

        public bool UpdateProfilePicture(string currentUsername, byte[] imageBytes)
        {
            string query = "UPDATE UserQuery SET ProfilePic = ? WHERE Username = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", imageBytes); // Store the image as a binary array
                        cmd.Parameters.AddWithValue("?", currentUsername); // Use username to identify the user

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if the update is successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating profile picture: {ex.Message}");
                    return false;
                }
            }
        }

        public bool UpdateDescription(string username, string newDescription)
        {
            string query = "UPDATE UserQuery SET Description = ? WHERE Username = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", newDescription);
                        cmd.Parameters.AddWithValue("?", username);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating description: {ex.Message}");
                    return false;
                }
            }
        }

        public bool UpdateFullName(string newFullName, string currentUsername)
        {
            string query = "UPDATE UserQuery SET FullName = ? WHERE Username = ?";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", newFullName);
                        cmd.Parameters.AddWithValue("?", currentUsername);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating full name: " + ex.Message);
                    return false;
                }
            }
        }

        public void UpdateLastLogin(string username)
        {
            string query = "UPDATE UserQuery SET LastLogin = @LastLogin WHERE Username = @Username";
            using (OleDbConnection con = new OleDbConnection(connectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, con))
            {
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                cmd.Parameters.AddWithValue("?", date);
                cmd.Parameters.AddWithValue("?", username);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
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



        //Delete Operations
        public bool DeleteAccount(string username, string password)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // 1. Get user ID first
                    int userId;
                    using (OleDbCommand cmd = new OleDbCommand(
                        "SELECT ID FROM Users WHERE Username = @Username", conn))
                    {
                        cmd.Parameters.Add("@Username", OleDbType.VarChar).Value = username;
                        userId = (int)cmd.ExecuteScalar();
                    }


                    // 2. Delete from Users
                    using (OleDbCommand cmd = new OleDbCommand(
                        "DELETE FROM Users WHERE ID = @ID", conn))
                    {
                        cmd.Parameters.Add("@ID", OleDbType.Integer).Value = userId;
                        cmd.ExecuteNonQuery();
                    }

                    using (OleDbCommand cmd = new OleDbCommand(
                        "DELETE FROM UserInfo WHERE ID = @ID", conn))
                    {
                        cmd.Parameters.Add("@ID", OleDbType.Integer).Value = userId;
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Deletion failed: {ex.Message}");
                return false;
            }
        }

        ///Helper Methods i.e verifying password or email format
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

        public bool isValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}