using Backend.Interface;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Backend.Implementation
{
    public class DriverService : IDriverSevice
    {
        private static List<Driver> drivers = new List<Driver>();


        private readonly IConfiguration _configuration;

        public DriverService(IConfiguration configuration)
        {
            _configuration = configuration;
            drivers = ReadListFromText();
        }

        public Driver CreateDriver(Driver driver)
        {
            
            driver.Id = drivers.Count() +1;
            drivers.Add(driver);

            InsertNewLine(driver);

            return driver;
        }

        public bool DeleteDriver(int id)
        {
            var driver = drivers.FirstOrDefault(d => d.Id == id);
            if (driver == null)
                return false;

            drivers.Remove(driver);
            return true;
        }

        public IEnumerable<Driver> GetAllDrivers()
        {
            return drivers;
        }

        public Driver GetDriver(int id)
        {
            var driver =  drivers.FirstOrDefault(d => d.Id == id);
            if (driver == null)
                return null!;

            return driver;
        }

        public Driver UpdateDriver(int id, Driver updatedDriver)
        {
            var driver = drivers.FirstOrDefault(d => d.Id == id);
            if (driver == null)
                return null!;

            // Update the driver properties
            driver.FirstName = updatedDriver.FirstName;
            driver.LastName = updatedDriver.LastName;
            driver.Email = updatedDriver.Email;
            driver.PhoneNumber = updatedDriver.PhoneNumber;

            return driver;
        }
        private List<Driver> ReadListFromText()
        {
            var filePath = _configuration["Settings:Path"]!;
            var lines =  File.ReadAllLinesAsync(filePath).Result;
            List<Driver>? tempList = new List<Driver>();
            for (int i = 0; i < lines.Length; i++)
            {
                tempList.Add(JsonSerializer.Deserialize<Driver>(lines[i])!);
            }
            return tempList;
        }

        private void InsertNewLine( Driver driver)
        {
            var filePath = _configuration["Settings:Path"]!;
            using var writer = File.AppendText(filePath);
            writer.WriteLine(JsonSerializer.Serialize(driver));
        }
    }
}