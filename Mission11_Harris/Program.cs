using Microsoft.EntityFrameworkCore;
using Mission11_Harris.Models;

var builder = WebApplication.CreateBuilder(args);
// Abby Harris 
// Section 001 
// Mission 11 - build a website to display books in an online bookstore 


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookstoreContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:BookstoreConnection"]);
});

builder.Services.AddScoped<IBookRepository, EFBookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute("pagination", "Books/{pageNum}", new {Controller = "Home", action="Index"});
app.MapDefaultControllerRoute();
app.Run();
