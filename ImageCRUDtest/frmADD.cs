using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCRUDtest
{
    public partial class frmADD : Form
    {
        MemberBLL bll = new MemberBLL();
        MemberDAL dal = new MemberDAL();

        string imageName = "no-image.jpg";
        string rowHeaderImage;
        string sourcePath = "";
        string destinationPath = "";
        public frmADD()
        {
            InitializeComponent();
        }

        private void frmADD_Load(object sender, EventArgs e)
        {
            Clear();
        }
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open  = new OpenFileDialog();
            open.Filter = "Image Files Only(*.jpg; *.jpeg; *.png; *.gif | *.jpg; *.jpeg; *.png; *.gif)";

            if(open.ShowDialog() == DialogResult.OK)
            {
                if(open.CheckFileExists)
                {
                    pictureBoxProfilePicture.Image = new Bitmap(open.FileName);

                    string ext = Path.GetExtension(open.FileName);
                    string name = Path.GetFileNameWithoutExtension(open.FileName);

                    Guid g = new Guid();
                    g = Guid.NewGuid();

                    imageName = "Strong_Gym_" + name + g + ext;

                    sourcePath = open.FileName;

                    string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length)-23);
                    destinationPath = path + "Image\\" + imageName;
                    
                }
            }
            
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            if (txtFName.Text == "" || txtLName.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("PLEASE FILL ALL FIELDS");
            }
            else
            {
                bll.imageName = imageName;
                bll.fName = txtFName.Text;
                bll.lName = txtLName.Text;
                bll.Email = txtEmail.Text;

              
                isSuccess = dal.Insert(bll);

                if(isSuccess == true)
                {
                    if (imageName != "no-image.jpg")
                    {
                        File.Copy(sourcePath, destinationPath);
                    }
                    MessageBox.Show("RECORD INSERTED SUCCESFULLY");
                    Clear();
                }
                else
                {
                    MessageBox.Show("RECORD FAILED TO INSERT");
                }
            }
            

        }
        public void Clear()
        {
            
            txtFName.Clear();
            txtLName.Clear();
            txtEmail.Clear();
            imageName = "no-image.jpg";
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 23);
            destinationPath = path + "Image\\" + imageName;
            pictureBoxProfilePicture.Image = new Bitmap(destinationPath);
        }

    }
}
