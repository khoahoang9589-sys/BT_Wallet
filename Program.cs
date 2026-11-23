using BT_Wallet.Services;

var builder = WebApplication.CreateBuilder(args);

// Cho phép dotnet run phục vụ asset framework Blazor khi chạy local.
builder.WebHost.UseStaticWebAssets();

// Chỉ ghi log ra console để ứng dụng không phụ thuộc quyền EventLog của Windows.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Blazor Server và các trang Razor của ứng dụng.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Mỗi người dùng có một ví riêng trong phiên làm việc hiện tại.
builder.Services.AddScoped<WalletStateService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapStaticAssets();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
