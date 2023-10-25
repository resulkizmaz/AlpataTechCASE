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

export class RegisterResult {
  constructor(public userID: number, public success: boolean) {}
}
