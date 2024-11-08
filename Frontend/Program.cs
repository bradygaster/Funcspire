using Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<FunctionHttpClient>(client =>
{
    client.BaseAddress = new("https+http://functions");
});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


// http client for the function
public class FunctionHttpClient(HttpClient httpClient)
{
    public async Task<string> GetWelcomeFromFunctions()
    {
        return await httpClient.GetStringAsync("/api/helloworld");
    }
}