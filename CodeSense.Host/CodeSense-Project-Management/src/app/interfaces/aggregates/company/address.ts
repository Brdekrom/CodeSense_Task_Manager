import { EUCountries } from "src/app/enums/eu-countries";

export interface Address {
    street: string;
    houseNumber: string;
    box?: string;
    city: string;
    state: string;
    zipCode: string;
    country: EUCountries ;
    isPrimary?: boolean;

}
