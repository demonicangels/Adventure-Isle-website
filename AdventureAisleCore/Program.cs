using Microsoft.AspNetCore.Authentication.Cookies;
using BusinessLogic;
using DAL;
using BusinessLogic.Interfaces; 


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<DestinationService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<TravelListService>();
builder.Services.AddScoped<CalculationService>();
builder.Services.AddScoped<RecommendationsService>();


builder.Services.AddTransient<IUserRepository>((sp) =>
{
    return new UserRepository();
});

builder.Services.AddTransient<IDestinationRepository>((sp) =>
{
	return new DestinationRepository();
});

builder.Services.AddTransient<IReviewRepository>((sp) =>
{
	return new ReviewRepository();
});

builder.Services.AddTransient<ITravelListRepository>((sp) =>
{
   return new TravelListRepository();
});
builder.Services.AddTransient<ICalculationsRepository>((sp) =>
{
    return new CalculationsRepo();
});
builder.Services.AddTransient<IRecommendationsRepository>((sp) =>
{
    return new RecommendationsRepo();
});






// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.AccessDeniedPath = "/Error";
    });

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(120);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
}
);

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

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
