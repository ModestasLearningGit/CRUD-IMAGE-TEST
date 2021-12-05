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
    public partial class frmUPDATE : Form
    {
        MemberBLL bll = new MemberBLL();
        MemberDAL dal = new MemberDAL();

        string imageName = "no-image.jpg";
        bool newImage = false;
        string rowHeaderImage;
        string sourcePath = "";
        string destinationPath = "";

        public frmUPDATE()
        {
            InitializeComponent();
        }

        private void frmUPDATE_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvTable.DataSource = dt;
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 23);
            destinationPath = path + "Image\\" + imageName;
            pictureBoxProfilePicture.Image = new Bitmap(destinationPath);
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files Only(*.jpg; *.jpeg; *.png; *.gif | *.jpg; *.jpeg; *.png; *.gif)";

            if (open.ShowDialog() == DialogResult.OK)
            {
                if (open.CheckFileExists)
                {
                    pictureBoxProfilePicture.Image = new Bitmap(open.FileName);

                    string ext = Path.GetExtension(open.FileName);
                    string name = Path.GetFileNameWithoutExtension(open.FileName);

                    Guid g = new Guid();
                    g = Guid.NewGuid();

                    imageName = "Strong_Gym_" + name + g + ext;
                    rowHeaderImage = imageName;

                    sourcePath = open.FileName;

                    string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 23);
                    destinationPath = path + "Image\\" + imageName;

                    newImage = true;
                    
                }
            }
        }

        private void dgvTable_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtMID.Text = dgvTable.Rows[rowIndex].Cells[0].Value.ToString();
            imageName = dgvTable.Rows[rowIndex].Cells[1].Value.ToString();
            txtFName.Text = dgvTable.Rows[rowIndex].Cells[2].Value.ToString();
            txtLName.Text = dgvTable.Rows[rowIndex].Cells[3].Value.ToString();
            txtEmail.Text = dgvTable.Rows[rowIndex].Cells[4].Value.ToString();

            newImage = false;

            try
            {
                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 23);
                destinationPath = path + "Image\\" + imageName;

                pictureBoxProfilePicture.Image = new Bitmap(destinationPath);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bll.memberId = int.Parse(txtMID.Text);
            bll.imageName = imageName;
            bll.fName = txtFName.Text;
            bll.lName = txtLName.Text;
            bll.Email = txtEmail.Text;

            bool isSuccess = dal.Update(bll);
            if(isSuccess == true)
            {
                MessageBox.Show("DATA UPDATED");
                if(newImage == true)
                {
                    string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 23);
                    string destinationPath = path + "Image//" + rowHeaderImage;

                    File.Copy(sourcePath, destinationPath);
                }

            }
            else
            {
                MessageBox.Show("DATA UPDATE FAILED");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            DataTable dt = new DataTable();
            if(keyword != null)
            {
                dt = dal.Search(keyword);
                dgvTable.DataSource = dt;
            }
            else
            {
                dt = dal.Select();
                dgvTable.DataSource = dt;
            }
        }
    }
}
