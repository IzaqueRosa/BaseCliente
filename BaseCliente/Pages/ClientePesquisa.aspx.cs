using BaseCliente.Business;
using BaseCliente.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BaseCliente.Pages
{
    public partial class ClientePesquisa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBancos();
                BindClientes();
            }
        }

        private void BindClientes()
        {
            PesquisarClientes();
        }

        private void PesquisarClientes(string nome = "", string idBAnco = "" )
        {
            gridClientes.DataSource = new Cliente().BuscarTodos(nome, idBAnco);
            gridClientes.DataBind();
        }

        private void BindBancos()
        {
            List<CwBanco> lstBancos = new Banco().BuscarTodos();

            ddlBancos.Items.Add(new ListItem("", ""));

            foreach (var banco in lstBancos)
                ddlBancos.Items.Add(new ListItem(banco.Nome, banco.Id.ToString()));
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            var nome = tbxNome.Text;
            var idBAnco = ddlBancos.SelectedValue;
            PesquisarClientes(nome, idBAnco);
        }

        protected void btnCadastrarNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteCadastro.aspx");
        }
    }
}