using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP_.Context;
using COMP_.UOW;
using COMP_.UOW.Interface;
using Microsoft.EntityFrameworkCore;

namespace COMP.UnitTest.XunitTests
{
    public class UsersTestController
    {
        public IUnitOfWork UOW;
        public static DbContextOptions<PostgreeContext> DbContextOptions { get; }
        public static string connectionString = "server=localhost;database=CompPlus;Port=5432; User Id=xxwelldone; password=123456;";
        static UsersTestController()
        {
            DbContextOptions = new DbContextOptionsBuilder<PostgreeContext>().UseNpgsql(connectionString).Options;
        }
        public UsersTestController()
        {
            var context = new PostgreeContext(DbContextOptions);
            UOW = new UnitOfWork(context);
        }

    }
}
