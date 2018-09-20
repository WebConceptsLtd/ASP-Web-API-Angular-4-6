import { User } from '../modules/users.model';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms'
import { UsersService } from '../share/users.service';
import { ToastrService } from 'ngx-toastr';
@Component({
    selector: 'app-users',
    templateUrl: './users.component.html',
    styleUrls: ['./users.component.css'],
    providers:[UsersService]
})
export class UsersComponent implements OnInit {

users: User[]=[];
data: any = [];
    constructor(private userService: UsersService, private toastr: ToastrService) {  
    }
           
  ngOnInit() {this.resetForm();}

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.userService.selectedUser= {
     userID:null,
      userName:'',
      fullName:'',
      birthday:null,
      email:'',
      isValidUSer:true,
      gender:'',
      teudatZeut:'',
      password:'',
      picPath:'',
      phone:null,
      userTypeID:1,
      Order:null,
    }
  }

onSubmit(form: NgForm) {
    console.log(form.value)
    parseInt(form.value['userType']);

    if (form.value.userID !== null) {
     this.userService.postUser(form.value)
      .subscribe(data => {   
          this.resetForm(form);
     this.userService.getUserList();
          this.toastr.success('New Record Added Succcessfully', 'User Register');
       })
      }
    else {
     this.userService.putUser(form.value.userID, form.value)
     .subscribe(data => {
       this.resetForm(form);
       this.userService.getUserList();
       this.toastr.info('Record Updated Successfully!', 'User Register');
     });
    }
}  
}