using System.Configuration;

namespace WindowsFormsApp1.Models
{
    public class AppConnection
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
    }
}
