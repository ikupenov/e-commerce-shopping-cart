namespace ECommerce.Core.Entities
{
    public sealed class Customer : Entity
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
    }
}
