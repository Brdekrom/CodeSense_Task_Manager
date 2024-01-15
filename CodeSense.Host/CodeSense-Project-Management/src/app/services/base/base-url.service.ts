import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class BaseUrlService {
  getBaseUrl(): string {
    // Example logic for determining the base URL based on the environment
    if (environment.production) {
      return '';
    } else {
      return 'http://localhost:5007/api';
    }
  }
}

