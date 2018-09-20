import { Component, OnInit } from '@angular/core';
import { OrderService } from '../share/order.service';
import { Order } from '../modules/order.model';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { Cars } from '../modules/cars.model';
import { CarType } from '../modules/car-type.model';

import form from 'devextreme/ui/form';
import { BranchService } from '../share/branch.service';
import { Branch } from '../modules/branch.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    startDate:Date;
    ordersList: Order[];
    branchesList:Branch;
    data: any = [];
    selected=null;
  constructor( private branchServ:BranchService, private toastr: ToastrService, private orderService: OrderService) { }

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
       carID:1,
       userID:1,
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
          
         
            this.toastr.success('Order plaiced Successfully')
        })
    }
    }
}