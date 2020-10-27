using BLL.CategoryBLL;
using BLL.ProductBLL;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class product : System.Web.UI.Page
    {
        CategoryBLL categoryBLL = new CategoryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory();
                divPrimary.Visible = false;
            }
        }
        protected void bntRegister_Click(object sender, EventArgs e)
        {
            try
            {
                ProductBLL productBLL = new ProductBLL();
                msgPrimary.Text = productBLL.SaveProduct(productName.Value, productDescription.Value, Convert.ToDouble(productPrice.Value, CultureInfo.InvariantCulture), Convert.ToInt32(ddlCategory.SelectedValue));
                divPrimary.Visible = true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void LoadCategory()
        {
            ddlCategory.DataSource = categoryBLL.ListAllCategory();
            ddlCategory.DataValueField = "cate_id";
            ddlCategory.DataTextField = "cate_name";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select a category", "0"));
        }
    }
}