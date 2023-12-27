// login.component.ts
import { Component } from '@angular/core';


@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor() { }

  login(): void {
    // Handle login logic here
    console.log('Logging in with', this.username, this.password);
  }
}
