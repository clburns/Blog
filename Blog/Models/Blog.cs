using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MyBlog_ChristonBurns.com_.Models
{
    public class Blog
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM d, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
    }

    public class Member
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class BlogDBContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}