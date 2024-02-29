import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateCompanyCommand } from 'src/app/interfaces/commands/company/create-company-command';
import { BaseUrlService } from '../base/base-url.service';

@Injectable({
  providedIn: 'root'
})
export class CompanyClientService {

  url = this.baseUrl.getBaseUrl() + '/company';
  constructor(private httpClient: HttpClient, private baseUrl: BaseUrlService) 
  {
    
   }


  createCompany(command : CreateCompanyCommand) {
    return this.httpClient.post(this.url, command);
  }
}
