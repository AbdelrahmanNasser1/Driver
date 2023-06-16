import { Component } from '@angular/core';
import { Driver } from 'src/Model/Driver';
import { DriverService } from 'src/Service/driver.service';

@Component({
  selector: 'app-driver',
  templateUrl: './driver.component.html',
  styleUrls: ['./driver.component.css']
})
export class DriverComponent {
  drivers: Driver[] = [];
  newDriver: Driver = new Driver();
  selectedDriver: Driver | undefined;

  constructor(private driverService: DriverService) { }

  ngOnInit() {
    this.getDrivers();
  }

  getDrivers() {
    this.driverService.getDrivers()
      .subscribe(drivers => this.drivers = drivers);
  }

  createDriver() {
    this.driverService.createDriver(this.newDriver)
      .subscribe(driver => {
        this.drivers.push(driver);
        this.newDriver = new Driver();
      });
  }

  updateDriver() {
    if (this.selectedDriver) {
      this.driverService.updateDriver(this.selectedDriver.id, this.selectedDriver)
        .subscribe(driver => {
          const index = this.drivers.findIndex(d => d.id === driver.id);
          if (index !== -1) {
            this.drivers[index] = driver;
          }
        });
    }
  }

  deleteDriver(driver: Driver) {
    this.driverService.deleteDriver(driver.id)
      .subscribe(() => {
        this.drivers = this.drivers.filter(d => d.id !== driver.id);
        if (this.selectedDriver === driver) {
          this.selectedDriver = undefined;
        }
      });
  }

  onSelectDriver(driver: Driver) {
    this.selectedDriver = { ...driver };
  }
}
