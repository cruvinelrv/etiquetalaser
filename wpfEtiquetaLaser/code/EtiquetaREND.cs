using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace wpfEtiquetaLaser.code
{
    public class EtiquetaREND
    {
        IList<EtiquetaVO> etiquetas;

        public EtiquetaREND(IList<EtiquetaVO> etiquetas)
        {
            this.etiquetas = etiquetas;
        }

        public string renderizar(string nomeEmpresa, int quebraPagina)
        {
            string path = @"C:\set\impressoes_html\paginas\" + DateTime.Now.GetHashCode().ToString() + ".html";
            StringBuilder sb = new StringBuilder();


            sb.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            sb.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
            sb.Append("<head>");
            sb.Append("<link rel='StyleSheet' href='../etiquetas.css' type='text/css' media='all'/>");
            sb.Append("<title>Multisoft</title>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body class='a4'>");

            IList<int> quebras = new List<int>();

            for (int i = 1; i <= 10; i++)
			{
                quebras.Add(i*33);
			}

            sb.AppendLine("  <div class='pagina'>");
            for (int i = 0; i < etiquetas.Count; i++)
			{
                bool booQuebraSuperior = (quebras.Contains(i));

                if (booQuebraSuperior)
                    sb.AppendLine("  </div>");//pagina

                if (booQuebraSuperior)
                    sb.AppendLine("  <div class='pagina'>");

                sb.Append("    <div class='pimaco_a4_256'>");
                sb.AppendFormat("<p class='empresa'>{0}</p>", /*i.ToString()+" - "+*/nomeEmpresa);
                sb.AppendFormat("<p class='idproduto'>{0}</p>", etiquetas[i].idProduto);
                sb.AppendFormat("<p class='descricao'>{0}</p>", etiquetas[i].nome);
                sb.AppendFormat("<p class='grade'>GRADE: {0}</p>", etiquetas[i].referencia);
                sb.AppendFormat("<p class='original'>{0}</p>", etiquetas[i].codOriginal);
                sb.AppendFormat("<p class='fornecedor'>FRNC: {0}</p>", etiquetas[i].idFornecedor);
                if (etiquetas[i].marca == "")
                    sb.Append("<p class='marca'></p>");
                else
                    sb.AppendFormat("<p class='marca'>MARCA: {0}</p>", etiquetas[i].marca);
                //sb.AppendFormat("<p class='barra'><img src='{0}'/></p>", etiquetas[i].codBarraArquivo);
                sb.AppendFormat("<p class='barra' style=\"background-image:url('{0}')\"></p>", etiquetas[i].codBarraArquivo);
                sb.AppendFormat("<p class='valor'>{0}</p>", etiquetas[i].valor);
                sb.AppendLine("</div>");

			}
            sb.AppendLine("  </div>");

            sb.AppendLine();
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");


            //gera html
            //C:\set\impressoes_html\etiqueta.html


            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
            return path;
        }

    }
}
