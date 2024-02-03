import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'priceInRon'
})
export class PriceInRonPipe implements PipeTransform {

  transform(value: number): string {
    if (isNaN(value) || value === null || value === undefined) {
      return '';
    }

    return value.toString() + ' lei';
  }

}
