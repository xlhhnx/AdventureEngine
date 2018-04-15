using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetPlanner
{
    public partial class LoadForm : Form
    {
        public LoadForm()
        {
            InitializeComponent();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            Program.LoadFile = openFileDialog.FileName;
            Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
