import { Injectable } from '@angular/core';
import {Cars} from '../modules/cars.model';
import {CarsComponent} from '../cars/cars.component';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import {URLSearchParams} from '@angular/http'
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';



@Injectable()


export class CarsService {

    url: string = "http://localhost:52800/api/car";
    carList:Cars[];
    headers:any;
    cardata:Cars;
    selectedCar: Cars;
    id:number=0;
    cars: Observable<Cars>;
    constructor(private myHttpClient: HttpClient, private http: Http) { 
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
    }
 
   add(car: any){ this.cars.push(car);}

    getAll() { return Observable.of(this.cars)}
  
    getCarList()
    { return this.http.get('http://localhost:52800/api/car/all')
      .map((data: Response) =>{
         return data.json() as Cars[];
    }).toPromise().then(x => { this.carList=x; } ) }
     
     getCarDetails(id:number)
     {return this.http.get('http://localhost:52800/api/car/details/'+id)
       .map((data: Response) =>data.json()); }

     detailsCar(id:number) {
        return this.http.get('http://localhost:52800/api/car/details/' + id).map((data:Response)=>{
            return data.json();
          }).catch(this._errorHandler); }

      getCarDetsil(id: number): Cars {
        let cars = this.getacar();
        for (let i = 0; i < cars.length; i++) {
            if (cars[i].carID == id) { return cars[i]; }
        } return null;}

    getacar():Cars[]{
        const cars = new Array<Cars>();
        return cars;}

    postCars(car: Cars){
    let body = JSON.stringify(car);
    console.log(body)
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Post,headers : headerOptions});
   
    return this.http.post("http://localhost:52800/api/car/post",body, requestOptions).map(x => x.json());
  }

  putCars(id, car: Cars) {
    var body = JSON.stringify(car);
    console.log(body)
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
   
    return this.http.put("http://localhost:52800/api/car/put/"+ id, body, requestOptions)
    .map(res => res.json()); }

  deleteCars(id: number) {
    return this.http.delete('http://localhost:52800/api/car/' + id).map((response:Response) =>  response.json())
    .catch(this._errorHandler);
  }
    getCars(): Observable<Cars[]>{
    return this.myHttpClient.get('http://localhost:52800/api/car/all').map((response:Response)=><Cars[]>
     response.json()) }

    _errorHandler(error:Response){debugger;
        console.log(error);
        return Observable.throw(error || "Internal server error");
      }
}
