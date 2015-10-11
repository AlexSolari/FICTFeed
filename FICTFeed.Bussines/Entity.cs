using System;

namespace FICTFeed.Bussines
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
