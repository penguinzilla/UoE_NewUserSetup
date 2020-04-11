using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace NewUser
{
    public partial class Form1 : Form
    {

        //Form1 Loaded on launch, this is the primary window
        public Form1()
        {
            InitializeComponent();
            disable_menu();
        }

        //Menu items start disabled
        private void disable_menu()
        {
            k_access_btn.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            mark_done_btn.Enabled = false;
            rqst_alias_btn.Enabled = false;
        }

        //Enables menu when a user is loaded
        private void enable_menu()
        {
            k_access_btn.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            mark_done_btn.Enabled = true;
            rqst_alias_btn.Enabled = true;
        }











        //Must run first | Prompts for full name input then comfirms returned user | Creates user object and populates check-list
        private void find_btn_Click(object sender, EventArgs e)
        {
            LoadUser lu = new LoadUser();
            string loadedUser = lu.Find_user();
            if(loadedUser != null)
            { 
                load_checklist(loadedUser);
            }
        }

        //Creates a new user object and checklist
        private void load_checklist(string user)
        {
            User u = new User();
            User user1 = u.create_user(user);
            Globals.User = user1;

            update_listbox();
            enable_menu();            
        }


        //Clears and updates Form1 list box (New user checklist)
        private void update_listbox()
        {
            User u = new User();
            List<string> Checklist = new List<string>();
            Checklist = u.checklist(Globals.User);
            listBox1.Items.Clear();
            foreach (var item in Checklist)
            {
                if (item.Contains("False"))
                {
                    string item2 = item.Replace("False", " ");
                    listBox1.Items.Add(item2.ToString());
                }
                else if (item.Contains("True"))
                {
                    string item2 = item.Replace("True", "Done");
                    listBox1.Items.Add(item2.ToString());
                }
                else if (!(item.Contains("False")) && !(item.Contains("True")))
                {
                    listBox1.Items.Add(item.ToString());
                }
            }
        }

        









        //Opens and writes a new Outlook email | Only to to press send
        private void rqst_alias_btn_Click(object sender, EventArgs e)
        {
            RequestAlias ra = new RequestAlias();
            ra.rqst_alias();
            update_listbox();
        }



        private void mark_done_btn_Click(object sender, EventArgs e)
        {
             
        }







        private void k_access_btn_Click(object sender, EventArgs e)
        {
            KDriveGroups k = new KDriveGroups();
            User u = new User();
            User user = k.find_same_as_user();
            List<string> groups = k.run_script(user);
            Form3 form3 = new Form3(groups);
            form3.Show();

        }
    }

}

