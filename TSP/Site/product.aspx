<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="Site.product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Tech Start Pro - Olist</title>
    <link href="Content/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-reboot.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="index.aspx">TSP</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item ">
                        <a class="nav-link" href="index.aspx">Home</a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="product.aspx">Product <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Pricing</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link disabled" href="#">Disabled</a>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="col-8" style="padding: 10px">
            <div class="form-row">
                <div class="col-md-4 mb-3">
                    <label>*Name:</label>
                    <input type="text" id="productName" runat="server" class="form-control" maxlength="255" />
                </div>

                <div class="col-md-4 mb-3">
                    <label>*Description:</label>
                    <input type="text" id="productDescription" runat="server" class="form-control" maxlength="255" />
                </div>
            </div>
            <div class="form-row">
                <div class="col-md-4 mb-3">
                    <label>Price:</label>
                    <input type="number" step="0.01" id="productPrice" runat="server" class="form-control" />
                </div>
                <div class="col-md-4 mb-3">
                    <label>*Category:</label>
                    <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
            <div class="form-row" style="padding: 4px">
                <asp:Button ID="bntRegister" Text="Register" runat="server" CssClass="btn btn-success" OnClick="bntRegister_Click" />
                <asp:Button ID="btnUpdate" Text="Update" runat="server" CssClass="btn btn-info" />
                <div class="alert alert-primary" role="alert" runat="server" visible="false" id="divPrimary">
                    <asp:Label ID="msgPrimary" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <hr />

        <script src="Scripts/bootstrap.min.js"></script>
        <script src="Scripts/jquery-3.0.0.min.js"></script>
        <script src="Scripts/popper.min.js"></script>
    </form>
</body>
</html>
