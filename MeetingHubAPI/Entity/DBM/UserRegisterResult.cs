using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class UserRegisterResult : IEntity
    {
        public string Name { get; set; }
        public bool Success { get; set; }

    }
}
