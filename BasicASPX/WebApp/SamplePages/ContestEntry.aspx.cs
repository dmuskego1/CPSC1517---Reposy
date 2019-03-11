using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        public static List<Contestant> ContestantCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                ContestantCollection = new List<Contestant>();
            }

        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            Province.ClearSelection();
            PostalCode.Text = "";
            EmailAddress.Text = "";
            Terms.Checked = false;
            CheckAnswer.Text = "";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            /*-- Required Field
             *    ensures that the user has not skipped the field
             *-- Range Validator
             *    Checks that a users entry is within a lower-upper range of numbers or characters
             *-- Regular Expression Validator
             *    checks that the users entry matches a pattern defined by a regular expression ie. Email Phone Postal Code ect.
             *-- Compare Validator
             *    1)data type check
             *    2)check an entered value against a constant value
             *    3)check an entered value 'A' against an entered value 'B'
             *-- Custom Validator
             *    Calls a user method on the webserver 
             *    
             *    Display ValidationSummary()
             * */

            if (Page.IsValid) //This test will fire the validation controls on the server side
            {
                //if additional validation is required check that first
                if (Terms.Checked)
                {

                    string firstName = FirstName.Text;
                    string lastName = LastName.Text;
                    string streetAddress1= StreetAddress1.Text;
                    string streetAddress2 = StreetAddress2.Text;
                    string city = City.Text;
                    string province= Province.SelectedValue;
                    string postal = PostalCode.Text;
                    string email = EmailAddress.Text;

                    ContestantCollection.Add(new Contestant(firstName, lastName, streetAddress1, streetAddress2, city, province, postal, email));
                    ContestantList.DataSource=ContestantCollection;
                    ContestantList.DataBind();
                }
                else
                {
                    Message.Text = "You did not agree to the contest terms your entry is denied.";
                }
            }
        }
    }
}