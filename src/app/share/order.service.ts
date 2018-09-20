import { Injectable } from '@angular/core';
import { Order } from '../modules/order.model';
import { Observable } from 'rxjs/Observable';
import {BehaviorSubject} from 'rxjs';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { HttpClient} from '@angular/common/http';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Router } from '@angular/router';
import { CarType } from '../modules/car-type.model';



@Injectable()
export class OrderService {

    public readonly url: string = 'http://localhost:52800/api/order';
    ordersList: Order[]=[];
    selectedOrder:Order;
    id:number=0;
    ordermodel: Order;
    daysNumber: number = 0;
    totalPrice: number;
    toatlCalculated: boolean = false;
   // private itemsSubject: BehaviorSubject<CarType[]> = new BehaviorSubject([]);
    constructor(private myHttpClient: HttpClient, private Route: Router, private http: Http) { }

 
//    calculateUsersOrderTotal(users: User[]) {
//         for (const user of users) {
//             if (user && user.orders) {
//                 let total = 0;
//                 for (const order of user.orders) {
//                     total += order.itemCost;
//                 }
//                 user.orderTotal = total;
//             }
//         }
//    }

addOrder(order: Order, callBack: (b: boolean) => void): void {
    this.myHttpClient.post<boolean>('http://localhost:52800/api/order/post', order)
    .subscribe(
        callBack
    );

}
postOrder(order: Order){
    let body = JSON.stringify(order);
    console.log(body)
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Post,headers : headerOptions});
    
    return this.http.post("http://localhost:52800/api/order/post",body, requestOptions).map(x => x.json());
  }
 
  putOrderprice(id:CarType, order:Order) {
    var body = JSON.stringify(order);
    console.log(body)
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
   
    return this.http.put('http://localhost:52800/api/order/price/'+id,
      body,
      requestOptions).map(res => res.json());
  }
  getDetails(id:number)
  {
   return this.http.get('http://localhost:52800/api/order/get/'+id)
    .map((data: Response) =>data.json());
   }
  putOrder(id, order:Order) {
    var body = JSON.stringify(order);
    console.log(body)
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
   
    return this.http.put('http://localhost:52800/api/order/'+id,
      body,
      requestOptions).map(res => res.json());
  }
  _errorHandler(error:Response){debugger;
    console.log(error);
    return Observable.throw(error || "Internal server error");
  }
  deleteOrder(id: number) {
    return this.http.delete('http://localhost:52800/api/order/' + id).map((response:Response) =>  response.json())
    .catch(this._errorHandler);
  }
    
//     
  getOrderList2()
  {
   return this.myHttpClient.get('http://localhost:52800/api/order/all')
    .map((data: Response) =>data.json());
   }
   getOrderList()
   { return this.http.get("http://localhost:52800/api/order/all")
   .map((data: Response) =>{
      return data.json() as Order[];
    }).toPromise().then(x => {
      this.ordersList = x;
    })
  }

}
