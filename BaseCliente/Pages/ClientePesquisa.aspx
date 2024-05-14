<%@ Page Title="Buscar Clientes" Language="C#" MasterPageFile="~/Master/Pesquisa.Master" AutoEventWireup="true" CodeBehind="ClientePesquisa.aspx.cs" Inherits="BaseCliente.Pages.ClientePesquisa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>

        <div class="row">
            <asp:Label class="col-form-label" runat="server" Width="10%">Nome</asp:Label>
            <asp:TextBox runat="server" ID="tbxNome" Width="20%"></asp:TextBox>
            
            <asp:Label class="col-form-label" runat="server" Width="10%">Bancos</asp:Label>
            <asp:DropDownList runat="server" ID="ddlBancos" Width="20%"></asp:DropDownList>
        </div>

        <div class="row">
            <asp:Button runat="server" Text="Pesquisar" ID="btnPesquisar" Width="10%" OnClick="btnPesquisar_Click"/>
            <asp:Button runat="server" Text="Cadastrar Novo" ID="btnCadastrarNovo" Width="10%" OnClick="btnCadastrarNovo_Click"/>
        </div>

        <hr />

        <asp:GridView runat="server" ID="gridClientes" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="IdCliente" HeaderText="Código">
                    <HeaderStyle Width="20%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:HyperLinkField DataTextField="Nome" HeaderText="Nome" DataNavigateUrlFields="IdCliente" DataNavigateUrlFormatString="ClienteCadastro.aspx?IdCliente={0}">
                    <HeaderStyle Width="20%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="Cpf" HeaderText="CPF">
                    <HeaderStyle Width="20%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Banco" HeaderText="Banco">
                    <HeaderStyle Width="20%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="DataCriacao" HeaderText="Data de Cadastro">
                    <HeaderStyle Width="20%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </main>
</asp:Content>
