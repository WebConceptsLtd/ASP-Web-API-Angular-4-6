
import { UserType } from "./usertype.model";
import { Order } from "./order.model";

export class User {
    userID?:number;
    gender?: any;
    teudatZeut?:any;
    birthday?: Date;
    userName?: string;
    password?: string;
    email?: string;
    fullName?: string;
    picPath?:string;
    phone?:number;
    userTypeID?:number;
    isValidUSer?:boolean;
    role?:string;
    Order?:Order=new Order;
    UserType?:UserType;
    // constructor(public FullName?: string, public userUrlAvatar?: string) {}
}
