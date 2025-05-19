using Microsoft.EntityFrameworkCore;
using restApiAnkiety;
using restApiAnkiety.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=ankieta.db"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// w Program.cs dodaj tymczasowo przed app.Run()
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Forms.Any())
    {
        var form1 = new Form
        {
            Question = "Czy odpowiada Ci taka forma kursu?",
            Options = new List<Option>
            {
                new Option { Description = "Tak" },
                new Option { Description = "Nie" }
            }
        };

        var form2 = new Form
        {
            Question = "Czy dwie lekcje tygodniowo to:",
            Options = new List<Option>
            {
                new Option { Description = "Za du¿o" },
                new Option { Description = "Za ma³o" },
                new Option { Description = "W sam raz" }
            }
        };

        var form3 = new Form
        {
            Question = "Jak¹ tematyk¹ by³byœ zainteresowany?",
            Options = new List<Option>
            {
                new Option { Description = "Biznes" },
                new Option { Description = "Rozmowa o pracê" },
                new Option { Description = "Wakacje" },
                new Option { Description = "Œwiêta Wielkanocne" },
                new Option { Description = "Internet" },
                new Option { Description = "Inn¹, jak¹?" }
            }
        };

        db.Forms.AddRange(form1, form2, form3);
        db.SaveChanges();
    }
}


app.Run();
