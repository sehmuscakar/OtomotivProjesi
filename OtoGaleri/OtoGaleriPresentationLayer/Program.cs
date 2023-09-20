using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using PresentationLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.MyconfigureServices();//extensions klasördeki için
builder.Services.AddDbContext<ProjeContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ProjeContext>();//hangi tablolarý özeleþtirmiþsen onlarý buraya tanýman lazým ýdentitye ile sisteme
builder.Services.AddMvc(config =>//bu tüm sistemi kilitliyor kimlik doðrulama oladan açýlmaz eriþilemez
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => //otonatike olmayan kýsmý buraya yunlendirecek bunu yapmadan da  [AllowAnonymous] bu kodu controllera yazarak ta yapabilirsin 
{
    x.LoginPath = "/Admin/Login/SignÝn";
});
var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}
app.UseStatusCodePagesWithReExecute("/Admin/Login/Error404", "?code={0}");//bu url e gidecek metot içindeki paremtre code olmalý kesin çünkü burda oyle yaptýk paretre ayný olmasý lazým 

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();//loginin otantike iþlemi için kullanacaz. buna gerek kalmadan otoantikee iþlemi oluyor
app.UseAuthorization();


app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Anasayfa}/{id?}");

app.Run();
