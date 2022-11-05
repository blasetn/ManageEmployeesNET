using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database.Models;

namespace DAL.Database
{
    public static class ManageEmployeesSeedData
    {
        public static void Seeding(this ModelBuilder modelBuilder)
        {
            Random random = new Random();
            List<Employees> Employees = new List<Employees>();
            for (int i = 1; i < 30; i++)
            {
                string randPhone = "0";
                for (int j = 1; j < 10; j++)
                {
                    randPhone += random.Next(0, 9).ToString();
                }
                Employees.Add(new Employees()
                {
                    Id = i,
                    Name = "Full Name " + i,
                    Email = $"email{i}@mail.com",
                    Address = $"No {i} Address, Can Tho, VN",
                    Phone = randPhone,
                });
            }
            modelBuilder.Entity<Employees>().HasData(Employees);
        }
    }
}
