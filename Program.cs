using Microsoft.EntityFrameworkCore;
using tropsly_api.Data;
using tropsly_api.Repository;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using tropsly_api.Model;
using tropsly_api.Repository.Category;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());
//builder.Services.AddTransient(typeof(ICrudDataContext<Product>), typeof(CrudDataContext<Product>)); ;
//builder.Services.AddTransient(typeof(ICrudRepository<>), typeof(CrudRepository<>)); ;
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IDeliveryOptionRepository, DeliveryOptionRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICommentSectionRepository, CommentSectionRepository>();
builder.Services.AddScoped<IRatingDataRepository, RatingDataRepository>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(c =>
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
);
/*builder.Services.AddAuthentication("BasicAuthenticationHandler")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthenticationHandler", null);*/
var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
