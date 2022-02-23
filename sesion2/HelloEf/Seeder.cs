public static class Seeder {
    public static async Task Seed(BlogContext ctx) {
        if (!ctx.Blogs.Any()) {
            Console.WriteLine("Insertando blogs...");
            var blog = new Blog() {
                Name = "Test blog",
                Url = "https://escuela.it/blogs/edu"
            };

            ctx.Blogs.Add(blog);

            var blog2 = new Blog() {
                Name = "Test blog 2",
                Url = "https://escuela.it/blogs/miguel"
            };

            ctx.Blogs.Add(blog2);
            
            for (var idx = 1; idx <=10; idx++) {
                var post = new Post() {
                    PublishedDate = DateTime.UtcNow,
                    Texto = $"Lorem ipsum: {idx}"
                };
            
                blog.Posts.Add(post);
            }

            for (var idx = 1; idx <=5; idx++) {
                var post = new Post() {
                    PublishedDate = DateTime.UtcNow,
                    Texto = $"Lorem ipsum Miguel: {idx}"
                };
            
                blog2.Posts.Add(post);
            }

    
            await ctx.SaveChangesAsync();
        }
    }
}