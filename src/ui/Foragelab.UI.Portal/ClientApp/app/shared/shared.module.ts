import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AuthGuard } from "./guards/auth.guard";

@NgModule({
    imports: [
        RouterModule
    ],
    declarations: [    
    ],
    entryComponents: [    
    ],
    exports: [
        CommonModule,
        FormsModule,
        HttpModule,
        RouterModule    
    ],
    providers: [
        AuthGuard
    ]
})
export class SharedModule {
}
