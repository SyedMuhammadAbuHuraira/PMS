using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using PharmacyManagementSystem.DL;
using PharmacyManagementSystem.BL;
using PharmacyManagementSystem.Forms;
using Color = System.Drawing.Color;

namespace PharmacyManagementSystem
{
    public partial class Form1 : Form
    {
        private IconButton currentBtn;
        private Panel LeftBorderBtn;
        private Form currentChildForm;
        bool containerCollapsed;
        private String Role = "";
        public Form1()
        {
            InitializeComponent();
            CustomizeDesign();
            LeftBorderBtn = new Panel();
            LeftBorderBtn.Size = new Size(7, 60);
            PanelMenu.Controls.Add(LeftBorderBtn);
            this.Text = String.Empty;
            // remove the buffer
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            int id = UsersDL.GetLoggedId();
            foreach(Users o in UsersDL.GetUsersList() )
            {
                if(o.GetID()==id)
                {
                    Role = o.GetRole();    
                }
            }

        }
        public void CustomizeDesign()
        {
            panelPharmacySubMenu.Visible = false;
        }
        public void hideSubMenue()
        {
            if(panelPharmacySubMenu.Visible == true)
            {
                panelPharmacySubMenu.Visible = false;
            }
        }
        public void ShowSubMenu(Panel SubMenu)
        {
            if (panelPharmacySubMenu.Visible == false)
            {
                hideSubMenue();
                SubMenu.Visible = true;
            }
            else
            {
                SubMenu.Visible = false;
            }
        }
        private struct RGBColors
        {
          public static Color color1 = Color.FromArgb  (172,126,241);
          public static Color color2 = Color.FromArgb      (249,118,176);
          public static Color color3 = Color.FromArgb      (253,138,114);
          public static Color color4 = Color.FromArgb      (95,77,221);
          public static Color color5 = Color.FromArgb(24, 161, 251);
        }
        private void OpenChildForm(Form chileForm)
        {
            if(currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }

            currentChildForm = chileForm;
            chileForm.TopLevel = false;
            chileForm.FormBorderStyle = FormBorderStyle.None;
            chileForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(chileForm);
            panelDesktop.Tag = chileForm;
            chileForm.BringToFront();
            chileForm.Show();
            lblTitleChildForm.Text = chileForm.Text;
            
        }
        private void ActiveButton(object senderBtn , Color color)
        {
            if(senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);

                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                // left border button
                LeftBorderBtn.BackColor = color;
                LeftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                LeftBorderBtn.Visible = true;
                LeftBorderBtn.BringToFront();


                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if(currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31,30,68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
            OpenChildForm(new DashBoard());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Products_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            OpenChildForm(new Add_Patient());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color2);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3);
            ShowSubMenu(panelPharmacySubMenu);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
           // ActiveButton(sender, RGBColors.color4);
            //OpenChildForm(new RegisterUser());
            if (Role == "Manager" )
            {
                ActiveButton(sender, RGBColors.color4);
                OpenChildForm(new RegisterUser());
            }
            
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color5);
            this.Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Rest();
        }
        private void Rest()
        {
            DisableButton();
            LeftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void PanelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitleChildForm_Click(object sender, EventArgs e)
        {

        }

        private void iconCurrentChildForm_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

       

        private void iconButton8_Click(object sender, EventArgs e)
        {

        }

        private void iconButton15_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color2);
            OpenChildForm(new GenerateReports());
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {

            ActiveButton(sender, RGBColors.color3);
            OpenChildForm(new AddItem());
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color5);
            OpenChildForm(new Stock_Return());
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
            OpenChildForm(new SaleReturn());
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);

            OpenChildForm(new CreateInvoice());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton8_Click_1(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);

            OpenChildForm(new AddStock());
        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
            OpenChildForm(new AddManufacturer());
        }

        private void iconButton13_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
            OpenChildForm(new AddSupplier());

        }

        private void panelPharmacySubMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                // Maximize the form to the full screen
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                // Restore the form to the specified size
                this.WindowState = FormWindowState.Maximized;
               // this.WindowState = FormWindowState.Normal;
                //this.Width = 1304;
                //this.Height = 841;
            }
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        private void Manager_Click(object sender, EventArgs e)
        {
           // ActiveButton(sender, RGBColors.color4);
            //OpenChildForm(new AuditTables());
            if (Role == "Manager")
            {
                ActiveButton(sender, RGBColors.color4);
                OpenChildForm(new RegisterUser());
            }
        }

    }
}
