import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import {HomeComponent} from './home/home.component';
import {CarsComponent} from './cars/cars.component';
import {UsersComponent} from './users/users.component';
import {LoginComponent} from './login/login.component';
import { ThankuComponent } from './thanku/thanku.component';
import { Home1Component } from './home.1/home1.component';
import { BranchsComponent } from './branch/branchs/branchs.component';
import { BrancListComponent } from './branch/branc-list/branc-list.component';
import { BranchComponent } from './branch/branch.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { DisplayUserComponent } from './users/display-user/display-user.component';
import { CarsTypeComponent } from './cars/cars-type/cars-type.component';
import { CarTypesListComponent } from './cars/cars-type/car-types-list/car-types-list.component';
import { CarListComponent } from './cars/car-list/car-list.component';
import { CarComponent } from './cars/car/car.component';
import { CartypeComponent } from './cars/cartype/cartype.component';
import { CantactComponent } from './cantact/cantact.component';
import { AboutComponent } from './about/about.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { OrdersComponent } from './orders/orders.component';
import { OrderComponent } from './orders/order/order.component';
import { OrderListComponent } from './orders/order/order-list/order-list.component';
import { CarDetailsComponent } from './cars/car-search/car-details/car-details.component';
import { CarSearchComponent } from './cars/car-search/car-search.component';
import { RegisterComponent } from './register/register.component';
import { MakeOrderComponent } from './cars/car-search/make-order/make-order.component';
import { FooterComponent } from './footer/footer.component';
import { UserComponent } from './users/user/user.component';


export const appRoutes: Routes = [


    ///////home1
    { path: 'home1',component: Home1Component},
    { path: 'home', component: HomeComponent},
    { path: 'footer', component: FooterComponent},
    { path: 'cantact', component: CantactComponent },
    { path: 'about', component: AboutComponent },
    // cars//////
    { path: 'car-search', component: CarSearchComponent},
    { path: 'car-search/:id', component: CarDetailsComponent,data: [{isProd: true}]},
    { path: 'cars', component: CarsComponent,
     children:[
     { path: 'car-list', component: CarListComponent },
     ] },
        { path: 'car', component: CarComponent},
        { path: 'cartype', component: CartypeComponent, children:[
        { path: 'cars-type', component: CarsTypeComponent},
        { path: 'car-types-list', component: CarTypesListComponent}]},
    
   
    //users
            { path: 'display-user', component:  DisplayUserComponent},
            { path: 'user-list', component: UserListComponent },
            { path: 'users', component: UsersComponent},
            { path: 'user', component: UserComponent},
       /////// //order
            { path: 'thanku', component: ThankuComponent },
            { path: 'orders', component: OrdersComponent },
            { path: 'order', component: OrderComponent},
        
            { path: 'order-list', component: OrderListComponent },
            { path: 'order-list/:id',  component: CarDetailsComponent},
           {path: 'make-order', component: MakeOrderComponent}, // data: [{isProd: true}],
            // resolve: {
            //     contact: 'cardetails'
            //   }},
        
            
     ///////   //branches
            { path: "branch", component: BranchComponent},
            { path: "branchs", component: BranchsComponent},
            { path: 'branc-list', component: BrancListComponent },
         

    ///////////register

    { path: 'register', component: RegisterComponent},
  
             ///login///
        { path: 'login', component: LoginComponent},
           /// //redirect page///// 
        { path: 'page-not-found', component: PageNotFoundComponent},
            
        { path: '**', redirectTo: '/home', pathMatch: 'full' },
];
   const appRouters = RouterModule.forRoot(appRoutes);
@NgModule({

    imports: [appRouters]
})
export class AppRoutingModule {constructor(private router: Router) {
   this.router.errorHandler = (error: any) => {
        this.router.navigate(['404']); // or redirect to default route
    }
}

}
