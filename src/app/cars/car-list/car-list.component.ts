import { Component, OnInit } from '@angular/core';
import { CarsService } from '../../share/cars.service';
import { Cars } from '../../modules/cars.model';
import {CarsComponent} from '../cars.component';
import { CarTypeService } from '../../share/car-type.service';
import { BranchService } from '../../share/branch.service';
import { ToastrService } from 'ngx-toastr';
import { FormsModule} from '@angular/forms'
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw'
import { observable } from 'rxjs';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
    
   
    cars: Array<any> = [];
    searchTerm: string; 
    errorMessage: any;
    constructor(private carService: CarsService, private carTypeService: CarTypeService,  private toastr : ToastrService, private branchService: BranchService) {
 
     }

    ngOnInit() {

    this.carService.getCarList();   
    }
    showForEdit(car: Cars){
        this.carService.selectedCar=Object.assign({}, car);
    }
  

    onDelete(id, car:Cars){
        var ans = confirm("Are you sure to delete car with Id: " + id);
        if(ans){
          this.carService.deleteCars(id)
              .subscribe(  data=> {
                var index = this.cars.findIndex(x=>x.id == car.carID);
                this.cars.splice(index, 1);
                this.toastr.warning("Deleted Successfully");
                this.carService.getCarList();
              }, error=> this.errorMessage = error )
        }
      }
    
}

