using System.Data.OleDb;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Linq;

namespace FinalProjectOOP2
{
    public class ResumeDatabase : DatabaseHelper
    {
        //Template Related Operations
        public interface IResumeSaveable
        {
            bool SaveResume(string currentUsername, string resumeTitle);
            void LoadResume(ResumeSummary resume);
        }

        public interface IResumeExportable
        {
            void ExportToPDF(string outputPath, int resumeId);
        }


        #region For Analytics Methods

        //Main Fetch Method
        public (int resumesCreated, int resumesSaved, int resumesExported, int resumesSent) GetUserAnalytics(int userId)
        {
            string query = @"
        SELECT 
            IIf(IsNull(ResumesCreated),0,ResumesCreated), 
            IIf(IsNull(ResumesSaved),0,ResumesSaved), 
            IIf(IsNull(ResumesExported),0,ResumesExported), 
            IIf(IsNull(ResumesSent),0,ResumesSent) 
        FROM UserInfo WHERE ID = ?";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("?", userId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (
                            reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader.GetValue(0)),
                            reader.IsDBNull(1) ? 0 : Convert.ToInt32(reader.GetValue(1)),
                            reader.IsDBNull(2) ? 0 : Convert.ToInt32(reader.GetValue(2)),
                            reader.IsDBNull(3) ? 0 : Convert.ToInt32(reader.GetValue(3))
                        );
                    }
                }
            }
            return (0, 0, 0, 0);
        }

        //For Resumes Created and Saved
        public void IncrementResumesCreatedAndSaved(int userId)
        {
            string query = @"
        UPDATE UserInfo 
        SET 
            ResumesCreated = IIF(ResumesCreated IS NULL, 1, ResumesCreated + 1),
            ResumesSaved = IIF(ResumesSaved IS NULL, 1, ResumesSaved + 1)
        WHERE ID = ?";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", userId);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                        MessageBox.Show("No rows updated. Check if userId is correct and exists in UserInfo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error incrementing ResumesCreated and ResumesSaved: " + ex.Message);
            }
        }

        public void DecrementResumesCreatedAndSaved(int userId)
        {
            string query = @"
        UPDATE UserInfo 
        SET 
            ResumesCreated = IIF(ResumesCreated IS NULL OR ResumesCreated <= 0, 0, ResumesCreated - 1),
            ResumesSaved = IIF(ResumesSaved IS NULL OR ResumesSaved <= 0, 0, ResumesSaved - 1)
        WHERE ID = ?";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", userId);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                        MessageBox.Show("No rows updated. Check if userId is correct and exists in UserInfo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error decrementing ResumesCreated and ResumesSaved: " + ex.Message);
            }
        }

        public void SyncResumesCreatedAndSaved(int userId)
        {
            string query = @"
        UPDATE UserInfo 
        SET 
            ResumesCreated = (SELECT COUNT(*) FROM Resumes WHERE OwnerID = ?),
            ResumesSaved = (SELECT COUNT(*) FROM Resumes WHERE OwnerID = ?)
        WHERE ID = ?";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", userId);
                    cmd.Parameters.AddWithValue("?", userId);
                    cmd.Parameters.AddWithValue("?", userId);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                        MessageBox.Show("No rows updated during sync. Check if userId is correct and exists in UserInfo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error syncing ResumesCreated and ResumesSaved: " + ex.Message);
            }
        }

        //For Resumes Exported
        public void IncrementResumesExported(int userId)
        {
            string query = "UPDATE UserInfo SET ResumesExported = IIf(IsNull(ResumesExported), 0, ResumesExported) + 1 WHERE ID = ?";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("?", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //For Resumes Sent
        public void IncrementResumesSent(int userId)
        {
            string query = "UPDATE UserInfo SET ResumesSent = IIf(IsNull(ResumesSent), 0, ResumesSent) + 1 WHERE ID = ?";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("?", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion


        #region Fetching Data from Database (Not resume specific)

        //Fetching Methods
        public DataTable LoadSentResumes(int userId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            ID,
                            ResumePath,
                            Recipients,
                            Subject,
                            Message,
                            HasCoverLetter,
                            SentDate
                        FROM SentResumes 
                        WHERE UserID = ? 
                        ORDER BY SentDate DESC";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", userId);
                        dt.Load(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading sent resumes: {ex.Message}");
            }
            return dt;
        }

        public List<ResumeSummary> GetRecentResumesForUser(int ownerId, int count = 5)
        {
            return GetAllResumesForUser(ownerId).OrderByDescending(r => r.DateCreated).Take(count).ToList();
        }

        public List<ResumeSummary> GetAllResumesForUser(int ownerId)
        {
            var resumes = new List<ResumeSummary>();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                // Join Resumes and ResumeInfo to get TemplateType and LastUpdated
                string query = @"SELECT r.ID, r.Title, r.DateCreated, r.FilePath, ri.TemplateType, ri.LastUpdated
                                 FROM Resumes r
                                 LEFT JOIN ResumeInfo ri ON r.ID = ri.ResumeID
                                 WHERE r.OwnerID = ?
                                 ORDER BY r.DateCreated DESC";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", ownerId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resumes.Add(new ResumeSummary
                            {
                                ResumeID = Convert.ToInt32(reader["ID"]),
                                Title = reader["Title"].ToString(),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"]),
                                FilePath = reader["FilePath"].ToString(),
                                TemplateType = reader["TemplateType"] == DBNull.Value ? null : reader["TemplateType"].ToString(),
                                DateModified = Convert.ToDateTime(reader["DateCreated"]),
                            });
                        }
                    }
                }
            }
            return resumes;
        }

        public string GetTemplateTypeForResume(int resumeId)
        {
            string templateType = "";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TemplateType FROM ResumeInfo WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        templateType = result.ToString();
                }
            }
            return templateType;
        }

        public string GetResumeDateModified(int resumeID)
        {
            string? dateModified = "";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT LastUpdated FROM ResumeInfo WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeID);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        dateModified = result.ToString();
                }
            }
            if (dateModified != null)
                return dateModified;
            else
                return "";
        }

        #endregion

       

        // Helper to extract image bytes from OLE Object
        public static byte[] ExtractImageFromOLEField(byte[] oleFieldBytes)
        {
            // JPEG header: FF D8
            byte[] jpegHeader = new byte[] { 0xFF, 0xD8 };
            // PNG header: 89 50 4E 47
            byte[] pngHeader = new byte[] { 0x89, 0x50, 0x4E, 0x47 };

            int startIndex = -1;

            // Search for JPEG header
            for (int i = 0; i < oleFieldBytes.Length - jpegHeader.Length; i++)
            {
                if (oleFieldBytes[i] == jpegHeader[0] && oleFieldBytes[i + 1] == jpegHeader[1])
                {
                    startIndex = i;
                    break;
                }
                // Search for PNG header
                if (oleFieldBytes[i] == pngHeader[0] && oleFieldBytes[i + 1] == pngHeader[1] &&
                    oleFieldBytes[i + 2] == pngHeader[2] && oleFieldBytes[i + 3] == pngHeader[3])
                {
                    startIndex = i;
                    break;
                }
            }

            if (startIndex >= 0)
            {
                byte[] imgBytes = new byte[oleFieldBytes.Length - startIndex];
                Array.Copy(oleFieldBytes, startIndex, imgBytes, 0, imgBytes.Length);
                return imgBytes;
            }
            // If not found, return original
            return oleFieldBytes;
        }

        //Delete Methods
        public bool DeleteResume(int resumeId)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Check if there are any sent resume records first
                        bool hasSentResumes = false;
                        using (OleDbCommand checkCmd = new OleDbCommand("SELECT COUNT(*) FROM SentResumes WHERE ResumePath LIKE ?", conn, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("?", $"%{resumeId}%");
                            hasSentResumes = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
                        }

                        // Only try to delete from SentResumes if records exist
                        if (hasSentResumes)
                        {
                            using (OleDbCommand cmd = new OleDbCommand("DELETE FROM SentResumes WHERE ResumePath LIKE ?", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("?", $"%{resumeId}%");
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 1. Delete from child tables first (order matters due to FK constraints)
                        // Electrical Engineering
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM ElectricalEngineeringExperienceContribution WHERE ExperienceID IN (SELECT ID FROM ElectricalEngineeringExperience WHERE ResumeID = ?)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM ElectricalEngineeringExperience WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM ElectricalEngineeringExpertise WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM ElectricalEngineeringEducation WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM ElectricalEngineeringResume WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }

                        // Attorney
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM AttorneyExperience WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM AttorneyEducation WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM AttorneyLicense WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM AttorneyEarlierPosition WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM AttorneyResume WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }

                        // Doctor
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM DoctorExperience WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM DoctorEducation WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM DoctorLicense WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM DoctorAffiliation WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM DoctorResume WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }

                        // Call Center
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM CallCenterExperience WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM CallCenterEducation WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM CallCenterResume WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }

                        // ResumeInfo
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM ResumeInfo WHERE ResumeID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Finally, delete from Resumes
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM Resumes WHERE ID = ?", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            int rows = cmd.ExecuteNonQuery();
                            transaction.Commit();
                            return rows > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Failed to delete resume: {ex.Message}");
                        return false;
                    }
                }
            }
        }


        #region Load Methods for Resume Templates

        public object? LoadResume(int resumeId, string? templateType)
        {
            if (string.IsNullOrEmpty(templateType))
                return null;

            return templateType switch
            {
                "Attorney" => LoadAttorneyResume(resumeId),
                "Doctor" => LoadDoctorResume(resumeId),
                "CallCenter" => LoadCallCenterResume(resumeId),
                "ElectricalEngineering" => LoadEEResume(resumeId),
                _ => null
            };
        }

        public PersonalInfo LoadPersonalInfo(int OwnerID)
        {
            var info = new PersonalInfo();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                //1. Search for the Info of the Owner if it exists
                string searchInfoQuery = "SELECT COUNT(*) FROM PersonalInfo WHERE OwnerID = ?";
                using (OleDbCommand searchCmd = new OleDbCommand(searchInfoQuery, conn))
                {
                    searchCmd.Parameters.AddWithValue("?", OwnerID);

                    int count = (int)searchCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // 2. Load PersonalInfo
                        string personalInfoQuery = "SELECT * FROM PersonalInfo WHERE OwnerID = ?";
                        using (OleDbCommand cmd = new OleDbCommand(personalInfoQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("?", OwnerID);
                            using (OleDbDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    info.FirstName = reader["FirstName"].ToString();
                                    info.MiddleName = reader["MiddleName"].ToString();
                                    info.LastName = reader["LastName"].ToString();
                                    info.Email = reader["Email"].ToString();
                                    info.Phone = reader["PhoneNum"].ToString();
                                    info.Address = reader["Address"].ToString();
                                    info.Title = reader["Designation"].ToString();
                                    info.Summary = reader["Summary"].ToString();
                                    var rawBytes = reader["ProfilePic"] == DBNull.Value ? null : (byte[])reader["ProfilePic"];
                                    info.ProfilePic = rawBytes != null ? ExtractImageFromOLEField(rawBytes) : null;
                                }
                            }
                        }
                    }
                }

            }

            return info;
        }

        //For Attorney Resume
        public AttorneyResumeModel LoadAttorneyResume(int resumeId)
        {
            var resumeModel = new AttorneyResumeModel();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // 1. Load PersonalInfo
                string personalInfoQuery = "SELECT * FROM PersonalInfo WHERE OwnerID = (SELECT OwnerID FROM Resumes WHERE ID = ?)";
                using (OleDbCommand cmd = new OleDbCommand(personalInfoQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            resumeModel.FirstName = reader["FirstName"].ToString();
                            resumeModel.MiddleName = reader["MiddleName"].ToString();
                            resumeModel.LastName = reader["LastName"].ToString();
                            resumeModel.Email = reader["Email"].ToString();
                            resumeModel.Phone = reader["PhoneNum"].ToString();
                            resumeModel.Address = reader["Address"].ToString();
                            resumeModel.Title = reader["Designation"].ToString();
                            resumeModel.Summary = reader["Summary"].ToString();
                            resumeModel.Name = $"{resumeModel.FirstName} {resumeModel.MiddleName} {resumeModel.LastName}";
                            var rawBytes = reader["ProfilePic"] == DBNull.Value ? null : (byte[])reader["ProfilePic"];
                            resumeModel.ProfilePic = rawBytes != null ? ExtractImageFromOLEField(rawBytes) : null;
                        }
                    }
                }

                // 2. Load AttorneyResume
                string attorneyQuery = "SELECT * FROM AttorneyResume WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(attorneyQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            resumeModel.CoreSkills = reader["CoreSkills"].ToString()?.Split(';').ToList();
                            resumeModel.LegalTech = reader["LegalTech"].ToString()?.Split(';').ToList();
                            resumeModel.BarAdmissions = reader["BarAdmissions"].ToString()?.Split(';').ToList();
                            resumeModel.Expertise = reader["Expertise"].ToString()?.Split(';').ToList();
                        }
                    }
                }

                // 3. Load Education
                string educationQuery = "SELECT * FROM AttorneyEducation WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(educationQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        resumeModel.Education = new List<AttorneyEducation>();
                        while (reader.Read())
                        {
                            resumeModel.Education.Add(new AttorneyEducation
                            {
                                DegreePosition = reader["DegreePosition"].ToString(),
                                Institution = reader["Institution"].ToString(),
                                Location = reader["Location"].ToString()
                            });
                        }
                    }
                }

                // 4. Load Experience
                string experienceQuery = "SELECT * FROM AttorneyExperience WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(experienceQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        resumeModel.Experience = new List<AttorneyExperience>();
                        while (reader.Read())
                        {
                            resumeModel.Experience.Add(new AttorneyExperience
                            {
                                Position = reader["Position"].ToString(),
                                Company = reader["Company"].ToString(),
                                Location = reader["Location"].ToString(),
                                Duration = reader["Duration"].ToString(),
                                Description = reader["Description"].ToString(),
                                Contributions = reader["Contributions"] == DBNull.Value
                                    ? new List<string>()
                                    : reader["Contributions"].ToString().Split(';').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList()
                            });
                        }
                    }
                }

                // 5. Load Licenses
                string licenseQuery = "SELECT * FROM AttorneyLicense WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(licenseQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        resumeModel.Licenses = new List<AttorneyLicense>();
                        while (reader.Read())
                        {
                            resumeModel.Licenses.Add(new AttorneyLicense
                            {
                                Type = reader["LicenseType"].ToString(),
                                LicenseNumber = reader["LicenseNumber"].ToString(),
                                AdmissionDate = Convert.ToDateTime(reader["AdmissionDate"])
                            });
                        }
                    }
                }

                // 6. Load Earlier Positions
                string earlierPositionsQuery = "SELECT * FROM AttorneyEarlierPosition WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(earlierPositionsQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        resumeModel.EarlierPositions = new List<EarlierPosition>();
                        while (reader.Read())
                        {
                            resumeModel.EarlierPositions.Add(new EarlierPosition
                            {
                                Position = reader["Position"].ToString(),
                                Company = reader["Company"].ToString(),
                                Location = reader["Location"].ToString(),
                                Duration = reader["Duration"].ToString()
                            });
                        }
                    }
                }
            }

            return resumeModel;
        }

        //Doctor Resume
        public DoctorResumeModel LoadDoctorResume(int resumeId)
        {
            var resumeModel = new DoctorResumeModel();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // 1. Load PersonalInfo
                string personalInfoQuery = "SELECT * FROM PersonalInfo WHERE OwnerID = (SELECT OwnerID FROM Resumes WHERE ID = ?)";
                using (OleDbCommand cmd = new OleDbCommand(personalInfoQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            resumeModel.FirstName = reader["FirstName"].ToString();
                            resumeModel.MiddleName = reader["MiddleName"].ToString();
                            resumeModel.LastName = reader["LastName"].ToString();
                            resumeModel.Email = reader["Email"].ToString();
                            resumeModel.Phone = reader["PhoneNum"].ToString();
                            resumeModel.Address = reader["Address"].ToString();
                            resumeModel.Title = reader["Designation"].ToString();
                            resumeModel.Summary = reader["Summary"].ToString();
                            resumeModel.Name = $"{resumeModel.FirstName} {resumeModel.MiddleName} {resumeModel.LastName}";
                            var rawBytes = reader["ProfilePic"] == DBNull.Value ? null : (byte[])reader["ProfilePic"];
                            resumeModel.ProfilePic = rawBytes != null ? ExtractImageFromOLEField(rawBytes) : null;
                        }
                    }
                }

                // 2. Load DoctorResume
                string doctorQuery = "SELECT * FROM DoctorResume WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(doctorQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            resumeModel.ClinicalSkills = reader["ClinicalSkills"].ToString()?.Split(';').ToList();
                            resumeModel.MedicalTech = reader["MedTechSkills"].ToString()?.Split(';').ToList();
                            resumeModel.AreasOfExpertise = reader["AreasOfExpertise"].ToString()?.Split(';').ToList();
                        }
                    }
                }

                // 3. Load Education
                string educationQuery = "SELECT * FROM DoctorEducation WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(educationQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        resumeModel.Education = new List<DoctorEducationItem>();
                        while (reader.Read())
                        {
                            resumeModel.Education.Add(new DoctorEducationItem
                            {
                                Degree = reader["Degree"].ToString(),
                                Institution = reader["Institution"].ToString(),
                                Specialization = reader["Specialization"].ToString(),
                                Location = reader["Location"].ToString()
                            });
                        }
                    }
                }

                // 4. Load Experience
                string experienceQuery = "SELECT * FROM DoctorExperience WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(experienceQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        resumeModel.Experience = new List<DoctorExperienceItem>();
                        while (reader.Read())
                        {
                            string? contributionsStr = reader["Contribution"].ToString();
                            List<string> contributions = string.IsNullOrEmpty(contributionsStr)
                                ? new List<string>()
                                : contributionsStr.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(s => s.Trim())
                                                .ToList();

                            resumeModel.Experience.Add(new DoctorExperienceItem
                            {
                                Position = reader["Position"].ToString(),
                                Company = reader["Company"].ToString(),
                                Location = reader["Location"].ToString(),
                                Duration = reader["Duration"].ToString(),
                                Description = reader["Description"].ToString(),
                                Contributions = contributions
                            });
                        }
                    }
                }

                // 5. Load Licenses
                string licenseQuery = "SELECT * FROM DoctorLicense WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(licenseQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        resumeModel.Licenses = new List<DoctorLicense>();
                        while (reader.Read())
                        {
                            resumeModel.Licenses.Add(new DoctorLicense
                            {
                                Type = reader["LicenseType"].ToString(),
                                LicenseNumber = reader["LicenseNumber"].ToString(),
                                InitialDate = Convert.ToDateTime(reader["InitialDate"]),
                                ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"])
                            });
                        }
                    }
                }

                // 6. Load Affiliations
                string affiliationsQuery = "SELECT * FROM DoctorAffiliation WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(affiliationsQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        resumeModel.Affiliations = new List<DoctorAffiliation>();
                        while (reader.Read())
                        {
                            resumeModel.Affiliations.Add(new DoctorAffiliation
                            {
                                Status = reader["Status"].ToString(),
                                Institution = reader["Institution"].ToString()
                            });
                        }
                    }
                }
            }

            return resumeModel;
        }

        //CallCenter Resume
        public CallCenterResume.CallCenterResumeModel LoadCallCenterResume(int resumeId)
        {
            var resumeModel = new CallCenterResume.CallCenterResumeModel();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // 1. Get OwnerID
                int ownerId = 0;
                string ownerQuery = "SELECT OwnerID FROM Resumes WHERE ID = ?";
                using (OleDbCommand cmd = new OleDbCommand(ownerQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        ownerId = Convert.ToInt32(result);
                }

                // 2. Load Personal Info
                string personalInfoQuery = "SELECT * FROM PersonalInfo WHERE OwnerID = ?";
                using (OleDbCommand cmd = new OleDbCommand(personalInfoQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", ownerId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            resumeModel.FirstName = reader["FirstName"].ToString();
                            resumeModel.MiddleName = reader["MiddleName"].ToString();
                            resumeModel.LastName = reader["LastName"].ToString();
                            resumeModel.Email = reader["Email"].ToString();
                            resumeModel.Phone = reader["PhoneNum"].ToString();
                            resumeModel.Address = reader["Address"].ToString();
                            resumeModel.Title = reader["Designation"].ToString();
                            resumeModel.Summary = reader["Summary"].ToString();
                            resumeModel.Name = $"{resumeModel.FirstName} {resumeModel.MiddleName} {resumeModel.LastName}";
                            var rawBytes = reader["ProfilePic"] == DBNull.Value ? null : (byte[])reader["ProfilePic"];
                            resumeModel.ProfilePic = rawBytes != null ? ExtractImageFromOLEField(rawBytes) : null;
                        }
                    }
                }

                // 3. Load CallCenterResume (skills/languages)
                string resumeQuery = "SELECT * FROM CallCenterResume WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(resumeQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            resumeModel.CoreSkills = reader["CoreSkills"].ToString()?.Split(';').ToList();
                            resumeModel.TechSkills = reader["TechSkills"].ToString()?.Split(';').ToList();
                            resumeModel.Languages = reader["Languages"].ToString()?.Split(';').ToList();
                        }
                    }
                }

                // 4. Load Education
                resumeModel.Education = new List<CallCenterResume.EducationItem>();
                string educationQuery = "SELECT * FROM CallCenterEducation WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(educationQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resumeModel.Education.Add(new CallCenterResume.EducationItem
                            {
                                Degree = reader["Degree"].ToString(),
                                School = reader["School"].ToString(),
                                Location = reader["Location"].ToString(),
                                Year = reader["Year"].ToString()
                            });
                        }
                    }
                }

                // 5. Load Experience
                resumeModel.Experience = new List<CallCenterResume.ExperienceItem>();
                string experienceQuery = "SELECT * FROM CallCenterExperience WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(experienceQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var responsibilities = reader["Responsibilities"].ToString()?.Split(';').ToList() ?? new List<string>();
                            resumeModel.Experience.Add(new CallCenterResume.ExperienceItem
                            {
                                Title = reader["JobTitle"].ToString(),
                                Company = reader["Company"].ToString(),
                                Location = reader["Location"].ToString(),
                                Duration = reader["Duration"].ToString(),
                                Achievement = reader["Achievement"].ToString(),
                                Responsibilities = responsibilities
                            });
                        }
                    }
                }
            }
            return resumeModel;
        }

        //Electrical Engineer Resume
        public ElectricalEngineeringResumeModel LoadEEResume(int resumeId)
        {
            var resumeModel = new ElectricalEngineeringResumeModel();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // 1. Get OwnerID
                int ownerId = 0;
                string ownerQuery = "SELECT OwnerID FROM Resumes WHERE ID = ?";
                using (OleDbCommand cmd = new OleDbCommand(ownerQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        ownerId = Convert.ToInt32(result);
                }

                // 2. Load Personal Info
                string personalInfoQuery = "SELECT * FROM PersonalInfo WHERE OwnerID = ?";
                using (OleDbCommand cmd = new OleDbCommand(personalInfoQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", ownerId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            resumeModel.FirstName = reader["FirstName"].ToString();
                            resumeModel.MiddleName = reader["MiddleName"].ToString();
                            resumeModel.LastName = reader["LastName"].ToString();
                            resumeModel.Email = reader["Email"].ToString();
                            resumeModel.Phone = reader["PhoneNum"].ToString();
                            resumeModel.Address = reader["Address"].ToString();
                            resumeModel.Title = reader["Designation"].ToString();
                            resumeModel.Summary = reader["Summary"].ToString();
                            resumeModel.Name = $"{resumeModel.FirstName} {resumeModel.MiddleName} {resumeModel.LastName}";
                            var rawBytes = reader["ProfilePic"] == DBNull.Value ? null : (byte[])reader["ProfilePic"];
                            resumeModel.ProfilePic = rawBytes != null ? ExtractImageFromOLEField(rawBytes) : null;
                        }
                    }
                }

                // 3. Load Resume Skills
                string resumeQuery = "SELECT * FROM ElectricalEngineeringResume WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(resumeQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            resumeModel.CoreSkills = reader["CoreSkills"].ToString()?.Split(';').ToList();
                            resumeModel.TechSkills = reader["TechSkills"].ToString()?.Split(';').ToList();
                            resumeModel.ProfessionalDevelopment = reader["ProfessionalDevelopment"] != DBNull.Value ? reader["ProfessionalDevelopment"].ToString()?.Split(';').ToList() : new List<string>();
                        }
                    }
                }

                // 4. Load Technical Expertise
                var techExpertise = new TechExpertise();
                string expertiseQuery = "SELECT Category, Skill FROM ElectricalEngineeringExpertise WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(expertiseQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        var plcs = new List<string>();
                        var designSkills = new List<string>();
                        var methodologies = new List<string>();
                        var productionSkills = new List<string>();
                        while (reader.Read())
                        {
                            string? category = reader["Category"].ToString();
                            string? skill = reader["Skill"].ToString();
                            switch (category)
                            {
                                case "PLC": plcs.Add(skill); break;
                                case "Design": designSkills.Add(skill); break;
                                case "Methodology": methodologies.Add(skill); break;
                                case "Production": productionSkills.Add(skill); break;
                            }
                        }
                        techExpertise.PLCs = plcs;
                        techExpertise.DesignSkills = designSkills;
                        techExpertise.Methodologies = methodologies;
                        techExpertise.ProductionSkills = productionSkills;
                    }
                }
                resumeModel.TechnicalExpertise = techExpertise;

                // 5. Load Education
                resumeModel.Education = new List<EEEducationItem>();
                string educationQuery = "SELECT * FROM ElectricalEngineeringEducation WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(educationQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resumeModel.Education.Add(new EEEducationItem
                            {
                                Degree = reader["Degree"].ToString(),
                                School = reader["School"].ToString(),
                                Location = reader["Location"].ToString(),
                                Year = reader["Year"].ToString()
                            });
                        }
                    }
                }

                // 6. Load Experience and Contributions
                resumeModel.Experience = new List<EEExperienceItem>();
                string experienceQuery = "SELECT * FROM ElectricalEngineeringExperience WHERE ResumeID = ?";
                using (OleDbCommand cmd = new OleDbCommand(experienceQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", resumeId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int experienceId = Convert.ToInt32(reader["ID"]);
                            var expItem = new EEExperienceItem
                            {
                                Position = reader["Position"].ToString(),
                                Company = reader["Company"].ToString(),
                                Location = reader["Location"].ToString(),
                                Duration = reader["Duration"].ToString(),
                                Achievement = reader["Achievement"].ToString(),
                                Contributions = new List<string>()
                            };
                            // Load contributions for this experience
                            string contribQuery = "SELECT Contribution FROM ElectricalEngineeringExperienceContribution WHERE ExperienceID = ?";
                            using (OleDbCommand contribCmd = new OleDbCommand(contribQuery, conn))
                            {
                                contribCmd.Parameters.AddWithValue("?", experienceId);
                                using (OleDbDataReader contribReader = contribCmd.ExecuteReader())
                                {
                                    while (contribReader.Read())
                                    {
                                        expItem.Contributions.Add(contribReader["Contribution"].ToString());
                                    }
                                }
                            }
                            resumeModel.Experience.Add(expItem);
                        }
                    }
                }
            }
            return resumeModel;
        }

        #endregion

        #region Saving Personal Info of templates (this remains the same across all templates)

        //For PersonalInfo
        public int SavePersonalInfo(PersonalInfo personalInfo, string currentUsername)
        {
            int ownerID = GetCurrentUserID(currentUsername);
            if (ownerID == 0)
            {
                MessageBox.Show("Error: Could not find current user.");
                return 0;
            }

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // 1. Check if record exists
                string checkQuery = "SELECT COUNT(*) FROM PersonalInfo WHERE OwnerID = ?";
                using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("?", ownerID);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // 2. Update existing record
                        string updateQuery = @"
                            UPDATE PersonalInfo 
                            SET FirstName = ?, MiddleName = ?, LastName = ?, Email = ?, PhoneNum = ?, Address = ?, Designation = ?, Summary = ?, ProfilePic = ?
                            WHERE OwnerID = ?";
                        using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, connection))
                        {
                            updateCmd.Parameters.AddWithValue("?", personalInfo.FirstName ?? "");
                            updateCmd.Parameters.AddWithValue("?", personalInfo.MiddleName ?? "");
                            updateCmd.Parameters.AddWithValue("?", personalInfo.LastName ?? "");
                            updateCmd.Parameters.AddWithValue("?", personalInfo.Email ?? "");
                            updateCmd.Parameters.AddWithValue("?", personalInfo.Phone ?? "");
                            updateCmd.Parameters.AddWithValue("?", personalInfo.Address ?? "");
                            updateCmd.Parameters.AddWithValue("?", personalInfo.Title ?? "");
                            updateCmd.Parameters.AddWithValue("?", personalInfo.Summary ?? "");
                            updateCmd.Parameters.AddWithValue("?", personalInfo.ProfilePic ?? (object)DBNull.Value);
                            updateCmd.Parameters.AddWithValue("?", ownerID);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // 3. Insert new record
                        string insertQuery = @"
                            INSERT INTO PersonalInfo (OwnerID, FirstName, MiddleName, LastName, Email, PhoneNum, Address, Designation, Summary, ProfilePic) 
                            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                        using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("?", ownerID);
                            insertCmd.Parameters.AddWithValue("?", personalInfo.FirstName ?? "");
                            insertCmd.Parameters.AddWithValue("?", personalInfo.MiddleName ?? "");
                            insertCmd.Parameters.AddWithValue("?", personalInfo.LastName ?? "");
                            insertCmd.Parameters.AddWithValue("?", personalInfo.Email ?? "");
                            insertCmd.Parameters.AddWithValue("?", personalInfo.Phone ?? "");
                            insertCmd.Parameters.AddWithValue("?", personalInfo.Address ?? "");
                            insertCmd.Parameters.AddWithValue("?", personalInfo.Title ?? "");
                            insertCmd.Parameters.AddWithValue("?", personalInfo.Summary ?? "");
                            insertCmd.Parameters.AddWithValue("?", personalInfo.ProfilePic ?? (object)DBNull.Value);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
                return ownerID;
            }
        }

        #endregion

        #region CallCenterResume Database Methods
        public bool SaveCallCenterResume(int ownerId, string resumeTitle, List<string> coreSkills, List<string> techSkills, List<string> languages,
            List<CallCenterResume.EducationItem> education, List<CallCenterResume.ExperienceItem> experience)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert into Resumes
                        int resumeId;
                        using (OleDbCommand cmd = new OleDbCommand(
                            "INSERT INTO Resumes (OwnerID, Title, DateCreated, FilePath) VALUES (?, ?, ?, ?)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", ownerId);
                            cmd.Parameters.AddWithValue("?", resumeTitle);
                            cmd.Parameters.AddWithValue("?", DateTime.Today);
                            cmd.Parameters.AddWithValue("?", ""); // FilePath not used
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "SELECT @@IDENTITY";
                            cmd.Parameters.Clear();
                            resumeId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 2. Insert into ResumeInfo
                        using (OleDbCommand cmd = new OleDbCommand(
                            "INSERT INTO ResumeInfo (ResumeID, OwnerID, DateCreated, LastUpdated, TemplateType) VALUES (?, ?, ?, ?, ?)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.Parameters.AddWithValue("?", ownerId);
                            cmd.Parameters.AddWithValue("?", DateTime.Today);
                            cmd.Parameters.AddWithValue("?", DateTime.Today);
                            cmd.Parameters.AddWithValue("?", "CallCenter");
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Insert into CallCenterResume
                        using (OleDbCommand cmd = new OleDbCommand(
                            "INSERT INTO CallCenterResume (ResumeID, OwnerID, CoreSkills, TechSkills, Languages) VALUES (?, ?, ?, ?, ?)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.Parameters.AddWithValue("?", ownerId);
                            cmd.Parameters.AddWithValue("?", string.Join(";", coreSkills));
                            cmd.Parameters.AddWithValue("?", string.Join(";", techSkills));
                            cmd.Parameters.AddWithValue("?", string.Join(";", languages));
                            cmd.ExecuteNonQuery();
                        }

                        // 4. Insert Education
                        if (education != null)
                        {
                            foreach (var edu in education)
                            {
                                using (OleDbCommand cmd = new OleDbCommand(
                                    "INSERT INTO CallCenterEducation (ResumeID, OwnerID, Degree, School, Location, [Year]) VALUES (?, ?, ?, ?, ?, ?)", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("?", resumeId);
                                    cmd.Parameters.AddWithValue("?", ownerId);
                                    cmd.Parameters.AddWithValue("?", edu.Degree ?? "");
                                    cmd.Parameters.AddWithValue("?", edu.School ?? "");
                                    cmd.Parameters.AddWithValue("?", edu.Location ?? "");
                                    cmd.Parameters.AddWithValue("?", edu.Year ?? "");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // 5. Insert Experience
                        if (experience != null)
                        {
                            foreach (var exp in experience)
                            {
                                using (OleDbCommand cmd = new OleDbCommand(
                                    "INSERT INTO CallCenterExperience (ResumeID, OwnerID, JobTitle, Company, Location, Duration, Achievement, Responsibilities) VALUES (?, ?, ?, ?, ?, ?, ?, ?)", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("?", resumeId);
                                    cmd.Parameters.AddWithValue("?", ownerId);
                                    cmd.Parameters.AddWithValue("?", exp.Title ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Company ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Location ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Duration ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Achievement ?? "");
                                    cmd.Parameters.AddWithValue("?", string.Join(";", exp.Responsibilities ?? new List<string>()));
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Save failed: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        // Add a method to get all resumes for a user
        public List<ResumeInfo> GetUserResumes(int ownerId)
        {
            List<ResumeInfo> resumes = new List<ResumeInfo>();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT r.*, ri.DateCreated, ri.LastUpdated, ri.TemplateType
            FROM CallCenterResume r
            INNER JOIN ResumeInfo ri ON r.OwnerID = ri.OwnerID
            WHERE r.OwnerID = ?
            ORDER BY ri.DateCreated DESC";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", ownerId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resumes.Add(new ResumeInfo
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                OwnerID = Convert.ToInt32(reader["OwnerID"]),
                                CoreSkills = reader["CoreSkills"].ToString(),
                                TechSkills = reader["TechSkills"].ToString(),
                                Languages = reader["Languages"].ToString(),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"]),
                                LastUpdated = Convert.ToDateTime(reader["LastUpdated"]),
                                TemplateType = reader["TemplateType"].ToString()
                            });
                        }
                    }
                }
            }

            return resumes;
        }

        // Class to hold resume information
        public class ResumeInfo
        {
            public int ID { get; set; }
            public int OwnerID { get; set; }
            public string? CoreSkills { get; set; }
            public string? TechSkills { get; set; }
            public string? Languages { get; set; }
            public DateTime DateCreated { get; set; }
            public DateTime LastUpdated { get; set; }
            public string? TemplateType { get; set; }
        }

        // Method to update an existing resume
        public bool UpdateCallCenterResume(
            int resumeId,
            int ownerId,
            List<string> coreSkills,
            List<string> techSkills,
            List<string> languages,
            List<CallCenterResume.EducationItem> education,
            List<CallCenterResume.ExperienceItem> experience)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Update ResumeInfo
                            string updateResumeInfoQuery = @"
                        UPDATE ResumeInfo 
                        SET LastUpdated = ? 
                        WHERE OwnerID = ? AND TemplateType = 'CallCenter'";

                            using (OleDbCommand cmd = new OleDbCommand(updateResumeInfoQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("?", DateTime.Now);
                                cmd.Parameters.AddWithValue("?", ownerId);
                                cmd.ExecuteNonQuery();
                            }

                            // 2. Update CallCenterResume
                            string updateQuery = @"
                        UPDATE CallCenterResume 
                        SET CoreSkills = ?, TechSkills = ?, Languages = ?
                        WHERE ID = ? AND OwnerID = ?";

                            using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("?", string.Join(";", coreSkills));
                                cmd.Parameters.AddWithValue("?", string.Join(";", techSkills));
                                cmd.Parameters.AddWithValue("?", string.Join(";", languages));
                                cmd.Parameters.AddWithValue("?", resumeId);
                                cmd.Parameters.AddWithValue("?", ownerId);
                                cmd.ExecuteNonQuery();
                            }

                            // 3. Delete existing education and experience records
                            using (OleDbCommand cmd = new OleDbCommand())
                            {
                                cmd.Connection = conn;
                                cmd.Transaction = transaction;

                                cmd.CommandText = "DELETE FROM CallCenterEducation WHERE CallCenterResumeID = ?";
                                cmd.Parameters.AddWithValue("?", resumeId);
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = "DELETE FROM CallCenterExperience WHERE CallCenterResumeID = ?";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("?", resumeId);
                                cmd.ExecuteNonQuery();
                            }

                            // 4. Insert new education records
                            if (education != null && education.Count > 0)
                            {
                                string eduQuery = @"INSERT INTO CallCenterEducation 
                            (CallCenterResumeID, Degree, School, Location, [Year]) 
                            VALUES (?, ?, ?, ?, ?)";

                                using (OleDbCommand cmd = new OleDbCommand(eduQuery, conn, transaction))
                                {
                                    foreach (var edu in education)
                                    {
                                        cmd.Parameters.Clear();
                                        cmd.Parameters.AddWithValue("?", resumeId);
                                        cmd.Parameters.AddWithValue("?", edu.Degree ?? "");
                                        cmd.Parameters.AddWithValue("?", edu.School ?? "");
                                        cmd.Parameters.AddWithValue("?", edu.Location ?? "");
                                        cmd.Parameters.AddWithValue("?", edu.Year ?? "");
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            // 5. Insert new experience records
                            if (experience != null && experience.Count > 0)
                            {
                                string expQuery = @"INSERT INTO CallCenterExperience 
                            (CallCenterResumeID, JobTitle, Company, Location, Duration, Achievement, Responsibilities) 
                            VALUES (?, ?, ?, ?, ?, ?, ?)";

                                using (OleDbCommand cmd = new OleDbCommand(expQuery, conn, transaction))
                                {
                                    foreach (var exp in experience)
                                    {
                                        cmd.Parameters.Clear();
                                        cmd.Parameters.AddWithValue("?", resumeId);
                                        cmd.Parameters.AddWithValue("?", exp.Title ?? "");
                                        cmd.Parameters.AddWithValue("?", exp.Company ?? "");
                                        cmd.Parameters.AddWithValue("?", exp.Location ?? "");
                                        cmd.Parameters.AddWithValue("?", exp.Duration ?? "");
                                        cmd.Parameters.AddWithValue("?", exp.Achievement ?? "");
                                        cmd.Parameters.AddWithValue("?", string.Join(";", exp.Responsibilities ?? new List<string>()));
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Update Error: {ex.Message}");
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection Error: {ex.Message}");
                    return false;
                }
            }
        }

        #endregion

        #region Doctor Resume Database Methods
        public bool SaveDoctorResume(int ownerId, string resumeTitle, List<string> clinicalSkills, List<string> medTechSkills, List<string> areasOfExpertise,
            List<DoctorExperienceItem> experience, List<DoctorLicense> licenses, List<DoctorAffiliation> affiliations, List<DoctorEducationItem> education)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert into Resumes
                        int resumeId;
                        using (OleDbCommand cmd = new OleDbCommand(
                            "INSERT INTO Resumes (OwnerID, Title, DateCreated, FilePath) VALUES (?, ?, ?, ?)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", ownerId);
                            cmd.Parameters.AddWithValue("?", resumeTitle);
                            cmd.Parameters.AddWithValue("?", DateTime.Today);
                            cmd.Parameters.AddWithValue("?", "");
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "SELECT @@IDENTITY";
                            cmd.Parameters.Clear();
                            resumeId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 2. Insert into ResumeInfo
                        using (OleDbCommand cmd = new OleDbCommand(
                            "INSERT INTO ResumeInfo (ResumeID, OwnerID, DateCreated, LastUpdated, TemplateType) VALUES (?, ?, ?, ?, ?)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.Parameters.AddWithValue("?", ownerId);
                            cmd.Parameters.AddWithValue("?", DateTime.Today);
                            cmd.Parameters.AddWithValue("?", DateTime.Today);
                            cmd.Parameters.AddWithValue("?", "Doctor");
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Insert into DoctorResume
                        using (OleDbCommand cmd = new OleDbCommand(
                            "INSERT INTO DoctorResume (ResumeID, OwnerID, ClinicalSkills, MedTechSkills, AreasOfExpertise) VALUES (?, ?, ?, ?, ?)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.Parameters.AddWithValue("?", ownerId);
                            cmd.Parameters.AddWithValue("?", string.Join(";", clinicalSkills));
                            cmd.Parameters.AddWithValue("?", string.Join(";", medTechSkills));
                            cmd.Parameters.AddWithValue("?", string.Join(";", areasOfExpertise));
                            cmd.ExecuteNonQuery();
                        }

                        // 4. Insert Experience
                        if (experience != null)
                        {
                            foreach (var exp in experience)
                            {
                                using (OleDbCommand cmd = new OleDbCommand(
                                    "INSERT INTO DoctorExperience (ResumeID, OwnerID, [Position], [Company], [Location], [Duration], [Description], [Contribution]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("?", resumeId);
                                    cmd.Parameters.AddWithValue("?", ownerId);
                                    cmd.Parameters.AddWithValue("?", exp.Position ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Company ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Location ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Duration ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Description ?? "");
                                    cmd.Parameters.AddWithValue("?", string.Join(";", exp.Contributions ?? new List<string>()));
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // 5. Insert Licenses
                        if (licenses != null)
                        {
                            foreach (var lic in licenses)
                            {
                                using (OleDbCommand cmd = new OleDbCommand(
                                    "INSERT INTO DoctorLicense (ResumeID, OwnerID, LicenseType, LicenseNumber, InitialDate, ExpiryDate) VALUES (?, ?, ?, ?, ?, ?)", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("?", resumeId);
                                    cmd.Parameters.AddWithValue("?", ownerId);
                                    cmd.Parameters.AddWithValue("?", lic.Type ?? "");
                                    cmd.Parameters.AddWithValue("?", lic.LicenseNumber ?? "");
                                    cmd.Parameters.AddWithValue("?", lic.InitialDate);
                                    cmd.Parameters.AddWithValue("?", lic.ExpiryDate);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // 6. Insert Affiliations
                        if (affiliations != null)
                        {
                            foreach (var aff in affiliations)
                            {
                                using (OleDbCommand cmd = new OleDbCommand(
                                    "INSERT INTO DoctorAffiliation (ResumeID, OwnerID, Status, Institution) VALUES (?, ?, ?, ?)", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("?", resumeId);
                                    cmd.Parameters.AddWithValue("?", ownerId);
                                    cmd.Parameters.AddWithValue("?", aff.Status ?? "");
                                    cmd.Parameters.AddWithValue("?", aff.Institution ?? "");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // 7. Insert Education
                        if (education != null)
                        {
                            foreach (var edu in education)
                            {
                                using (OleDbCommand cmd = new OleDbCommand(
                                    "INSERT INTO DoctorEducation (ResumeID, OwnerID, Degree, Institution, Specialization, Location) VALUES (?, ?, ?, ?, ?, ?)", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("?", resumeId);
                                    cmd.Parameters.AddWithValue("?", ownerId);
                                    cmd.Parameters.AddWithValue("?", edu.Degree ?? "");
                                    cmd.Parameters.AddWithValue("?", edu.Institution ?? "");
                                    cmd.Parameters.AddWithValue("?", edu.Specialization ?? "");
                                    cmd.Parameters.AddWithValue("?", edu.Location ?? "");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Save failed: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        #endregion

        #region Attorney Database Methods
        public bool SaveAttorneyResume(int ownerId, string resumeTitle, List<string> coreSkills, List<string> legalTech, List<string> barAdmissions, List<string> expertise,
            List<AttorneyEducation> education, List<AttorneyExperience> experience, List<AttorneyLicense> licenses, List<EarlierPosition> earlierPositions)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert into Resumes
                        int resumeId;
                        using (OleDbCommand cmd = new OleDbCommand(
                            "INSERT INTO Resumes (OwnerID, Title, DateCreated, FilePath) VALUES (?, ?, ?, ?)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", ownerId);
                            cmd.Parameters.AddWithValue("?", resumeTitle);
                            cmd.Parameters.AddWithValue("?", DateTime.Today);
                            cmd.Parameters.AddWithValue("?", "");
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "SELECT @@IDENTITY";
                            cmd.Parameters.Clear();
                            resumeId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 2. Insert into ResumeInfo
                        using (OleDbCommand cmd = new OleDbCommand(
                            "INSERT INTO ResumeInfo (ResumeID, OwnerID, DateCreated, LastUpdated, TemplateType) VALUES (?, ?, ?, ?, ?)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.Parameters.AddWithValue("?", ownerId);
                            cmd.Parameters.AddWithValue("?", DateTime.Today);
                            cmd.Parameters.AddWithValue("?", DateTime.Today);
                            cmd.Parameters.AddWithValue("?", "Attorney");
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Insert into AttorneyResume
                        using (OleDbCommand cmd = new OleDbCommand(
                            "INSERT INTO [AttorneyResume] ([ResumeID], [OwnerID], [CoreSkills], [LegalTech], [BarAdmissions], [Expertise]) VALUES (?, ?, ?, ?, ?, ?)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.Parameters.AddWithValue("?", ownerId);
                            cmd.Parameters.AddWithValue("?", string.Join(";", coreSkills));
                            cmd.Parameters.AddWithValue("?", string.Join(";", legalTech));
                            cmd.Parameters.AddWithValue("?", string.Join(";", barAdmissions));
                            cmd.Parameters.AddWithValue("?", string.Join(";", expertise));
                            cmd.ExecuteNonQuery();
                        }

                        // 4. Insert Education
                        if (education != null)
                        {
                            foreach (var edu in education)
                            {
                                using (OleDbCommand cmd = new OleDbCommand(
                                    "INSERT INTO [AttorneyEducation] ([ResumeID], [OwnerID], [DegreePosition], [Institution], [Location]) VALUES (?, ?, ?, ?, ?)", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("?", resumeId);
                                    cmd.Parameters.AddWithValue("?", ownerId);
                                    cmd.Parameters.AddWithValue("?", edu.DegreePosition ?? "");
                                    cmd.Parameters.AddWithValue("?", edu.Institution ?? "");
                                    cmd.Parameters.AddWithValue("?", edu.Location ?? "");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // 5. Insert Experience
                        if (experience != null)
                        {
                            foreach (var exp in experience)
                            {
                                using (OleDbCommand cmd = new OleDbCommand(
                                    "INSERT INTO [AttorneyExperience] ([ResumeID], [OwnerID], [Position], [Company], [Location], [Duration], [Description], [Contributions]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("?", resumeId);
                                    cmd.Parameters.AddWithValue("?", ownerId);
                                    cmd.Parameters.AddWithValue("?", exp.Position ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Company ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Location ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Duration ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Description ?? "");
                                    cmd.Parameters.AddWithValue("?", string.Join(";", exp.Contributions ?? new List<string>()));
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // 6. Insert Licenses
                        if (licenses != null)
                        {
                            foreach (var lic in licenses)
                            {
                                using (OleDbCommand cmd = new OleDbCommand(
                                    "INSERT INTO [AttorneyLicense] ([ResumeID], [OwnerID], [LicenseType], [LicenseNumber], [AdmissionDate]) VALUES (?, ?, ?, ?, ?)", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("?", resumeId);
                                    cmd.Parameters.AddWithValue("?", ownerId);
                                    cmd.Parameters.AddWithValue("?", lic.Type ?? "");
                                    cmd.Parameters.AddWithValue("?", lic.LicenseNumber ?? "");
                                    cmd.Parameters.AddWithValue("?", lic.AdmissionDate);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // 7. Insert Earlier Positions
                        if (earlierPositions != null)
                        {
                            foreach (var pos in earlierPositions)
                            {
                                using (OleDbCommand cmd = new OleDbCommand(
                                    "INSERT INTO [AttorneyEarlierPosition] ([ResumeID], [OwnerID], [Position], [Company], [Location], [Duration]) VALUES (?, ?, ?, ?, ?, ?)", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("?", resumeId);
                                    cmd.Parameters.AddWithValue("?", ownerId);
                                    cmd.Parameters.AddWithValue("?", pos.Position ?? "");
                                    cmd.Parameters.AddWithValue("?", pos.Company ?? "");
                                    cmd.Parameters.AddWithValue("?", pos.Location ?? "");
                                    cmd.Parameters.AddWithValue("?", pos.Duration ?? "");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Save failed: {ex}");
                        return false;
                    }
                }
            }
        }

        #endregion

        #region Electrical Enginnering Methods

        public bool SaveElectricalEngineeringResume(
            int ownerId,
            string resumeTitle,
            List<string> coreSkills,
            List<string> techSkills,
            List<(string Category, string Skill)> expertise, // e.g. ("PLC", "Siemens")
            List<EEExperienceItem> experience,
            List<EEEducationItem> education,
            List<string> professionalDevelopment)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert into Resumes
                        int resumeId;
                        using (OleDbCommand cmd = new OleDbCommand(
                            "INSERT INTO [Resumes] ([OwnerID], [Title], [DateCreated], [FilePath]) VALUES (?, ?, ?, ?)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", ownerId);
                            cmd.Parameters.AddWithValue("?", resumeTitle);
                            cmd.Parameters.AddWithValue("?", DateTime.Today);
                            cmd.Parameters.AddWithValue("?", "");
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "SELECT @@IDENTITY";
                            cmd.Parameters.Clear();
                            resumeId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 2. Insert into ResumeInfo
                        using (OleDbCommand cmd = new OleDbCommand(
                            "INSERT INTO [ResumeInfo] ([ResumeID], [OwnerID], [DateCreated], [LastUpdated], [TemplateType]) VALUES (?, ?, ?, ?, ?)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.Parameters.AddWithValue("?", ownerId);
                            cmd.Parameters.AddWithValue("?", DateTime.Today);
                            cmd.Parameters.AddWithValue("?", DateTime.Today);
                            cmd.Parameters.AddWithValue("?", "ElectricalEngineering");
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Insert into ElectricalEngineeringResume
                        using (OleDbCommand cmd = new OleDbCommand(
                            "INSERT INTO [ElectricalEngineeringResume] ([ResumeID], [OwnerID], [CoreSkills], [TechSkills], [ProfessionalDevelopment]) VALUES (?, ?, ?, ?, ?)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", resumeId);
                            cmd.Parameters.AddWithValue("?", ownerId);
                            cmd.Parameters.AddWithValue("?", string.Join(";", coreSkills));
                            cmd.Parameters.AddWithValue("?", string.Join(";", techSkills));
                            cmd.Parameters.AddWithValue("?", professionalDevelopment != null ? string.Join(";", professionalDevelopment) : "");
                            cmd.ExecuteNonQuery();
                        }

                        // 4. Insert Expertise
                        if (expertise != null)
                        {
                            foreach (var exp in expertise)
                            {
                                using (OleDbCommand cmd = new OleDbCommand(
                                    "INSERT INTO [ElectricalEngineeringExpertise] ([ResumeID], [OwnerID], [Category], [Skill]) VALUES (?, ?, ?, ?)", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("?", resumeId);
                                    cmd.Parameters.AddWithValue("?", ownerId);
                                    cmd.Parameters.AddWithValue("?", exp.Category ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Skill ?? "");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // 5. Insert Experience and Contributions
                        if (experience != null)
                        {
                            foreach (var exp in experience)
                            {
                                int experienceId;
                                using (OleDbCommand cmd = new OleDbCommand(
                                    "INSERT INTO [ElectricalEngineeringExperience] ([ResumeID], [OwnerID], [Position], [Company], [Location], [Duration], [Achievement]) VALUES (?, ?, ?, ?, ?, ?, ?)", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("?", resumeId);
                                    cmd.Parameters.AddWithValue("?", ownerId);
                                    cmd.Parameters.AddWithValue("?", exp.Position ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Company ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Location ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Duration ?? "");
                                    cmd.Parameters.AddWithValue("?", exp.Achievement ?? "");
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = "SELECT @@IDENTITY";
                                    cmd.Parameters.Clear();
                                    experienceId = Convert.ToInt32(cmd.ExecuteScalar());
                                }

                                // Insert Contributions for this experience
                                if (exp.Contributions != null)
                                {
                                    foreach (var contrib in exp.Contributions ?? Enumerable.Empty<string>())
                                    {
                                        using (OleDbCommand cmd = new OleDbCommand(
                                            "INSERT INTO [ElectricalEngineeringExperienceContribution] ([ExperienceID], [Contribution]) VALUES (?, ?)", conn, transaction))
                                        {
                                            cmd.Parameters.AddWithValue("?", experienceId);
                                            cmd.Parameters.AddWithValue("?", contrib ?? "");
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }

                        // 6. Insert Education
                        if (education != null)
                        {
                            foreach (var edu in education)
                            {
                                using (OleDbCommand cmd = new OleDbCommand(
                                    "INSERT INTO [ElectricalEngineeringEducation] ([ResumeID], [OwnerID], [School], [Location], [Year], [Degree]) VALUES (?, ?, ?, ?, ?, ?)", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("?", resumeId);
                                    cmd.Parameters.AddWithValue("?", ownerId);
                                    cmd.Parameters.AddWithValue("?", edu.School ?? "");
                                    cmd.Parameters.AddWithValue("?", edu.Location ?? "");
                                    cmd.Parameters.AddWithValue("?", edu.Year ?? "");
                                    cmd.Parameters.AddWithValue("?", edu.Degree ?? "");

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Save failed: {ex.Message}");
                        return false;
                    }
                }
            }
        }
        #endregion

        // Fetch monthly created trend for analytics
        public List<(string Month, int CreatedCount)> GetMonthlyCreatedTrend(int ownerId)
        {
            var result = new List<(string, int)>();
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT Format(DateCreated, 'yyyy-mm') AS [Month], COUNT(*) AS CreatedCount
                    FROM ResumeInfo
                    WHERE OwnerID = ?
                    GROUP BY Format(DateCreated, 'yyyy-mm')
                    ORDER BY Format(DateCreated, 'yyyy-mm')";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", ownerId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string month = reader["Month"].ToString();
                            int count = Convert.ToInt32(reader["CreatedCount"]);
                            result.Add((month, count));
                        }
                    }
                }
            }
            return result;
        }

        // Fetch monthly sent trend for  analytics
        public List<(string Month, int SentCount)> GetMonthlySentTrend(int userId)
        {
            var result = new List<(string, int)>();
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT Format(SentDate, 'yyyy-mm') AS [Month], COUNT(*) AS SentCount
                    FROM SentResumes
                    WHERE UserID = ?
                    GROUP BY Format(SentDate, 'yyyy-mm')
                    ORDER BY Format(SentDate, 'yyyy-mm')";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string? month = reader["Month"].ToString();
                            int count = Convert.ToInt32(reader["SentCount"]);
                            result.Add((month, count));
                        }
                    }
                }
            }
            return result;
        }

        public bool SendResumeEmail(string fromEmail, string fromName, string recipients, string subject, string message, string resumePath, string coverLetterPath = null)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromEmail, fromName);
                    
                    // Add recipients
                    foreach (string recipient in recipients.Split(';'))
                    {
                        if (!string.IsNullOrWhiteSpace(recipient))
                        {
                            mail.To.Add(recipient.Trim());
                        }
                    }

                    mail.Subject = subject;
                    mail.Body = message;
                    mail.IsBodyHtml = true;

                    // Attach resume
                    if (File.Exists(resumePath))
                    {
                        mail.Attachments.Add(new Attachment(resumePath));
                    }

                    // Attach cover letter if provided
                    if (!string.IsNullOrEmpty(coverLetterPath) && File.Exists(coverLetterPath))
                    {
                        mail.Attachments.Add(new Attachment(coverLetterPath));
                    }

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("scorch857@gmail.com", "geuj lqnj rkfo prvs");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error sending email: {ex.Message}");
            }
        }

        public bool TrackSentResume(int userId, string resumePath, string recipients, string subject, string message, bool hasCoverLetter)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO SentResumes 
                        (UserID, ResumePath, Recipients, Subject, Message, HasCoverLetter, SentDate)
                        VALUES 
                        (?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("@UserID", OleDbType.Integer).Value = userId;
                        cmd.Parameters.Add("@ResumePath", OleDbType.VarWChar).Value = resumePath;
                        cmd.Parameters.Add("@Recipients", OleDbType.VarWChar).Value = recipients;
                        cmd.Parameters.Add("@Subject", OleDbType.VarWChar).Value = subject;
                        cmd.Parameters.Add("@Message", OleDbType.VarWChar).Value = message;
                        cmd.Parameters.Add("@HasCoverLetter", OleDbType.Boolean).Value = hasCoverLetter;
                        cmd.Parameters.Add("@SentDate", OleDbType.Date).Value = DateTime.Today;

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error tracking sent resume: {ex.Message}");
            }
        }

        public bool DeleteSentResume(int id)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM SentResumes WHERE ID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting sent resume: {ex.Message}");
            }
        }
    }
}
