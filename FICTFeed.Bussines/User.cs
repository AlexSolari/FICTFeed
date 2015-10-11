namespace FICTFeed.Bussines
{
    class User : Entity
    {
        public virtual string Name { get; set; }
        public virtual string PasswordCrypted { get; set; }
        public virtual string Mail { get; set; }
    }
}
