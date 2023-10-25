export interface IUserAuthentication {
    email: string | undefined;
    password: string | undefined;
}

export interface IUserAuthenticateResponse {
    token: string | undefined;
    refreshToken: string | undefined;
    refreshTokenDate: Date | undefined;
}