using System.Configuration;

namespace ENMT_V2.Repository
{
    public class Context
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
}
