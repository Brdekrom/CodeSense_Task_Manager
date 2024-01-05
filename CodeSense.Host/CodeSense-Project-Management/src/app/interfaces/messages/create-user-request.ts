export interface CreateUserRequest {
    clientCompanyName: string;
    firstName: string;
    lastName: string;
    emailAddress: string;
    password: string;
    isAdmin?: boolean;
}
