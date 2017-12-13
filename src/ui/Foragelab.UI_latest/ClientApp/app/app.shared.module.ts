import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { FeedcodeComponent } from './components/feedcode/feedcode.component';
import { SharedModule } from "./shared/shared.module";
import { CoreModule } from "./core/core.module";


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent, 
        FeedcodeComponent,
       
    ],    
    imports: [
        CoreModule,
        CommonModule,
        HttpModule,
        FormsModule,
        SharedModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'feedcode', component: FeedcodeComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
