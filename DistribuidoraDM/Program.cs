
class Program
{
    public static string connectionString { get; private set; }
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        connectionString = builder.Configuration.GetConnectionString("DistribuidoraDelMal");

        // Add services to the container.
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin",
                builder => builder.AllowAnyOrigin()
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("AllowAnyOrigin");
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        //DataProduct   = new DataProduct(app.Configuration); 

        app.Run();

    }

}
