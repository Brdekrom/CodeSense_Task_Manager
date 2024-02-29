import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { ProjectInputComponent } from './components/project-input/project-input.component';
import { ContactComponent } from './components/contact/contact.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { RegisterUserComponent } from './components/user/register-user/register-user.component';
import { CompanyManagerComponent } from './components/company-manager/company-manager.component';
import { AddressFormComponent } from './components/shared/address-form/address-form.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        ProjectInputComponent,
        ContactComponent,
        NavbarComponent,
        RegisterUserComponent,
        CompanyManagerComponent,
        AddressFormComponent
    ],
    providers: [
    provideAnimationsAsync()
  ],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        FormsModule,
        HttpClientModule,
        ReactiveFormsModule,
        MatCardModule,
        MatInputModule,
        MatButtonModule,
        MatSelectModule,
        MatCheckboxModule,
    ]
})
export class AppModule { }
