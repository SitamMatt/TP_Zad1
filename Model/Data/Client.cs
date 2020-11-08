namespace Model.Data
{
    public class Client
    {
        public Client(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }
        public string Firstname { get; }
        public string Lastname { get; }
    }
}
