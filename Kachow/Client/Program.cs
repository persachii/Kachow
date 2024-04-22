using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Kachow.Client;
using Blazorise;
using Blazorise.Bootstrap5;
using Kachow.Client.Services.ParcelService;
using Kachow.Client.Services.UserService;
using Kachow.Client.Services.ParcelNameService;
using Kachow.Client.Services.DeliveryStatusService;
using Kachow.Client.Services.DeliveryMethodService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers();

builder.Services.AddScoped<IParcelService, ParcelService>();
builder.Services.AddScoped<IParcelNameService, ParcelNameService>();
builder.Services.AddScoped<IDeliveryStatusService, DeliveryStatusService>();
builder.Services.AddScoped<IDeliveryMethodService, DeliveryMethodService>();
builder.Services.AddScoped<IUserService, UserService>();

await builder.Build().RunAsync();

