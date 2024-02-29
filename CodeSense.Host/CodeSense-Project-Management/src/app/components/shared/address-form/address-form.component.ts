import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { EUCountries } from 'src/app/enums/eu-countries';

@Component({
  selector: 'app-address-form',
  templateUrl: './address-form.component.html',
  styleUrls: ['./address-form.component.sass']
})
export class AddressFormComponent {

  @Input() form!: FormGroup;
  @Input() countries!: EUCountries[];
  @Input() selectedCountry!: EUCountries;

  constructor() { }

}


