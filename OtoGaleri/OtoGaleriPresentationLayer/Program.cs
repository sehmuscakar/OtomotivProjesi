using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using PresentationLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.MyconfigureServices();//extensions klas�rdeki i�in
builder.Services.AddDbContext<ProjeContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ProjeContext>();//hangi tablolar� �zele�tirmi�sen onlar� buraya tan�man laz�m �dentitye ile sisteme
builder.Services.AddMvc(config =>//bu t�m sistemi kilitliyor kimlik do�rulama oladan a��lmaz eri�ilemez
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => //otonatike olmayan k�sm� buraya yunlendirecek bunu yapmadan da  [AllowAnonymous] bu kodu controllera yazarak ta yapabilirsin 
{
    x.LoginPath = "/Admin/Login/Sign�n";
});
var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}
app.UseStatusCodePagesWithReExecute("/Admin/Login/Error404", "?code={0}");//bu url e gidecek metot i�indeki paremtre code olmal� kesin ��nk� burda oyle yapt�k paretre ayn� olmas� laz�m 

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();//loginin otantike i�lemi i�in kullanacaz. buna gerek kalmadan otoantikee i�lemi oluyor
app.UseAuthorization();


app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Anasayfa}/{id?}");

app.Run();
