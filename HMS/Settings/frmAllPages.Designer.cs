namespace HMS
{
    partial class frmAllPages
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Users List");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Add New User");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Users", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Room List");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Add New Room");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Rooms", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Bookings List");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Bookings", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.treeView1.Location = new System.Drawing.Point(12, 87);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Users List";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "Node0";
            treeNode2.Text = "Add New User";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Users";
            treeNode4.Name = "Node5";
            treeNode4.Text = "Room List";
            treeNode5.Name = "Node6";
            treeNode5.Text = "Add New Room";
            treeNode6.Name = "Node4";
            treeNode6.Text = "Rooms";
            treeNode7.Name = "Node10";
            treeNode7.Text = "Bookings List";
            treeNode8.Name = "Node9";
            treeNode8.Text = "Bookings";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(508, 343);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(-204, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(928, 44);
            this.lblTitle.TabIndex = 113;
            this.lblTitle.Text = "Application Architecture";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAllPages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 442);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.treeView1);
            this.Name = "frmAllPages";
            this.Text = "Application Architecture";
            this.Load += new System.EventHandler(this.frmAllPages_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label lblTitle;
    }
}