import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./features/home/home.component";
import { NavMenuComponent } from './features/navmenu/navmenu.component';
import { FetchDataComponent } from './features/fetchdata/fetchdata.component';
import { CounterComponent } from './features/counter/counter.component';
import { AuthGuard } from "./shared/guards/auth.guard";
import { LoginComponent } from "./features/auth/login/login.component";
import { AppRoutingComponent } from "./app.routing.component";



//const appRoutes: Routes = [

//    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
//    { path: 'auth/login', component: LoginComponent }, 
//    { path: 'home', component: HomeComponent },
//    { path: 'counter', component: CounterComponent },
//    { path: 'fetch-data', component: FetchDataComponent },
//    { path: '**', redirectTo: '' }

//];

export const appRoutes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        component: AppRoutingComponent
        //redirectTo: '/dashboard'
    }
];

//export const routing = RouterModule.forRoot(appRoutes);
