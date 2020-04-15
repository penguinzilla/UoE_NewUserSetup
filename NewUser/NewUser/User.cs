using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewUser
{
    public class User
    {
        public string Name { get; set; }
        public string UUN { get; set; }

        public string Email { get; set; }
        public bool Kdriveaccess { get; set; }
        public bool KXaccess { get; set; }
        public bool MailBoxes { get; set; }
        public bool MailingLists { get; set; }
        public bool AssetReg { get; set; }
        public bool EdLan { get; set; }
        public int PhoneExt { get; set; }
        public bool PhoneDir { get; set; }
        public bool Other { get; set; }


        
        public User()   //Sets all user properties
        {
            Name = "";
            UUN = "";
            Email = "";
            Kdriveaccess = false;
            KXaccess = false;
            MailBoxes = false;
            MailingLists = false;
            AssetReg = false;
            EdLan = false;
            PhoneExt = 0;
            PhoneDir = false;
            Other = false;
            
        }


        public User create_user(string user)
        {

            user = user.Remove(0, 9);
            int indexoffname = user.IndexOf("FirstName");
            string uun = user.Substring(0, indexoffname);
            uun = Regex.Replace(uun, @"\r\n?|\n", "");
            user = user.Remove(0, indexoffname + 20);
            int indexofsname = user.IndexOf("Surname");
            string name = user.Substring(0, indexofsname);
            user = user.Remove(0, indexofsname + 20);
            int indexofgroup = user.IndexOf("Group");
            name = name + user.Substring(0, indexofgroup);
            name = Regex.Replace(name, @"\r\n?|\n", " ");
            string email = user.Substring(user.IndexOf("Email") + 8);

            User user1 = new User();
            user1.Name = name.TrimEnd();
            user1.UUN = uun;
            user1.Email = email;
            return user1;
        }        //Takes input string breaks it down and creates a user object with Name, UUN, and Email



        public List<string> checklist(User user)
        {

            List<string> Checklist = new List<string>();

            Checklist.Add("Name     : " + user.Name);
            Checklist.Add("UUN      : " + user.UUN);
            Checklist.Add("Email    : " + user.Email);
            Checklist.Add("K: drive : " + user.Kdriveaccess);
            Checklist.Add("KX access: " + user.KXaccess);
            Checklist.Add("Mailboxes: " + user.MailBoxes);
            Checklist.Add("M Lists  : " + user.MailingLists);
            Checklist.Add("Asset Reg: " + user.AssetReg);
            Checklist.Add("EdLan    : " + user.EdLan);
            Checklist.Add("Phone Ext: " + user.PhoneExt);
            Checklist.Add("Phone Dir: " + user.PhoneDir);
            Checklist.Add("Other    : " + user.Other);
            return Checklist;
        }   //Creates the checklist which is displayed on Form1
    }
}
