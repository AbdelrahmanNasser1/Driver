using Backend.Interface;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverSevice _driverSevice;
        public DriversController(IDriverSevice driverSevice)
        {
            _driverSevice = driverSevice;
        }

        // GET: api/<DriversController>|
        [HttpGet]
        public ActionResult<IEnumerable<Driver>> Get()
        {
            return _driverSevice.GetAllDrivers().ToList();
        }

        // GET api/<DriversController>/5
        [HttpGet("{id}")]
        public ActionResult<Driver> Get(int id)
        {
            var driver = _driverSevice.GetDriver(id);
            if (driver == null)
                return NotFound();

            return driver;
        }

        // POST api/<DriversController>
        [HttpPost]
        public ActionResult<Driver> Post([FromBody] Driver driver)
        {
            var result= _driverSevice.CreateDriver(driver);
            return CreatedAtAction(actionName: nameof(Get), new { id = result.Id }, result);
        }

        // PUT api/<DriversController>/5
        [HttpPut("{id}")]
        public ActionResult<Driver> Put(int id, [FromBody] Driver updatedDriver)
        {
            return _driverSevice.UpdateDriver(id, updatedDriver);
        }

        // DELETE api/<DriversController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _driverSevice.DeleteDriver(id) == true ?  NoContent() : NotFound(); 
        }
    }
}