<%@ Page Title="Display" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Display.aspx.cs" Inherits="Display" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div>
        <asp:GridView runat="server" ID="gdImage" HeaderStyle-BackColor="Blue" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="BookName" HeaderText="BookName" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" Text="View" OnClick="View"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="BookImage" HeaderText="BookImage" />
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:Literal ID="ltEmbed" runat="server" />
    </div>
</asp:Content>

