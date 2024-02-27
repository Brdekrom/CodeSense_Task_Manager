import { EUCountries } from "src/app/enums/eu-countries";

export interface Address {
    street: string;
    city: string;
    state: string;
    zipCode: string;
    country: EUCountries ;
    isPrimary?: boolean;

}
