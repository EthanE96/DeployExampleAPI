using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class DeletePost : IDeletePost
    {
        public void DropPostsTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = @"DROP TABLE IF EXISTS posts";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    
        public void RemovePost(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = @"DELETE FROM posts WHERE id=@id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}