import { Component, OnInit, Input } from '@angular/core';
import { Cars } from '../../modules/cars.model';
import { CarsService } from '../../share/cars.service';
import { CarTypeService } from '../../share/car-type.service';
import { CarType } from '../../modules/car-type.model';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { BranchService } from '../../share/branch.service';


@Component({
  selector: 'app-cars-type',
  templateUrl: './cars-type.component.html',
  styleUrls: ['./cars-type.component.css']
})
export class CarsTypeComponent implements OnInit {
    // @Input()events;
    carTyp:CarType[];
    carType:CarType;
    data:any=[];
    // onClick(event, value){console.log(event); console.log(value);}

    constructor(private carTypeService: CarTypeService, private cars: CarsService, private branch: BranchService,
        private toaster: ToastrService,
        private Route: Router,) { 
       // carTypeService.getCarTypeList().then(x=>{this.carTyp=x; console.log(this.carTyp)});
    }
   
        ngOnInit() {
            this.resetForm();
        }
        
     resetForm(form?: NgForm) {
        if(form !=null)
        form.reset();
        this.carTypeService.selectedCarType={
        carTypeID:null,
        model:'',
        brand:'',
        priceExtraPerDay:null,
        pricePerDay:null,
        isManual:null,
        year:null,
        
    }
}
onSubmit(form: NgForm ){
    console.log(form.value)
    // parseInt(form.value['isManual']);
    if(form.value.carTypeID==null){
       
        this.carTypeService.postCars(form.value)
        .subscribe(data =>{
            this.resetForm(form);
            this.carTypeService.getCarTypeList();
           // this.carTypeService.getCarTypeList().catch(x=>this.carTypes=x);
            
            this.toaster.success('New record added Successfully')
        })
    }
    else{
        this.carTypeService.putCars(form.value.carTypeID, form.value)
        .subscribe(data =>{ 
            this.resetForm(form);
            this.carTypeService.getCarTypeList();
            this.toaster.info('Record updated Successfully', 'CarType Register');
        });
    }
}
}
    
    

