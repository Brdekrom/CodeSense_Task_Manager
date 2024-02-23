export interface CreateClientCompany {
    name: string;
    primaryEmail: string;
    primaryPhone: string;
    address: {
        street: string;
        city: string;
        state: string;
        zip: string;
        country: string;
    }
}
