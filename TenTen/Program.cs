using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TenTenApp;
using TenTenApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// 서비스 등록
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<ITenTenService, TenTenService>();

await builder.Build().RunAsync();
