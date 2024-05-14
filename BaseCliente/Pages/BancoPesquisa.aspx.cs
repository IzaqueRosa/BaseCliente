using BaseCliente.Business;
using System;

namespace BaseCliente.Pages
{
    public partial class BancoPesquisa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PesquisarBancos();
            }
        }

        private void PesquisarBancos(string nome = "")
        {
            gridBancos.DataSource = new Banco().BuscarTodosComFiltro(nome);
            gridBancos.DataBind();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            var nome = tbxNome.Text;
            PesquisarBancos(nome);
        }

        protected void btnCadastrarNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("BancoCadastro.aspx");
        }
    }
}