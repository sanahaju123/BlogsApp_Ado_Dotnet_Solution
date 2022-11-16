
using BlogSApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogsApp.BusinessLayer.Services.Repository
{
    public interface IBlogRepository
    {
        Blog AddBlog(Blog blog);
        Blog GetBlogById(int blogId);
        Status DeleteBlog(int blogId);
    }
}
