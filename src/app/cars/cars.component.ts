import { Component, OnInit } from '@angular/core';
import { CarsService } from '../share/cars.service';
import { NgForm } from '@angular/forms';
import { Cars } from '../modules/cars.model';
import { ToastrService } from 'ngx-toastr';
import { CarTypeService } from '../share/car-type.service';
import { BranchService } from '../share/branch.service';
//import { BranchComponent} from '../branch/branch'
import { CarType } from '../modules/car-type.model';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css'],
//  providers: [CarsService]
})
export class CarsComponent implements OnInit {
cartype:CarType;
car:Cars;
cars:Cars[];
data: any = [];

 constructor(private carService: CarsService, private toastr: ToastrService, private carTypeService: CarTypeService, private branchService: BranchService) {
  
  }
 
 ngOnInit() {

    this.resetForm();

}
resetForm(form?: NgForm) {
   
    if (form != null)
      form.reset();
    this.carService.selectedCar= {
     carID:null,
     carTypeID:null,
     branchID:null,
     km:null,
     carNum:'',
     carPic: '',
     isAvailable:null,
     isFix:null, 
     CarType:null,
     Branch:null,
    }
    
  }

  onSubmit(form: NgForm) {
    console.log(form.value)
    if (form.value.carID != null) {
       
        this.carService.putCars(form.value.carID, form.value)
        .subscribe(data => {
          this.resetForm(form);
          this.carService.getCarList();
          this.toastr.info('Record Updated Successfully!', 'Car Was Saved');
        })
    }
    else {
        console.log(form.value)
      this.carService.postCars(form.value)
      .subscribe(data => {
    
       this.resetForm(form);
       this.carService.getCarList();
       this.toastr.success('New Record Added Succcessfully', 'Cars Register');
     
      })
    }

  }




}

