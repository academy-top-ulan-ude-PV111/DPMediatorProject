namespace DPMediatorProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new();
            Employe customer = new Customer(manager);
            Employe developer = new Developer(manager);
            Employe tester = new Tester(manager);

            manager.Customer = customer;
            manager.Developer = developer;
            manager.Tester = tester;

            customer.Message("Order! Program for my bank");
            developer.Message("First Step finish. Testing");
            tester.Message("All right. Prog is good");
        }
    }
}