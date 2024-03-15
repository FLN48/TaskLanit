using System.ComponentModel.Design;
using TaskLanit;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

CarShowroomBlue carShowroomBlue = new CarShowroomBlue(100);
CarShowroomGreen carShowroomGreen = new CarShowroomGreen(100);
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<ACar, Mercedes>(x => { return new Mercedes(""); });
builder.Services.AddTransient<ACar, BMV>(x => { return new BMV(""); });

builder.Services.AddSingleton<ACarShowroom>(carShowroomGreen);
builder.Services.AddSingleton<ACarShowroom>(carShowroomBlue);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
//app.UseMiddleware<MiddlewareCarShowroom>();
app.MapRazorPages();

app.Run();

//public class MiddlewareCarShowroom
//{
//    readonly IEnumerable<ACarShowroom> CarShowrooms;
//    RequestDelegate next;
//    public MiddlewareCarShowroom(RequestDelegate _, IEnumerable<ACarShowroom> _CarShowrooms)
//    {
//        this.CarShowrooms = _CarShowrooms;
//        this.next = _;
//    }

//    public async Task InvokeAsync(HttpContext context)
//    {
//        foreach (var CarShowroom in CarShowrooms)
//        {

//        }
//        await this.next.Invoke(context);
//    }
//}