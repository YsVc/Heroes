import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'secondsConverter'
})
export class SecondsConverterPipe implements PipeTransform {

  transform(value: number): string {
    const minutes = Math.floor(value / 60); 
    return minutes + ':' + (value - 60 * minutes).toLocaleString('en-US', { minimumIntegerDigits: 2, useGrouping: false});
  }

}
