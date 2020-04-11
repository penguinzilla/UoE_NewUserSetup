using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            run_script();
        }

        private void run_script()
        {

        }
    }
}
