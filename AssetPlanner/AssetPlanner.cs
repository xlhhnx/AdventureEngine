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
    public partial class AssetPlanner : Form
    {
        public AssetPlanner()
        {
            InitializeComponent();
        }

        private void browseFilesButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            assetFileTextBox.Text = openFileDialog.FileName;
        }

        private void AssetPlanner_Load(object sender, EventArgs e)
        {
            if (Program.LoadFile != string.Empty)
            {
                // Load here
            }
        }
    }
}
