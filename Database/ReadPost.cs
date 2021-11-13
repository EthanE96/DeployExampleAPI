using System.Reflection.Emit;
using System.Collections.Generic;
using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class ReadPost: IReadPost
    {
        public List<Post> GetAllPosts()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
    
            //sorts in desc timestamp order
            string stm = "SELECT * FROM posts ORDER BY STR_TO_DATE(date, '%m/%d/%Y %H:%i:%s') DESC";
            using var cmd = new MySqlCommand(stm, con); cmd.Prepare();          
            MySqlDataReader reader = cmd.ExecuteReader();
            
            List<Post> readPost = new List<Post>();
            while (reader.Read())
            {
                readPost.Add(new Post(){postID=reader.GetInt32(0),postText=reader.GetString(1),timeDate=reader.GetString(2)});
            } 
            return readPost; 
        }

        public Post GetPost(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM posts WHERE id=@id";
            using var cmd = new MySqlCommand(stm, con);  
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return new Post(){postID=reader.GetInt32(0),postText=reader.GetString(1),timeDate=reader.GetString(2)};
        }
    }
}