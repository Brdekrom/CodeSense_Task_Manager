import { Guid } from "guid-typescript";
import { Employee } from "../employee/emloyee";
import { FinancialData } from "../shared/financial-data";
import { ProjectDates } from "./project-dates";
import { Requirement } from "./requirement";

export interface Project {
    id?: number;
    quoteId: Guid;
    clientCompanyId?: number;
    consultantCompanyId?: number;
    name: string;
    description?: string;
    financialData?: FinancialData;
    projectDates: ProjectDates;
    requirements?: Requirement[];
    emloyees?: Employee[];
    isCompleted: boolean;

}
