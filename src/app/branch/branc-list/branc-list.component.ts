import { Component, OnInit } from '@angular/core';
import { BranchService } from '../../share/branch.service';
import { ToastrService } from 'ngx-toastr';
import { Branch } from '../../modules/branch.model';

@Component({
  selector: 'app-branc-list',
  templateUrl: './branc-list.component.html',
  styleUrls: ['./branc-list.component.css']
})
export class BrancListComponent implements OnInit {
    branchs: Array<any> = [];
    errorMessage: any;
  constructor(private branchServ: BranchService, private toastr: ToastrService) { }

  ngOnInit() {
      this.branchServ.getBranchList();
  }
showForEdit(branch: Branch){
    this.branchServ.selectedBranch=Object.assign({}, branch);
}
onDelete(id, branch:Branch){
    var ans = confirm("Are you sure to delete this branch with Id#: " + id);
    if(ans){
      this.branchServ.deleteBranch(id)
          .subscribe(  data=> {
            var index = this.branchs.findIndex(x=>x.id == branch.branchID);
            this.branchs.splice(index, 1);
            this.toastr.warning("Deleted Successfully");
            this.branchServ.getBranchList();
          }, error=> this.errorMessage = error )
    }
  }
delete(id: number) {
    if (confirm('Are you sure to delete this record ?') == true) {
      this.branchServ.deleteBranch(id)
      .subscribe(x => {
        this.branchServ.getBranchList();
        this.toastr.warning("Deleted Successfully");
      })
    }
  }
}
