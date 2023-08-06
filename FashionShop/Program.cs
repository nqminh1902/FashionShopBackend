using FashionShopBL;
using FashionShopBL.BaseBL;
using FashionShopBL.ProductBL;
using FashionShopBL.ProductColorBL;
using FashionShopBL.ProductImageBL;
using FashionShopBL.ProductSizeBL;
using FashionShopBL.ProductVariantBL;
using FashionShopDL;
using FashionShopDL.BaseDL;
using FashionShopDL.ProductColorDL;
using FashionShopDL.ProductDL;
using FashionShopDL.ProductImageDL;
using FashionShopDL.ProductSizeDL;
using FashionShopDL.ProductVariantDL;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped<IProductDL, ProductDL>();
builder.Services.AddScoped<IProductBL, ProductBL>();
builder.Services.AddScoped<IProductColorDL, ProductColorDL>();
builder.Services.AddScoped<IProductColorBL, ProductColorBL>();
builder.Services.AddScoped<IProductSizeDL, ProductSizeDL>();
builder.Services.AddScoped<IProductSizeBL, ProductSizeBL>();
builder.Services.AddScoped<IProductImageDL, ProductImageDL>();
builder.Services.AddScoped<IProductImageBL, ProductImageBL>();
builder.Services.AddScoped<IProductVariantDL, ProductVariantDL>();
builder.Services.AddScoped<IProductVariantBL, ProductVariantBL>();

// Lấy dữ liệu từ connectionString từ file appsetting.Development.json
DatabaseContext.ConnectionString = builder.Configuration.GetConnectionString("MySQL");

// Fix lỗi cors
builder.Services.AddCors();

// Chặn ErrorMessage mặc định của visualStudio
builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
