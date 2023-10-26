using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MeetHubDB : DbContext
    {
        public MeetHubDB()
        {

        }
        public MeetHubDB(DbContextOptions options) : base(options)
        {

        }

        public static object Nullable(object value)
        {
            if (value is null)
                return DBNull.Value;
            else
                return value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-9I3O269\\MSSQLSERVER03;database=MeetingHUB;trusted_connection=true;TrustServerCertificate=true;");
                base.OnConfiguring(optionsBuilder);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLoginResult>().HasNoKey();
            modelBuilder.Entity<UserRegisterResult>().HasNoKey(); 
            modelBuilder.Entity<GetMeetingResult>().HasNoKey();
            modelBuilder.Entity<UserInfoResult>().HasNoKey();
        }


        //DB SET
        public DbSet<UserLoginResult> UserLoginResults { get; set; }
        public DbSet<UserRegisterResult> UserRegisterResults { get; set; }
        public DbSet<GetMeetingResult> GetMeetingResults { get; set; }
        public DbSet<UserInfoResult> GetUserInfoResults { get; set; }
         
    }
}
