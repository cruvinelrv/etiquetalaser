using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace wpfEtiquetaLaser.code
{
    //Padrão Composite
    public class EtiquetaVO
    {
        public EtiquetaVO() { }
        public EtiquetaVO(EtiquetaVO e)
        {
            this.clone(e);
        }

        private void clone(EtiquetaVO e)
        {
            foreach (FieldInfo f in typeof(EtiquetaVO).GetFields())
            {
                f.SetValue(this, f.GetValue(e));
            }
        }

        public int
            idProduto, idGrade, idFornecedor;
        public string
            nome, referencia, descricao, codBarra, codOriginal, marca, codBarraArquivo, valor;
        public override string ToString()
        {
            return referencia+" - "+nome;
        }
    }

    public class GradeVO : EtiquetaVO
    {
        public override string ToString()
        {
            return referencia;
        }
    }
    public class ProdutoVO : GradeVO
    {
        public IList<GradeVO> grades;

        public override string ToString()
        {
            return idProduto+" "+ nome;
        }
    }
}
