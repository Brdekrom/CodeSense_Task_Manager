

export interface Employee {
    id: number; 
    clientCompanyId?: number; 
    firstName: string;
    lastName: string;
    position: string;
    salary: number;
    emailAddress: string;
    phoneNumber: string;
    availableFrom: Date; 
    availableUntil?: Date; 
    isAvailable: boolean;
  }
  
