namespace Entities.Models
{
    public class ShapedEntity
    {
        public ShapedEntity() 
        {
            Entity = new Entity();
        }

        public Guid Id { get; set; }
        public Entity entity { get; set; }
    }
}
