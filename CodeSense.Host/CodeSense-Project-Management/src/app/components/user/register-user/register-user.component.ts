import { Component, } from '@angular/core';
import { UserClientService } from 'src/app/services/users/user-Client.service';
import { FormControl, FormGroup } from '@angular/forms';
import { User } from 'src/app/interfaces/user';
import { Router } from '@angular/router';
import { CreateUserRequest } from 'src/app/interfaces/messages/create-user-request';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.sass'],
})
export class RegisterUserComponent {

  successMessage: string | null = null;
  errorMessage: string | null = null;

  constructor(
    private userClientService: UserClientService, 
    private router: Router,
    ) { }

  registerForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    company: new FormControl('')

  });


  mapToRequest(): CreateUserRequest {
    return {
      clientCompanyName: this.registerForm.value.company!,
      firstName: this.registerForm.value.firstName!,
      lastName: this.registerForm.value.lastName!,
      emailAddress: this.registerForm.value.email!,
      password: this.registerForm.value.password!,
    }
  }

  onSubmit() {
    this.successMessage = null;
    this.errorMessage = null;

    const CreateUserRequest = this.mapToRequest();
    this.userClientService.createUser(CreateUserRequest).subscribe({
      next: (result) => {
        console.warn("result", result);
        this.successMessage = "User successfully registered.";
        this.registerForm.reset(); 
        this.router.navigate(['/login']); 
      },
      error: (error) => {
        console.error("Error", error);
        this.errorMessage = "There was an error registering the user.";
      }
    });
  }
}