import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { LoginComponent } from "./components/login/login.component";
import { AppComponent } from "./components/app/app.component";

@NgModule({
    declarations: [      
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent, 
        LoginComponent, 
        AppComponent 
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        
    ]
})
export class AppModuleShared {
}
