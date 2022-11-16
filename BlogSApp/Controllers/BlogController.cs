using BlogsApp.BusinessLayer.Interfaces;
using BlogSApp.Entities;
using BlogSApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet]
        public Blog Get([FromQuery]int id)
        {
            return _blogService.GetBlogById(id);
        }

        [HttpPost]
        public Blog AddBlog(Blog blog)
        {
            return _blogService.AddBlog(blog);
        }

        [HttpDelete]
        public Status DeleteBlogByID([FromQuery] int id)
        {
            return _blogService.DeleteBlog(id);
        }
    }
}