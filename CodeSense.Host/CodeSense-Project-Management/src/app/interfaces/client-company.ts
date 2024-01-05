import { Address } from "./address";
import { Employee } from "./emloyee";
import { Project } from "./project";
import { User } from "./user";

export interface ClientCompany {
    id: number;
    name: string;
    emailAddress: string;
    secondaryEmailAddress?: string[];
    primaryPhoneNumber?: string;
    secondaryPhoneNumber?: string[];
    Addresses?: Address[];
    Users?: User[];
    Emoloyees?: Employee[];
    Projects?: Project[];
}
