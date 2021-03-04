export interface User {
    firstName: string;
    lastName: string;
    email: string;
}

export interface Users{
    data: Array<User>;
    total: string;
    page: string;
    limit: string;
}