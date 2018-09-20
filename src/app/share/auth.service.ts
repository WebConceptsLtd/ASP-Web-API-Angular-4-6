import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Http, Headers, RequestOptions} from '@angular/http';
import 'rxjs/add/observable/of';
import { ToastrService } from '../../../node_modules/ngx-toastr';
import { BehaviorSubject } from '../../../node_modules/rxjs';
import { User } from '../modules/users.model';

@Injectable()
export class AuthService {
    user:User;
    private loggedIn = new BehaviorSubject<boolean>(false); 
   
    get isLoggedIn() {
      return this.loggedIn.asObservable();
    }
  
  private registerUrl = 'http://localhost:52800/api/auth';
  NAME_KEY = 'name';
  TOKEN_KEY = 'token';
//   ADMIN_Key = 'admin';
  headers:any;
  constructor(private http: Http,
              private router: Router,
               private toastr:ToastrService,
               ) { }
    
   get name() {  return localStorage.getItem(this.NAME_KEY); } 
           
   get isAuthenticated() {
         return !!localStorage.getItem(this.TOKEN_KEY); }
           
        register(user) {
             delete user.confirmPassword;
                this.http.post(this.registerUrl + '/register', user).subscribe(res => {
                    this.authenticate(res);
                });
            }

    get tokenHeader() {
        var header = new Headers({'Authorization': 'Bearer ' + localStorage.getItem(this.TOKEN_KEY)});
        return new RequestOptions({ headers: header});
    }


    login(loginData:User) {
        this.http.post(this.registerUrl + '/login', loginData).subscribe(res => { this.authenticate(res);},
             error => { this.handleError("username or password incorect");
            });
    }

  logout() {
    localStorage.removeItem(this.NAME_KEY);
    localStorage.removeItem(this.TOKEN_KEY);
    this.router.navigate(['/home'])
}
  authenticate(res) {
             var authResponse = res.json();
             if (!authResponse.token)
                return;
         
             localStorage.setItem(this.TOKEN_KEY, authResponse.token)
             localStorage.setItem(this.NAME_KEY, authResponse.userName )
            // localStorage.setItem(this.ADMIN_Key, authResponse.userTypeID)
            this.router.navigate(['/']);
         }
         private handleError(error) {
            console.error(error);
            this.toastr.error(error, 'close');
        }
        //  usert={UserTypeID:false};
        //  checkPermission(){
        //      return Observable.of(this.user.UserTypeID);
        //  }
}
