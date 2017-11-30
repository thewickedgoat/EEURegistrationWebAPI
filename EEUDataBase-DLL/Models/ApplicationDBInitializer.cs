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

                roleManager.Create(role1);
                roleManager.Create(role2);
                roleManager.Create(role3);
            }

            if (!context.Users.Any())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new ApplicationUserManager(userStore);

                var user = new ApplicationUser
                {
                    Email = "nbo@eeu1.dk",
                    UserName = "Admin"
                };
                userManager.Create(user, "!Administrator1");
                userManager.AddToRole(user.Id, "Administrator");
            }

            Department readOnlyDepartment = new Department()
            {
                Id = 1,
                Name = $"Utildelte Medarbejdere",
                Employees = new List<Employee>()
            };
            context.Departments.Add(readOnlyDepartment);

            Department fælles = new Department() { Id = 2, Name = "Fælles", Employees = new List<Employee>() };
            Department erhvervs = new Department() { Id = 3, Name = "Erhverv", Employees = new List<Employee> () };
            Department markerting = new Department() { Id = 4, Name = "Marketing", Employees = new List<Employee>() };

            Employee admin = new Employee()
            {
                FirstName = "Niels",
                LastName = "Bock",
                UserName = "Admin",
                Email = "nbo@eeu1.dk",
                EmployeeRole = Role.Administrator,
                Absences = new List<Absence>(),
                Password = "!Administrator1"
            };
            Employee chief1 = new Employee()
            {
                FirstName = "Tom",
                LastName = "Lykkegaard Nielsen",
                UserName = "tln",
                Email = "tln@eeu1.dk",
                EmployeeRole = Role.Afdelingsleder,
                Absences = new List<Absence>()

            };
            Employee chief2 = new Employee()
            {
                FirstName = "Birgit",
                LastName = "Bech Jensen",
                UserName = "bbj",
                Email = "bbj@eeu1.dk",
                EmployeeRole = Role.Afdelingsleder,
                Absences = new List<Absence>()
            };
            Employee chief3 = new Employee()
            {
                FirstName = "Karsten",
                LastName = "Rieder",
                UserName = "kar",
                Email = "kar@eeu1.dk",
                EmployeeRole = Role.Afdelingsleder,
                Absences = new List<Absence>()
            };
            Employee employee = new Employee()
            {
                FirstName = "Noah",
                LastName = "Bock",
                UserName = "nob",
                Email = "nob@eeu1.dk",
                EmployeeRole = Role.Medarbejder,
                Absences = new List<Absence>()
            };
            Employee employee2 = new Employee()
            {
                FirstName = "Søs",
                LastName = "Knudsen",
                UserName = "skn",
                Email = "mks@eeu1.dk",
                EmployeeRole = Role.Medarbejder,
                Absences = new List<Absence>()
            };
            Employee employee3 = new Employee()
            {
                FirstName = "Mikael",
                LastName = "Simonsen",
                UserName = "mks",
                Email = "mks@eeu1.dk",
                EmployeeRole = Role.Medarbejder,
                Absences = new List<Absence>()
            };
            Employee employee4 = new Employee()
            {
                FirstName = "Gitte",
                LastName = "Sydbøge",
                UserName = "gsy",
                Email = "gsy@eeu1.dk",
                EmployeeRole = Role.Medarbejder,
                Absences = new List<Absence>()
            };
            Employee employee5 = new Employee()
            {
                FirstName = "Peter",
                LastName = "Hegelund",
                UserName = "phe",
                Email = "phe@eeu1.dk",
                EmployeeRole = Role.Medarbejder,
                Absences = new List<Absence>()
            };
            Employee employee6 = new Employee()
            {
                FirstName = "Gert",
                LastName = "Laustsen",
                UserName = "gla",
                Email = "gla@eeu1.dk",
                EmployeeRole = Role.Medarbejder,
                Absences = new List<Absence>()
            };
            Employee employee7 = new Employee()
            {
                FirstName = "Lasse",
                LastName = "Jensen",
                UserName = "laj",
                Email = "laj@eeu1.dk",
                EmployeeRole = Role.Medarbejder,
                Absences = new List<Absence>()
            };
            Employee employee8 = new Employee()
            {
                FirstName = "Uffe",
                LastName = "Lundgaard",
                UserName = "ufl",
                Email = "ufl@eeu1.dk",
                EmployeeRole = Role.Medarbejder,
                Absences = new List<Absence>()
            };
            Employee employee9 = new Employee()
            {
                FirstName = "Randi",
                LastName = "Høxbro",
                UserName = "rah",
                Email = "rah@eeu1.dk",
                EmployeeRole = Role.Medarbejder,
                Absences = new List<Absence>()
            };       
            Employee employee10 = new Employee()
            {
                FirstName = "Kirsten",
                LastName = "Rasmussen",
                UserName = "kra",
                Email = "kra@eeu1.dk",
                EmployeeRole = Role.Medarbejder,
                Absences = new List<Absence>()
            };

            Absence a = new Absence() { Employee = employee, Date = DateTime.Today.AddDays(10), Status = Status.FF };
            Absence a2 = new Absence() { Employee = employee, Date = DateTime.Today.AddDays(5), Status = Status.FF };
            Absence a3 = new Absence() { Employee = employee, Date = DateTime.Today.AddDays(2), Status = Status.B };
            Absence a4 = new Absence() { Employee = employee, Date = DateTime.Today.AddDays(6), Status = Status.SN };

            Absence a5 = new Absence() { Employee = employee2, Date = DateTime.Today.AddDays(4), Status = Status.S };
            Absence a6 = new Absence() { Employee = employee2, Date = DateTime.Today.AddDays(11), Status = Status.S };
            Absence a7 = new Absence() { Employee = employee2, Date = DateTime.Today.AddDays(9), Status = Status.HA };
            Absence a8 = new Absence() { Employee = employee2, Date = DateTime.Today.AddDays(3), Status = Status.HA };

            Absence a9 = new Absence() { Employee = employee3, Date = DateTime.Today.AddDays(12), Status = Status.A };
            Absence a10 = new Absence() { Employee = employee3, Date = DateTime.Today.AddDays(5), Status = Status.A };
            Absence a11 = new Absence() { Employee = employee3, Date = DateTime.Today.AddDays(9), Status = Status.F };
            Absence a12 = new Absence() { Employee = employee3, Date = DateTime.Today.AddDays(0), Status = Status.F };

            Absence a13 = new Absence() { Employee = employee4, Date = DateTime.Today.AddDays(7), Status = Status.F };
            Absence a14 = new Absence() { Employee = employee4, Date = DateTime.Today.AddDays(2), Status = Status.F };
            Absence a15 = new Absence() { Employee = employee4, Date = DateTime.Today.AddDays(12), Status = Status.S };
            Absence a16 = new Absence() { Employee = employee4, Date = DateTime.Today.AddDays(8), Status = Status.S };

            Absence a17 = new Absence() { Employee = employee5, Date = DateTime.Today.AddDays(-7), Status = Status.A };
            Absence a18 = new Absence() { Employee = employee5, Date = DateTime.Today.AddDays(-14), Status = Status.A };
            Absence a19 = new Absence() { Employee = employee5, Date = DateTime.Today.AddDays(0), Status = Status.SN };
            Absence a20 = new Absence() { Employee = employee5, Date = DateTime.Today.AddDays(-21), Status = Status.HA };
            Absence a21 = new Absence() { Employee = employee5, Date = DateTime.Today.AddDays(-28), Status = Status.FF };

            Absence a22 = new Absence() { Employee = employee6, Date = DateTime.Today.AddDays(8), Status = Status.FF };
            Absence a23 = new Absence() { Employee = employee6, Date = DateTime.Today.AddDays(3), Status = Status.FF };
            Absence a24 = new Absence() { Employee = employee6, Date = DateTime.Today.AddDays(6), Status = Status.FF };

            Absence a25 = new Absence() { Employee = employee7, Date = DateTime.Today.AddDays(1), Status = Status.F };
            Absence a26 = new Absence() { Employee = employee7, Date = DateTime.Today.AddDays(2), Status = Status.HFF };
            Absence a27 = new Absence() { Employee = employee7, Date = DateTime.Today.AddDays(8), Status = Status.AF };
            Absence a28 = new Absence() { Employee = employee7, Date = DateTime.Today.AddDays(4), Status = Status.F };

            Absence a29 = new Absence() { Employee = employee8, Date = DateTime.Today.AddDays(1), Status = Status.FF };
            Absence a30 = new Absence() { Employee = employee8, Date = DateTime.Today.AddDays(3), Status = Status.S };
            Absence a31 = new Absence() { Employee = employee8, Date = DateTime.Today.AddDays(8), Status = Status.HFF };
            Absence a32 = new Absence() { Employee = employee8, Date = DateTime.Today.AddDays(4), Status = Status.F };

            Absence a33 = new Absence() { Employee = employee9, Date = DateTime.Today.AddDays(1), Status = Status.B };
            Absence a34 = new Absence() { Employee = employee9, Date = DateTime.Today.AddDays(9), Status = Status.SN };
            Absence a35 = new Absence() { Employee = employee9, Date = DateTime.Today.AddDays(3), Status = Status.HA };
            Absence a36 = new Absence() { Employee = employee9, Date = DateTime.Today.AddDays(4), Status = Status.K };

            admin.Department = fælles;
            chief1.Department = fælles;
            chief2.Department = erhvervs;
            chief3.Department = markerting;

            employee.Department = erhvervs;
            employee2.Department = erhvervs;
            employee3.Department = erhvervs;
            employee4.Department = erhvervs;

            employee5.Department = fælles;
            employee6.Department = fælles;
            employee7.Department = fælles;
            employee8.Department = fælles;

            employee9.Department = markerting;
            employee10.Department = markerting;

            employee.Absences.Add(a);
            employee.Absences.Add(a2);
            employee.Absences.Add(a3);
            employee.Absences.Add(a4);

            employee2.Absences.Add(a5);
            employee2.Absences.Add(a6);
            employee2.Absences.Add(a7);
            employee2.Absences.Add(a8);

            employee3.Absences.Add(a9);
            employee3.Absences.Add(a10);
            employee3.Absences.Add(a11);
            employee3.Absences.Add(a12);

            employee4.Absences.Add(a13);
            employee4.Absences.Add(a14);
            employee4.Absences.Add(a15);
            employee4.Absences.Add(a16);

            employee5.Absences.Add(a17);
            employee5.Absences.Add(a18);
            employee5.Absences.Add(a19);
            employee5.Absences.Add(a20);
            employee5.Absences.Add(a21);

            employee6.Absences.Add(a22);
            employee6.Absences.Add(a23);
            employee6.Absences.Add(a24);

            employee7.Absences.Add(a25);
            employee7.Absences.Add(a26);
            employee7.Absences.Add(a27);
            employee7.Absences.Add(a28);

            employee8.Absences.Add(a29);
            employee8.Absences.Add(a30);
            employee8.Absences.Add(a31);
            employee8.Absences.Add(a32);

            employee9.Absences.Add(a33);
            employee9.Absences.Add(a34);
            employee9.Absences.Add(a35);
            employee9.Absences.Add(a36);

            context.Employees.Add(admin);
            context.Employees.Add(chief1);
            context.Employees.Add(chief2);
            context.Employees.Add(chief3);
            context.Employees.Add(employee);
            context.Employees.Add(employee2);
            context.Employees.Add(employee3);
            context.Employees.Add(employee4);
            context.Employees.Add(employee5);
            context.Employees.Add(employee6);
            context.Employees.Add(employee7);
            context.Employees.Add(employee8);
            context.Employees.Add(employee9);
            context.Employees.Add(employee10);
        
            base.Seed(context);
        }
    }
}
