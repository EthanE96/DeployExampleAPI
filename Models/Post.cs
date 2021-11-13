using System;
using API.Database;
using API.Interfaces;

namespace API.Models
{
    public class Post
    {
        public int postID { get; set; }
        public string postText { get; set; }
        public string timeDate { get; set; }
        public Post()
        {
            
        }
    }
}