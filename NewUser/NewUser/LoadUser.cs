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


   
    class LoadUser   // Run on Find User... button press | returns User
    {

        
        public string Find_user()
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Please enter the name of the user", "Find User", "Andrew Taylor");

            string[] names = new string[3];

            try
            {
                names = name.Split(' ');
            }
            catch (System.IndexOutOfRangeException) { names[0] = " "; names[1] = " "; }

            if (names.Length > 1)
            {
                string output = run_script(names);
                if (output.Length == 0)
                {
                    MessageBox.Show("No results found.");
                    return null;
                }
                else
                {
                    string confirmeduser = confirm_user(output);
                    return confirmeduser;
                }
            }
            else
            {
                MessageBox.Show("Please enter a first and surname.");
                return null;
            }
        }   //Asks for full name w/ validation and passes on


        
        private string run_script(string[] names)
        {
            string path = @"\\sg.datastore.ed.ac.uk\sg\accom\users\nkelly3\[WIP]\QueryADForUser.ps1";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"powershell.exe";
            startInfo.Arguments = String.Format("{0} {1} {2}", path, names[0], names[1]);
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();

            string errors = process.StandardError.ReadToEnd();

            output.Trim();

            return output;
        }   //Runs powershell AD script w/ provided name | returns all mathcing users


        
        private int check_num_returns(string output)
        {
            int num = Regex.Matches(output, "DistinguishedName").Count;
            return num;
        }   //Checks how many mathcing users were fiund | returns number of users found



        
        private (List<string>, List<string>, List<string>, List<string>, List<string>) Format_output(string output)
        {
            int num = check_num_returns(output);

            var details = new List<string>();
            var uun = new List<string>();
            var department = new List<string>();
            var fname = new List<string>();
            var sname = new List<string>();
            var email = new List<string>();


            var resultString = Regex.Replace(output, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
            details = (resultString.Split('\n')).ToList();

            foreach (string item in details)
            {
                if (item.StartsWith("DistinguishedName"))
                {
                    department.Add(item.Replace("DistinguishedName", "Group"));
                }
                if (item.StartsWith("SamAccountName"))
                {
                    uun.Add(item.Replace("SamAccountName", "UUN"));
                }
                if (item.StartsWith("GivenName"))
                {
                    fname.Add(item.Replace("GivenName", "FirstName"));
                }
                if (item.StartsWith("Surname"))
                {
                    sname.Add(item);
                }
                if (item.StartsWith("UserPrincipalName"))
                {
                    email.Add(item.Replace("UserPrincipalName", "Email"));
                }

            }

            return (uun, fname, sname, department, email);

        }   //Formats usre details to make them easier to read for confirming


        
        private string confirm_user(string output)
        {


            int num = check_num_returns(output);

            var details = new List<string>();
            var uun = new List<string>();
            var department = new List<string>();
            var fname = new List<string>();
            var sname = new List<string>();
            var email = new List<string>();

            (uun, fname, sname, department, email) = Format_output(output);

            if (num == 1)
            {
                string singleUser = uun[0] + fname[0] + sname[0] + department[0] + email[0];
                var dialogResult = MessageBox.Show(singleUser, "Is this the User you are looking for?", MessageBoxButtons.YesNoCancel);
                if (dialogResult.ToString() == "Yes")
                {

                    return singleUser;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                Form2 form2 = new Form2(uun, fname, sname, department, email);
                var dialogResult = form2.ShowDialog();
                if (dialogResult.ToString() == "Confirm")
                {
                    int user_num = Globals.Confirmed;
                    string singleUser = uun[user_num] + fname[user_num] + sname[user_num] + department[user_num] + email[user_num];
                    return singleUser;
                }
                else
                {
                    return null;
                }
            }

        }   //Prompts user to confirm correct user | returns single confirmed user


    }
}

