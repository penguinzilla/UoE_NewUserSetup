using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUser
{
    class RequestAlias
    {

        
        public void rqst_alias()
        {

            string def = Globals.User.Name.Replace(" ", ".") + "@ed.ac.uk";
            string email = Microsoft.VisualBasic.Interaction.InputBox("Please enter new alias", "Request Alias", def);
            Globals.User.Email = email + "   (Requested)";
            CreateMailItem(Globals.User.UUN, Globals.User.Email);

        }   //Prompts the user to enter the new alias to request



        private void CreateMailItem(string uun, string email)
        {
            Microsoft.Office.Interop.Outlook.Application app = new
                          Microsoft.Office.Interop.Outlook.Application();
            MailItem item = app.CreateItem(OlItemType.olMailItem);
            item.BodyFormat = OlBodyFormat.olFormatHTML;
            item.To = "nathan.kelly@ed.ac.uk";
            item.Subject = "Email Alias";
            item.Body =String.Format(
                "Hi,\n\n" +
                "Please could you set 0365 email alias {0} for UUN: {1}\n\n" +
                "Thanks,\n" +
                "ACE IT", email, uun);
            item.Display();
        }   //Creates a new Outlook email and populates all information

    }
}
