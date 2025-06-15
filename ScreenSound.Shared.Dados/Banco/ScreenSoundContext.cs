using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
public class ScreenSoundContext: DbContext
{
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }

    private string connectionString = "Server=tcp:screensoundserver2.database.windows.net,1433;Initial Catalog=screensoundV0;Persist Security Info=False;User ID=taboada;Password=Malaka312@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    //"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"

    public ScreenSoundContext(DbContextOptions options) : base(options)
    {

    }
    public ScreenSoundContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Musica>()
            .HasMany(c => c.Generos)
            .WithMany(c => c.Musicas);

        // Relacionamento: Um Artista tem muitas Músicas, uma Música tem um Artista
        modelBuilder.Entity<Musica>()
            .HasOne(m => m.Artista)
            .WithMany(a => a.Musicas)
            .HasForeignKey(m => m.ArtistaId)
            .OnDelete(DeleteBehavior.SetNull); // ou .OnDelete(DeleteBehavior.Restrict) conforme sua regra de negócio
    }

    
}
