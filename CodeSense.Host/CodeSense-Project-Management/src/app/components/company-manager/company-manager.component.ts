import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { EUCountries } from 'src/app/enums/eu-countries';
import { CreateCompanyCommand } from 'src/app/interfaces/commands/company/create-companyCommand';
import { CompanyClientService } from 'src/app/services/company/company-client.service';

@Component({
  selector: 'app-company-manager',
  templateUrl: './company-manager.component.html',
  styleUrl: './company-manager.component.sass'
})
export class CompanyManagerComponent {

  createCompanyForm: FormGroup;
  countries = Object.values(EUCountries);
  selectedCountry: EUCountries = EUCountries.BE;

  constructor(private client: CompanyClientService) {
    this.createCompanyForm = new FormGroup({
      vatNumber: new FormControl(''),
      name: new FormControl(''),
      contactData: new FormGroup({
        primaryEmail: new FormControl(''),
        primaryPhone: new FormControl('')
      }),
      address: new FormGroup({
        street: new FormControl(''),
        city: new FormControl(''),
        state: new FormControl(''),
        zip: new FormControl(''),
        country: new FormControl(this.selectedCountry) // Set the default country here
      }),
      isClient: new FormControl(false) 
    });
  }
  

  onSubmit() {
    const command = this.mapToRequest();

    this.client.createCompany(command).subscribe(
      () => {
        console.log('Company created');
      },
      (error) => {
        console.error('Error creating company', error);
      }
    );

  }

  mapToRequest(): CreateCompanyCommand {
    return {
      vatNumber: this.createCompanyForm.value.vatNumber,
      name: this.createCompanyForm.value.name,
      contactData: {
        primaryEmail: this.createCompanyForm.value.primaryEmail,
        primaryPhone: this.createCompanyForm.value.primaryPhone
      },
      address: {
        street: this.createCompanyForm.value.address.street,
        city: this.createCompanyForm.value.address.city,
        state: this.createCompanyForm.value.address.state,
        zipCode: this.createCompanyForm.value.address.zip,
        country: this.createCompanyForm.value.address.country
      },
      isClient: this.createCompanyForm.value.isClient
    };
  }


}
