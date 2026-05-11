using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 1. Thêm cấu hình file ocelot.json
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// 2. Thêm dịch vụ Ocelot và OpenAPI (Swagger)
builder.Services.AddOpenApi();
builder.Services.AddOcelot();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 3. Kích hoạt Middleware Ocelot 
// Lưu ý: Phải đặt trước app.Run() và thường là ở cuối đường ống HTTP
await app.UseOcelot();

app.Run();