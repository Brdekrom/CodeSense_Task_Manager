import { Component, } from '@angular/core';
import { UserService } from 'src/app/services/users/user.service';
import { FormControl, FormGroup } from '@angular/forms';
import { User } from 'src/app/interfaces/user';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.sass'],
})
export class RegisterUserComponent {

  constructor(private userService: UserService) { }

  registerForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    company: new FormControl('')

  });


  mapUser(): User {
    return {
      firstName: this.registerForm.value.firstName!,
      lastName: this.registerForm.value.lastName!,
      emailAddress: this.registerForm.value.email!,
      password: this.registerForm.value.password!,
      clientCompanyName: this.registerForm.value.company!
    }
  }

  onSubmit() {
    const user = this.mapUser();
    this.userService.createUser(user).subscribe((result) => {
      console.warn("result", result)
    })
  }
}