import { LoginData } from "./login-data";
import { UserContactData } from "./user-contact-data";

export interface User {
    id?: number;
    clientCompanyId?: number;
    userContactData: UserContactData;
    loginData: LoginData;
    isAdmin?: boolean;
  }
  
