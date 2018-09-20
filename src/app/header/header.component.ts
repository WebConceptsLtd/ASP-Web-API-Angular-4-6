import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserRegisterService } from '../share/user-register.service';
import { User } from '../modules/users.model';
import { AuthService } from '../share/auth.service';
import { style } from '../../../node_modules/@angular/animations';
import { Observable } from '../../../node_modules/rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
    
        isLoggedIn$: Observable<boolean>;  
        userClaims: any;
        isCollapsed: Boolean = true;
      
        user:User;
        constructor(private router: Router, private auth: AuthService, private rService: UserRegisterService) { }
   
   get name() {
    return localStorage.getItem('name');
        }  
        get adminu() {
            return localStorage.getItem('admin');
                }  
   // usertype= JSON.parse(localStorage.getItem('name')).user.userTypeID === 1;
        
   get isAuthenticated() {
     return !!localStorage.getItem('token');
        }
        ngOnInit() {
          this.isLoggedIn$ = this.auth.isLoggedIn;
        }
        logout() {
            localStorage.removeItem('name');
            localStorage.removeItem('token');
            this.router.navigate(['/home'])
        }
       

}
