# ASP-Web-API-Angular-4-6
Angular 4/5 - Asp.Net Web API Car Rental Front &amp;BackEnd
![home](https://user-images.githubusercontent.com/33725262/45802452-8fac2880-bcbf-11e8-83bc-88ac48219bf9.PNG)
![contact](https://user-images.githubusercontent.com/33725262/45805770-18c75d80-bcc8-11e8-9ee0-4aef1a920c93.PNG)
![about](https://user-images.githubusercontent.com/33725262/45805771-18c75d80-bcc8-11e8-86d1-f3f70d48052a.PNG)

#  Login

 ![register](https://user-images.githubusercontent.com/33725262/45805764-182ec700-bcc8-11e8-8245-3f202424a01e.PNG) 
 ![login](https://user-images.githubusercontent.com/33725262/45805772-18c75d80-bcc8-11e8-86cb-c2dd01886188.PNG)
           
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
 ![carsearch](https://user-images.githubusercontent.com/33725262/45805765-182ec700-bcc8-11e8-988f-b3917932902a.PNG)

     
     transform(items: any[], field:string): any[] {
        if (!field || !field) {
            return items;
        }
        return items.filter(singleItem =>singleItem.model.toLowerCase().indexOf(field.toLowerCase())!==-1);  }

#Using Router-

viewDetail(id){
 this.router.navigate(['order-list', id]);
}

![order](https://user-images.githubusercontent.com/33725262/45805769-18c75d80-bcc8-11e8-91f6-83168fe1dbef.PNG)


#To mirror selected car detail to a form
   
   showForEdit(car: Cars){
        this.carService.selectedCar=Object.assign({}, car);
    }

# Show for Edit & Delete

Add Users, Branchs, Cars..
![user](https://user-images.githubusercontent.com/33725262/45805766-182ec700-bcc8-11e8-8011-9a1e32ff2799.PNG)
![branch](https://user-images.githubusercontent.com/33725262/45805767-182ec700-bcc8-11e8-986e-c17c057baafd.PNG)

  
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
    
