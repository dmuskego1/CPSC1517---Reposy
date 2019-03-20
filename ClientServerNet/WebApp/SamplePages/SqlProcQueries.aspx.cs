using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NorthwindData;
using NorthwindSystem.BLL;
namespace WebApp.SamplePages
{
    public partial class SqlProcQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //clear old messages
            MessageLabel.Text = "";
            //load the drop down list on the first time processing this page
            if (!Page.IsPostBack)
            {
                //all calls should be done in use friendly error handling
                try
                {
                    //when the page is first loaded obtain the complete list of categories from the database
                    CategoryController sysmgr = new CategoryController();
                    List<Category> results = sysmgr.Category_List();
                    //  sort this list alphabetically
                    results.Sort((x, y) => x.CategoryName.CompareTo(y.categoryName));
                    //  assign the data to the drop down list control
                    CategoryList.DataSource = results;
                    //  indicate the DataTextField and DataValueField
                    CategoryList.DataTextField = nameof(CategoryList.CategoryName);
                    CategoryList.DataValueField = nameof(CategoryList.CategoryID);
                    //  bind the data source
                    CategoryList.DataBind();
                    //  add a prompt
                    CategoryList.Items.Insert(0, "select...");
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //ensure a selection was made
            if(CategoryList.SelectedIndex==0)
            {
                MessageLabel.Text = "Select a category of products to display";
            }
            else
            {
                //within user friendly error handling
                try
                {
                    //connect to the appropriate controller
                    ProductController sysmgr = new ProductController();
                    // issue a request to the controllers appropriate method
                    List<Product> datainfo = sysmgr.Product_GetByCategory(int.Parse(CategoryList.SelectedValue));
                    //check results
                    //  none (.count()==0):message to user
                    if (datainfo.Count() == 0)
                    {
                        MessageLabel.Text = "No products were found for that category";

                        CategoryProductList.DataSource = null;
                        CategoryProductList.DataBind();
                    }
                    //  found:load a gridview
                    else
                    {
                        datainfo.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                        CategoryProductList.DataSource = datainfo;
                        CategoryProductList.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            CategoryList.ClearSelection();
            CategoryProductList.DataSource = null;
            CategoryProductList.DataBind();
        }
    }
}