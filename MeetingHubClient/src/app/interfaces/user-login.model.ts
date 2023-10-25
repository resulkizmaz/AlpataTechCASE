import { IComponentRequest } from "./component-request.interface";

export interface IUserAuthentication {
    email: IComponentRequest<string | undefined>;
    password: IComponentRequest<string | undefined>;
}

export interface IUserAuthenticateResponse {
    token: string | undefined;
    refreshToken: string | undefined;
    refreshTokenDate: Date | undefined;
}



//FA2 yapısı kullanılırken
// export interface IAdminAuthentication {
//     email: string;
//     password: string;
//     fa2: string;
// }
// export class AdminAuthInitializerData {
//     constructor(public token: string,
//         public refreshToken: string,
//         public refreshTokenDate: Date,
//         public authorizations: string,
//         public userName: string,
//         public userSurname: string) {}
// }