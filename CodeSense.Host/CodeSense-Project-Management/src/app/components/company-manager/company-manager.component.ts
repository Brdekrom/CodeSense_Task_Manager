import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EUCountries } from 'src/app/enums/eu-countries';
import { CreateCompanyCommand } from 'src/app/interfaces/commands/company/create-company-command';
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
  addressform: FormGroup;

  constructor(private client: CompanyClientService) {
    this.createCompanyForm = new FormGroup({
      vatNumber: new FormControl('', Validators.required),
      name: new FormControl('', Validators.required),
      primaryEmail: new FormControl('', [Validators.required, Validators.email]),
      primaryPhoneNumber: new FormControl('', Validators.required),
      address: new FormGroup({
        street: new FormControl('', Validators.required),
        houseNumber: new FormControl('', Validators.required),
        box: new FormControl(''),
        city: new FormControl('', Validators.required),
        state: new FormControl(''),
        zip: new FormControl('', Validators.required),
        country: new FormControl(this.selectedCountry, Validators.required)
      }),
      isClient: new FormControl(false)
    });
    this.addressform = this.createCompanyForm.get('address') as FormGroup

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
        primaryPhoneNumber: this.createCompanyForm.value.primaryPhoneNumber
      },
      address: {
        street: this.createCompanyForm.value.address.street,
        houseNumber: this.createCompanyForm.value.address.houseNumber,
        box: this.createCompanyForm.value.address.box,
        city: this.createCompanyForm.value.address.city,
        state: this.createCompanyForm.value.address.state,
        zipCode: this.createCompanyForm.value.address.zip,
        country: this.createCompanyForm.value.address.country
      },
      isClient: this.createCompanyForm.value.isClient
    };
  }


}
