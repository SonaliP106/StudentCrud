<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="operation.aspx.cs" Inherits="StudentCrud.operation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="nametxt" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nametxt" ErrorMessage="enter name"></asp:RequiredFieldValidator>
            <br />
            <br />
            Stream&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="streamtxt" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="streamtxt" ErrorMessage="enter stream"></asp:RequiredFieldValidator>
            <br />
            <br />
            Age&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="agetxt" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="agetxt" ErrorMessage="enter age"></asp:RequiredFieldValidator>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="bView" runat="server" Text="view" OnClick="bView_Click" />

            <br />

            <asp:GridView ID="DataView" runat="server" DataKeyNames="id" OnRowCancelingEdit="DataView_RowCancelingEdit" OnRowEditing="DataView_RowEditing" OnRowUpdating="DataView_RowUpdating" OnRowDeleting="DataView_RowDeleting">
                <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
            </asp:GridView>


        </div>
    </form>
</body>
</html>
