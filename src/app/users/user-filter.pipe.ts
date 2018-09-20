import {Injectable, PipeTransform, Pipe } from '@angular/core';
import { User} from '../modules/users.model';

@Pipe({  
    name: 'searchfilter' 
     
})  
  
export class FilterPipe implements PipeTransform {
    transform(items: any[], field:string): any[] {
      
        if (!field || !field) {
            return items;
        }
        return items.filter(singleItem =>singleItem.fullName.toLowerCase().indexOf(field.toLowerCase())!==-1);
        
    }
}  