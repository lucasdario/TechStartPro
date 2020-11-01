using BLL.CategoryBLL;
using BLL.ProductCategoryBLL;
using BLL.ProductBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.entity.productCategory;
using System.Globalization;

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
        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                msgPrimary.Text = productCategoryBLL.UpdateProduct(Convert.ToInt32(product_Id.Value), productName.Value, productDescription.Value, productPrice.Value, Convert.ToInt32(ddlCategory.SelectedValue));
                divPrimary.Visible = true;
                LoadProducts();
                CleanScreen();
                btnRegister.Visible = true;
                btnUpdateProduct.Visible = false;
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
                    ProductCategory objProductCategory = productCategoryBLL.FindByProductId(Convert.ToInt32(productId));

                    if (objProductCategory != null)
                    {
                        btnRegister.Visible = false;
                        btnUpdateProduct.Visible = true;
                        product_Id.Value = objProductCategory.prca_id.ToString();
                        productName.Value = objProductCategory.product_id.prod_name.ToString();
                        productDescription.Value = objProductCategory.product_id.prod_description.ToString();
                        productPrice.Value = objProductCategory.product_id.prod_price.ToString(CultureInfo.InvariantCulture);
                        ddlCategory.SelectedValue = objProductCategory.category_id.cate_id.ToString();
                    }
                    else
                    {
                        divPrimary.Visible = true;
                        msgPrimary.Text = "Error loading product.";
                    }
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
                        divPrimary.Visible = true;
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
                product_Id.Value = string.Empty;
                ddlCategory.SelectedValue = "0";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}