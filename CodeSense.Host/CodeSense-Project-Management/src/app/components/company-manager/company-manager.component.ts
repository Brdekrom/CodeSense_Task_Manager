import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CreateClientCompany } from 'src/app/interfaces/messages/create-client-company';
import { ClientCompanyClientService } from 'src/app/services/clientCompany/client-company-client.service';

@Component({
  selector: 'app-company-manager',
  templateUrl: './company-manager.component.html',
  styleUrl: './company-manager.component.sass'
})
export class CompanyManagerComponent {

  myForm: FormGroup;

  constructor(private client: ClientCompanyClientService) {
    this.myForm = new FormGroup({
      name: new FormControl(''),
      primaryEmail: new FormControl(''),
      primaryPhone: new FormControl(''),
      address: new FormGroup({
        street: new FormControl(''),
        city: new FormControl(''),
        state: new FormControl(''),
        zip: new FormControl(''),
        country: new FormControl('')
      })
    });
  }

  onSubmit() {
    const company = this.mapToRequest();

    this.client.

  }

  mapToRequest(): CreateClientCompany {
    return {
      name: this.myForm.value.name,
      primaryEmail: this.myForm.value.primaryEmail,
      primaryPhone: this.myForm.value.primaryPhone,
      address: {
        street: this.myForm.value.address.street,
        city: this.myForm.value.address.city,
        state: this.myForm.value.address.state,
        zip: this.myForm.value.address.zip,
        country: this.myForm.value.address.country
      }
    };
  }


}
