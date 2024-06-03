using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tabloid.Models;

namespace Tabloid.Models.DTOs;
  public class UsersPostsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime? Publication { get; set; }

        public UsersPostsDTO(Post posts)
        {
            Id = posts.Id;
            Title = posts.Title;
            Author = posts.Author.FirstName;
            Category = posts.Category.CategoryName;
            Publication = posts.Publication;
        }
    }