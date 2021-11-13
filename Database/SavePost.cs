using System;
using System.Collections.Generic;
using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class SavePost: ISavePost, ISeedPost
    {
        public void CreatePostsTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE posts(id INTEGER PRIMARY KEY AUTO_INCREMENT, text TEXT, date TEXT)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void SeedData()
        {
            IDeletePost deleteTemp = new DeletePost();
            deleteTemp.DropPostsTable();
            ISeedPost seedTemp = new SavePost();
            seedTemp.CreatePostsTable();
            
            List<Post> alPosts = new List<Post>();
            alPosts.Add(new Post(){postText="Al's first post, YAY!",timeDate="9/10/2021 7:20:00"});
            alPosts.Add(new Post(){postText="Roll tide roll",timeDate="9/18/2021 11:20:00"});
            alPosts.Add(new Post(){postText="Me and Bryce Young",timeDate="9/30/2021 7:15:30"});
            alPosts.Add(new Post(){postText="I hate Texas A&M",timeDate="10/9/2021 10:30:00"});
            alPosts.Add(new Post(){postText="Maybe just here to test sort, maybe...",timeDate="9/20/2018 10:30:00"});
            alPosts.Add(new Post(){postText="On the road to MSU",timeDate="10/12/2020 14:30:00"});

            foreach (Post post in alPosts)
            {
                ISavePost savePost = new SavePost();
                savePost.CreatePost(post);
            }
        }

        public void CreatePost(Post alPost)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO posts(text, date) VALUES (@text, @date)";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@text", alPost.postText);
            cmd.Parameters.AddWithValue("@date", alPost.timeDate);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public void ATimeCreatePost(Post alPost)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO posts(text, date) VALUES (@text, @date)";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@text", alPost.postText);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }


        public void EditPost(int id, string text)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            
            string stm = @"UPDATE posts SET text=@text WHERE id=@id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@text", text);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}