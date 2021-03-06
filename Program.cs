using Microsoft.EntityFrameworkCore;
using tropsly_api.Data;
using tropsly_api.Repository;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using tropsly_api.Model;
using tropsly_api.Repository.Category;
using tropsly_api.Repository.ProductOrderRepo;
using Amazon.S3;
using Amazon;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());
builder.Services.AddTransient(typeof(ICrudRepository<>), typeof(CrudRepository<>)); ;
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderedProductRepository, OrderedProductRepository>();
builder.Services.AddScoped<ICustomerPersonalDataRepository, CustomerPersonalDataRepository>();
builder.Services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IDeliveryOptionRepository, DeliveryOptionRepository>();
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
//builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddSingleton<IAmazonS3>(p => {
    var config = new AmazonS3Config
    {
        RegionEndpoint = RegionEndpoint.EUWest2,
        ServiceURL= "http://localhost:4566",
        ForcePathStyle = true,
};
    return new AmazonS3Client("test", "test", config);
});
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
