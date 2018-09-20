import { Injectable, Component } from "@angular/core";
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Branch } from "../modules/branch.model";

@Injectable()
export class BranchService {
   
    public readonly url = "http://localhost:52800/api/branch";
    branchesList: Branch[]=[];
    selectedBranch:Branch;
    id:number=0;
  
    constructor( private http: Http) {}

getBranchList(){
    return this.http.get("http://localhost:52800/api/branch/all")
    .map((data: Response) =>{
        return data.json() as Branch[];
      }).toPromise().then(x => {
        this.branchesList = x;
      })
}

postBranch(branch: Branch){
let body = JSON.stringify(branch);
console.log(body)

var headerOptions = new Headers({'Content-Type':'application/json'});
var requestOptions = new RequestOptions({ method: RequestMethod.Post, headers : headerOptions});

return this.http.post('http://localhost:52800/api/branch/post',body, requestOptions).map(x => x.json());
}

putBranchs(id, branch:Branch) {
var body = JSON.stringify(branch);
console.log(body)
var headerOptions = new Headers({ 'Content-Type': 'application/json' });
var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });

return this.http.put('http://localhost:52800/api/branch/put/' + id,
  body,requestOptions).map(res => res.json());
}
   
deleteBranch(id:number) {
    return this.http.delete('http://localhost:52800/api/branch/'+id).map(res => res.json());
  }
  
}
