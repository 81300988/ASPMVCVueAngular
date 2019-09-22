using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vue_blog.Data;
using vue_blog.Models;

namespace vue_blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : Controller
    {
        private AppDbContext _ctx;
        public BlogController(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        public IEnumerable<Post> GetPosts() => _ctx.Posts.ToList();
        [HttpGet("{id}")]
        public Post GetPost(int id) => _ctx.Posts.FirstOrDefault(x => x.Id == id);
    }
}