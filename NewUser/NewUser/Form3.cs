using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewUser
{

    public partial class Form3 : Form
    {

        private List<string> Groups;

        public Form3(List<string> groups)
        {
            InitializeComponent();
            this.Groups = groups;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            update_listbox();
        }

        private void update_listbox()
        {
            foreach (string item in Groups)
            {
                listBox1.Items.Add(item);
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirm_btn_Click(object sender, EventArgs e)
        {

            apply_groups_script(this.Groups);

        }

        public void apply_groups_script(List<string> Groups)
        {
            foreach (string Group in Groups)
            {

                string path = @"\\sg.datastore.ed.ac.uk\sg\accom\users\nkelly3\[WIP]\ApplyGroups.ps1";
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"powershell.exe";
                startInfo.Arguments = String.Format("{0} {1} {2}", path, Globals.User.UUN, Group);
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                Process p = new Process();
                p.StartInfo = startInfo;
                p.Start();
                p.WaitForExit();

                string output = p.StandardOutput.ReadToEnd();

                string errors = p.StandardError.ReadToEnd();
            }

        }
    }
}

    