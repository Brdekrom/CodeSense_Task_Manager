export interface Address {
    id?: number;
    clientCompanyId: number;
    street: string;
    city: string;
    state: string;
    zipCode: string;
    country: string;
    isPrimary: boolean;

}
