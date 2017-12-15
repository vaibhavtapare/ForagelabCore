import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './features/app/app.component';
import { appRoutes } from './app-routing.module';
import { NavMenuComponent } from './features/navmenu/navmenu.component';
import { HomeComponent } from './features/home/home.component';
import { FetchDataComponent } from './features/fetchdata/fetchdata.component';
import { CounterComponent } from './features/counter/counter.component';

import { AuthGuard } from "./shared/guards/auth.guard";
import { AuthModule } from "./features/auth/auth.module";
import { AppRoutingComponent } from "./app.routing.component";
import { HomeModule } from "./features/home/home.module";
import { LayoutModule } from "./layout/layout.module";
import { SharedModule } from "./shared/shared.module";
import { CoreModule } from "./core/core.module";
import * as Globals from './shared/global/globals'; 

@NgModule({
    imports: [     
        CoreModule,
        LayoutModule,
        SharedModule,      
        
        AuthModule,    
        HttpModule,
        FormsModule,  
        HomeModule,
        RouterModule.forRoot(appRoutes)
    ],

    declarations: [
        AppComponent,
        AppRoutingComponent, 
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent     
    ],
    
    providers: [
        { provide: 'API_BASE', useValue: Globals.API_BASE },
        { provide: 'API_VERSION', useValue: Globals.API_VERSION },
    ]
})
export class AppModuleShared {
}

