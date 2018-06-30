using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYP_test
{
    public partial class Form1 : Form
    {
        String originalPath = "C:\\";

        public Form1()
        {
            InitializeComponent();
            if (btnStart.Text.Equals("Start"))
            {
                lblStatus.Text = "Down";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text.Equals("Start"))
            {
                fdb.SelectedPath = originalPath;
                if (MessageBox.Show("Is this the folder " + "\n" + originalPath + "   ?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    fdb.ShowDialog();
                    String folderName = fdb.SelectedPath;
                    originalPath = folderName;
                    lblStatus.Text = folderName;
                }

                
                picStatus.Image = FYP_test.Properties.Resources.Neon_green_dot_hi;
                btnStart.Text = "Stop";
                lblStatus.Text = "Running";
                var test = new Process();
                if (test.Start(originalPath))
                {
                    lblFolder.Text = "Folder is empty";
                }
                else
                {
                    lblFolder.Text = "Folder is not empty";
                    DeliveryOrder deliveryOrder = new DeliveryOrder();
                    Folder folder = new Folder();
                    if (folder.read(originalPath, ref deliveryOrder))
                    {
                        txtResult.AppendText("Read Successfully");
                        txtResult.AppendText(Environment.NewLine);
                        txtResult.AppendText(deliveryOrder.ToString());

                    }
                }


            }
            else
            {
                btnStart.Text = "Start";
                lblStatus.Text = "Down";
                picStatus.Image = FYP_test.Properties.Resources.red_dot_md;
            }
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
