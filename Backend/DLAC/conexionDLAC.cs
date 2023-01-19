using Microsoft.Data.SqlClient;
namespace web_api_es.DLAC
{
    public class conexionDLAC
    {
        SqlConnection cn = new SqlConnection(@"server=DESKTOP-GAU7660\SQLEXPRESS; database=PrubaAgaval;Trusted_Connection= True;" +
            "MultipleActiveResultSets= True;TrustServerCertificate= False;Encrypt= False");
        public SqlConnection getcn
        {
            get { return cn; }
        }
    }
}
