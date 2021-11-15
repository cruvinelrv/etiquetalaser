using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace wpfEtiquetaLaser.code
{
    public class SuperDAO
    {
        protected IDbConnection cn;
    }
    public class EtiquetaDAO : SuperDAO
    {
        public EtiquetaDAO()
        {
            this.cn = FabricaCN.getNewCN();
        }
        public EtiquetaDAO(IDbConnection cn)
        {
            this.cn = cn;
        }

        public string nomeEmpresa()
        {
            string sql = "SELECT FIRST 1 nomefantasia FROM empresa";
            
            using (IDbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sql;

                using (IDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                {
                    if (dr.Read())
                    {
                        return dr.GetString(0);
                    }
                }
            }
            return "EMPRESA";
        }

        public IList<ProdutoVO> pesquisaProdutos(string parametros)
        {
            parametros = parametros.Replace("'", "").Replace("\"", "").ToUpper();

            #region sql produto
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT FIRST 20 p.codigo, p.cod_original, p.nome, p.cod_barra, p.cod_fornecedor, p.p_venda, m.nome");
            sb.AppendLine(" FROM produto p LEFT JOIN marca m");
            sb.AppendLine(" ON p.cod_marca = m.codigo WHERE ");

            try
            {
                int.Parse(parametros);
                sb.AppendFormat("(p.codigo = '{0}') OR (p.nome LIKE '%{0}%') OR (m.nome LIKE '%{0}%') OR (p.cod_original LIKE '%{0}%')", parametros);
            }
            catch
            {
                sb.AppendFormat("(p.nome LIKE '%{0}%') OR (m.nome LIKE '%{0}%') OR (p.cod_original LIKE '%{0}%')", parametros);
            }

            //sb.AppendFormat(" WHERE (p.codigo = '{0}') OR (p.nome LIKE '%{0}%') OR (m.nome LIKE '%{0}%') OR (p.cod_original LIKE '%{0}%')", parametros);
            string sqlProduto = sb.ToString();

            System.IO.File.WriteAllText("c:\\set\\impressoes_html\\sql.txt",sqlProduto);

            #endregion

            IList<ProdutoVO> ls = new List<ProdutoVO>();

            using (IDbCommand cmdProduto = cn.CreateCommand())
            {
                cmdProduto.CommandText = sqlProduto;

                using (IDataReader drP = cmdProduto.ExecuteReader())
                {
                    while (drP.Read())
                    {
                        ProdutoVO p = new ProdutoVO()
                        {
                            idProduto = drP.GetInt32(0),
                            codOriginal = drP.GetString(1),
                            nome = drP.GetString(2),
                            codBarra = drP.GetString(3),
                            idFornecedor = drP.GetInt32(4),
                            //valor = string.Format("0:0.0,0", drP.GetFloat(5)),
                            valor = drP.GetDouble(5).ToString("C"),
                            marca = drP.GetString(6),
                            grades = new List<GradeVO>()
                        };

                        if (p.descricao != null && p.descricao.Length > 35)
                            p.descricao = p.descricao.Substring(0, 35);
                        if (p.marca != null && p.marca.Length > 35)
                            p.marca = p.marca.Substring(0, 15);

                        //grade
                        #region grade
                        IDbCommand cmdGrade = cn.CreateCommand();
                        cmdGrade.CommandText = string.Format("SELECT cod_grade, referencia, cod_barra FROM produto_grade WHERE cod_produto = {0}", p.idProduto);

                        using (IDataReader drG = cmdGrade.ExecuteReader())
                        {
                            while (drG.Read())
                            {
                                p.grades.Add(
                                    new GradeVO()
                                    {
                                        idGrade = drG.GetInt32(0),
                                        referencia = drG.GetString(1),
                                        codBarra = drG.GetString(2)
                                    }
                                    );
                            }
                        }
                        if (p.grades.Count == 0)
                        {
                            p.grades.Add(
                                new GradeVO()
                                {
                                    referencia = "U",
                                    codBarra = p.codBarra
                                }
                                );
                        }
                        #endregion
                        ls.Add(p);
                    }
                }
            }
            return ls;
        }

    }
}
