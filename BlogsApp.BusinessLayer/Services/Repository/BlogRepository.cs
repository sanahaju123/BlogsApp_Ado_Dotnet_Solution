
using BlogSApp.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsApp.BusinessLayer.Services.Repository
{
    public class BlogRepository:IBlogRepository
    {
        static private string GetConnectionString()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Data Source=DESKTOP-7LIHPHH\SQLEXPRESS01;Initial Catalog=BlogApp_Db;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return myConnection.ConnectionString;
        }
        public Blog AddBlog(Blog blog)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = GetConnectionString();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Blog (BlogId,Content,Title) Values (@BlogId,@Content,@Title)";
            sqlCmd.Connection = myConnection;


            sqlCmd.Parameters.AddWithValue("@BlogId", blog.BlogId);
            sqlCmd.Parameters.AddWithValue("@Content", blog.Content.ToString());
            sqlCmd.Parameters.AddWithValue("@Title", blog.Title.ToString());
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            return blog;
            myConnection.Close();
        }

        public Status DeleteBlog(int blogId)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = GetConnectionString();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from Blog where BlogId=" + blogId + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            int rowDeleted = sqlCmd.ExecuteNonQuery();
            Status st = new Status();
            st.Message = "Data Deleted Successfully";
            return st;
            myConnection.Close();
        }

        public Blog GetBlogById(int blogId)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = GetConnectionString();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from Blog where BlogId=" + blogId + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Blog blog = null;
            while (reader.Read())
            {
                blog = new Blog();
                blog.BlogId = Convert.ToInt32(reader.GetValue(0));
                blog.Content = reader.GetValue(1).ToString();
                blog.Title = reader.GetValue(2).ToString();
            }
            return blog;
            myConnection.Close();
        }
    }
}
