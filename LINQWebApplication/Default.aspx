<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LINQWebApplication._Default" %>

<!DOCTYPE html>

<html>

<head>
<title>Linq Test Page</title>

</head>

    <body>
<form id="form1" runat="server">

        <asp:GridView ID="GridView1" runat="server" DataKeyNames="Id">
        </asp:GridView>
    <asp:GridView ID="GridView2" runat="server"></asp:GridView>

    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

    <div style="width:100%">
        <div style="display:inline; width:33%">
            <asp:Button ID="btnAdo" runat="server" Text="Load Using ADO" OnClick="btnAdo_Click"  /></div>
        <div style="display:inline; width:33%">
            <asp:Button ID="btnLinqArray" runat="server" Text="Load Array using LinQ" OnClick="btnLinqArray_Click" /></div>
        <div style="display:inline; width:33%">
            <asp:Button ID="btnLinq" runat="server" Text="Load LinQ" OnClick="btnLinq_Click" /></div>
    </div>

    <div>
        <asp:Button ID="btnLambdaGetStudents" runat="server" Text="Lambda Get Students" OnClick="btnLambdaGetStudents_Click" />

        <asp:GridView ID="GridView3" runat="server">
        </asp:GridView>

    </div>


</form>
        

    </body>

</html>




