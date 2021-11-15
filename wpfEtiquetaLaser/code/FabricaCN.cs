using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace wpfEtiquetaLaser.code
{
    using FirebirdSql.Data.FirebirdClient;

    public class FabricaCN
    {
        static string cnString = "";

        public static IDbConnection getNewCN()
        {
            if (cnString == "")
            {
                string[] dados = File.ReadAllLines(@"c:\set\impressoes_html\dados.txt");
                string ip_servidor = dados[0];
                string path_banco = dados[1];
                cnString = @"User=SYSDBA;Password=masterkey;Database="+path_banco+";DataSource="+ip_servidor+";Port=3050;Dialect=3; Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=0;";
                System.IO.File.WriteAllText(@"c:\set\impressoes_html\cn.txt", cnString);
            }
            IDbConnection cn = new FbConnection(cnString);
            cn.Open();
            return cn;
        }

    }
}
