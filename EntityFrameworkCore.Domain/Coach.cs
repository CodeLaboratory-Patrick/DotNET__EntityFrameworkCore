namespace EntityFrameworkCore.Domain
{
    public class Coach : BaseDomainModel
    {
        public string Name { get; set; }
        public Team? TeamId { get; set; }
    }
}
