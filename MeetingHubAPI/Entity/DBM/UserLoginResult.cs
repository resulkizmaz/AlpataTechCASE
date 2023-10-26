namespace Entity
{
    public class UserLoginResult : IEntity
    {
        //Veri tabanından dönen
        public bool Success { get; set; }
        public string Email { get; set; } 
        public string Phone { get; set; }
        public string Name { get; set; }
        public string ProfileImagePath { get; set; }

    }

    public class UserInfoResult : IEntity
    {
        public bool Success { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
