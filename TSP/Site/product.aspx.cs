using BLL.CategoryBLL;
using BLL.ProductCategoryBLL;
using BLL.ProductBLL;
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
        ProductCategoryBLL productCategoryBLL = new ProductCategoryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory();
                LoadProducts();
                divPrimary.Visible = false;
            }
        }
        protected void bntRegister_Click(object sender, EventArgs e)
        {
            try
            {
                ProductBLL productBLL = new ProductBLL();
                msgPrimary.Text = productBLL.SaveProduct(productName.Value, productDescription.Value, productPrice.Value, Convert.ToInt32(ddlCategory.SelectedValue));
                divPrimary.Visible = true;
                LoadProducts();
                CleanScreen();
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void grdProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "up")
                {
                    string productId = e.CommandArgument.ToString();
                }
                if (e.CommandName == "del")
                {
                    string productId = e.CommandArgument.ToString();
                    if (productCategoryBLL.DeleteProduct(Convert.ToInt32(productId)))
                    {
                        divPrimary.Visible = true;
                        msgPrimary.Text = "Deleted product.";
                        LoadProducts();
                    }
                    else
                    {
                        msgPrimary.Text = "Error when deleting the product.";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void LoadProducts()
        {
            try
            {
                grdProducts.DataSource = productCategoryBLL.ListAllProducts(); ;
                grdProducts.DataBind();
            }
            catch (Exception ex)
            {

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
        protected void CleanScreen()
        {
            try
            {
                productName.Value = string.Empty;
                productDescription.Value = string.Empty;
                productPrice.Value = string.Empty;
                ddlCategory.SelectedValue = "0";
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}