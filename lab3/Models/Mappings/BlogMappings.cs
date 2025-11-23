using lab3.Models.Entities;

namespace lab3.Models.Mappings
{
    public static class BlogMappings
    {
        public static BlogArticle ToEntity(this CreateBlogArticleModel blogArticle) => new() {
            Id = blogArticle.Id,
            Title = blogArticle.Title,
            Description = blogArticle.Description ?? string.Empty,
            Content = blogArticle.Content
        };

        public static BlogComment ToEntity(this CreateBlogCommentModel comment) => new() {
            ArticleId = comment.ArticleId,
            Author = comment.Author,
            Content = comment.Content,
            CreatedAt = DateTime.UtcNow
        };

        public static BlogCommentViewModel ToViewModel(this BlogComment comment) => new() {
            Id = comment.Id,
            Author = comment.Author,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt
        };

        public static BlogArticleViewModel ToViewModel(this BlogArticle blogArticle) => new() {
            Id = blogArticle.Id,
            Title = blogArticle.Title,
            Description = blogArticle.Description,
            Content = blogArticle.Content,
            Comments = blogArticle.Comments.OrderByDescending(c => c.CreatedAt)
            .Select(c => c.ToViewModel()).ToList()
        };
    }
}