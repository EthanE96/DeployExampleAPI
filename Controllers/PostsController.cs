using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [EnableCors("AnotherPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class postsController : ControllerBase
    {
        // GET: api/posts
        //getPosts()
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Post> Get()
        {
            IReadPost readObject = new ReadPost();
            return readObject.GetAllPosts();
        }

        // GET: api/posts/5
        // **** not in use ****
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Post Get(int id)
        {
            //Not in use
            IReadPost readPost = new ReadPost();
            return readPost.GetPost(id);
        }

        // POST: api/posts
        //postPost()
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Post value)
        {
            ISavePost newPost = new SavePost();
            newPost.ATimeCreatePost(value);
        }

        // PUT: api/posts/5
        //editPost()
        //reseedDatabase()
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            if (value == "reseed"){
                ISeedPost seedPost = new SavePost();
                seedPost.SeedData();
            }
            else if (value != "reseed"){
                ISavePost savePost = new SavePost();
                savePost.EditPost(id, value);
            }
        }

        // DELETE: api/posts/5
        //removePost()
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeletePost deletePost = new DeletePost();
            deletePost.RemovePost(id);
        }


        //for future reference => 
        //the [FromBody] is the body: JSON.stringify(value)
        //the [HttpDelete("{id}")] the added data to the https request ...
        //which can also be sent to the constructor

    }
}
