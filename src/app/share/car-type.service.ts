import { Injectable } from '@angular/core';
import {Cars} from '../modules/cars.model';
import {CarsComponent} from '../cars/cars.component';
import { HttpClient } from '@angular/common/http';
import { CarType } from '../modules/car-type.model';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Router, ActivatedRoute } from '@angular/router';


   
@Injectable()
export class CarTypeService {
 
   // public readonly url = 'http://localhost:52800/api/cartype';
    carTypelist:CarType[];
    selectedCarType:CarType;
    id:number = 0;
    headers:any;
    constructor(private myHttpClient: HttpClient, private http: Http,  private route: ActivatedRoute,
        private router: Router) { 
       
    }

    getCarDetails(id:number)
    {
     return this.http.get('http://localhost:52800/api/cartype/detail/'+id)
      .map((data: Response) =>data.json());
     }
     
     getCarDetail(id: number): CarType {
      
        let cars = this.getacar();
      for (let i = 0; i < cars.length; i++) {
            if (cars[i].carTypeID == id) {
                return cars[i];
            }
        }
        return null;
    }
    getacar():CarType[]{
        let cars = new Array<CarType>();
        return cars;
    }
deleteCarType(id:number){
   return this.http.delete("http://localhost:52800/api/cartype/"+id).map((response:Response) =>  response.json())
   .catch(this._errorHandler);}

postCars(cartype: CarType){
    var body = JSON.stringify(cartype);
    console.log(body)
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Post, headers: headerOptions});
   
    return this.http.post("http://localhost:52800/api/cartype/post",body, requestOptions).map(x => x.json());
  }

putCars(id, cars:CarType) {
    var body = JSON.stringify(cars);
    console.log(body)
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
   
        return this.http.put("http://localhost:52800/api/cartype/put/" +id,
        body, requestOptions).map(res => res.json());
    }
        
selectModel(){
        return this.http.get('http://localhost:52800/api/cartype/model')
        .map((data : Response) =>data.json());
    }
getCarTypeList(){
        return this.http.get("http://localhost:52800/api/cartype/all")
        .map((data: Response) =>{
            return data.json() as CarType[];
        }).toPromise().then(x =>{
            this.carTypelist=x;
        }) 
    }

    
    getCtypeList()
    {
     return this.myHttpClient.get('http://localhost:52800/api/cartype/all')
      .map((data: Response) =>data.json());
     }
_errorHandler(error:Response){debugger;
        console.log(error);
        return Observable.throw(error || "Internal server error");
      }
      
    // getCarType(id: number): CarType {
    //     let cartypes = this.getCartypes();
    //     for(let i = 0; i < cartypes.length; i++) {
    //         if(cartypes[i].CarTypeID == id) {
    //             return cartypes[i];
    //         }
    //     }
    //     return null;
    // }

}