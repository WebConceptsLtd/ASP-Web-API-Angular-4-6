# ASP-Web-API-Angular-4-6
Angular 4/5 - Asp.Net Web API Car Rental Front &amp;BackEnd

#  Login

         
             localStorage.setItem(this.TOKEN_KEY, authResponse.token)
             localStorage.setItem(this.NAME_KEY, authResponse.userName )
             localStorage.setItem(this.ADMIN_Key, authResponse.userTypeID)
            this.router.navigate(['/']);
         }
         private handleError(error) {
            console.error(error);
            this.toastr.error(error, 'close');
        }
 # Pipe search
  
  transform(items: any[], field:string): any[] {
      
        if (!field || !field) {
            return items;
        }
        return items.filter(singleItem =>singleItem.fullName.toLowerCase().indexOf(field.toLowerCase())!==-1);
        
    }
# Show for Edit & Delete

     showForEdit(car: Cars){
        this.carService.selectedCar=Object.assign({}, car);
    }
  
Using: import { ToastrService } from 'ngx-toastr' 

    onDelete(id, car:Cars){
        var ans = confirm("Are you sure to delete car with Id: " + id);
        if(ans){
          this.carService.deleteCars(id)
              .subscribe(  data=> {
                var index = this.cars.findIndex(x=>x.id == car.carID);
                this.cars.splice(index, 1);
                this.toastr.warning("Deleted Successfully");
                this.carService.getCarList();
              }, error=> this.errorMessage = error )
        }
      }
    
