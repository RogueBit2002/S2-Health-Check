using HetBetereGroepje.HealthCheck.Factory;
using HetBetereGroepje.HealthCheck.ILogic;

ServiceFactory.Init();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddScoped<IManagerService>(provider => ServiceFactory.Create<IManagerService>());
builder.Services.AddScoped<IHealthCheckService>(provider => ServiceFactory.Create<IHealthCheckService>());
builder.Services.AddScoped<IResponseService>(provider => ServiceFactory.Create<IResponseService>());
builder.Services.AddScoped<ITemplateService>(provider => ServiceFactory.Create<ITemplateService>());
builder.Services.AddScoped<IQuestionService>(provider => ServiceFactory.Create<IQuestionService>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();