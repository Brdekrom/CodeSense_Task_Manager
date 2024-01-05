import { Component, } from '@angular/core';
import { UserClientService } from 'src/app/services/users/user-Client.service';
import { FormControl, FormGroup, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
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
  registerForm: FormGroup;

  constructor(
    private userClientService: UserClientService,
    private router: Router,) {
    this.registerForm = new FormGroup({
      firstName: new FormControl('', [Validators.required, Validators.minLength(2)]),
      lastName: new FormControl('', [Validators.required, Validators.minLength(2)]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
      confirmPassword: new FormControl('', Validators.required),
      companyName: new FormControl('', Validators.required)
    }, { validators: this.passwordMatchValidator });
  }

  passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;
    console.log(confirmPassword, password);
    console.log(password === confirmPassword);
    
    
    return password === confirmPassword ? null : { 'mismatch': true };
  }

  mapToRequest(): CreateUserRequest {
    return {
      clientCompanyName: this.registerForm.value.company!,
      firstName: this.registerForm.value.firstName!,
      lastName: this.registerForm.value.lastName!,
      email: this.registerForm.value.email!,
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