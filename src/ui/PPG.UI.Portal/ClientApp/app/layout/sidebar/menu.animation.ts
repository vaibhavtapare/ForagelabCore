import { trigger, state, animate, transition, style } from '@angular/core';

export const subMenuAnimation =
    trigger('expansionChanged', [
        state('true', style({
            display: 'block'
        })),
        state('false', style({
            display: 'none'
        })),
        transition('1 => 0', [
            style({ height: '*', overflow: 'hidden' }),
            animate(100, style({ height: 0 }))
        ]),
        transition('0 => 1', [
            style({ height: 0, overflow: 'hidden' }),
            animate(100, style({ height: '*' }))
        ])
    ]);
