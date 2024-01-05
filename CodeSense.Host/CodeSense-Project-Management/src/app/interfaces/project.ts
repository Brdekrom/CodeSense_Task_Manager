import { Employee } from "./emloyee";
import { Requirement } from "./requirement";

export interface Project {
    id?: number;
    clientCompanyId?: number;
    title: string;
    description: string;
    budget: number;
    cost: number;
    profit: number;
    deadline: Date;
    startDate: Date;
    requirements: Requirement[];
    emloyees?: Employee[];
    isCompleted: boolean;

}
