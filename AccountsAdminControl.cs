using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FinalProjectOOP2
{
    public partial class AccountsAdminControl : UserControl
    {
        private BindingList<UserRow> usersList;
        private List<UserRow> allUsers;

        public AccountsAdminControl()
        {
            InitializeComponent();
            StyleUsersGrid();
            LoadUsers();
        }

        private void StyleUsersGrid()
        {
            // Alternating row style
            var altStyle = new DataGridViewCellStyle();
            altStyle.BackColor = Color.FromArgb(216, 225, 233);
            altStyle.ForeColor = Color.Black;
            usersGrid.AlternatingRowsDefaultCellStyle = altStyle;

            // Header style
            var headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(10, 17, 40);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            usersGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            usersGrid.ColumnHeadersHeight = 50;
            usersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Default cell style
            var cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cellStyle.BackColor = Color.FromArgb(254, 252, 251);
            cellStyle.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular);
            cellStyle.ForeColor = Color.Black;
            cellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            cellStyle.SelectionForeColor = Color.White;
            cellStyle.WrapMode = DataGridViewTriState.False;
            usersGrid.DefaultCellStyle = cellStyle;

            // Row style
            var rowStyle = new DataGridViewCellStyle();
            rowStyle.Font = new Font("Century Gothic", 14F, FontStyle.Regular);
            rowStyle.ForeColor = Color.Black;
            rowStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            rowStyle.SelectionForeColor = Color.White;
            usersGrid.RowsDefaultCellStyle = rowStyle;

            usersGrid.BackgroundColor = Color.FromArgb(216, 225, 233);
            usersGrid.BorderStyle = BorderStyle.None;
            usersGrid.EnableHeadersVisualStyles = false;
            usersGrid.GridColor = Color.FromArgb(0, 31, 84);
            usersGrid.RowTemplate.Height = 50;
            usersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadUsers()
        {
            var db = new DatabaseHelper();
            allUsers = db.GetAllUsers();
            usersList = new BindingList<UserRow>(allUsers.ToList());
            usersGrid.DataSource = usersList;
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string search = searchBox.Text.Trim().ToLower();
            var filtered = allUsers.Where(u =>
                u.Username.ToLower().Contains(search) ||
                u.Email.ToLower().Contains(search) ||
                u.Role.ToLower().Contains(search)).ToList();
            usersList = new BindingList<UserRow>(filtered);
            usersGrid.DataSource = usersList;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user to update.");
                return;
            }
            var row = usersGrid.SelectedRows[0].DataBoundItem as UserRow;
            if (row == null) return;

            using (var dialog = new UpdateUserDialog(row))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var updated = dialog.UpdatedUser;
                    var db = new DatabaseHelper();
                    if (db.UpdateUser(updated))
                    {
                        row.Email = updated.Email;
                        row.Role = updated.Role;
                        row.FullName = updated.FullName;
                        row.Description = updated.Description;
                        usersGrid.Refresh();
                        MessageBox.Show("User updated.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update user.");
                    }
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user to delete.");
                return;
            }
            var row = usersGrid.SelectedRows[0].DataBoundItem as UserRow;
            if (row == null) return;
            var confirm = MessageBox.Show($"Are you sure you want to delete user '{row.Username}'?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var db = new DatabaseHelper();
                if (db.DeleteUser(row.Username))
                {
                    allUsers.Remove(row);
                    usersList.Remove(row);
                    MessageBox.Show("User deleted.");
                }
                else
                {
                    MessageBox.Show("Failed to delete user.");
                }
            }
        }
    }

    public class UserRow
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
    }
} 