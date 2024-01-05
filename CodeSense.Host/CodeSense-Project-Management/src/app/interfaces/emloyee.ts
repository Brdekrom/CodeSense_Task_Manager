import { ClientCompany } from "./client-company";

export interface Employee {
    id: number; 
    firstName: string;
    lastName: string;
    position: string;
    salary: number;
    clientCompany?: ClientCompany; 
    emailAddress: string;
    phoneNumber: string;
    availableFrom: Date; 
    availableUntil?: Date; 
    isAvailable: boolean;
  }
  
