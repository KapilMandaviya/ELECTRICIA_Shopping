using DataAccessLayer.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.IRepo;
using RepositoryLayer.Repo;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//uncomment below ling for testing in mobile with same network 
//builder.WebHost.UseUrls("http://192.168.0.115:7278"); // Bind to all interfaces, use HTTP for simplicity
//builder.WebHost.UseUrls("http://localhost:7278");
        builder.Services.AddCors(options => options.AddPolicy(name: "EmployeeOrigins",
        policy =>    
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            // policy.WithOrigins("http://192.168.0.115:4200").AllowAnyMethod().AllowAnyHeader();
        }));

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x => {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JaiShreeKrishnaThisIsA256BitKey!!!!!!!..")),
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.Zero
                
            };
        });
// Add services to the container.
// Configure the DbContext with the connection string
    builder.Services.AddDbContext<ELECTRICIADBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add repositories and other services
builder.Services.AddScoped<IAuthenticRepo, AuthenticRepo>(); // Example repository
builder.Services.AddScoped<IAboutUsDetail,AboutUsRepo>(); // Example repository
builder.Services.AddScoped<IBlogServices,BlogServices>(); // Example repository
builder.Services.AddScoped<ICategoryDetailService,CategoryDetailService>(); // Example repository
builder.Services.AddScoped<IProductServiceDetails,ProductServiceDetails>(); // Example repository
builder.Services.AddScoped<ICartWishList,CartWishListService>(); // Example repository
builder.Services.AddScoped<IHomeRepo,HomeRepo>(); // Example repository


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSession();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) // TEMP
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("EmployeeOrigins");
app.Use(async (context, next) =>
{
    context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
    context.Response.Headers["Pragma"] = "no-cache";
    context.Response.Headers["Expires"] = "-1";
    await next();
});
app.UseRouting();

app.UseAuthentication();

//comment below ling for testing in mobile with same network 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
