import { Component, OnInit,Input} from '@angular/core';
import { CarType } from '../../modules/car-type.model';
import { CarTypeService } from '../../share/car-type.service';
import { CarsService } from '../../share/cars.service';

import { Branch } from '../../modules/branch.model';

import { Cars } from '../../modules/cars.model';
import { Router, ActivatedRoute } from '../../../../node_modules/@angular/router';
import { Order } from '../../modules/order.model';
import { OrderService } from '../../share/order.service';




@Component({
  selector: 'app-car-search',
  moduleId: module.id,
  templateUrl: './car-search.component.html',
  styleUrls: ['./car-search.component.css'],
  providers: [Cars]
})
export class CarSearchComponent implements OnInit {
  cars:Cars[];
  cartype: CarType[];
  cart:CarType;
  car:Cars;
  searchTerm2:string;
  branch:Branch[];
  id:any;
//   @Input() car:Cars;
  constructor( private route: ActivatedRoute,
    private router: Router, 
    private carTypeService: CarTypeService,
    private orderService: OrderService,
     private carService: CarsService,
     ) { }

  
  ngOnInit() { 
   
  this.carTypeService.getCarTypeList();   
   this.carService.getCarList();

   
}
showForEdit(car: Cars){
    this.carService.selectedCar=Object.assign({}, car);
}

viewDetail(id){
 this.router.navigate(['order-list', id]);
}  

}
