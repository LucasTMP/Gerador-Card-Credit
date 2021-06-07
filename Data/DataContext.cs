using Microsoft.EntityFrameworkCore;
using testecore.Models;

namespace testecore.Data{

    public class DataContext : DbContext{

        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {

        }

        public DbSet<Cartoes_credito_digital> Cards {get; set;}

        public DbSet<Pessoas> Pessoa {get; set;}

    

    }

}
