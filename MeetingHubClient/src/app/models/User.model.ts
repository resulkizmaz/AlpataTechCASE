export class UserRegisterRequest {
  constructor(
    public email: string,
    public password: string,
    public name: string,
    public surname: string,
    public phone: string,
    public profileImage: File
  ) {}
}
export class UserRegisterResult {
  constructor(public userID: number, public success: boolean) {}
}

export class UserLoginResult{
  constructor(public email :string,
    public phone:string,
    public name : string,
    public image: File ) {}
}

export class UserLoginRequest {
  constructor(public email: string,
    public password: string) {}
  
}

// export interface IUserAuthenticateResponse {
//   token: string | undefined;
//   refreshToken: string | undefined;
//   refreshTokenDate: Date | undefined;
// }
