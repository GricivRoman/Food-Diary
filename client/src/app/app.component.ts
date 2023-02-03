
import { Component } from '@angular/core';
import { Router, RouterStateSnapshot } from '@angular/router';
import { Login } from './services/login.servise';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styles: []
    
})
export class AppComponent {

    constructor(public loginService: Login) {
       
    }

   

}
