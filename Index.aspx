<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AcessarSite.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css" integrity="sha512-+4zCK9k+qNFUR5X+cKL9EIR+ZOhtIloNl9GIKS57V1MyNsYpYcUrUeQc9vNfzsWfV28IaLL3i96P9sdNyeRssA==" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="col-sm-2 md-form md-outline input-with-post-icon datepicker">
                <asp:TextBox ID="Tb_Data_Compra" runat="server" 
                    placeholder="Select date" type="date" 
                    CssClass="form-control" OnTextChanged="Tb_Data_Compra_TextChanged">
                </asp:TextBox>
                <asp:TextBox ID="Tb_Data_Final" runat="server" 
                    placeholder="Select date" type="date" 
                    CssClass="form-control" OnTextChanged="Tb_Data_Final_TextChanged">
                </asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </div>
            <asp:Calendar 
                ID="Cal_Compra" 
                runat="server"
                OnSelectionChanged="Cal_Compra_SelectionChanged">
            </asp:Calendar>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Button 
                ID="Btn_AcessaSite" 
                runat="server" 
                Text="Acessar"
                OnClick="Btn_AcessaSite_Click"
                 CssClass="btn btn-outline-primary"/>
        </div>
        <asp:GridView 
                runat="server"
                ID="Grid_Precos"
                CssClass="table table-dark">
        </asp:GridView>
    </form>
</body>
</html>
