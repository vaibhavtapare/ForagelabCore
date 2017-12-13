import {Pipe, PipeTransform} from '@angular/core';

@Pipe({ name: 'phone' })
export class PhoneNumberPipe implements PipeTransform {
    transform(value: string): string {
        let numberOnly = value.replace(/[^0-9]/g, "");
        switch (numberOnly.length) {
            case 7:
                return numberOnly.slice(0, 3) + '-' + numberOnly.slice(3);
            case 10:
                return numberOnly.slice(0, 3) + '-' + numberOnly.slice(3, 6) + '-' + numberOnly.slice(6);
            default:
                return value;
        }
    }
}
