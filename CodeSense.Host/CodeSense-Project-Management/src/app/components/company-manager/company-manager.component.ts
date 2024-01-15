import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-company-manager',
  templateUrl: './company-manager.component.html',
  styleUrl: './company-manager.component.sass'
})
export class CompanyManagerComponent implements OnInit {

  myForm: FormGroup = new FormGroup({});

  ngOnInit() {
    this.myForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      // Initialize other form controls as needed
    });
  }

  onSubmit() {
    console.log(this.myForm.value);
  }

}
