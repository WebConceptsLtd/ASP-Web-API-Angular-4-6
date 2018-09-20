import {Injectable, PipeTransform, Pipe } from '@angular/core';
import { Cars } from '../../modules/cars.model';


@Pipe({  
    name: 'searchfilter2' ,
    pure: false
})  
// export class FilterPipe2 implements PipeTransform {
// transform(mlist: Cars[], carNum: string): any[] {
//     if (mlist) {
//         return mlist.filter((mist: object) => list.carNum === carNum);
//     }

 export class FilterPipe2 implements PipeTransform {
    transform(items: any[], field:string): any[] {
      
        if (!field || !field) {
            return items;
        }
       
        return items.filter(singleItem =>singleItem.carType.brand.toLowerCase().indexOf(field.toLowerCase())!==-1);
    }
}  