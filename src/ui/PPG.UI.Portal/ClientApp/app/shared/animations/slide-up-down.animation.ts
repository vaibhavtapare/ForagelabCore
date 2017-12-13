import { animate, state, style , transition, trigger } from '@angular/core';

/**
 * Animation for sliding object up and down as it appears/disappears
 */
export const slideUpDownAnimation =
    trigger('visibilityChanged', [
        transition('* => void', [
            style({ height: '*', overflow: 'hidden' }),
            animate(400, style({ height: 0 }))
        ]),
        transition('void => *', [
            style({ height: 0, overflow: 'hidden' }),
            animate(200, style({ height: '*' }))
        ])
    ]);
