using BookingSystem;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); //tells ASP.NET that this application will use controllers as entry points
builder.Services.AddSwaggerGen();

// Register domain services
builder.Services.AddSingleton<BookingManager>();

var app = builder.Build();

app.MapControllers();//calling the controllers that will be used eventually

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();//will always be the last line of the program.cs class