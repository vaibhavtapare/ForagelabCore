import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';

import { CoreModule } from "./core/core.module";
import { AppComponent } from "./app.component";

declare var API_BASE: string;
declare var API_VERSION: string;
declare var AZURE_FILE_PATH: string;

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        ServerModule,
        AppModule, 
        CoreModule
    ],  
    providers: [
        { provide: 'API_BASE', useValue: API_BASE },
        { provide: 'API_VERSION', useValue: API_VERSION },
        { provide: 'AZURE_FILE_PATH', useValue: AZURE_FILE_PATH }
    ]
})
export class AppModule {
}
