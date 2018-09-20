import { Component, OnInit, Input } from '@angular/core';
import { Cars } from '../../../modules/cars.model';
import { Order } from '../../../modules/order.model';
import { CarType } from '../../../modules/car-type.model';
import { User } from '../../../modules/users.model';
import { UsersService } from '../../../share/users.service';
import { Router, ActivatedRoute } from '../../../../../node_modules/@angular/router';
import { OrderService } from '../../../share/order.service';
import { NgForm } from '../../../../../node_modules/@angular/forms';
import { ToastrService } from '../../../../../node_modules/ngx-toastr';
import { CarsService } from '../../../share/cars.service';
import { THROW_IF_NOT_FOUND } from '../../../../../node_modules/@angular/core/src/di/injector';
import { Branch } from '../../../modules/branch.model';
import { BehaviorSubject } from '../../../../../node_modules/rxjs/internal/BehaviorSubject';
import { AuthService } from '../../../share/auth.service';
import { CarTypeService } from '../../../share/car-type.service';



@Component({
  selector: 'app-order-details', 
  moduleId: module.id,
 providers: [Cars],
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit {

  car:Cars = new Cars();
  price:number;
  carType:CarType=new CarType();
  branch:Branch=new Branch;
  id:any;
  order: Order = new Order();
    userModel:any;
    user:User = new User();
    result:any;
    carprice:number;
    selected=null;
    startDate:Date;
    carNumber: string = "";
    daysNumber: number = 0;
    totalPrice: number;
    toatlCalculated: boolean = false;
    isUser=false;
    public users:User[];
   
cars:Cars[];
data: any = [];
  
  constructor(private usersService: UsersService, 
     private auth: AuthService,
     private service: OrderService,
     private route: ActivatedRoute,
     private toastr: ToastrService, 
     private carTypeService: CarTypeService,
     private carService:CarsService, 
     private router: Router) {
    }
  ngOnInit() {
  
    var name = this.route.snapshot.params['name'];
    this.usersService.getUser(name,this.id);
    this.usersService.getLoggedUser().subscribe();
}
resetForm(form?:NgForm){
    if(form != null)
    form.reset();
    this.service.selectedOrder =
    {
       startDate:null,
       finishDate:null,
       returned:null,
       
       User:null,
      
    }
    this.carService.selectedCar= {
        carID:null,
        CarType:null,
        Branch:null,
        
       }
    }
    get name() {
        return localStorage.getItem('name');
            }    
  getUser(){
    if (localStorage.getItem('name') != null) {
    this.isUser = true;
    return this.user } 
}
onSubmit(form: NgForm ){
    if(form.value.orderID == null){
        console.log(form.value)
        this.service.postOrder(form.value)
        .subscribe(data =>{
          
            this.resetForm(form);
            this.toastr.success('Thank You! Your Order was plaiced Successfully')
        })
    }
// onSubmit(form: NgForm, order:Order ){
//     if(form.value.orderID == null){
//         console.log(form.value, order)
//         this.service.postOrder(form.value)
//        // this.carService.getCarDetails(form.value)
//         .subscribe(data =>{
          
//             this.resetForm(form);
            
         
//             this.toastr.success('Order plaiced Successfully')
//         })
//     }
}
     setNewUser(user: User): void {
        console.log(user);
        this.userModel = user;
        }
       
        // get name() {
        //     return localStorage.getItem('name');
        //         }
            
        //    get isAuthenticated() {
        //      return !!localStorage.getItem('token');
        //         }
sumPrice(form:NgForm) {
    var start = new Date(form.value.startDate).getTime();
    var end= new Date(form.value.finishDate).getTime();
   //this.daysNumber = Math.abs(form.value.finishDate.getTime()-form.value.startDate.getTime()) / (1000 * 60 * 60 * 24);
  
    this.daysNumber = Math.round((end - start) / (1000 * 60 * 60 * 24));
   
    // var time = new Date().getTime() - new Date(this.StartDate).getTime();
    
    this.result = this.route.snapshot.paramMap.get('result');
    this.totalPrice = this.daysNumber * this.carType.pricePerDay;
    // if (this.daysNumber > 0 && this.totalPrice > 0) {
    //     this.toatlCalculated = true;
    // }
console.log(this.totalPrice, this.toatlCalculated);
}
}

