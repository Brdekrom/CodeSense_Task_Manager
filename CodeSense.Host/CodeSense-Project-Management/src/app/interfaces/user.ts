export interface User {
    id?: number;
    clientCompanyId?: number;
    firstName: string;
    lastName: string;
    emailAddress: string;
    password: string;
    isAdmin?: boolean;
  }
  
