import { Component } from '@angular/core';
import { StateService } from "../core/services/state.service";



@Component({
    templateUrl: './layout.component.html'
})

export class LayoutComponent  {
    constructor(public stateService: StateService)
    { }
}