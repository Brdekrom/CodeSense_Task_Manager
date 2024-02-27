import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateCompanyCommand } from 'src/app/interfaces/commands/company/create-companyCommand';

@Injectable({
  providedIn: 'root'
})
export class CompanyClientService {

  constructor(private httpClient: HttpClient) { }

  createCompany(command : CreateCompanyCommand) {
    return this.httpClient.post('/company', command);
  }
}
