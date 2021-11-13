namespace API.Interfaces
{
    public interface IDeletePost
    {
        public void RemovePost(int postID); 
        public void DropPostsTable();
    }
}