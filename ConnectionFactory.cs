namespace DAO
{
    public class ConnectionFactory
    {
        //private string Servidor = 'SKY007\\SQLEXPRESS';
        //private string Usuario = 'sa';
        //private string Senha = 'Summer@1987#';
        //private string BancoDados = 'dbProjetoX';

        public static string StringDeConexao
    {
            get
            {
                //return "server=Servidor;database=BancoDados;user=Usuario;pwd=Senha";
                //return "server=SKY007\\SQLEXPRESS;database=dbProjetoX;user=sa;pwd=Summer@1987#";
                //return "server=DESKTOP-5AP72DN\\SQLEXPRESS;database=dbProjetoX;user=sa;pwd=ca4f6fbd4";
                return "server=LAPTOP-AGLSPNV5\\SQLEXPRESS2;database=dbProjetoX;user=sa;pwd=fied";
            }
        }
    }            
}
