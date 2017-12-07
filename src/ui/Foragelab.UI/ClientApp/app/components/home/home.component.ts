import { Component } from '@angular/core';
import { User } from "../../shared/models/user";
import { UserService } from "../../core/services/index";

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    users: User[] = [];

    constructor(private userService: UserService) { }

    ngOnInit() {
        // get users from secure api end point
        this.userService.getUsers()
            .subscribe(users => {
                this.users = users;
            });
    }
}
