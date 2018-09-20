import { Component, OnInit, Input } from '@angular/core';
import { CarType } from '../../../modules/car-type.model';
import { Cars } from '../../../modules/cars.model';
import { CarsService } from '../../../share/cars.service';
import { CarTypeService } from '../../../share/car-type.service';
import { ActivatedRoute, Router } from '../../../../../node_modules/@angular/router';
import { Order } from '../../../modules/order.model';
import { ToastrService } from '../../../../../node_modules/ngx-toastr';
import { Branch } from '../../../modules/branch.model';
import { User } from '../../../modules/users.model';
import { OrderService } from '../../../share/order.service';

@Component({
  selector: 'app-car-details',
  moduleId: module.id,
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})

export class CarDetailsComponent implements OnInit {
 CarTypeID: any;
 user:User;
 car:Cars = new Cars();
carType:CarType=new CarType;
branch:Branch=new Branch;
id:any;
order:Order=new Order;
orderarray:Order[];
//@Input()carID:number;
    constructor( private carService: CarsService, private carTypeService: CarTypeService, 
        private route: ActivatedRoute, private toastr: ToastrService, private orderService: OrderService,
        private router: Router) {    
  
      
    } 
   
    ngOnInit() {
         
    var car= this.carService.getCarDetails(this.id).subscribe();
    console.log(car);
    const id = +this.route.snapshot.params["id"];
    this.carService.getCarDetails(id).subscribe(ct=> {this.car=ct, this.carType=ct, this.branch=ct})
    }
        
    goBack(): void { 
        this.router.navigate(["/car-search"]);
    }
    
viewDetail(id){
    this.router.navigate(['order-details', id]);
   } 
   showForEdit(car: Cars){
    this.car=Object.assign({}, car); 
  }
}
