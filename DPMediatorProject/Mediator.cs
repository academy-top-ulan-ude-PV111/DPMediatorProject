using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPMediatorProject
{
    abstract class Mediator
    {
        public abstract void Message(string msg, Employe employe);
    }

    abstract class Employe
    {
        protected Mediator mediator;
        public Employe(Mediator mediator)
        {
            this.mediator = mediator;
        }
        public virtual void Message(string msg)
        {
            mediator.Message(msg, this);
        }

        public abstract void Notify(string msg);
    }

    class Customer : Employe
    {
        public Customer(Mediator mediator) : base(mediator) { }

        public override void Notify(string msg)
        {
            Console.WriteLine("To Customer: " + msg);
        }
    }

    class Developer : Employe
    {
        public Developer(Mediator mediator) : base(mediator) { }

        public override void Notify(string msg)
        {
            Console.WriteLine("To Developer: " + msg);
        }
    }

    class Tester : Employe
    {
        public Tester(Mediator mediator) : base(mediator) { }

        public override void Notify(string msg)
        {
            Console.WriteLine("To Tester: " + msg);
        }
    }

    class Manager : Mediator
    {
        public Employe Customer { set; get; }
        public Employe Developer { set; get; }
        public Employe Tester { set; get; }

        public override void Message(string msg, Employe employe)
        {
            
            if(employe == Customer)
                Developer.Notify(msg);
            if(employe == Developer)
            {
                Customer.Notify(msg);
                Tester.Notify(msg);
            }
            if(employe == Tester)
            {
                Customer.Notify(msg);
                Developer.Notify(msg);
            }
            
        }

    }
}
