using BLL.CategoryBLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divSuccess.Visible = false;
                divAlert.Visible = false;
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            UploadAndProcessFile();
        }

        protected bool UploadAndProcessFile()
        {
            if (File.HasFile)
            {
                string excelPath = Server.MapPath("~/Files/") + Path.GetFileName(File.PostedFile.FileName);
                File.SaveAs(excelPath);
                CategoryBLL categoryBLL = new CategoryBLL();
                if (categoryBLL.ReadCSV(excelPath))
                {
                    divSuccess.Visible = true;
                    msgSuccess.Text = "Upload completed.";
                    return true;
                }
                else
                {
                    divAlert.Visible = true;
                    msgAlert.Text = "Error while processing the file.";
                    return false;
                }
            }
            else
            {
                divAlert.Visible = true;
                msgAlert.Text = "File not found.";
                return false;
            }
        }
    }
}