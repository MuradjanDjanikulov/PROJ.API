namespace DataAccess.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Development { get; set; }
        public string Email { get; set; }

        public Address? Address { get; set; }

        public Employee(int id, string fullName, string development, string email, Address address)
        {
            Id = id;
            FullName = fullName;
            Development = development;
            Email = email;
            Address = address;
        }

        public Employee(int id, string fullName, string development, string email)
        {
            Id = id;
            FullName = fullName;
            Development = development;
            Email = email;
        }

        public Employee(string fullName, string development, string email,Address address)
        {
            FullName = fullName;
            Development = development;
            Email = email;
            Address=address;
        }

        public Employee(string fullName, string development, string email)
        {
            FullName = fullName;
            Development = development;
            Email = email;
        }

    }
}
