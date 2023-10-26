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
  constructor(public name: string, public success: boolean) {}
}

export class UserLoginResult {
  constructor(
    public success: boolean | null,
    public email: string | null,
    public phone: string | null,
    public name: string | null, 
    public image: File | null,
    public token: string | null
  ) {}
}

export class UserLoginRequest {
  constructor(public email: string, public password: string) {}
}
