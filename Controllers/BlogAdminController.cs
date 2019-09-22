using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vue_blog.Data;
using vue_blog.Models;

namespace vue_blog.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class BlogAdminController : Controller
    {
        private AppDbContext _ctx;
        public BlogAdminController(AppDbContext ctx)
        {
            _ctx = ctx;
        }
    [HttpGet]
    public IActionResult Index() => View(_ctx.Posts.ToList());
    [HttpPost]
    public async Task<IActionResult> Index(string title, string body)
    {
        _ctx.Posts.Add(new Post{
            Title = title,
            Body = body
        });
        await _ctx.SaveChangesAsync();
        return RedirectToAction("Index", "BlogAdmin");
    }
    }
}