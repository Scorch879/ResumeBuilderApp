﻿using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FinalProjectOOP2
{
    public partial class Dashboard : Form
    {
        private string? currentUser;

        public string? CurrentUser 
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                // Add Accounts tab if user is admin and not already added
                if (!string.IsNullOrEmpty(currentUser))
                {
                    var db = new DatabaseHelper();
                    string role = db.GetUserRole(currentUser);
                    isAdmin = (role == "Admin");
                    if (isAdmin && accountsBtn == null)
                    {
                        AddAccountsTab();
                    }
                }
            }
        }

        // private Home? homeControl;
        private MyResumes? myResumes;
        public CreateResumes? createResumes;
        // private Profile? profile;
        private About? about;
        private Panel highlightPanel;
        private int targetTop;
        private FontAwesome.Sharp.IconButton? accountsBtn;
        private bool isAdmin = false;

        public Home? Home { get; set; }  // Your Home user control
        public Profile? Profile { get; set; }  // Your Profile user control
        
        //For dragging the form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Dashboard()
        {
            InitializeComponent();
            this.MouseDown += Form_MouseDown;
            headerPanel.MouseDown += Form_MouseDown;
            highlightTimer = new System.Windows.Forms.Timer();
            highlightTimer.Interval = 1; 
            highlightTimer.Tick += HighlightTimer_Tick;

            highlightPanel = new Panel
            {
                Size = new Size(5, homeBtn.Height),
                BackColor = Color.FromArgb(216,225,233)
            };

            this.Controls.Add(highlightPanel);
            highlightPanel.Left = sideLayoutTable.Left;
            highlightPanel.Top = homeBtn.Top + 10;

            highlightPanel.BringToFront();
        }

        private void Form_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CloseBtn_MouseEnter(object sender, EventArgs e)
        {
            closeBtn.BackColor = Color.LightGray;
        }

        private void CloseBtn_MouseLeave(object sender, EventArgs e)
        {
            closeBtn.BackColor = Color.Transparent;
        }

        private void MinimizeBtn_MouseEnter(object sender, EventArgs e)
        {
            minimizeBtn.BackColor = Color.LightGray;  // Hover color
        }

        private void MinimizeBtn_MouseLeave(object sender, EventArgs e)
        {
            minimizeBtn.BackColor = Color.Transparent;  
        }

        private void HighlightTimer_Tick(object? sender, EventArgs e)
        {
            float easeFactor = 0.3f;

            int currentTop = highlightPanel.Top;

            float delta = targetTop - currentTop;

            if (Math.Abs(delta) < 1f)
            {
                highlightPanel.Top = targetTop;
                highlightTimer.Stop();
            }
            else
            {
                highlightPanel.Top += (int)(delta * easeFactor);
            }
        }

        private void ActivateButton(Control button)
        {
            targetTop = button.Top + sideLayoutTable.Top;

            highlightPanel.Height = button.Height;

            highlightTimer.Start();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximizeBtn_Click(Object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(homeBtn);

            if (Home == null)
            {
                Home = new Home();
            }

            // Always update username
            Home.CurrentUsername = currentUser;

            if (!mainPanel.Controls.Contains(Home))
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(Home);
            }

            Home.Refresh(); // Move this outside so it always refreshes
        }

        private void myResumeBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(myResumeBtn);

            if (myResumes == null)
            {
                myResumes = new MyResumes();
                myResumes.Username = currentUser;
                myResumes.LoadUserResumes(currentUser);
                
            }

            if (!mainPanel.Controls.Contains(myResumes))
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(myResumes);
                myResumes.Username = currentUser;
                myResumes.LoadUserResumes(currentUser);
            }
        }

        public void createResumeBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(createResumeBtn);

            if (createResumes == null)
            {
                createResumes = new CreateResumes();
                createResumes.CurrentUsername = currentUser;
            }

            if (!mainPanel.Controls.Contains(createResumes))
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(createResumes);
                createResumes.CurrentUsername = currentUser;
                
            }
        }

        private void AddAccountsTab()
        {
            accountsBtn = new FontAwesome.Sharp.IconButton();
            accountsBtn.BackColor = Color.FromArgb(41, 128, 185);
            accountsBtn.Dock = DockStyle.Top;
            accountsBtn.FlatAppearance.BorderSize = 0;
            accountsBtn.FlatStyle = FlatStyle.Flat;
            accountsBtn.Font = new Font("Century Gothic", 13.8F);
            accountsBtn.ForeColor = Color.White;
            accountsBtn.IconChar = FontAwesome.Sharp.IconChar.Users;
            accountsBtn.IconColor = Color.FromArgb(216, 225, 233);
            accountsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            accountsBtn.IconSize = 50;
            accountsBtn.ImageAlign = ContentAlignment.MiddleLeft;
            accountsBtn.Name = "accountsBtn";
            accountsBtn.Padding = new Padding(30, 0, 0, 0);
            accountsBtn.Size = new Size(303, 67);
            accountsBtn.TabIndex = 40;
            accountsBtn.Text = " Accounts";
            accountsBtn.TextAlign = ContentAlignment.MiddleLeft;
            accountsBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            accountsBtn.UseVisualStyleBackColor = false;
            accountsBtn.Click += accountsBtn_Click;

            // Insert Accounts tab just above logoutBtn
            int logoutIndex = sideLayoutTable.Controls.IndexOf(logoutBtn);
            sideLayoutTable.Controls.Add(accountsBtn, 0, logoutIndex);
        }

        private void accountsBtn_Click(object? sender, EventArgs e)
        {
            ActivateButton(accountsBtn);

            var accountsControl = new AccountsAdminControl();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(accountsControl);
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(profileBtn);

            if (Profile == null)
            {
                Profile = new Profile();
                Profile.CurrentUsername = CurrentUser;
                Profile.LoadProfileData();
            }
            else
            {
                Profile.CurrentUsername = CurrentUser;
                Profile.LoadProfileData(); 
            }

            if (!mainPanel.Controls.Contains(Profile))
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(Profile);
            }
        }


        private void sentResumesBtn_Click(object sender, EventArgs e)
        {
            using (SentResumesForm sentResumesForm = new SentResumesForm(CurrentUser))
            {
                sentResumesForm.ShowDialog();
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            ImageAnimator.Animate(resumeIcon.Image, OnFrameChanged);

            // Gif panel setup
            DoubleBufferedPanel gifPanel = new DoubleBufferedPanel
            {
                Height = 302,
                Dock = DockStyle.Top,
                BackColor = Color.Transparent
            };

            resumeIcon.Dock = DockStyle.Fill;
            gifPanel.Controls.Add(resumeIcon);

            sideLayoutTable.Controls.Add(gifPanel);

            sideLayoutTable.Controls.SetChildIndex(gifPanel, 0);
            sideLayoutTable.Controls.SetChildIndex(homeBtn, 1);
            sideLayoutTable.Controls.SetChildIndex(myResumeBtn, 2);
            sideLayoutTable.Controls.SetChildIndex(createResumeBtn, 3);
            sideLayoutTable.Controls.SetChildIndex(profileBtn, 4);
            sideLayoutTable.Controls.SetChildIndex(logoutBtn, 5);

            homeBtn_Click(sender, e);

        }

        private void OnFrameChanged(object? o, EventArgs e)
        {
            resumeIcon.Invalidate();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            if (Login.instance == null)
                return;

            if (Application.OpenForms.Count == 1)
                Application.Exit();

            Login.instance.Show();
            this.Close();
        }

        public void CloseAndShowLogin()
        {           
            var loginForm = new Login();

            this.FormClosed += (s, args) =>
            {
                loginForm.Show();
            };

            this.Close();
        }

        
    }

    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }
    }
}
