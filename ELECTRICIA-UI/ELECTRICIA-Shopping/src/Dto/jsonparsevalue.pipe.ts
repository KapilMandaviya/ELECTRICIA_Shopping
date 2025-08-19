import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'jsonparsevalue',
  standalone: true
})
export class JsonparsevaluePipe implements PipeTransform {
  transform(value: string): any[] {
    try {
       
      const parsed = JSON.parse(value);
       
      return parsed;
    } catch (e) {
      console.error('Error parsing JSON:', e);
      return [];
    }
  }
}
