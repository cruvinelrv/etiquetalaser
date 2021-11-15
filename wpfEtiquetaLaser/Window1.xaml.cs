using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace wpfEtiquetaLaser
{
    using code;
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private ProdutoVO produto;
        string nomeEmpresa;

        public Window1()
        {
            InitializeComponent();

            try
            {
                for (int i = 1; i <= 50; i++)
                {
                    cmbQtd.Items.Add(i);
                }
                cmbQtd.SelectedIndex = 0;
                txtPesquisaProduto.Focus();
                EtiquetaDAO dao = new EtiquetaDAO();
                nomeEmpresa = dao.nomeEmpresa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceção: "+ex.Message);
                throw;
            }

        }

        private void txtPesquisaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                pesquisaProduto();
        }

        private void btnPesquisaProduto_Click(object sender, RoutedEventArgs e)
        {
            pesquisaProduto();
        }

        private void pesquisaProduto()
        {
            try
            {

                produto = null;
                lblProduto.Content = "";
                string parametros = txtPesquisaProduto.Text;
                txtPesquisaProduto.Text = "";
                EtiquetaDAO dao = new EtiquetaDAO();
                IList<ProdutoVO> produtos = dao.pesquisaProdutos(parametros);

                if (produtos.Count == 0)
                {
                    MessageBox.Show("nenhum produto encontrado");
                    lstbxPesquisaProduto.Focus();
                    return;
                }

                lstbxPesquisaProduto.Items.Clear();
                foreach (ProdutoVO p in produtos)
                {
                    lstbxPesquisaProduto.Items.Add(p);
                }

                if (produtos.Count == 0)
                    txtPesquisaProduto.Focus();
                else
                {
                    lstbxPesquisaProduto.SelectedIndex = 0;
                    lstbxPesquisaProduto.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceção: " + ex.Message);
                throw;
            }
        }

        private void lstbxPesquisaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                jogaProduto();
        }
        private void lstbxPesquisaProduto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            jogaProduto();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            jogaProduto();
        }

        private void jogaProduto()
        {
            try
            {

                if (lstbxPesquisaProduto.SelectedItem == null)
                {
                    lstbxPesquisaProduto.Items.Clear();
                    return;
                }

                produto = (ProdutoVO)lstbxPesquisaProduto.SelectedItem;
                lblProduto.Content = produto.nome;


                cmbGrade.Items.Clear();
                foreach (GradeVO g in produto.grades)
                {
                    cmbGrade.Items.Add(g);
                }

                cmbQtd.Focus();
                cmbQtd.SelectedIndex = 0;
                cmbGrade.SelectedIndex = 0;
                lstbxPesquisaProduto.Items.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceção: " + ex.Message);
                throw;
            }
        }

        private void cmbQtd_KeyDown(object sender, KeyEventArgs e)
        {
            cmbGrade.Focus();
        }

        private void cmbGrade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                jogaEtiquetas();
        }

        private void btnJogaGrade_Click(object sender, RoutedEventArgs e)
        {
            jogaEtiquetas();
        }

        private void jogaEtiquetas()
        {
            try
            {

                if (produto == null)
                {
                    cmbGrade.Items.Clear();
                    return;
                }

                produto.idGrade = cmbGrade.SelectedIndex;
                GradeVO g = produto.grades[produto.idGrade];
                produto.referencia = g.referencia;
                produto.descricao = g.descricao;
                produto.codBarra = g.codBarra;
                
                EtiquetaVO et = new EtiquetaVO(produto);//upcasting via reflexão
                
                int qtd = (int)cmbQtd.SelectedItem;

                for (int i = 0; i < qtd; i++)
                {
                    lstbxEtiquetas.Items.Add(et);
                }
                lblQtdEtiquetas.Content = lstbxEtiquetas.Items.Count.ToString();

                txtPesquisaProduto.Focus();
                produto = null;
                lblProduto.Content = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceção: " + ex.Message);
                throw;
            }
        }

        private void lstbxEtiquetas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && lstbxEtiquetas.SelectedIndex > 0)
            {
                lstbxEtiquetas.Items.RemoveAt(
                    lstbxEtiquetas.SelectedIndex);
                lblQtdEtiquetas.Content = lstbxEtiquetas.Items.Count.ToString();
            }
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                IList<EtiquetaVO> etiquetas = new List<EtiquetaVO>();

                EtiquetaBARRA barra = new EtiquetaBARRA();

                foreach (EtiquetaVO et in lstbxEtiquetas.Items)
                {
                    if (et.codBarra == "")
                        throw new Exception("O produto " + et.idProduto.ToString() + " (" + et.nome + ") não possui código de barras");

                    int x = 0;
                    while (x < 11)
                    {
                        try
                        {
                            //throw new Exception();
                            et.codBarraArquivo = barra.geraArquivo(et.codBarra);
                            x = 20;
                        }
                        catch
                        {
                            if (x < 10)
                                MessageBox.Show(
                                    string.Format("Tentativa: {0}\n\nNão foi possivel imprimir o código {1},\n\ntentando novamente... ", x, et.codBarra)
                                    );
                            else
                                MessageBox.Show(
                                    string.Format("O erro com o código de barras {0} persistiu por mais de 10 vezes,\n\nTente imprimir novamente ou contate a Multisoft ", et.codBarra)
                                    );
                            x++;
                        }
                    }





                    etiquetas.Add(et);
                }
                //lstbxEtiquetas.Items.Clear();

                EtiquetaREND rend = new EtiquetaREND(etiquetas);
                string arquivoHTML = rend.renderizar(nomeEmpresa, 33);
                string firefox = @"C:\Arquivos de programas\Mozilla Firefox\firefox.exe";

                if (!System.IO.File.Exists(firefox))
                {
                    MessageBox.Show("Você deve instalar o Mozila Firefox ® para imprimir etiquetas");
                }
                else
                    System.Diagnostics.Process.Start(firefox, arquivoHTML);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceção: " + ex.Message);
                throw;
            }
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            lstbxEtiquetas.Items.Clear();
            lblQtdEtiquetas.Content = "0";
        }

    }
}
