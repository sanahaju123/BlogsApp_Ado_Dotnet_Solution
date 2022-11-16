
using BlogSApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogsApp.BusinessLayer.Interfaces
{
    public interface IBlogService
    {
        Blog AddBlog(Blog blog);
        Blog GetBlogById(int blogId);
        Status DeleteBlog(int blogId);
    }
}
