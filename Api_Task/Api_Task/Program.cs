using ApiTask.core.Repositories;
using ApiTask.Data;
using ApiTask.Data.Repositories;
using ApiTask.Service.Dtos.GroupDtos;
using ApiTask.Service.Exceptions;
using ApiTask.Service.Implementations;
using ApiTask.Service.Interfaces;
using ApiTask.Service.Profiles;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Api_Task.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(opt =>
{


    opt.InvalidModelStateResponseFactory = context =>
    {

        var errors = context.ModelState.Where(x => x.Value.Errors.Count() > 0)

        .Select(x => new RestExceptionsErrorItem(x.Key,x.Value.Errors.First().ErrorMessage)).ToList();
        return new BadRequestObjectResult(new { message = (string)null, errors = errors });

    };

});




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationRulesToSwagger();

builder.Services.AddDbContext<StudentDbContext>(opt =>
{

    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IGroupRepository,GroupRepositories>();
builder.Services.AddScoped<IStudentRepository, StudentRepositories>();
builder.Services.AddScoped<IGroupServices, GroupServices>();
builder.Services.AddScoped<IStudentServices, StudentService>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<GroupCreatDtoValidator>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped(provider =>


    new MapperConfiguration(opt =>
    {

        opt.AddProfile(new MappingProfile(provider.GetService<IHttpContextAccessor>()));
    }).CreateMapper());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();
