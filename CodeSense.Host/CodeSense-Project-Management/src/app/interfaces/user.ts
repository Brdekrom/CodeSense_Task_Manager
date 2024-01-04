export interface User {
    id: number;
    createdAt: Date;
    updatedAt: Date;
    isDeleted: boolean;
    firstName: string;
    lastName: string;
    emailAddress: string;
    password: string;
    clientCompanyName: string;
    isAdmin: boolean;
  }
  
