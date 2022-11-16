
using BlogsApp.BusinessLayer.Interfaces;
using BlogsApp.BusinessLayer.Services.Repository;
using BlogsApp.Tests.TestCases;
using BlogSApp.Entities;
using BlogsApplication.BusinessLayer.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace BlogsApp.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IBlogService _blogServices;
        public readonly Mock<IBlogRepository> blogservice = new Mock<IBlogRepository>();
        private readonly Blog _blog;
        private readonly Status _status;
        private static string type = "Functional";
        public FunctionalTests(ITestOutputHelper output)
        {
            _blogServices = new BlogService(blogservice.Object);
            _output = output;

            _blog = new Blog
            {
                BlogId = 1,
                Content = "MyBlog",
                Title = "MyTitle",
            };
            _status = new Status
            {
                Message = "Data Deleted Successfully"
            };
        }

        /// <summary>
        /// Test to Add a new Blog.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Add_Blog()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                blogservice.Setup(repos => repos.AddBlog(_blog)).Returns(_blog);
                var result =  _blogServices.AddBlog(_blog);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

       

        /// <summary>
        /// Test to get Blog By Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetBlogById()
        {
            //Arrange
            var res = false;
            int blogId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                blogservice.Setup(repos => repos.GetBlogById(blogId)).Returns(_blog);
                var result =  _blogServices.GetBlogById(blogId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Delete Blog By Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_DeleteBlogById()
        {
            //Arrange
            var res = false;
            int blogId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                blogservice.Setup(repos => repos.DeleteBlog(blogId)).Returns(_status);
                var result =  _blogServices.DeleteBlog(blogId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
    }
}