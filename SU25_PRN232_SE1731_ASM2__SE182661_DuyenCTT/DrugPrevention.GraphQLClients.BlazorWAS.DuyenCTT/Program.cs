using DrugPrevention.GraphQLClients.BlazorWAS.DuyenCTT;
using DrugPrevention.GraphQLClients.BlazorWAS.DuyenCTT.GraphQLClients;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IGraphQLClient>(c => new GraphQLHttpClient(builder.Configuration["GraphQLURI"], new NewtonsoftJsonSerializer()));
Console.WriteLine("GraphQL URI: " + builder.Configuration["GraphQLURI"]);
builder.Services.AddScoped<GraphQLConsumer>();

await builder.Build().RunAsync();
