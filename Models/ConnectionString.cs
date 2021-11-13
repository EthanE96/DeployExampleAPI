namespace API.Models
{
    public class ConnectionString
    {
        public string cs { get; set; }
        public ConnectionString() //heroku connection
        {
            string server = "sql5.freemysqlhosting.net";
            string database = "sql5450748";
            string port = "3306";
            string userName = "sql5450748";
            string password = "AFEttDk1hI";

            cs = $@"server={server}; user={userName}; database={database}; port={port}; password={password}";
        }
    }
}