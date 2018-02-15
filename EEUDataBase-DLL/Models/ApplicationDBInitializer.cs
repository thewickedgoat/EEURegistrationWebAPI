using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EEUDataBase_DLL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace EEUDataBase_DLL.Models
{
    public class ApplicationDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var role1 = new IdentityRole()
                {
                    Name = "Medarbejder"
                };
                var role2 = new IdentityRole()
                {
                    Name = "Afdelingsleder"
                };
                var role3 = new IdentityRole
                {
                    Name = "Administrator"
                };
                var role4 = new IdentityRole()
                {
                    Name = "Direktør"
                };

                roleManager.Create(role1);
                roleManager.Create(role2);
                roleManager.Create(role3);
                roleManager.Create(role4);
            }

            if (!context.Users.Any())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new ApplicationUserManager(userStore);

                var user = new ApplicationUser
                {
                    Email = "nbo@eeu.dk",
                    UserName = "Admin"
                };
                userManager.Create(user, "!Administrator1");
                userManager.AddToRole(user.Id, "Administrator");
                var user1 = new ApplicationUser
                {
                    Email = "tln@eeu.dk",
                    UserName = "tln"
                };
                userManager.Create(user1, "123456");
                userManager.AddToRole(user1.Id, "Direktør");
                var user2 = new ApplicationUser
                {
                    Email = "bbj@eeu.dk",
                    UserName = "bbj"
                };
                userManager.Create(user2, "123456");
                userManager.AddToRole(user2.Id, "Afdelingsleder");
                var user3 = new ApplicationUser
                {
                    Email = "kar@eeu.dk",
                    UserName = "kar"
                };
                userManager.Create(user3, "123456");
                userManager.AddToRole(user3.Id, "Afdelingsleder");
                var user4 = new ApplicationUser
                {
                    Email = "jms@visitribe.dk",
                    UserName = "jms"
                };
                userManager.Create(user4, "123456");
                userManager.AddToRole(user4.Id, "Afdelingsleder");
                var user5 = new ApplicationUser
                {
                    Email = "nbo@eeu1.dk",
                    UserName = "nbo"
                };
                userManager.Create(user5, "123456");
                userManager.AddToRole(user5.Id, "Medarbejder");
                var user6 = new ApplicationUser
                {
                    Email = "nob@eeu.dk",
                    UserName = "nob"
                };
                userManager.Create(user6, "123456");
                userManager.AddToRole(user6.Id, "Medarbejder");
                var user7 = new ApplicationUser
                {
                    Email = "skn@eeu.dk",
                    UserName = "skn"
                };
                userManager.Create(user7, "123456");
                userManager.AddToRole(user7.Id, "Medarbejder");
                var user8 = new ApplicationUser
                {
                    Email = "llc@eeu.dk",
                    UserName = "llc"
                };
                userManager.Create(user8, "123456");
                userManager.AddToRole(user8.Id, "Medarbejder");
                var user9 = new ApplicationUser
                {
                    Email = "mks@eeu.dk",
                    UserName = "mks"
                };
                userManager.Create(user9, "123456");
                userManager.AddToRole(user9.Id, "Medarbejder");
                var user10 = new ApplicationUser
                {
                    Email = "laj@eeu.dk",
                    UserName = "laj"
                };
                userManager.Create(user10, "123456");
                userManager.AddToRole(user10.Id, "Medarbejder");
                var user11 = new ApplicationUser
                {
                    Email = "mw@visitesbjerg.dk",
                    UserName = "mw"
                };
                userManager.Create(user11, "123456");
                userManager.AddToRole(user11.Id, "Medarbejder");
                var user12 = new ApplicationUser
                {
                    Email = "apo@esbjergfestuge.dk",
                    UserName = "apo"
                };
                userManager.Create(user12, "123456");
                userManager.AddToRole(user12.Id, "Medarbejder");
                var user13 = new ApplicationUser
                {
                    Email = "gla@eeu.dk",
                    UserName = "gla"
                };
                userManager.Create(user13, "123456");
                userManager.AddToRole(user13.Id, "Medarbejder");
                var user14 = new ApplicationUser
                {
                    Email = "ufl@eeu.dk",
                    UserName = "ufl"
                };
                userManager.Create(user14, "123456");
                userManager.AddToRole(user14.Id, "Medarbejder");
                var user15 = new ApplicationUser
                {
                    Email = "rah@eeu.dk",
                    UserName = "rah"
                };
                userManager.Create(user15, "123456");
                userManager.AddToRole(user15.Id, "Medarbejder");
                var user16 = new ApplicationUser
                {
                    Email = "gsy@eeu.dk",
                    UserName = "gsy"
                };
                userManager.Create(user16, "123456");
                userManager.AddToRole(user16.Id, "Medarbejder");
                var user17 = new ApplicationUser
                {
                    Email = "phe@eeu.dk",
                    UserName = "phe"
                };
                userManager.Create(user17, "123456");
                userManager.AddToRole(user17.Id, "Medarbejder");
                var user18 = new ApplicationUser
                {
                    Email = "efn@visitribe.dk",
                    UserName = "efn"
                };
                userManager.Create(user18, "123456");
                userManager.AddToRole(user18.Id, "Medarbejder");
                var user19 = new ApplicationUser
                {
                    Email = "kju@visitribe.dk",
                    UserName = "kju"
                };
                userManager.Create(user19, "123456");
                userManager.AddToRole(user19.Id, "Medarbejder");
                var user20 = new ApplicationUser
                {
                    Email = "sps@visitribe.dk",
                    UserName = "sps"
                };
                userManager.Create(user20, "123456");
                userManager.AddToRole(user20.Id, "Medarbejder");
                var user21 = new ApplicationUser
                {
                    Email = "rk@visitfanoe.dk",
                    UserName = "rk"
                };
                userManager.Create(user21, "123456");
                userManager.AddToRole(user21.Id, "Medarbejder");
                var user22 = new ApplicationUser
                {
                    Email = "pt@visitfanoe.dk",
                    UserName = "pt"
                };
                userManager.Create(user22, "123456");
                userManager.AddToRole(user22.Id, "Medarbejder");

            }

            Department fælles = new Department() { Id = 1, Name = "Fælles", Employees = new List<Employee>() };
            Department erhvervs = new Department() { Id = 2, Name = "Erhverv", Employees = new List<Employee>() };
            Department markerting = new Department() { Id = 3, Name = "Marketing", Employees = new List<Employee>() };
            Department turisme = new Department() { Id = 4, Name = "Turisme", Employees = new List<Employee>() };

            Month januar = new Month() { Id = 1, MonthDate = new DateTime(2018, 1, 1, 10, 0, 0), AbsencesInMonth = new List<Absence>(), Employee = new Employee(),
                IsLockedByEmployee = false, IsLockedByChief = false, IsLockedByCEO = false, IsLockedByAdmin = false };
            Month februar = new Month() { Id = 2, MonthDate = new DateTime(2018, 2, 1, 10, 0, 0), AbsencesInMonth = new List<Absence>(), Employee = new Employee(),
                IsLockedByEmployee = false, IsLockedByChief = false, IsLockedByCEO = false, IsLockedByAdmin = false };
            Month marts = new Month() { Id = 3, MonthDate = new DateTime(2018, 3, 1, 10, 0, 0), AbsencesInMonth = new List<Absence>(), Employee = new Employee(),
                IsLockedByEmployee = false, IsLockedByChief = false, IsLockedByCEO = false, IsLockedByAdmin = false };
            Month april = new Month() { Id = 4, MonthDate = new DateTime(2018, 4, 1, 10, 0, 0), AbsencesInMonth = new List<Absence>(), Employee = new Employee(),
                IsLockedByEmployee = false, IsLockedByChief = false, IsLockedByCEO = false, IsLockedByAdmin = false };
            Month maj = new Month() { Id = 5, MonthDate = new DateTime(2017, 5, 1, 10, 0, 0), AbsencesInMonth = new List<Absence>(), Employee = new Employee(),
                IsLockedByEmployee = false, IsLockedByChief = false, IsLockedByCEO = false, IsLockedByAdmin = false };
            Month juni = new Month() { Id = 6, MonthDate = new DateTime(2017, 6, 1, 10, 0, 0), AbsencesInMonth = new List<Absence>(), Employee = new Employee(),
                IsLockedByEmployee = false, IsLockedByChief = false, IsLockedByCEO = false, IsLockedByAdmin = false };
            Month juli = new Month() { Id = 7, MonthDate = new DateTime(2017, 7, 1, 10, 0, 0), AbsencesInMonth = new List<Absence>(), Employee = new Employee(),
                IsLockedByEmployee = false, IsLockedByChief = false, IsLockedByCEO = false, IsLockedByAdmin = false };
            Month august = new Month() { Id = 8, MonthDate = new DateTime(2017, 8, 1, 10, 0, 0), AbsencesInMonth = new List<Absence>(), Employee = new Employee(),
                IsLockedByEmployee = false, IsLockedByChief = false, IsLockedByCEO = false, IsLockedByAdmin = false };
            Month september = new Month() { Id = 9, MonthDate = new DateTime(2017, 9, 1, 10, 0, 0), AbsencesInMonth = new List<Absence>(), Employee = new Employee(),
                IsLockedByEmployee = false, IsLockedByChief = false, IsLockedByCEO = false, IsLockedByAdmin = false };
            Month oktober = new Month() { Id = 10, MonthDate = new DateTime(2017, 10, 1, 10, 0, 0), AbsencesInMonth = new List<Absence>(), Employee = new Employee(),
                IsLockedByEmployee = false, IsLockedByChief = false, IsLockedByCEO = false, IsLockedByAdmin = false };
            Month november = new Month() { Id = 11, MonthDate = new DateTime(2017, 11, 1, 10, 0, 0), AbsencesInMonth = new List<Absence>(), Employee = new Employee(),
                IsLockedByEmployee = false, IsLockedByChief = false, IsLockedByCEO = false, IsLockedByAdmin = false };
            Month december = new Month() { Id = 12, MonthDate = new DateTime(2017, 12, 1, 10, 0, 0), AbsencesInMonth = new List<Absence>(), Employee = new Employee(),
                IsLockedByEmployee = false, IsLockedByChief = false, IsLockedByCEO = false, IsLockedByAdmin = false };
            
            Status sygedag = new Status() { Id = 1, StatusCode = "S", StatusName = "Sygedag" };
            Status halvSygedag = new Status() { Id = 2, StatusCode = "HS", StatusName = "½ Sygedag" };
            Status feriedag = new Status() { Id = 3, StatusCode = "F", StatusName = "Feriedag" };
            Status halvFeriedag = new Status() { Id = 4, StatusCode = "HF", StatusName = "½ Feriedag" };
            Status ferieFridag = new Status() { Id = 5, StatusCode = "FF", StatusName = "Feriefridag" };
            Status halvFerieFridag = new Status() { Id = 6, StatusCode = "HFF", StatusName = "½ Feriefridag" };
            Status kursus = new Status() { Id = 7, StatusCode = "K", StatusName = "Kursus" };
            Status barsel = new Status() { Id = 8, StatusCode = "B", StatusName = "Barsel" };
            Status barnsFørsteSygedag = new Status() { Id = 9, StatusCode = "BS", StatusName = "Barn 1. sygedag" };
            Status andetFravær = new Status() { Id = 10, StatusCode = "AF", StatusName = "Andet fravær" };
            Status afspadsering = new Status() { Id = 11, StatusCode = "A", StatusName = "Afspadsering" };
            Status halvAfspadsering = new Status() { Id = 12, StatusCode = "HA", StatusName = "½ Afspadsering" };
            Status seniordag = new Status() { Id = 13, StatusCode = "SN", StatusName = "Seniordag" };
            Status GRAY = new Status() { Id = 14, StatusCode = "GRAY", StatusName = "GRAY" };

            Employee admin = new Employee()
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Admin",
                Email = "nbo@eeu.dk",
                EmployeeRole = Role.Administrator,
                HolidayYears = new List<HolidayYear>(),
                Password = "!Administrator1"
            };
            Employee chief1 = new Employee()
            {
                FirstName = "Tom",
                LastName = "L. Nielsen",
                UserName = "tln",
                Email = "tln@eeu.dk",
                Password = "123456",
                EmployeeRole = Role.Direktør,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee chief2 = new Employee()
            {
                FirstName = "Birgit",
                LastName = "B. Jensen",
                UserName = "bbj",
                Email = "bbj@eeu.dk",
                Password = "123456",
                EmployeeRole = Role.Afdelingsleder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee chief3 = new Employee()
            {
                FirstName = "Karsten",
                LastName = "Rieder",
                UserName = "kar",
                Email = "kar@eeu.dk",
                Password = "123456",
                EmployeeRole = Role.Afdelingsleder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee chief4 = new Employee()
            {
                FirstName = "Jane",
                LastName = "M. Søndergaard",
                UserName = "jms",
                Email = "jms@visitribe.dk",
                Password = "123456",
                EmployeeRole = Role.Afdelingsleder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee employee = new Employee()
            {
                FirstName = "Noah",
                LastName = "Bock",
                UserName = "nob",
                Email = "nob@eeu.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),
               
            };
            Employee employee1 = new Employee()
            {
                FirstName = "Niels",
                LastName = "Bock",
                UserName = "nbo",
                Email = "nbo@eeu.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),

            };
            Employee employee2 = new Employee()
            {
                FirstName = "Søs",
                LastName = "Josefsen",
                UserName = "skn",
                Email = "skn@eeu.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee employee3 = new Employee()
            {
                FirstName = "Mikael",
                LastName = "Simonsen",
                UserName = "mks",
                Email = "mks@eeu.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),

            };
            Employee employee4 = new Employee()
            {
                FirstName = "Gitte",
                LastName = "Sydbøge",
                UserName = "gsy",
                Email = "gsy@eeu.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee employee5 = new Employee()
            {
                FirstName = "Peter",
                LastName = "Hegelund",
                UserName = "phe",
                Email = "phe@eeu.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),

            };
            Employee employee6 = new Employee()
            {
                FirstName = "Gert",
                LastName = "Laustsen",
                UserName = "gla",
                Email = "gla@eeu.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),

            };
            Employee employee7 = new Employee()
            {
                FirstName = "Lasse",
                LastName = "Jensen",
                UserName = "laj",
                Email = "laj@eeu.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee employee8 = new Employee()
            {
                FirstName = "Uffe",
                LastName = "Lundgaard",
                UserName = "ufl",
                Email = "ufl@eeu.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee employee9 = new Employee()
            {
                FirstName = "Randi",
                LastName = "Høxbro",
                UserName = "rah",
                Email = "rah@eeu.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee employee10 = new Employee()
            {
                FirstName = "Lianna",
                LastName = "L. Chirstensen",
                UserName = "llc",
                Email = "llc@eeu.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee employee11 = new Employee()
            {
                FirstName = "Susanne",
                LastName = "P. Sørensen",
                UserName = "sps",
                Email = "sps@visitribe.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee employee12 = new Employee()
            {
                FirstName = "Katrine",
                LastName = "Jung",
                UserName = "kju",
                Email = "kju@visitribe.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee employee13 = new Employee()
            {
                FirstName = "Else",
                LastName = "F. Nielsen",
                UserName = "efn",
                Email = "efn@visitribe.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee employee14 = new Employee()
            {
                FirstName = "Marie",
                LastName = "warming",
                UserName = "mw",
                Email = "mw@visitesbjerg.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee employee15 = new Employee()
            {
                FirstName = "Annette",
                LastName = "Posselt",
                UserName = "apo",
                Email = "apo@esbjergfestuge.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee employee16 = new Employee()
            {
                FirstName = "Poul",
                LastName = "Therkelsen",
                UserName = "pt",
                Email = "pt@visitfanoe.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),
            };
            Employee employee17 = new Employee()
            {
                FirstName = "Ragnhild",
                LastName = "Kallehauge",
                UserName = "rk",
                Email = "rk@visitfanoe.dk",
                Password = "123456",
                EmployeeRole = Role.Medarbejder,
                HolidayYears = new List<HolidayYear>(),
            };

            januar.Employee = employee;
            februar.Employee = employee;
            marts.Employee = employee;
            april.Employee = employee;
            maj.Employee = employee;
            juni.Employee = employee;
            juli.Employee = employee;
            august.Employee = employee;
            september.Employee = employee;
            oktober.Employee = employee;
            november.Employee = employee;
            december.Employee = employee;

            List<Month> months = new List<Month>();
            months.Add(januar);
            months.Add(februar);
            months.Add(marts);
            months.Add(april);
            months.Add(maj);
            months.Add(juni);
            months.Add(juli);
            months.Add(august);
            months.Add(september);
            months.Add(oktober);
            months.Add(november);
            months.Add(december);

            HolidayYear holidayYear = new HolidayYear()
            {
                Id = 1,
                Name = "2017-2018",
                StartDate = new DateTime(2017, 4, 1),
                EndDate = new DateTime(2018, 3, 30),
                Months = months,
                Employee = employee,
                IsClosed = false,
                HolidayAvailable = 25,
                HolidayFreedayAvailable = 5,
                RemainingHoliday = 25,
                RemainingHolidayFreedays = 5
            };

            List<HolidayYear> holidayYears = new List<HolidayYear>();
            holidayYears.Add(holidayYear);

            employee.HolidayYears = holidayYears;

            admin.Department = fælles;
            chief1.Department = fælles;
            chief2.Department = markerting;
            chief3.Department = erhvervs;
            chief4.Department = turisme;

            employee.Department = fælles;
            employee1.Department = fælles;
            employee2.Department = fælles;
            employee3.Department = fælles;
            employee10.Department = fælles;

            employee7.Department = markerting;

            employee4.Department = erhvervs;
            employee5.Department = erhvervs;
            employee6.Department = erhvervs;
            employee8.Department = erhvervs;
            employee9.Department = erhvervs;

            employee11.Department = turisme;
            employee12.Department = turisme;
            employee13.Department = turisme;
            employee14.Department = turisme;
            employee15.Department = turisme;
            employee16.Department = turisme;
            employee17.Department = turisme;

            context.Employees.Add(admin);
            context.Employees.Add(chief1);
            context.Employees.Add(chief2);
            context.Employees.Add(chief3);
            context.Employees.Add(chief4);
            context.Employees.Add(employee);
            context.Employees.Add(employee1);
            context.Employees.Add(employee2);
            context.Employees.Add(employee3);
            context.Employees.Add(employee4);
            context.Employees.Add(employee5);
            context.Employees.Add(employee6);
            context.Employees.Add(employee7);
            context.Employees.Add(employee8);
            context.Employees.Add(employee9);
            context.Employees.Add(employee10);
            context.Employees.Add(employee11);
            context.Employees.Add(employee12);
            context.Employees.Add(employee13);
            context.Employees.Add(employee14);
            context.Employees.Add(employee15);
            context.Employees.Add(employee16);
            context.Employees.Add(employee17);

            context.Statuses.Add(sygedag);
            context.Statuses.Add(halvSygedag);
            context.Statuses.Add(feriedag);
            context.Statuses.Add(halvFeriedag);
            context.Statuses.Add(ferieFridag);
            context.Statuses.Add(halvFeriedag);
            context.Statuses.Add(kursus);
            context.Statuses.Add(barsel);
            context.Statuses.Add(barnsFørsteSygedag);
            context.Statuses.Add(andetFravær);
            context.Statuses.Add(afspadsering);
            context.Statuses.Add(halvAfspadsering);
            context.Statuses.Add(seniordag);
            context.Statuses.Add(GRAY);

            base.Seed(context);
        }
    }
}
