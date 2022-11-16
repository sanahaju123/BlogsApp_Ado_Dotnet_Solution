
using BlogsApp.BusinessLayer.Interfaces;
using BlogsApp.BusinessLayer.Services.Repository;
using BlogSApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogsApplication.BusinessLayer.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public Blog AddBlog(Blog blog)
        {
            return  _blogRepository.AddBlog(blog);
        }

        public  Status DeleteBlog(int blogId)
        {
            return  _blogRepository.DeleteBlog(blogId);
        }


        public Blog GetBlogById(int blogId)
        {
            return  _blogRepository.GetBlogById(blogId);
        }

    }
}
