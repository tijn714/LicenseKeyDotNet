using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QP = QP_Helpers.QP_Helpers;

namespace LicenseKeyDotNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string fullRegistryPath = @"HKEY_CURRENT_USER\Software\DotNetLicense";
            string registryValueName = "KeY";

            string key = QP.GetRegister(fullRegistryPath, registryValueName);

            if (key != null && QP.IsLicensed(key, "LicenseKeyDotNet.LicenseKeys.txt"))
                QP._isLicensed = true;
            else
            {
                QP._isLicensed = false;

                Window_Buy win = new Window_Buy();

                win.ShowDialog();
            }
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (QP._isLicensed == false)
            {
                subcribersToolStripMenuItem.Enabled = false;
                btn_secret.Enabled = false;
                label_status.Text = "Status: No License key found."; 

            }

            else
            {
                activateToolStripMenuItem.Enabled = false;
                activateToolStripMenuItem.Text = "Activated";
                label_status.Text = "Status: License Active";
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void subcribersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseKeyDotNet.sub per = new LicenseKeyDotNet.sub();
            per.Show();
        }

        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (QP._isLicensed==true)
            {
                activateToolStripMenuItem.Enabled = false;
                activateToolStripMenuItem.Text = "Activated";

            }
            else
            {
                Window_Buy act = new Window_Buy();

                act.ShowDialog();
            }
        }

        private void abouytToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseKeyDotNet.about abt = new LicenseKeyDotNet.about();
            abt.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Q: I activated the app with the menu but everything is still disabled, how to fix? \nA: Restart the app to activate all the functions.\n\n"
                           +"Q: Why is the 'activate' in the menu disabled? \nA: You already activated the software, so you don't need this :)" ,"Help");
        }

        private void btn_secret_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I am proud of you.","Secret");
        }

        private void label_status_Click(object sender, EventArgs e)
        {
            if (QP._isLicensed == true)
            {
                label_status.Text = "Status: License Active";
            }
            else
            {
                label_status.Text = "Status: No License key found.";
            }
        }
    }
}
