import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { BranchService } from '../../share/branch.service';
import { Branch } from '../../modules/branch.model';
@Component({
  selector: 'app-branchs',
  templateUrl: './branchs.component.html',
  styleUrls: ['./branchs.component.css']
//providers :[BranchService]
})
export class BranchsComponent implements OnInit {

    branchs: Branch[];
  constructor(private branchServ: BranchService, private toastr: ToastrService) { 
          // this.branchServ.getBranchList().catch(x=>this.branchs=x);
  }

  ngOnInit() {
      this.resetForm();
     
  }
resetForm(form?:NgForm){
    if(form != null)
    form.reset();
    this.branchServ.selectedBranch = {
       branchID:null,
       name:'',
       address: '',
       latitude:null,
       longitude:null,
    }
}
onSubmit(form: NgForm ){
    if(form.value.branchID !== null){
        this.branchServ.putBranchs(form.value.branchID, form.value)
        .subscribe(data =>{
            this.resetForm(form);
            this.branchServ.getBranchList();
            this.toastr.info('Record updated Successfully', 'Branch Register');
       
        })
    }
    else{
        console.log(form.value)
        this.branchServ.postBranch(form.value)
        .subscribe(data =>{
       
            this.resetForm(form);
            this.branchServ.getBranchList();
            this.toastr.success('New record added Successfully')
         });
    }
 }

}
