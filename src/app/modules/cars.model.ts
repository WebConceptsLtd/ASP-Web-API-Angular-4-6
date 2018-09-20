import { CarType } from "./car-type.model";
import { Branch } from "./branch.model";


export class Cars {
       public carID:number;
       public carNum?:string;
       public isAvailable?: boolean;
       public km?: number;
       public carPic?: string;
       public isFix?: boolean;
       public carTypeID?:number;
       public branchID?:number;
       public CarType?:CarType;
       public Branch?:Branch;
}