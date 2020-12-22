namespace ProjectCoreDDD.Domain.Entities
{
    public class City : EntityBase
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }

    }
}