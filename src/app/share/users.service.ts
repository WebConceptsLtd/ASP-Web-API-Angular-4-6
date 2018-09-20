import { Injectable } from '@angular/core';
import { User } from '../modules/users.model';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { HttpClient, HttpHeaders, HttpErrorResponse  } from '@angular/common/http';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { AuthService } from './auth.service';



// const httpOptions = {
//     headers: new HttpHeaders({ 'Content-Type': 'application/json' })
//   };

@Injectable()
export class  UsersService {
id: number = 0;
userName:any;
  selectedUser: User;
  userList: User[];
  headers:any;
private currentUser: any;
  constructor(private http : Http, private httpclient: HttpClient, private auth: AuthService) {}
 
    updateCurrentUser() {
    return this.currentUser
      ? Observable.of(this.currentUser) 
      : this.http.get('api/login/currentUser')
          .do(data => { this.currentUser = data }) 
          .this._errorHandler('currentUser');
  }


getLoggedUser() {
    return this.http.get('http://localhost:52800/api/user/details', this.auth.tokenHeader).map(res => res.json());
}  
getUsers():Observable<User[]>{
   return this.httpclient.get<User[]>("http://localhost:52800/api/user/all")
}
getUser(userName: string, callBack: (b: User) => void): void {
    this.httpclient.get<User>('http://localhost:52800/api/user/details/')
    .subscribe(
        callBack
    );
}

 getUserList()  {
        return this.http.get("http://localhost:52800/api/user/all")
         .map((data: Response) =>{
            return data.json() as User[];
          }).toPromise().then(x => {
            this.userList = x;
          })
        }
      
        postUser(user: User){
            let body = JSON.stringify(user);
            console.log(body)
            var headerOptions = new Headers({'Content-Type':'application/json'});
            var requestOptions = new RequestOptions({method: RequestMethod.Post, headers: headerOptions});
        
            return this.http.post('http://localhost:52800/api/user/post1', body, requestOptions).map(x => x.json());
        }
        upload(fileToUpload: any) {
        const formData = new FormData();
        formData.append('PicPath', this.selectedUser.picPath[0]);
        formData.append('FullName', this.selectedUser.fullName);
        formData.append('UserName', this.userName.value );
        formData.append('Email', this.selectedUser.email);
      
        const options = new RequestOptions();
        options.headers = new Headers();
        options.headers.append('enctype', 'multipart/form-data');
      
        return  this.http.post('http://localhost:52800/api/user/post2', formData, options);{
      
        }
    }
        postFile(fileToUpload: File, user:User) {
            let body = JSON.stringify(user);
            console.log(body)
            var headerOptions = new Headers({'Content-Type':'application/json'});
            var requestOptions = new RequestOptions({method: RequestMethod.Post, headers: headerOptions});
        
            //const endpoint = 'http://localhost:52800/api/user/post2';
            const formData: FormData = new FormData();
            formData.append('Image', fileToUpload, fileToUpload.name);
           
            return this.http.post('http://localhost:52800/api/user/post2',formData, body).map(x => x.json());
          }
        
        putUser(id, user:User) {
            var body = JSON.stringify(user);
            console.log(body)
            var headerOptions = new Headers({ 'Content-Type': 'application/json' });
            var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
           
            return this.http.put('http://localhost:52800/api/user/put/' + id,
            body, requestOptions).map(res => res.json());  
        }

        deleteUser(id) {
            return this.http.delete('http://localhost:52800/api/user/' + id).map((response:Response) =>  response.json())
            .catch(this._errorHandler);
        }

        roleMatch(allowedRoles): boolean {
            var isMatch = false;
            var userRoles: string[] = JSON.parse(localStorage.getItem('userRoles'));
            allowedRoles.forEach(element => {
              if (userRoles.indexOf(element) > -1) {
                isMatch = true;
                return false;
              }
            });
            return isMatch;
          }

          _errorHandler(error:Response){debugger;
            console.log(error);
            return Observable.throw(error || "Internal server error");

          }
          userAuthentication(userName, password) {
            var data = "username=" + userName + "&password=" + password + "&grant_type=password";
            var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'True' });
            return this.http.post('http://localhost:52800/api/user/uregister'+ '/token', data, { });
          }

generateToken(UserName: string , Password: string, callBack: (token: string) => void): void {
const data = 'username=' + UserName + '&password=' + Password ;
    
    this.httpclient.get<string>('http://localhost:52800/api/user/GenerateToken?' + data)
        .subscribe(
            callBack
        );
}

          
    }