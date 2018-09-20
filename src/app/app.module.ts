//models
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule} from '@angular/router';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
//import { Branch } from "./modules/branch.model";
import { appRoutes } from './app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { DxTooltipModule } from 'devextreme-angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule, NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpModule } from '@angular/http';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { CalendarModule } from 'angular-calendar';
/////angular material///////
import {MatButtonModule, 
    MatInputModule, 
    MatMenuModule, 
    MatCardModule, 
    MatIconModule, 
    MatToolbarModule, 
    MatFormFieldModule, 
    MatDatepickerModule, 
    MatNativeDateModule,
    MatRadioModule,
    MatOptionModule, 
    MatSelectModule, 
    MatSlideToggleModule } from '@angular/material';
//////Components home///////
import {PageNotFoundComponent} from './page-not-found/page-not-found.component';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { Home1Component } from './home.1/home1.component';
import { CantactComponent } from './cantact/cantact.component';
import { AboutComponent } from './about/about.component';

//service
import { AuthService } from './share/auth.service';
import { BranchService } from './share/branch.service';
import { UserRegisterService} from './share/user-register.service';
import { CarTypeService} from './share/car-type.service';
import { OrderService } from './share/order.service';
import { UsersService } from './share/users.service';
import { CarsService } from './share/cars.service';

             // ///////////branch//////////////

import { ThankuComponent } from './thanku/thanku.component';
import { BranchComponent } from './branch/branch.component';
import { BranchsComponent } from './branch/branchs/branchs.component';
import { BrancListComponent } from './branch/branc-list/branc-list.component';

                // /////////users//////////////////

import { LoginComponent } from './login/login.component';
import { FilterPipe } from './users/user-filter.pipe';
import { UserListComponent } from './users/user-list/user-list.component';
import { DisplayUserComponent } from './users/display-user/display-user.component';
import { UsersComponent } from './users/users.component';
import { AdminComponent } from './admin/admin.component';
import { SocialLinkComponent } from './social-link/social-link.component';
import { RegisterComponent } from './register/register.component';


                 /////////cars///////////////////
import { CarTypesListComponent } from './cars/cars-type/car-types-list/car-types-list.component';
import { CarsTypeComponent } from './cars/cars-type/cars-type.component';
import { CarListComponent } from './cars/car-list/car-list.component';
import { CarComponent } from './cars/car/car.component';
import { CartypeComponent } from './cars/cartype/cartype.component';
import { CarsComponent } from './cars/cars.component';
import { CarDetailsComponent } from './cars/car-search/car-details/car-details.component';
import { FilterPipe2 } from './cars/car-search/car-filter.pipe';
import { CarSearchComponent } from './cars/car-search/car-search.component';

    /////Order////
import { OrdersComponent } from './orders/orders.component';
import { OrderDetailsComponent } from './cars/car-search/order-details/order-details.component';
import { OrderComponent } from './orders/order/order.component';
import { OrderListComponent } from './orders/order/order-list/order-list.component';
import { MakeOrderComponent } from './cars/car-search/make-order/make-order.component';
import { UserComponent } from './users/user/user.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    Home1Component,
    UsersComponent,
    CarsComponent,
    LoginComponent,
    OrderComponent,
    OrderDetailsComponent,
    FooterComponent,
    HeaderComponent,
    PageNotFoundComponent,
    CarListComponent,
    CarDetailsComponent,
    CarsTypeComponent,
    UserListComponent,
    FilterPipe,
    FilterPipe2,
    OrderListComponent,
    CarTypesListComponent,
    CarSearchComponent,
    ThankuComponent,
    BranchComponent,
    BranchsComponent,
    BrancListComponent,
    DisplayUserComponent,
    CarComponent,
    CartypeComponent,
    SocialLinkComponent,
    CantactComponent,
    AboutComponent,
    OrdersComponent,
    AdminComponent,
    RegisterComponent,
    MakeOrderComponent,
    UserComponent,


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    BrowserAnimationsModule,
    HttpModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    AngularFontAwesomeModule,
    NgbModule.forRoot(),
    FormsModule,
    DxTooltipModule,
    MatButtonModule,MatInputModule,
    FormsModule,  
    ReactiveFormsModule,  
    
    MatButtonModule,  
    MatMenuModule,  
    MatToolbarModule,  
    MatIconModule,  
    MatCardModule,  
    BrowserAnimationsModule,  
    MatFormFieldModule,  
    MatInputModule,  
    MatDatepickerModule,  
    MatNativeDateModule,  
    MatRadioModule,  
    MatSelectModule,  
    MatOptionModule,  
    MatSlideToggleModule ,
    NgbModalModule.forRoot(),
    CalendarModule.forRoot(),
    BsDatepickerModule.forRoot()
],
schemas: [
    CUSTOM_ELEMENTS_SCHEMA
],
 
providers: [UsersService, CarsService, CarTypeService, 
    OrderService,  UserRegisterService, BranchService, AuthService,
    
   {
      provide : HTTP_INTERCEPTORS,
      useClass : AuthService, 
      multi : true},
      {
        provide: HTTP_INTERCEPTORS,
        useClass: UsersService,
        multi: true
    },
//    },
//    CarsService,
//     {
//       provide: 'cardetails',
//      useValue: (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => { 
//      },
//     //   useValue: () => {
//     //     return {
//     //       id: 1,
//     //       name: 'car-details',
      
//     }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
