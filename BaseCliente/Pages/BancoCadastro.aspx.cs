using BaseCliente.Business;
using BaseCliente.Models;
using System;

namespace BaseCliente.Pages
{
    public partial class BancoCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["PreviousPageUrl"] = Request.UrlReferrer?.ToString();

                if (Request.QueryString["IdBanco"] != null)
                {
                    int idaBanco = int.Parse(Request.QueryString["IdBanco"].ToString());
                    CarregarDadosBanco(idaBanco);
                }

                string confirmMessage = "Tem certeza que deseja excluir este banco?";
                string confirmScript = "return confirm('" + confirmMessage + "');";
                btnExcluir.OnClientClick = confirmScript;
            }
        }

        private void CarregarDadosBanco(int idaBanco)
        {
            CwBanco cwBanco = new Banco().BuscarPorId(idaBanco);
            if (cwBanco != null)
            {
                tbxCodigo.Text = cwBanco.Id.ToString();
                tbxDataCriacao.Text = cwBanco.DataCriacao.ToString();
                tbxNome.Text = cwBanco.Nome.ToString();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tbxNome.Text))
                {
                    int idBanco = 0;
                    bool inserir = false;

                    if (string.IsNullOrWhiteSpace(tbxCodigo.Text))
                    {
                        inserir = true;
                        idBanco = new Banco().Inserir(tbxNome.Text);
                    }
                    else
                    {
                        idBanco = int.Parse(tbxCodigo.Text);
                        new Banco().Alterar(tbxCodigo.Text, tbxNome.Text);
                    }

                    CarregarDadosBanco(idBanco);

                    if (inserir)
                    {
                        Response.Write("<script>alert('Cadastro realizado com sucesso!');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Alteração realizada com sucesso!');</script>");
                    }
                }
                else
                {
                    throw new Exception("Favor preencher todos os campos!");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            string previousPageUrl = Session["PreviousPageUrl"] as string;

            if (!string.IsNullOrEmpty(previousPageUrl))
            {
                Response.Redirect(previousPageUrl);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tbxCodigo.Text))
                {
                    if (Page.IsValid)
                    {
                        new Banco().Excluir(tbxCodigo.Text);
                    }

                    Response.Write("<script>alert('Exclusão realizada com sucesso!');</script>");
                    LimparCampos();
                }
                else
                {
                    throw new Exception("O Cadastro ainda não foi salvo!");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void LimparCampos()
        {
            tbxCodigo.Text = "";
            tbxNome.Text = "";
            tbxDataCriacao.Text = "";
        }
    }
}