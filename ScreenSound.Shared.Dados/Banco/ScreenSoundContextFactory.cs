using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ScreenSound.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Dados.Banco;

// ScreenSoundContextFactory.cs


    public class ScreenSoundContextFactory : IDesignTimeDbContextFactory<ScreenSoundContext>
    {
        public ScreenSoundContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ScreenSoundContext>();

            // Substitua pela sua connection string
            optionsBuilder.UseSqlServer("Server=tcp:screensoundserver2.database.windows.net,1433;Initial Catalog=screensoundV0;Persist Security Info=False;User ID=taboada;Password=Malaka312@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        //"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"

            return new ScreenSoundContext(optionsBuilder.Options);
        }
    }

