using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class FirstPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This method is executed on Each and every pass of the Page
            //This Method is executed before any of your event methods

        }
        protected void PressMe_Click(object sender, EventArgs e)
        {
            Output.Text = "wewwew";
        }
    }
}