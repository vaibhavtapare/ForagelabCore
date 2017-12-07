import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { LoginComponent } from "./components/login/login.component";
import { AuthGuard } from "./shared/guards/auth.guard";
import { AuthenticationService, UserService } from "./core/services/index";
import { fakeBackendProvider } from "./shared/helpers/fake-backend";
import { MockBackend } from "@angular/http/testing";
import { BaseRequestOptions } from "@angular/http";

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        AppComponent,
        LoginComponent,
        ServerModule,
        AppModuleShared
    ],
      providers: [
        AuthGuard,
        AuthenticationService,
        UserService,
        // providers used to create fake backend
        fakeBackendProvider,
        MockBackend,
        BaseRequestOptions
    ]
})
export class AppModule {
}
