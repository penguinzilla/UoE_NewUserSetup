using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewUser
{
    class KDriveGroups
    {
        public User find_same_as_user()
        {
            LoadUser lu = new LoadUser();
            string loadedUser = lu.Find_user();
            User u = new User();
            User user1 = u.create_user(loadedUser);
            return user1;
        }   //Prompts for the K: drive "Same As..." user

        public List<string> get_groups_script(User user)
        {
            string path = @"\\sg.datastore.ed.ac.uk\sg\accom\users\nkelly3\[WIP]\GetADGroups.ps1";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"powershell.exe";
            startInfo.Arguments = String.Format("{0} {1}", path, user.UUN);
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

            List<string> groups = sort_groups(output);
            return groups;
        }   //Runs script to get groups assosiated w/ "Same As..." user


        private List<string> sort_groups(string output)
        {
            List<string> temp = output.Split('\n').ToList();
            List<string> groups = new List<string>();

            foreach (string item in temp)
            {
                if (item.StartsWith("CN=ACE") || item.StartsWith("CN=ACCOM") || item.StartsWith("CN=Ace") || item.StartsWith("CN=Accom"))
                {
                    int i = item.IndexOf(',');
                    string t1 = item.Substring(3, (i - 3));
                    groups.Add(t1);
                }
            }
            return groups;
        }   //Keeps relevent groups (Ace & Accom) and discards the rest
    }
}
    
