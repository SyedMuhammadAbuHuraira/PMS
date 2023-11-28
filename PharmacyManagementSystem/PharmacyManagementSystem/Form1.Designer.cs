namespace PharmacyManagementSystem
{
    partial class Form1
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
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelPharmacySubMenu = new System.Windows.Forms.Panel();
            this.iconButton13 = new FontAwesome.Sharp.IconButton();
            this.iconButton12 = new FontAwesome.Sharp.IconButton();
            this.iconButton11 = new FontAwesome.Sharp.IconButton();
            this.iconButton10 = new FontAwesome.Sharp.IconButton();
            this.iconButton9 = new FontAwesome.Sharp.IconButton();
            this.iconButton8 = new FontAwesome.Sharp.IconButton();
            this.iconButton7 = new FontAwesome.Sharp.IconButton();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.Manager = new FontAwesome.Sharp.IconButton();
            this.iconButton15 = new FontAwesome.Sharp.IconButton();
            this.iconButton6 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.Pharmacy = new FontAwesome.Sharp.IconButton();
            this.Patient = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.PanelLogo = new System.Windows.Forms.Panel();
            this.btn = new System.Windows.Forms.PictureBox();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.panelPharmacySubMenu.SuspendLayout();
            this.PanelMenu.SuspendLayout();
            this.PanelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.White;
            this.panelTitleBar.Controls.Add(this.iconPictureBox2);
            this.panelTitleBar.Controls.Add(this.iconPictureBox1);
            this.panelTitleBar.Controls.Add(this.lblTitleChildForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(241, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(668, 55);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitleBar_Paint);
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.White;
            this.iconPictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.iconPictureBox2.IconColor = System.Drawing.Color.RoyalBlue;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 31;
            this.iconPictureBox2.Location = new System.Drawing.Point(606, 0);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(31, 55);
            this.iconPictureBox2.TabIndex = 3;
            this.iconPictureBox2.TabStop = false;
            this.iconPictureBox2.Click += new System.EventHandler(this.iconPictureBox2_Click);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Maximize;
            this.iconPictureBox1.IconColor = System.Drawing.Color.RoyalBlue;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 31;
            this.iconPictureBox1.Location = new System.Drawing.Point(637, 0);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(31, 55);
            this.iconPictureBox1.TabIndex = 2;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.Click += new System.EventHandler(this.iconPictureBox1_Click);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.Black;
            this.lblTitleChildForm.Location = new System.Drawing.Point(62, 26);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(45, 15);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = "Home";
            this.lblTitleChildForm.Click += new System.EventHandler(this.lblTitleChildForm_Click);
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.White;
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(24, 12);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(32, 32);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            this.iconCurrentChildForm.Click += new System.EventHandler(this.iconCurrentChildForm_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(241, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 9);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panelPharmacySubMenu
            // 
            this.panelPharmacySubMenu.Controls.Add(this.iconButton13);
            this.panelPharmacySubMenu.Controls.Add(this.iconButton12);
            this.panelPharmacySubMenu.Controls.Add(this.iconButton11);
            this.panelPharmacySubMenu.Controls.Add(this.iconButton10);
            this.panelPharmacySubMenu.Controls.Add(this.iconButton9);
            this.panelPharmacySubMenu.Controls.Add(this.iconButton8);
            this.panelPharmacySubMenu.Controls.Add(this.iconButton7);
            this.panelPharmacySubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPharmacySubMenu.Location = new System.Drawing.Point(0, 290);
            this.panelPharmacySubMenu.Name = "panelPharmacySubMenu";
            this.panelPharmacySubMenu.Size = new System.Drawing.Size(224, 355);
            this.panelPharmacySubMenu.TabIndex = 7;
            this.panelPharmacySubMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPharmacySubMenu_Paint);
            // 
            // iconButton13
            // 
            this.iconButton13.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton13.FlatAppearance.BorderSize = 0;
            this.iconButton13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.iconButton13.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton13.IconChar = FontAwesome.Sharp.IconChar.Info;
            this.iconButton13.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton13.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton13.IconSize = 32;
            this.iconButton13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton13.Location = new System.Drawing.Point(0, 300);
            this.iconButton13.Name = "iconButton13";
            this.iconButton13.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton13.Size = new System.Drawing.Size(224, 43);
            this.iconButton13.TabIndex = 11;
            this.iconButton13.Text = "Supplier";
            this.iconButton13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton13.UseVisualStyleBackColor = true;
            this.iconButton13.Click += new System.EventHandler(this.iconButton13_Click);
            // 
            // iconButton12
            // 
            this.iconButton12.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton12.FlatAppearance.BorderSize = 0;
            this.iconButton12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.iconButton12.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton12.IconChar = FontAwesome.Sharp.IconChar.HouseMedical;
            this.iconButton12.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton12.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton12.IconSize = 32;
            this.iconButton12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton12.Location = new System.Drawing.Point(0, 250);
            this.iconButton12.Name = "iconButton12";
            this.iconButton12.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton12.Size = new System.Drawing.Size(224, 50);
            this.iconButton12.TabIndex = 10;
            this.iconButton12.Text = "Manufacture";
            this.iconButton12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton12.UseVisualStyleBackColor = true;
            this.iconButton12.Click += new System.EventHandler(this.iconButton12_Click);
            // 
            // iconButton11
            // 
            this.iconButton11.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton11.FlatAppearance.BorderSize = 0;
            this.iconButton11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.iconButton11.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton11.IconChar = FontAwesome.Sharp.IconChar.Add;
            this.iconButton11.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton11.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton11.IconSize = 32;
            this.iconButton11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton11.Location = new System.Drawing.Point(0, 200);
            this.iconButton11.Name = "iconButton11";
            this.iconButton11.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton11.Size = new System.Drawing.Size(224, 50);
            this.iconButton11.TabIndex = 9;
            this.iconButton11.Text = "Add Items";
            this.iconButton11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton11.UseVisualStyleBackColor = true;
            this.iconButton11.Click += new System.EventHandler(this.iconButton11_Click);
            // 
            // iconButton10
            // 
            this.iconButton10.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton10.FlatAppearance.BorderSize = 0;
            this.iconButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.iconButton10.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton10.IconChar = FontAwesome.Sharp.IconChar.Salesforce;
            this.iconButton10.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton10.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton10.IconSize = 32;
            this.iconButton10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton10.Location = new System.Drawing.Point(0, 150);
            this.iconButton10.Name = "iconButton10";
            this.iconButton10.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton10.Size = new System.Drawing.Size(224, 50);
            this.iconButton10.TabIndex = 8;
            this.iconButton10.Text = "Sales Return";
            this.iconButton10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton10.UseVisualStyleBackColor = true;
            this.iconButton10.Click += new System.EventHandler(this.iconButton10_Click);
            // 
            // iconButton9
            // 
            this.iconButton9.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton9.FlatAppearance.BorderSize = 0;
            this.iconButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.iconButton9.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton9.IconChar = FontAwesome.Sharp.IconChar.Recycle;
            this.iconButton9.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton9.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton9.IconSize = 32;
            this.iconButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton9.Location = new System.Drawing.Point(0, 100);
            this.iconButton9.Name = "iconButton9";
            this.iconButton9.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton9.Size = new System.Drawing.Size(224, 50);
            this.iconButton9.TabIndex = 7;
            this.iconButton9.Text = "Stock Return";
            this.iconButton9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton9.UseVisualStyleBackColor = true;
            this.iconButton9.Click += new System.EventHandler(this.iconButton9_Click);
            // 
            // iconButton8
            // 
            this.iconButton8.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton8.FlatAppearance.BorderSize = 0;
            this.iconButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.iconButton8.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton8.IconChar = FontAwesome.Sharp.IconChar.Store;
            this.iconButton8.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton8.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton8.IconSize = 32;
            this.iconButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton8.Location = new System.Drawing.Point(0, 50);
            this.iconButton8.Name = "iconButton8";
            this.iconButton8.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton8.Size = new System.Drawing.Size(224, 50);
            this.iconButton8.TabIndex = 6;
            this.iconButton8.Text = "Manage Stocks";
            this.iconButton8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton8.UseVisualStyleBackColor = true;
            this.iconButton8.Click += new System.EventHandler(this.iconButton8_Click_1);
            // 
            // iconButton7
            // 
            this.iconButton7.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton7.FlatAppearance.BorderSize = 0;
            this.iconButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton7.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton7.IconChar = FontAwesome.Sharp.IconChar.ThinkPeaks;
            this.iconButton7.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton7.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton7.IconSize = 32;
            this.iconButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton7.Location = new System.Drawing.Point(0, 0);
            this.iconButton7.Name = "iconButton7";
            this.iconButton7.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton7.Size = new System.Drawing.Size(224, 50);
            this.iconButton7.TabIndex = 5;
            this.iconButton7.Text = "Invoice";
            this.iconButton7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton7.UseVisualStyleBackColor = true;
            this.iconButton7.Click += new System.EventHandler(this.iconButton7_Click);
            // 
            // PanelMenu
            // 
            this.PanelMenu.AutoScroll = true;
            this.PanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.PanelMenu.Controls.Add(this.Manager);
            this.PanelMenu.Controls.Add(this.panelPharmacySubMenu);
            this.PanelMenu.Controls.Add(this.iconButton15);
            this.PanelMenu.Controls.Add(this.iconButton6);
            this.PanelMenu.Controls.Add(this.iconButton2);
            this.PanelMenu.Controls.Add(this.iconButton5);
            this.PanelMenu.Controls.Add(this.Pharmacy);
            this.PanelMenu.Controls.Add(this.Patient);
            this.PanelMenu.Controls.Add(this.iconButton1);
            this.PanelMenu.Controls.Add(this.PanelLogo);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(241, 487);
            this.PanelMenu.TabIndex = 0;
            this.PanelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelMenu_Paint);
            // 
            // Manager
            // 
            this.Manager.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Manager.FlatAppearance.BorderSize = 0;
            this.Manager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Manager.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Manager.ForeColor = System.Drawing.Color.Gainsboro;
            this.Manager.IconChar = FontAwesome.Sharp.IconChar.Expeditedssl;
            this.Manager.IconColor = System.Drawing.Color.WhiteSmoke;
            this.Manager.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Manager.IconSize = 32;
            this.Manager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Manager.Location = new System.Drawing.Point(0, 645);
            this.Manager.Name = "Manager";
            this.Manager.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.Manager.Size = new System.Drawing.Size(224, 50);
            this.Manager.TabIndex = 13;
            this.Manager.Text = "AuditTables";
            this.Manager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Manager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Manager.UseVisualStyleBackColor = true;
            this.Manager.Click += new System.EventHandler(this.Manager_Click);
            // 
            // iconButton15
            // 
            this.iconButton15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.iconButton15.FlatAppearance.BorderSize = 0;
            this.iconButton15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.iconButton15.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton15.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.iconButton15.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton15.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton15.IconSize = 32;
            this.iconButton15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton15.Location = new System.Drawing.Point(0, 695);
            this.iconButton15.Name = "iconButton15";
            this.iconButton15.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton15.Size = new System.Drawing.Size(224, 50);
            this.iconButton15.TabIndex = 12;
            this.iconButton15.Text = "Reports";
            this.iconButton15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton15.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton15.UseVisualStyleBackColor = true;
            this.iconButton15.Click += new System.EventHandler(this.iconButton15_Click);
            // 
            // iconButton6
            // 
            this.iconButton6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.iconButton6.FlatAppearance.BorderSize = 0;
            this.iconButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.iconButton6.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton6.IconChar = FontAwesome.Sharp.IconChar.ArrowRightFromBracket;
            this.iconButton6.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton6.IconSize = 32;
            this.iconButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton6.Location = new System.Drawing.Point(0, 745);
            this.iconButton6.Name = "iconButton6";
            this.iconButton6.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton6.Size = new System.Drawing.Size(224, 49);
            this.iconButton6.TabIndex = 5;
            this.iconButton6.Text = "Logout";
            this.iconButton6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton6.UseVisualStyleBackColor = true;
            this.iconButton6.Click += new System.EventHandler(this.iconButton6_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.iconButton2.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.iconButton2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 32;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(0, 794);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton2.Size = new System.Drawing.Size(224, 50);
            this.iconButton2.TabIndex = 6;
            this.iconButton2.Text = "Contact Us";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconButton5
            // 
            this.iconButton5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.iconButton5.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.User;
            this.iconButton5.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton5.IconSize = 32;
            this.iconButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton5.Location = new System.Drawing.Point(0, 844);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton5.Size = new System.Drawing.Size(224, 50);
            this.iconButton5.TabIndex = 4;
            this.iconButton5.Text = "Users";
            this.iconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton5.UseVisualStyleBackColor = true;
            this.iconButton5.Click += new System.EventHandler(this.iconButton5_Click);
            // 
            // Pharmacy
            // 
            this.Pharmacy.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pharmacy.FlatAppearance.BorderSize = 0;
            this.Pharmacy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pharmacy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Pharmacy.ForeColor = System.Drawing.Color.Gainsboro;
            this.Pharmacy.IconChar = FontAwesome.Sharp.IconChar.Sleigh;
            this.Pharmacy.IconColor = System.Drawing.Color.Gainsboro;
            this.Pharmacy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Pharmacy.IconSize = 32;
            this.Pharmacy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Pharmacy.Location = new System.Drawing.Point(0, 240);
            this.Pharmacy.Name = "Pharmacy";
            this.Pharmacy.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.Pharmacy.Size = new System.Drawing.Size(224, 50);
            this.Pharmacy.TabIndex = 3;
            this.Pharmacy.Text = "Pharmacy";
            this.Pharmacy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Pharmacy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Pharmacy.UseVisualStyleBackColor = true;
            this.Pharmacy.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // Patient
            // 
            this.Patient.Dock = System.Windows.Forms.DockStyle.Top;
            this.Patient.FlatAppearance.BorderSize = 0;
            this.Patient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Patient.ForeColor = System.Drawing.Color.Gainsboro;
            this.Patient.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.Patient.IconColor = System.Drawing.Color.Gainsboro;
            this.Patient.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Patient.IconSize = 32;
            this.Patient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Patient.Location = new System.Drawing.Point(0, 190);
            this.Patient.Name = "Patient";
            this.Patient.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.Patient.Size = new System.Drawing.Size(224, 50);
            this.Patient.TabIndex = 1;
            this.Patient.Text = "Patient";
            this.Patient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Patient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Patient.UseVisualStyleBackColor = true;
            this.Patient.Click += new System.EventHandler(this.Products_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.AllowDrop = true;
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            this.iconButton1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 32;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(0, 140);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton1.Size = new System.Drawing.Size(224, 50);
            this.iconButton1.TabIndex = 0;
            this.iconButton1.Text = "Dashboard";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // PanelLogo
            // 
            this.PanelLogo.Controls.Add(this.btn);
            this.PanelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLogo.Location = new System.Drawing.Point(0, 0);
            this.PanelLogo.Name = "PanelLogo";
            this.PanelLogo.Size = new System.Drawing.Size(224, 140);
            this.PanelLogo.TabIndex = 0;
            this.PanelLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelLogo_Paint);
            // 
            // btn
            // 
            this.btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn.Image = global::PharmacyManagementSystem.Properties.Resources.pharmacy;
            this.btn.Location = new System.Drawing.Point(27, 26);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(148, 90);
            this.btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn.TabIndex = 0;
            this.btn.TabStop = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.White;
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(241, 64);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(668, 423);
            this.panelDesktop.TabIndex = 3;
            this.panelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktop_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 487);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.PanelMenu);
            this.MinimumSize = new System.Drawing.Size(911, 480);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.panelPharmacySubMenu.ResumeLayout(false);
            this.PanelMenu.ResumeLayout(false);
            this.PanelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitleChildForm;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelPharmacySubMenu;
        private FontAwesome.Sharp.IconButton iconButton13;
        private FontAwesome.Sharp.IconButton iconButton12;
        private FontAwesome.Sharp.IconButton iconButton11;
        private FontAwesome.Sharp.IconButton iconButton10;
        private FontAwesome.Sharp.IconButton iconButton9;
        private FontAwesome.Sharp.IconButton iconButton8;
        private FontAwesome.Sharp.IconButton iconButton7;
        private System.Windows.Forms.Panel PanelMenu;
        private FontAwesome.Sharp.IconButton iconButton15;
        private FontAwesome.Sharp.IconButton iconButton6;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton Pharmacy;
        private FontAwesome.Sharp.IconButton Patient;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Panel PanelLogo;
        private System.Windows.Forms.PictureBox btn;
        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconButton Manager;
    }
}

