namespace PharmacyManagementSystem.Forms
{
    partial class AddSupplier
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.Pharmacy = new FontAwesome.Sharp.IconButton();
            this.EDIT = new System.Windows.Forms.DataGridViewButtonColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(132, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier Name";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(132, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Supplier Email";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(374, 81);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 30);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(374, 130);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(212, 30);
            this.textBox2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(132, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Supplier Phone No";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EDIT,
            this.STATUS});
            this.dataGridView1.Location = new System.Drawing.Point(22, 318);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(637, 163);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(288, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "Add Supplier";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(374, 192);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(212, 30);
            this.textBox3.TabIndex = 13;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(374, 248);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(212, 30);
            this.textBox4.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.Location = new System.Drawing.Point(132, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 29);
            this.label7.TabIndex = 32;
            this.label7.Text = "Supplier Address";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.iconButton2);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.iconButton3);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.Pharmacy);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 512);
            this.panel1.TabIndex = 4;
            // 
            // iconButton2
            // 
            this.iconButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButton2.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Add;
            this.iconButton2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 32;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(702, 332);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton2.Size = new System.Drawing.Size(117, 36);
            this.iconButton2.TabIndex = 42;
            this.iconButton2.Text = "Update";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButton1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Add;
            this.iconButton1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 32;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(699, 390);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton1.Size = new System.Drawing.Size(120, 36);
            this.iconButton1.TabIndex = 41;
            this.iconButton1.Text = "Show ";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButton3.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton3.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.iconButton3.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 32;
            this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.Location = new System.Drawing.Point(699, 450);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton3.Size = new System.Drawing.Size(117, 31);
            this.iconButton3.TabIndex = 26;
            this.iconButton3.Text = "Clear";
            this.iconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton3.UseVisualStyleBackColor = false;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // Pharmacy
            // 
            this.Pharmacy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Pharmacy.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Pharmacy.FlatAppearance.BorderSize = 0;
            this.Pharmacy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pharmacy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pharmacy.ForeColor = System.Drawing.Color.Gainsboro;
            this.Pharmacy.IconChar = FontAwesome.Sharp.IconChar.Add;
            this.Pharmacy.IconColor = System.Drawing.Color.Gainsboro;
            this.Pharmacy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Pharmacy.IconSize = 32;
            this.Pharmacy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Pharmacy.Location = new System.Drawing.Point(702, 281);
            this.Pharmacy.Name = "Pharmacy";
            this.Pharmacy.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.Pharmacy.Size = new System.Drawing.Size(117, 36);
            this.Pharmacy.TabIndex = 6;
            this.Pharmacy.Text = "Add";
            this.Pharmacy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Pharmacy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Pharmacy.UseVisualStyleBackColor = false;
            this.Pharmacy.Click += new System.EventHandler(this.Pharmacy_Click);
            // 
            // EDIT
            // 
            this.EDIT.HeaderText = "EDIT";
            this.EDIT.MinimumWidth = 8;
            this.EDIT.Name = "EDIT";
            this.EDIT.ReadOnly = true;
            this.EDIT.Text = "Edit";
            this.EDIT.UseColumnTextForButtonValue = true;
            this.EDIT.Width = 150;
            // 
            // STATUS
            // 
            this.STATUS.HeaderText = "STATUS";
            this.STATUS.MinimumWidth = 8;
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            this.STATUS.Text = "Status";
            this.STATUS.UseColumnTextForButtonValue = true;
            this.STATUS.Width = 150;
            // 
            // AddSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(943, 511);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddSupplier";
            this.Text = "AddSupplier";
            this.Load += new System.EventHandler(this.AddSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton Pharmacy;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private FontAwesome.Sharp.IconButton iconButton3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.DataGridViewButtonColumn EDIT;
        private System.Windows.Forms.DataGridViewButtonColumn STATUS;
    }
}