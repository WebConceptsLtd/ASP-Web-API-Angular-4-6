import { Component, OnInit } from '@angular/core';

import { ToastrService } from 'ngx-toastr';
import { Order } from '../../../modules/order.model';
import { OrderService } from '../../../share/order.service';
import { OrderComponent } from '../order.component';
import { BranchService } from '../../../share/branch.service';
import { CarTypeService } from '../../../share/car-type.service';
import { UsersService } from '../../../share/users.service';



@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
    ordersList: Order[];
    order: Order;
    orders:Array<any>=[];
    errorMessage: any;

    constructor(private orderService: OrderService,
        private orderComponent: OrderComponent,
        private toastr : ToastrService,
        private userServ:UsersService,
        private cartype: CarTypeService,
        private branchServ: BranchService) { }

    ngOnInit() {
   this.orderService.getOrderList();
 
    }

    showForEdit(order: Order){
        this.orderService.selectedOrder=Object.assign({}, order);
    }
    onDelete(id, order:Order){
        var ans = confirm("Are you sure you want to delete order with Id: " + id);
        if(ans){
          this.orderService.deleteOrder(id)
              .subscribe(  data=> {
                var index = this.orders.findIndex(x=>x.id == order.carID);
                this.orders.splice(index, 1);
                this.toastr.warning("Deleted Successfully");
                this.orderService.getOrderList();
              }, error=> this.errorMessage = error )
        }
      }
}
