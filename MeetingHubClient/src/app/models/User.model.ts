export class UserInfo {
    constructor(public UserId: number,
        public Email: string,
        public Password:string,
        public Name:string,
        public Surname:string,
        public Phone:string,
        public ProfileImage : File) {}
  }