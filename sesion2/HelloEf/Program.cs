using Microsoft.EntityFrameworkCore;

var builder = new DbContextOptionsBuilder<BlogContext>()
    .UseNpgsql("Host=localhost;Database=blogs;Username=blogs;Password=Passw0rd!");

var ctx = new BlogContext(builder.Options);

await ctx.Database.EnsureCreatedAsync();

await Seeder.Seed(ctx);


var blogs = Filter(ctx.Blogs);

foreach (var blog in blogs) {
    Console.WriteLine(blog.Name);
}


IQueryable<Blog> Filter(IQueryable<Blog> blogs) {
    return blogs.Where(b => b.Name.ToUpperInvariant().StartsWith("T"));
}

/*
var blogs = ctx.Blogs.Include(b => b.Posts).Where(b => b.Posts.Any(p => p.Id > 5))
    .Select(b => new { Id = b.Id, Name = b.Name, PostCount = b.Posts.Count, Posts = b.Posts});

var result = blogs.AsEnumerable().Select(b => new {Id = b.Id, Name = b.Name, PostCount = b.PostCount, MaxPost = b.Posts.Max(p => p.Id)});

foreach (var blog in result) {
    Console.WriteLine($"blog name {blog.Name}" );
    Console.WriteLine($"El blog tiene {blog.PostCount} posts y su mayor id es {blog.MaxPost}");
}

*/



