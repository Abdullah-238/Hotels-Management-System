namespace HMS
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bookRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staticesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendImailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeWallpaperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeHomeWallpaperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationArchitectureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pcWallpaper = new System.Windows.Forms.PictureBox();
            this.ctrlCurrencyEchange1 = new HMS.main.ctrlCurrencyEchange();
            this.ctrlMainInfo1 = new HMS.main.Controls.ctrlMainInfo();
            this.ctrlInfo3 = new HMS.Main.ctrlInfo();
            this.ctrlInfo2 = new HMS.Main.ctrlInfo();
            this.ctrlInfo1 = new HMS.Main.ctrlInfo();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcWallpaper)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookRoomToolStripMenuItem,
            this.bookingsToolStripMenuItem,
            this.userToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.signOutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1274, 80);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bookRoomToolStripMenuItem
            // 
            this.bookRoomToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.bookRoomToolStripMenuItem.Image = global::HMS.Properties.Resources.purchase_order;
            this.bookRoomToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bookRoomToolStripMenuItem.Name = "bookRoomToolStripMenuItem";
            this.bookRoomToolStripMenuItem.Size = new System.Drawing.Size(153, 76);
            this.bookRoomToolStripMenuItem.Text = "Book ";
            this.bookRoomToolStripMenuItem.Click += new System.EventHandler(this.bookRoomToolStripMenuItem_Click);
            // 
            // bookingsToolStripMenuItem
            // 
            this.bookingsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.bookingsToolStripMenuItem.Image = global::HMS.Properties.Resources.purchase_order;
            this.bookingsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bookingsToolStripMenuItem.Name = "bookingsToolStripMenuItem";
            this.bookingsToolStripMenuItem.Size = new System.Drawing.Size(187, 76);
            this.bookingsToolStripMenuItem.Text = "Bookings";
            this.bookingsToolStripMenuItem.Click += new System.EventHandler(this.bookingsToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userToolStripMenuItem.Image = global::HMS.Properties.Resources.bellboy;
            this.userToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(143, 76);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.floorsToolStripMenuItem,
            this.roomsToolStripMenuItem,
            this.roomTypesToolStripMenuItem,
            this.staticesToolStripMenuItem,
            this.timeSettingsToolStripMenuItem,
            this.currentUserInfoToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.sendEmailToolStripMenuItem,
            this.applicationArchitectureToolStripMenuItem,
            this.signOutToolStripMenuItem});
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.settingsToolStripMenuItem.Image = global::HMS.Properties.Resources.gear;
            this.settingsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(177, 76);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // floorsToolStripMenuItem
            // 
            this.floorsToolStripMenuItem.Image = global::HMS.Properties.Resources.merger2;
            this.floorsToolStripMenuItem.Name = "floorsToolStripMenuItem";
            this.floorsToolStripMenuItem.Size = new System.Drawing.Size(327, 30);
            this.floorsToolStripMenuItem.Text = "Floors";
            this.floorsToolStripMenuItem.Click += new System.EventHandler(this.floorsToolStripMenuItem_Click);
            // 
            // roomsToolStripMenuItem
            // 
            this.roomsToolStripMenuItem.Image = global::HMS.Properties.Resources.closet__2_;
            this.roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
            this.roomsToolStripMenuItem.Size = new System.Drawing.Size(327, 30);
            this.roomsToolStripMenuItem.Text = "Rooms";
            this.roomsToolStripMenuItem.Click += new System.EventHandler(this.roomsToolStripMenuItem_Click);
            // 
            // roomTypesToolStripMenuItem
            // 
            this.roomTypesToolStripMenuItem.Image = global::HMS.Properties.Resources.closet__3_;
            this.roomTypesToolStripMenuItem.Name = "roomTypesToolStripMenuItem";
            this.roomTypesToolStripMenuItem.Size = new System.Drawing.Size(327, 30);
            this.roomTypesToolStripMenuItem.Text = "RoomTypes";
            this.roomTypesToolStripMenuItem.Click += new System.EventHandler(this.roomTypesToolStripMenuItem_Click);
            // 
            // staticesToolStripMenuItem
            // 
            this.staticesToolStripMenuItem.Image = global::HMS.Properties.Resources.stock_market;
            this.staticesToolStripMenuItem.Name = "staticesToolStripMenuItem";
            this.staticesToolStripMenuItem.Size = new System.Drawing.Size(327, 30);
            this.staticesToolStripMenuItem.Text = "Statistics";
            this.staticesToolStripMenuItem.Click += new System.EventHandler(this.staticesToolStripMenuItem_Click);
            // 
            // timeSettingsToolStripMenuItem
            // 
            this.timeSettingsToolStripMenuItem.Image = global::HMS.Properties.Resources.gear;
            this.timeSettingsToolStripMenuItem.Name = "timeSettingsToolStripMenuItem";
            this.timeSettingsToolStripMenuItem.Size = new System.Drawing.Size(327, 30);
            this.timeSettingsToolStripMenuItem.Text = "Hotel Settings";
            this.timeSettingsToolStripMenuItem.Click += new System.EventHandler(this.timeSettingsToolStripMenuItem_Click);
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Image = global::HMS.Properties.Resources.User_32__2;
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(327, 30);
            this.currentUserInfoToolStripMenuItem.Text = "Current User Info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::HMS.Properties.Resources.Password_32;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(327, 30);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendImailToolStripMenuItem,
            this.changeWallpaperToolStripMenuItem,
            this.removeHomeWallpaperToolStripMenuItem});
            this.sendEmailToolStripMenuItem.Image = global::HMS.Properties.Resources.gear;
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(327, 30);
            this.sendEmailToolStripMenuItem.Text = "More Option";
            this.sendEmailToolStripMenuItem.Click += new System.EventHandler(this.sendEmailToolStripMenuItem_Click);
            // 
            // sendImailToolStripMenuItem
            // 
            this.sendImailToolStripMenuItem.Image = global::HMS.Properties.Resources.send_email_32;
            this.sendImailToolStripMenuItem.Name = "sendImailToolStripMenuItem";
            this.sendImailToolStripMenuItem.Size = new System.Drawing.Size(333, 30);
            this.sendImailToolStripMenuItem.Text = "Send Email";
            this.sendImailToolStripMenuItem.Click += new System.EventHandler(this.sendImailToolStripMenuItem_Click);
            // 
            // changeWallpaperToolStripMenuItem
            // 
            this.changeWallpaperToolStripMenuItem.Image = global::HMS.Properties.Resources.Local_32;
            this.changeWallpaperToolStripMenuItem.Name = "changeWallpaperToolStripMenuItem";
            this.changeWallpaperToolStripMenuItem.Size = new System.Drawing.Size(333, 30);
            this.changeWallpaperToolStripMenuItem.Text = "Change home wallpaper";
            this.changeWallpaperToolStripMenuItem.Click += new System.EventHandler(this.changeWallpaperToolStripMenuItem_Click);
            // 
            // removeHomeWallpaperToolStripMenuItem
            // 
            this.removeHomeWallpaperToolStripMenuItem.Image = global::HMS.Properties.Resources.closeBlack32;
            this.removeHomeWallpaperToolStripMenuItem.Name = "removeHomeWallpaperToolStripMenuItem";
            this.removeHomeWallpaperToolStripMenuItem.Size = new System.Drawing.Size(333, 30);
            this.removeHomeWallpaperToolStripMenuItem.Text = "Remove home wallpaper";
            this.removeHomeWallpaperToolStripMenuItem.Click += new System.EventHandler(this.removeHomeWallpaperToolStripMenuItem_Click);
            // 
            // applicationArchitectureToolStripMenuItem
            // 
            this.applicationArchitectureToolStripMenuItem.Image = global::HMS.Properties.Resources.pencil__1_;
            this.applicationArchitectureToolStripMenuItem.Name = "applicationArchitectureToolStripMenuItem";
            this.applicationArchitectureToolStripMenuItem.Size = new System.Drawing.Size(327, 30);
            this.applicationArchitectureToolStripMenuItem.Text = "Application Architecture";
            this.applicationArchitectureToolStripMenuItem.Click += new System.EventHandler(this.applicationArchitectureToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Image = global::HMS.Properties.Resources.sign_out_32__2;
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(327, 30);
            this.signOutToolStripMenuItem.Text = "Sign out ";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem1
            // 
            this.signOutToolStripMenuItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.signOutToolStripMenuItem1.Image = global::HMS.Properties.Resources.sign_out_32__2;
            this.signOutToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.signOutToolStripMenuItem1.Name = "signOutToolStripMenuItem1";
            this.signOutToolStripMenuItem1.Size = new System.Drawing.Size(138, 76);
            this.signOutToolStripMenuItem1.Text = "Sign out";
            this.signOutToolStripMenuItem1.Click += new System.EventHandler(this.signOutToolStripMenuItem1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pcWallpaper
            // 
            this.pcWallpaper.Image = global::HMS.Properties.Resources.NewPic;
            this.pcWallpaper.Location = new System.Drawing.Point(0, 115);
            this.pcWallpaper.Name = "pcWallpaper";
            this.pcWallpaper.Size = new System.Drawing.Size(1920, 1080);
            this.pcWallpaper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pcWallpaper.TabIndex = 5;
            this.pcWallpaper.TabStop = false;
            // 
            // ctrlCurrencyEchange1
            // 
            this.ctrlCurrencyEchange1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrlCurrencyEchange1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ctrlCurrencyEchange1.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctrlCurrencyEchange1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlCurrencyEchange1.Location = new System.Drawing.Point(964, 115);
            this.ctrlCurrencyEchange1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrlCurrencyEchange1.Name = "ctrlCurrencyEchange1";
            this.ctrlCurrencyEchange1.Size = new System.Drawing.Size(310, 614);
            this.ctrlCurrencyEchange1.TabIndex = 4;
            // 
            // ctrlMainInfo1
            // 
            this.ctrlMainInfo1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ctrlMainInfo1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlMainInfo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlMainInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlMainInfo1.Location = new System.Drawing.Point(0, 80);
            this.ctrlMainInfo1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrlMainInfo1.Name = "ctrlMainInfo1";
            this.ctrlMainInfo1.Size = new System.Drawing.Size(1274, 35);
            this.ctrlMainInfo1.TabIndex = 3;
            // 
            // ctrlInfo3
            // 
            this.ctrlInfo3.BackColor = System.Drawing.Color.Red;
            this.ctrlInfo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlInfo3.InfoType = HMS.Main.ctrlInfo.enInfoType.RoomsInfoByPercentage;
            this.ctrlInfo3.Location = new System.Drawing.Point(541, 125);
            this.ctrlInfo3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrlInfo3.Name = "ctrlInfo3";
            this.ctrlInfo3.Size = new System.Drawing.Size(271, 170);
            this.ctrlInfo3.TabIndex = 0;
            // 
            // ctrlInfo2
            // 
            this.ctrlInfo2.BackColor = System.Drawing.Color.CadetBlue;
            this.ctrlInfo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlInfo2.InfoType = HMS.Main.ctrlInfo.enInfoType.AvailableRooms;
            this.ctrlInfo2.Location = new System.Drawing.Point(275, 125);
            this.ctrlInfo2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrlInfo2.Name = "ctrlInfo2";
            this.ctrlInfo2.Size = new System.Drawing.Size(254, 170);
            this.ctrlInfo2.TabIndex = 2;
            // 
            // ctrlInfo1
            // 
            this.ctrlInfo1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.ctrlInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlInfo1.InfoType = HMS.Main.ctrlInfo.enInfoType.RoomsInfo;
            this.ctrlInfo1.Location = new System.Drawing.Point(2, 125);
            this.ctrlInfo1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrlInfo1.Name = "ctrlInfo1";
            this.ctrlInfo1.Size = new System.Drawing.Size(261, 170);
            this.ctrlInfo1.TabIndex = 1;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1274, 729);
            this.Controls.Add(this.ctrlCurrencyEchange1);
            this.Controls.Add(this.ctrlMainInfo1);
            this.Controls.Add(this.ctrlInfo3);
            this.Controls.Add(this.ctrlInfo2);
            this.Controls.Add(this.ctrlInfo1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pcWallpaper);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPage";
            this.Text = "Hotels Managements System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcWallpaper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private Main.ctrlInfo ctrlInfo1;
        private Main.ctrlInfo ctrlInfo2;
        private Main.ctrlInfo ctrlInfo3;
        private System.Windows.Forms.ToolStripMenuItem bookRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private main.Controls.ctrlMainInfo ctrlMainInfo1;
        private main.ctrlCurrencyEchange ctrlCurrencyEchange1;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staticesToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem applicationArchitectureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendImailToolStripMenuItem;
        private System.Windows.Forms.PictureBox pcWallpaper;
        private System.Windows.Forms.ToolStripMenuItem changeWallpaperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeHomeWallpaperToolStripMenuItem;
    }
}

