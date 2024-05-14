<%@ Page Title="Cadastro Clientes" Language="C#" MasterPageFile="~/Master/Cadastro.Master" AutoEventWireup="true" CodeBehind="ClienteCadastro.aspx.cs" Inherits="BaseCliente.Pages.ClienteCadastro" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div class="row">
            <asp:Label class="col-form-label" runat="server" Width="10%">Código</asp:Label>
            <asp:TextBox runat="server" ID="tbxCodigo" CssClass="form-control" Enabled="false" Width="20%"></asp:TextBox>

            <asp:Label class="col-form-label" runat="server" Width="10%">Data de Criacao</asp:Label>
            <asp:TextBox runat="server" ID="tbxDataCriacao" CssClass="form-control" Enabled="false" Width="20%"></asp:TextBox>
        </div>

        <div class="row">
            <asp:Label class="col-form-label" runat="server" Width="10%">Nome</asp:Label>
            <asp:TextBox runat="server" ID="tbxNome" CssClass="form-control" Width="20%"></asp:TextBox>

            <asp:Label class="col-form-label" runat="server" Width="10%">CPF</asp:Label>
            <asp:TextBox runat="server" ID="tbxCpf" CssClass="form-control" Width="20%" MaxLength="11"></asp:TextBox>

            <asp:Label class="col-form-label" runat="server" Width="10%">Bancos</asp:Label>
            <asp:DropDownList runat="server" ID="ddlBancos" CssClass="form-control" Width="20%">
            </asp:DropDownList>

        </div>


        <div class="row">
            <asp:Button runat="server" Text="Salvar" ID="btnSalvar" Width="10%" OnClick="btnSalvar_Click" />
            <asp:Button runat="server" Text="Voltar" ID="btnVoltar" Width="10%" OnClick="btnVoltar_Click" />
            <asp:Button runat="server" Text="Excluir" ID="btnExcluir" Width="10%" OnClick="btnExcluir_Click"/>
        </div>
    </main>
</asp:Content>
