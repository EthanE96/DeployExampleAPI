using API.Models;

namespace API.Interfaces
{
    public interface ISavePost
    {
        public void CreatePost(Post alPost);
        public void EditPost(int id, string text);
        public void ATimeCreatePost(Post alPost);
    }
}