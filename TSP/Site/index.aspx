<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Site.index" %>

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
                    <li class="nav-item active">
                        <a class="nav-link" href="index.aspx">Home <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="product.aspx">Product</a>
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
        <div class="col-5">
            <div class="card">
                <div class="card-body">
                    <div class="form-group">
                        <asp:FileUpload ID="File" runat="server" />
                        <asp:Button ID="btnImport" runat="server" Text="Import" OnClick="btnImport_Click" CssClass="btn btn-dark" />

                        <div class="alert alert-success" role="alert" runat="server" visible="false" id="divSuccess">
                            <asp:Label ID="msgSuccess" runat="server"></asp:Label>
                        </div>
                        <div class="alert alert-warning" role="alert" runat="server" visible="false" id="divAlert">
                            <asp:Label ID="msgAlert" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script src="Scripts/bootstrap.min.js"></script>
        <script src="Scripts/jquery-3.0.0.min.js"></script>
        <script src="Scripts/popper.min.js"></script>
    </form>
</body>
</html>
