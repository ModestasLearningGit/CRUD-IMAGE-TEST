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
    public partial class frmDELETE : Form
    {
        MemberBLL bll = new MemberBLL();
        MemberDAL dal = new MemberDAL();

        string imageName = "no-image.jpg";
        string rowHeaderImage;
        string sourcePath = "";
        string destinationPath = "";
        public frmDELETE()
        {
            InitializeComponent();
        }

        private void frmDELETE_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvTable.DataSource = dt;

            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 23);
            destinationPath = path + "Image\\" + imageName;
            pictureBox1.Image = new Bitmap(destinationPath);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            DataTable dt = new DataTable();
            if (keyword != null)
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

        private void dgvTable_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtMID.Text = dgvTable.Rows[rowIndex].Cells[0].Value.ToString();
            imageName = dgvTable.Rows[rowIndex].Cells[1].Value.ToString();
            txtFName.Text = dgvTable.Rows[rowIndex].Cells[2].Value.ToString();
            txtLName.Text = dgvTable.Rows[rowIndex].Cells[3].Value.ToString();
            txtEmail.Text = dgvTable.Rows[rowIndex].Cells[4].Value.ToString();

            rowHeaderImage = imageName;

            try
            {
                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 23);
                destinationPath = path + "Image\\" + imageName;

                pictureBox1.Image = new Bitmap(destinationPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            bll.memberId = int.Parse(txtMID.Text);

            bool isSuccess = dal.Delete(bll);

            if(isSuccess == true)
            {
                if(rowHeaderImage != "no-image.jpg")
                {
                    string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 23);
                    destinationPath = path + "Image\\" + rowHeaderImage;
                    string noImageDestinationPath = path + "Image\\" + "no-image.jpg";
                    pictureBox1.Image = new Bitmap(noImageDestinationPath);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    if(File.Exists(destinationPath))
                    {
                       
                        File.Delete(destinationPath);
                    }

                   
                }
                MessageBox.Show("DONOR DELETED SUCCESSFULLY");
                Clear();
                DataTable dt = dal.Select();
                dgvTable.DataSource = dt;
            }
            else
            {
                MessageBox.Show("DONOR FAILED TO DELETE ");
            }
        }
        public void Clear()
        {
            txtMID.Clear();
            txtFName.Clear();
            txtLName.Clear();
            txtEmail.Clear();
            imageName = "no-image.jpg";
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 23);
            destinationPath = path + "Image\\" + imageName;
            pictureBox1.Image = new Bitmap(destinationPath);
        }
    }
}
