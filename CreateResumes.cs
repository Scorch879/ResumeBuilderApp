using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectOOP2
{
    public partial class CreateResumes : UserControl, ICurrentUsername
    {
        private SavingForm? savingForm;
        private DatabaseHelper? dbHelper;
        private string? currentUser;

        public string? CurrentUsername
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
            }
        }

        public CreateResumes()
        {
            InitializeComponent();
        }


     
        private void saveResume_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(currentUser))
                    throw new Exception("No user logged in");

                // Input validation
                if (string.IsNullOrWhiteSpace(firstNameTbx.Text))
                {
                    MessageBox.Show("First name is required");
                    return;
                }

                if (string.IsNullOrWhiteSpace(emailTbx.Text) || !IsValidEmail(emailTbx.Text))
                {
                    MessageBox.Show("Valid email is required");
                    return;
                }

                dbHelper = new DatabaseHelper();
                int currentUserId = dbHelper.GetCurrentUserID(currentUser);

                if (currentUserId == 0)
                    throw new Exception("User not found");

                bool success = new ResumeDatabase().SavePersonalInfo(
                    ownerId: currentUserId,
                    firstName: firstNameTbx.Text.Trim(),
                    middleName: middleNameTbx.Text.Trim(),
                    lastName: lastNameTbx.Text.Trim(),
                    email: emailTbx.Text.Trim(),
                    phoneNum: phoneNumTbx.Text.Trim(),
                    address: addressTbx.Text.Trim(),
                    designation: designationTbx.Text.Trim(),
                    summary: summaryTbx.Text.Trim()
                );

                MessageBox.Show(success ? "Personal info saved successfully!" : "No changes were made");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            } 
        }

   private bool IsValidEmail(string email)
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




        public void GenerateResume()
        {
            string firstName, middleName, lastName, email, phoneNum, address, designation, summary;

            firstName = firstNameTbx.Text.Trim();
            middleName = middleNameTbx.Text.Trim();
            lastName = lastNameTbx.Text.Trim();
            email = emailTbx.Text.Trim();
            phoneNum = phoneNumTbx.Text.Trim();
            address = addressTbx.Text.Trim();
            designation = designationTbx.Text.Trim();
            summary = summaryTbx.Text.Trim();

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                    string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNum))
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}
