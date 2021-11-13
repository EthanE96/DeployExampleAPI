using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IReadPost
    {
        public List<Post> GetAllPosts();
        public Post GetPost(int id);
    }
}