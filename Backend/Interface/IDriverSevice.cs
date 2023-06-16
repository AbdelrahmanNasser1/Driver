using Backend.Model;

namespace Backend.Interface
{
    public interface IDriverSevice
    {
        IEnumerable<Driver> GetAllDrivers();

        Driver GetDriver(int id);

        Driver CreateDriver(Driver driver);

        Driver UpdateDriver(int id, Driver updatedDriver);

        bool DeleteDriver(int id);
    }
}