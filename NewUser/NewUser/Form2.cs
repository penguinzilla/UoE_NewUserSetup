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
    //Form2 launches if multiple users return when searching for a user
    public partial class Form2 : Form
    {
        private List<string> sname;
        private List<string> department;
        private List<string> email;
        private List<string> uun;
        private List<string> fname;


        
        public Form2(List<string> uun, List<string> fname, List<string> sname, List<string> department, List<string> email)
        {
            InitializeComponent();

            this.uun = uun;
            this.fname = fname;
            this.sname = sname;
            this.department = department;
            this.email = email;

        }


        //On Load populate fields with users
        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (string item in uun)
            {
                listBox1.Items.Add(item.Substring(item.IndexOf(':')+1));
            }
            fill_listBox2();
        }

        //Changing between users updates details to desplay corresponding users 
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_listBox2();
        }

        private void fill_listBox2()
        {
            int selected = listBox1.SelectedIndex;
            if(selected == -1)
            {
                selected = 0;
            }

            listBox2.Items.Clear();
            listBox2.Items.Add(uun[selected]);
            listBox2.Items.Add(fname[selected]);
            listBox2.Items.Add(sname[selected]);
            listBox2.Items.Add(department[selected]);
            listBox2.Items.Add(email[selected]);
        }


        //Once correct user is confirmed passes back details
        private void confirm_btn_Click(object sender, EventArgs e)
        {
            int selected = listBox1.SelectedIndex;
            if (selected == -1)
            {
                MessageBox.Show("Please select a User.");
            }
            else
            {
                Globals.Confirmed = selected;
                this.Close();
            }


        }

        //Cancels search
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class Globals
    {
        public static User User;

        private static int conf_num;

        public static int Confirmed
        {
            get
            {
                return conf_num;
            }
            set
            {
                conf_num = value;
            }
        }
    }
}
