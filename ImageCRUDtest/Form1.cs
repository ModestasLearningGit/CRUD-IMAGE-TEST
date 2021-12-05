using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCRUDtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pnlADD_Click(object sender, EventArgs e)
        {
            frmADD add = new frmADD();
            add.Show();
        }

        private void pnlUpdate_Click(object sender, EventArgs e)
        {
            frmUPDATE update = new frmUPDATE();
            update.Show();
        }

        private void pnlDelete_Click(object sender, EventArgs e)
        {
            frmDELETE delete = new frmDELETE();
            delete.Show();
        }
    }
}
