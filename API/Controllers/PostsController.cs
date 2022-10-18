using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Domain;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly DataContext context;

        public PostsController(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// GET api/posts
        /// </summary>
        /// <returns>A list of posts </returns>
        [HttpGet(Name = "GetPosts")]

        public ActionResult <List<Post>> Get()
        {
            return this.context.Posts.ToList();
        }

        /// <summary>
        /// GET api/posts/[id]
        /// <param name="id">Post id</param>
        /// </summary>
        /// <returns>A list of posts </returns>
        [HttpGet("{id}", Name = "GetById")]

        public ActionResult<Post> GetById(Guid id)
        {
            var post = this.context.Posts.Find(id);
            if (post is null)
            {
                return NotFound();
            }

            return Ok(post);
        }
    }

    
}