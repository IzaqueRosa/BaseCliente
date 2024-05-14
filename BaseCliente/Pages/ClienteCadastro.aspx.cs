using BaseCliente.Business;
using BaseCliente.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseCliente.Pages
{
    public partial class ClienteCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["PreviousPageUrl"] = Request.UrlReferrer?.ToString();

                BindBancos();

                if (Request.QueryString["IdCliente"] != null)
                {
                    int idCliente = int.Parse(Request.QueryString["IdCliente"].ToString());
                    CarregarDadosCliente(idCliente);
                }

                string confirmMessage = "Tem certeza que deseja excluir este cliente?";
                string confirmScript = "return confirm('" + confirmMessage + "');";
                btnExcluir.OnClientClick = confirmScript;
            }
        }

        private void CarregarDadosCliente(int idCliente)
        {
            CwCliente cwCliente = new Cliente().BuscarPorId(idCliente);
            if(cwCliente != null)
            {
                tbxCodigo.Text = cwCliente.Id.ToString();
                tbxDataCriacao.Text = cwCliente.DataCriacao.ToString();
                tbxNome.Text = cwCliente.Nome.ToString();
                tbxCpf.Text = cwCliente.CPF.ToString();
                ddlBancos.SelectedValue = cwCliente.IdBanco.ToString();
            }
        }

        private void BindBancos()
        {
            List<CwBanco> lstBancos = new Banco().BuscarTodos();

            ddlBancos.Items.Add(new ListItem("", ""));

            foreach (var banco in lstBancos)
                ddlBancos.Items.Add(new ListItem(banco.Nome, banco.Id.ToString()));
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tbxNome.Text) && !string.IsNullOrWhiteSpace(tbxCpf.Text) && !string.IsNullOrWhiteSpace(ddlBancos.SelectedValue))
                {
                    int idCliente = 0;
                    bool inserir = false;

                    if (string.IsNullOrWhiteSpace(tbxCodigo.Text))
                    {
                        inserir = true;
                        idCliente = new Cliente().Inserir(tbxNome.Text, tbxCpf.Text, ddlBancos.SelectedValue);
                    }
                    else
                    {
                        idCliente = int.Parse(tbxCodigo.Text);
                        new Cliente().Alterar(tbxCodigo.Text, tbxNome.Text, tbxCpf.Text, ddlBancos.SelectedValue);
                    }

                    CarregarDadosCliente(idCliente);

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
            }catch (Exception ex)
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
                        new Cliente().Excluir(tbxCodigo.Text);
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
            tbxDataCriacao.Text = "";
            tbxCpf.Text = "";
            tbxNome.Text = "";
            ddlBancos.SelectedValue = "";
        }
    }
}