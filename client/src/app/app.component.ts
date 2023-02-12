
import { Component } from '@angular/core';
import { Router, RouterStateSnapshot } from '@angular/router';
import { UserService } from './services/user.servise';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styles: []
    
})
export class AppComponent {

    constructor(public userService: UserService) {
       
    }

   

}
