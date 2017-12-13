import {Pipe, PipeTransform} from '@angular/core';

@Pipe({ name: 'shortDescription' })
export class ShortDescriptionPipe implements PipeTransform {
    transform(value: string): string {
        if (value != null && value.split(/\s+/).length > 120) {
            return value.split(/\s+/).slice(1, 25).join(" ") + ' ...';
        }
        else {
            return value;
        }
    }
}
