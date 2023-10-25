using Business;
using DataAccess;
using DataAccess.Providers;
using DataAccess.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);





// Add services to the container.


//DataAccess Layer
builder.Services.AddScoped<IUserDataAccessService, UserDataAccessProvider>();
builder.Services.AddScoped<IMeetingDataAccessService, MeetingDataAccessProvider>();


//Business Layer
builder.Services.AddScoped<IAuthenticationService, AuthenticationManager>();
builder.Services.AddScoped<IMeetingService,MeetingManager>();
builder.Services.AddScoped<IUploadService, UploadManager>();


//Singleton
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



var key = Encoding.UTF8.GetBytes(builder.Configuration["ApplicationSettings:JwT:Secret"].ToString());
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["ApplicationSettings:JwT:ValidIssuer"]
    };
});


builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy( policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});



builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "MyMeetingHubAPI";
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyMeetingHubAPI");
    });
}

app.UseHttpsRedirection();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
