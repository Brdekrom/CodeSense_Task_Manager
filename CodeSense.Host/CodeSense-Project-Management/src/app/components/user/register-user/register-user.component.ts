import { Component, } from '@angular/core';
import { UserService } from 'src/app/services/users/user.service';
import { FormControl, FormGroup } from '@angular/forms';
import { User } from 'src/app/interfaces/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.sass'],
})
export class RegisterUserComponent {

  successMessage: string | null = null;
  errorMessage: string | null = null;

  constructor(private userService: UserService, private router: Router) { }

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
    this.successMessage = null;
    this.errorMessage = null;

    const user = this.mapUser();
    this.userService.createUser(user).subscribe({
      next: (result) => {
        console.warn("result", result);
        this.successMessage = "User successfully registered.";
        this.registerForm.reset(); // Reset form on successful submission
        this.router.navigate(['/login']); // Navigate to home page on successful submission
      },
      error: (error) => {
        console.error("Error", error);
        this.errorMessage = "There was an error registering the user.";
      }
    });
  }
}