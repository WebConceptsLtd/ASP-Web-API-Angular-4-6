import { Component, OnInit } from '@angular/core';
import { Response } from '@angular/http';
import { UserRegisterService } from '../share/user-register.service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

import { FormGroup, FormControl, FormArray, Validators, NgForm } from '@angular/forms';
//import { AuthInterceptor } from '../auth/auth.interceptor';


import { User } from '../modules/users.model';
import { UsersService } from '../share/users.service';
import { AuthService } from '../share/auth.service';


@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
    isLoginError:boolean = false;
    loginUserData={}
    user:User;
    constructor(private auth: AuthService, private router: Router, private userServices: UsersService) { }


    ngOnInit() {
    }
    //this.userServices.selectedUser{}
    loginData = {
      userName: '',
      password: ''
    }
  
  login() {
      this.auth.login(this.loginData);
  }
}
