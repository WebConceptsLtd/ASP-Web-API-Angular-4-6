import { Injectable } from '@angular/core';
import { User } from '../modules/users.model';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
;

    @Injectable()
    export class  UserRegisterService  {
       
        readonly rootUrl = 'http://localhost:52800/api/user/register';
      
        headers:any;
        
        registerUserSelect:User;
        constructor( private http: HttpClient) { }
        
             
                userAuthentication(userName, password) {
                  var data = "username=" + userName + "&password=" + password + "&grant_type=password";
                  var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'True' });
                  return this.http.post('http://localhost:52800/api/user/register', data, { headers: reqHeader });
                }
              
                getUserClaims(){
                 return  this.http.get('http://localhost:52800/api/user/register/getUserClaims');
                }
                
                //    getAllRoles() {
                //      var reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
                //      return this.http.get('http://localhost:52800/api/usertype/GetAllRoles', { headers: reqHeader });
                //    }
                 
                roleMatch(allowedRoles): boolean {
                  var isMatch = false;
                  var userRoles: string[] = JSON.parse(localStorage.getItem('Admin'));//1-Admin
                  allowedRoles.forEach(element => {
                    if (userRoles.indexOf(element) > -1) {
                      isMatch = true;
                      return false;
                    }
                  });
                  return isMatch;
              
                }
            } 