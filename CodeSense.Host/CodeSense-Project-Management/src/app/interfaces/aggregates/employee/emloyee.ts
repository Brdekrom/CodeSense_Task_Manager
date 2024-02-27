import { EmployeeLevel } from "src/app/enums/employee-level";
import { Company } from "../company/company";
import { ContactData } from "../shared/contact-data";
import { Availability } from "./availability";
import { EmployeeFinancialData } from "./employee-financial-data";


export interface Employee {
    id?: number; 
    projectId?: number;
    firstName: string;
    lastName: string;
    contactData: ContactData
    employerCompany: Company;
    level: EmployeeLevel;
    employeeFinancialData: EmployeeFinancialData;
    clientCompany?: Company; 
    availability: Availability;
  }
  
