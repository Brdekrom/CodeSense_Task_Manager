import { Address } from "./address";
import { ContactData } from "../shared/contact-data";
import { Employee } from "../employee/emloyee";
import { FinancialData } from "../shared/financial-data";
import { Project } from "../project/project";
import { ProjectQuotes } from "./project-quotes";
import { User } from "../user/user";

export interface Company {
    id: number;
    vatNumber: string;
    name: string;
    contactData: ContactData;
    financialData: FinancialData;
    mainAddress: Address;
    addresses?: Address[];
    users?: User[];
    emoloyees?: Employee[];
    projects?: Project[];
    projectQuotes?: ProjectQuotes[];
    isClient: boolean;
}
