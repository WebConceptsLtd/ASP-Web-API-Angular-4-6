import { Component, OnInit } from '@angular/core';
import { CarTypeService } from '../../../share/car-type.service';
import { CarsTypeComponent } from '../cars-type.component';
import { CarType } from '../../../modules/car-type.model';
import { CarsComponent } from '../../cars.component';
import { User } from '../../../modules/users.model';
import { ToastrService } from 'ngx-toastr';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Component({
  selector: 'app-car-types-list',
  templateUrl: './car-types-list.component.html',
  styleUrls: ['./car-types-list.component.css']
})
export class CarTypesListComponent implements OnInit {
cars:Array<any>=[]; 
 errorMessage: any;
id:number=0;
searchTerm: string;
    constructor(private carTypesService: CarTypeService,
         private toastr: ToastrService){}
     

    ngOnInit() {
      this.carTypesService.getCarTypeList();
       }

       showForEdit(carType:CarType){
        this.carTypesService.selectedCarType=Object.assign({},carType);
    }
    onDelete(id, cartype:CarType){
        var ans = confirm("Are you sure to delete this cartype with Id: " + id);
        if(ans){
          this.carTypesService.deleteCarType(id)
              .subscribe(  data=> {
                var index = this.cars.findIndex(x=>x.id == cartype.carTypeID);
                this.cars.splice(index, 1);
                this.toastr.warning("Deleted Successfully");
                this.carTypesService.getCarTypeList();
              }, error=> this.errorMessage = error )
        }
      }
      
}