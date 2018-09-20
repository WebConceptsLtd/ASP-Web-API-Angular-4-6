import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ValidatorFn , AbstractControl} from '@angular/forms';


import { TestBed, inject } from '@angular/core/testing';


@Injectable()
export class LoginService {

    readonly rootUrl = 'http://localhost:52800/user/login';

  constructor(private httpclient: HttpClient) { }
  

   
}

