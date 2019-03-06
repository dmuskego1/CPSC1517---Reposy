using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class BasicControls : System.Web.UI.Page
    {
        //create a static list<T> that will hang around between postings of the web page.
        //This could also have been done using a ViewState variable
        //Using a ViewState variable would require the user to retrieve the data on each posting
        public static List<DDLClass> DataCollection;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Page_Load executes each and every time there is a posting to this page
            //it is executed before any submit events
            //This method is an exelent place to do form initialization
            //you can test your postings using Page.IsPostBack
            //IsPostBack is the same item as IsPost from the Razor forms
            if (!Page.IsPostBack)
            {
                //create an instance for the static data collection
                DataCollection = new List<DDLClass>();

                //Add instance to this collection using the DDLClass greedy constructor
                DataCollection.Add(new DDLClass(1,"COMP1008"));
                DataCollection.Add(new DDLClass(2,"CPSC1517"));
                DataCollection.Add(new DDLClass(3,"DMIT2018"));
                DataCollection.Add(new DDLClass(4,"DMIT1508"));

                //sorting a List<T>
                //use the .sort()method
                //(x,y) represents any 2 items in the list
                //compare x.field to y.field; ascending
                //if we compare y.field to x.field; descending
                DataCollection.Sort((x, y) => x.DisplayField.CompareTo(y.DisplayField));

                //put the data Collection into the drop down list
                //a)assign the collection to the controls data source
                CollectionList.DataSource = DataCollection;

                //b) assign the field names through the properties of the drop down list for data association
                //DateValueField rpresents the value fot he item
                //DataTextField represents the display of the line item
                CollectionList.DataValueField = "ValueField";
                CollectionList.DataTextField = nameof(DDLClass.DisplayField);

                //c)bind the data to the web control
                //NOTE: This statement is not required in a windows form app
                CollectionList.DataBind();

                //can one put a prompt on their drowdownlist control
                //yes
                CollectionList.Items.Insert(0, "select ...");
            }
        }

        protected void SubmitButtonChoice_Click(object sender, EventArgs e)
        {
            //to grab the contents of a control will depend on the  access technique of the control
            //for a TextBox, Label, Literal use .Text
            //For Lists(RadioButtonLists, DropDownList) you may use a 
            //a) .SelectedValue -> The associated data value field
            //b) .SelectedIndex -> The selected position in the list
            //c) .SelectedItem -> The associated data display field
            //for a check box use .Checked (true of false)

            //for the most part, all data from a control returns as a String (Except for boolean type controls)
            string submitChoice = TextBoxNumberChoice.Text;
            int anum = 0;
            if (string.IsNullOrEmpty(submitChoice))
            {
                MessageLabel.Text = "Enter a number from 1 to 4";
            }
            else if (!int.TryParse(submitChoice,out anum))
            {
                MessageLabel.Text = "Entered value must be a number between 1 to 4";
            }
            else if (anum > 4 || anum <1)
            {
                MessageLabel.Text = "Entered value must be a number between 1 to 4";
            }
            else
            {
                // when Positioning in a list it is BEST to position using the SelectedValue 
                //unless you wish to position in a specific physical location such as your prompt line, then use SelectedIndex

                //SelectedValue expects a string value
                //SelectedIndex expects a numberic value
                RadioButtonListChoice.SelectedValue = submitChoice;

                //boolean controls are set using true or false
                CheckBoxChoice.Checked = (submitChoice.Equals("2") || submitChoice.Equals("3"));

                CollectionList.SelectedValue = submitChoice;

                //display label will show the various values obtained from a list using SelectedValue, SelectedIndex, and SelectedItem
                DisplayReadOnly.Text = CollectionList.SelectedItem.Text + " at index " + CollectionList.SelectedIndex + " has a value of " + CollectionList.SelectedValue;
            }
        }

        protected void DLLSetButton_Click(object sender, EventArgs e)
        {

        }
    }
}