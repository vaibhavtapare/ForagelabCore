import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './features/app/app.component';
import { NavMenuComponent } from './features/navmenu/navmenu.component';
import { HomeComponent } from './features/home/home.component';
import { FetchDataComponent } from './features/fetchdata/fetchdata.component';
import { CounterComponent } from './features/counter/counter.component';
import { LoginComponent } from "./features/auth/login/login.component";

import { routing } from "./app.routing";
import { AuthGuard } from "./shared/guards/auth.guard";


@NgModule({
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        routing
    ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent, 
        LoginComponent
    ],
    providers: [AuthGuard]  
   
})
export class AppModuleShared {
}
