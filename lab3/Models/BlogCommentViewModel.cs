using lab3.Models.Entities;

namespace lab3.Models{
    public class BlogCommentViewModel{
        public int Id {get; set;}
        public string Author {get; set;} = string.Empty;
        public string Content {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;}
        public DateTime PostedAt => CreatedAt;
    }

    public static class BlogCommentExtensions
    {
        public static BlogCommentViewModel ToViewModel(this BlogComment comment) => new() {
            Id = comment.Id,
            Author = comment.Author,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt
        };
    }
}