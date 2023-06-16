import { Component, OnInit } from '@angular/core';
import { Driver } from 'src/Model/Driver';
import { DriverService } from 'src/Service/driver.service';

@Component({
  selector: 'app-driver-list',
  templateUrl: './driver-list.component.html',
  styleUrls: ['./driver-list.component.css']
})
export class DriverListComponent implements OnInit{
  drivers: Driver[]=[];
  constructor(private driverService: DriverService) {
  }

  ngOnInit() {
    this.getDrivers();
  }

  getDrivers() {
    this.driverService.getDrivers()
      .subscribe(drivers => this.drivers = drivers);
      console.log(this.drivers);
  }
}
