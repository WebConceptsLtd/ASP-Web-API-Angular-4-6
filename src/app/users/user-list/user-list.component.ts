import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { User } from '../../modules/users.model';
import { UsersService } from '../../share/users.service';

import { identity } from 'rxjs';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})

        export class UserListComponent implements OnInit {
            users: Array<any> = [];
        // public errorMsg;
        errorMessage: any;
        searchTerm: string; 
    
    constructor(private userService: UsersService, private toastr : ToastrService) {  }

        ngOnInit() {
            this.userService.getUserList();     
  
        }
            
  
         showEdit(user: User){
            this.userService.selectedUser=Object.assign({}, user);
      
        }
        delete(id, user:User){
            var ans = confirm("Are you sure to delete this user with Id#: " + id);
            if(ans){
              this.userService.deleteUser(id)
                  .subscribe(  data=> {
                    var index = this.users.findIndex(x=>x.id == user.userID);
                    this.users.splice(index, 1);
                    this.toastr.warning("Deleted Successfully");
                    this.userService.getUserList();
                  }, error=> this.errorMessage = error )
            }
          }
          onDelete(id) {
        if (confirm('Are you sure to delete this record ?') == true) {
            this.userService.deleteUser(id)
            .subscribe(x => {
          this.userService.getUserList();
            this.toastr.warning("Deleted Successfully");})
           }
         }
      
       
        
//           showForEdit(user: User, i:number) {
//             console.log("user:"+user+i);
//             this.isEdit=true;
//              this.toastr.warning("Edit Successfully");
//              }
     
//         setClickedRow = function( u,i){
//             this.selectedRow = i;
//             console.log(this.selectedRow);
//             for (let index = 0; index < this.users.length; index++) {
//       if(this.selectedRow==index)  
//       {
      
//       }     }
//             if(this.selectedRow){
//               this.isEdit=!this.isEdit;
//             }
//             else
//             {
//               this.isEdit=false;
//             }
//           }
      
//           isSelected(selectedRow:number){
//             {
//               this.isEdit=false;
//             }
//       }
      
//    }
}
