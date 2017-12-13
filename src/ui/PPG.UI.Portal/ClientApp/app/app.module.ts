import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';

import { AppComponent } from './app.component'
import { appRoutes } from './app-routing.module';

import { CoreModule } from './core/core.module';
import { LayoutModule } from './layout/layout.module';
import { SharedModule } from './shared/shared.module';

// feature modules
import { AdminModule } from './features/admin/admin.module';
import { AuthModule } from './features/auth/auth.module';
import { ClientModule } from './features/clients/client.module';
import { DashboardModule } from './features/dashboard/dashboard.module';
import { EmployeeModule } from './features/employees/employee.module';
import { JobModule } from './features/jobs/job.module';
import { AppRoutingComponent } from "./app.routing.component";
import { CreatePDFModule } from './features/test/create-pdf.module';

declare var API_BASE: string;
declare var API_VERSION: string;
declare var AZURE_FILE_PATH: string;

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent, AppRoutingComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        
        CoreModule,
        LayoutModule,
        SharedModule,

        // feature modules
        AuthModule,
        DashboardModule,
        ClientModule,
        JobModule,
        EmployeeModule,
        AdminModule,
        CreatePDFModule,
        RouterModule.forRoot(appRoutes)
    ],
    providers: [
        { provide: 'API_BASE', useValue: API_BASE },
        { provide: 'API_VERSION', useValue: API_VERSION },
        { provide: 'AZURE_FILE_PATH', useValue: AZURE_FILE_PATH }
    ]
})
export class AppModule {
}
