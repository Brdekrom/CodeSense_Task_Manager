import { Address } from "../../aggregates/company/address";
import { ContactData } from "../../aggregates/shared/contact-data";

export interface CreateCompanyCommand {
    vatNumber: string;
    name: string;
    contactData: ContactData;
    address: Address;
    isClient: boolean;
}
