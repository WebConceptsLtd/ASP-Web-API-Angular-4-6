import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Order } from '../../modules/order.model';
import { Cars } from '../../modules/cars.model';
import { CarType } from '../../modules/car-type.model';
import { User } from '../../modules/users.model';
import { OrderService } from '../../share/order.service';
import { UsersService } from '../../share/users.service';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-order',
 
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
  providers: [OrderService]  
})
export class OrderComponent implements OnInit {
    serlectedCar: Cars;
    cars:Cars;
    order:Order;
    ordersList: Order[];
    data: any = [];
    branchesList: Array<string>;
    carTyp: Array<string>;
    carData:Cars[];
    carTypeData:CarType[];
    carType:CarType;
    userModel:any;
    user:User;
    selected=null;
    startDate:Date;
    carNumber: string = "";
    daysNumber: number = 0;
    totalPrice: number;
    toatlCalculated: boolean = false;
    isUser=false;
    public users:User[];
  


    constructor(private orderService: OrderService, 
        private usersService: UsersService, 
        private Route: Router,
        private route: ActivatedRoute, 
        private toastr: ToastrService,
     
      ) {
        
  
   //   usersService.getUserList().then(x=>{
   //   this.userModel=x; console.log(this.userModel)});
         }

    ngOnInit() { 
        this.orderService.getOrderList();
    }
     
        resetForm(form?:NgForm){
            if(form != null)
            form.reset();
            this.orderService.selectedOrder={
               orderID:null,
               startDate:null,
               finishDate:null,
               returned:null,
               carID:null,
               userID:null,
               Cars:null,
               User:null
            }
        }
        onSubmit(form: NgForm ){
            if(form.value.orderID == null){
                console.log(form.value)
                this.orderService.postOrder(form.value)
                .subscribe(data =>{
                  
                    this.resetForm(form);
                    this.orderService.getOrderList();
                 
                    this.toastr.success('Order plaiced Successfully')
                })
            }
            else{
                this.orderService.putOrder(form.value.orderID, form.value)
                .subscribe(data=>{
                    this.resetForm(form);
                    this.orderService.getOrderList();
                    this.toastr.info('Record Updated Successfully!', 'User Register');
                });
            }
        }

        onSelect(carTypeID) {  
            this.carType = this.orderService.getOrderList2().filter((carType) => carType.carTypeID == carTypeID);  
        }  
        setNewUser(user: User): void {
            console.log(user);
            this.userModel = user;
            }
       
    sumPrice(form:NgForm) {
        var start = new Date(form.value.startDate).getTime();
        var end= new Date(form.value.finishDate).getTime();
    
        this.daysNumber = Math.round((end - start) / (1000 * 60 * 60 * 24));
      
        this.totalPrice = this.daysNumber * this.order.Cars.CarType.pricePerDay;
        if (this.daysNumber > 0 && this.totalPrice > 0) {
            this.toatlCalculated = true;
        }
console.log(this.totalPrice, this.toatlCalculated);
  }
}