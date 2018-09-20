import { Cars } from './cars.model';
import { User } from './users.model';

export class Order {
    orderID?: number;
    startDate?: Date;
    finishDate?: Date;
    returned?:Date;
    userID?:number;
    carID?:number;
    Cars?: Cars;
    User?: User;
   
}