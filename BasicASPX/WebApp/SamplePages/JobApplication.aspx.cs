using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class JobApplication : System.Web.UI.Page
    {
        //this is a temporary storage area alternative to database
        //this is because we are not currently implementing database functionality
        public static List<GridViewData> GVCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                GVCollection = new List<GridViewData>();
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string fullName = FullName.Text;
            string email = EmailAddress.Text;
            string phoneNumber = PhoneNumber.Text;
            string fullOrPartTime = FullOrPartTime.SelectedValue;
            //The checkbox list is a collection of items (Rows)
            //  We can traversa  collection using a ForEach Loop
            //  on each row of the collection you can process its data
            string jobs = "";
            foreach(ListItem JobRow in Jobs.Items)
            {
                if (JobRow.Selected)
                {
                    jobs += JobRow.Text + ' ';
                }
            }
            GVCollection.Add(new GridViewData(fullName,email,phoneNumber,fullOrPartTime,jobs));

            //display the collection of data
            //  we would like to display the data in a tabular format
            //  we will use the GridView control to display the tabular format
            JobsApplicantList.DataSource = GVCollection;
            JobsApplicantList.DataBind();

        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FullName.Text = "";
            EmailAddress.Text = "";
            PhoneNumber.Text = "";
            //Two ways of clearing out selection lists
            FullOrPartTime.SelectedIndex = -1;
            FullOrPartTime.ClearSelection();
            Jobs.SelectedIndex = -1;
            
        }
    }
}