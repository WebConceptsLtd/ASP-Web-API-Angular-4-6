import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, NgForm, FormGroup } from '../../../node_modules/@angular/forms';
import { AuthService } from '../share/auth.service';
import { User } from '../modules/users.model';
import { UsersService } from '../share/users.service';
import { ToastrService } from '../../../node_modules/ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
    user:User;
    form: FormGroup;  
     hide = true;
     IsAccepted:number=0;  
    constructor( private userServices: UsersService, private toastr: ToastrService, private fb: FormBuilder, private auth : AuthService) {
    
    
        this.form = fb.group({
           
            userName: [null, Validators.required],
            //userID: [null, Validators.required],
            //userTypeID:[null],
            fullName: ['', Validators.required],
            birthday: [null, Validators.required],
            gender:[null],
            phone:[null],
            teudatZeut:['', Validators.required],
            email: ['', [Validators.required, emailValid()]],
            password: ['', Validators.required],
            
            confirmPassword: [null, Validators.required],
         
        }, 
        { validator: matchingFields('password', 'confirmPassword')}
      
    )}
    onSubmit() {
        console.log(this.form.errors);
        parseInt(this.form.value['userTypeID']);
        this.auth.register(this.form.value);
        this.toastr.success('User registration successful');
    }       
  

    onChange(event:any)  
    {  
      if (event.checked == true) {  
        this.IsAccepted = 1;  
      } else {  
        this.IsAccepted = 0;  
      }  
    }  
    

    isValid(control) {
        return this.form.controls[control].invalid && this.form.controls[control].touched
    }
}

function matchingFields(field1, field2) {
    return form => {
        if (form.controls[field1].value !== form.controls[field2].value)
            return { mismatchedFields: true }
    }
}

function emailValid() {
    return control => {
        var regex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/

        return regex.test(control.value) ? null : { invalidEmail: true }
    }
}


  


