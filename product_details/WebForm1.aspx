<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="product_details.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="商品" HeaderText="商品" SortExpression="商品" />
                    <asp:BoundField DataField="销量" HeaderText="销量" ReadOnly="True" SortExpression="销量" />
                    <asp:BoundField DataField="总价" HeaderText="总价" ReadOnly="True" SortExpression="总价" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Model1 %>" SelectCommand="select p_dt.p_name as '商品',SUM(p_od.o_num) as '销量',SUM(p_od.o_num)*p_dt.p_price as '总价' from p_od,p_dt where p_dt.p_id=p_od.p_id group by p_dt.p_name,p_dt.p_price"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
