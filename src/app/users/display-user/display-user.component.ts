import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw'
import { User } from '../../modules/users.model';
import { UsersService } from '../../share/users.service';


@Component({
  selector: 'app-display-user',
  templateUrl: './display-user.component.html',
  styleUrls: ['./display-user.component.css']
})
export class DisplayUserComponent implements OnInit {
    users: User[];
    searchTerm: string; 
  constructor(private userService: UsersService, private toastr : ToastrService) { }

  ngOnInit() { 
       this.userService.getUserList();        
  }
  showForEdit(user: User){
    this.userService.selectedUser=Object.assign({}, user);

}
}
