export class User {
    id: number;
    emailAddress: string;
    password: string;
    confirmPassword: string;
    lastLogin: Date;
    isArchived: boolean;
    profileImage: string;
    fullName: string;
}

export enum usertypes {
    Employee = 1,
    Contact=2
}