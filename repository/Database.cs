namespace pastanova.Database
{
    using Microsoft.EntityFrameworkCore;

    public class Contexto : DbContext
    {
         private string _connectionString = "Server=localhost;User Id=root;pwd=pamela;Database=usuario;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));


        public DbSet<Model.Automovel>? Automoveis { get; set; }


    }
}