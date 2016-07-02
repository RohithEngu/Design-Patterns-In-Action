/*
Implemented for - Design Pattern Course ( CSE 776) - Decorator Pattern.
By - Rohith Engu
Main Objective - Code level implementation of Decorator Pattern.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDecorator
{
    abstract class Component
    {
        public abstract void operation();
    }

    class ConcreteComponent : Component
    {
        public override void operation()
        {
            Console.WriteLine("Brewing the Coffee");
        }
    }

    class Decorator : Component
    {
        protected Component component;
        public Decorator(Component c)
        {
            this.component = c;
        }
        
        public override void operation()
        {
            if(component!=null)
                component.operation();
        }
    }

    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(Component c) : base(c){ }
        public override void operation()
        {
            base.operation();
            Console.WriteLine("Adding Sugar\n");
        }
    }

    
    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(Component c) : base(c){ }
        public override void operation()
        {
            base.operation();
            Console.WriteLine("Adding Milk\n");
            AddedFlavour();
        }

        void AddedFlavour()
        {
            Console.WriteLine("Adding Vanilla Flavour to it\n");
        }
    }

    class Client
    {
        static void Main()
        {
            // Create ConcreteComponent
            Component coffee = new ConcreteComponent();
            
            //Creating concrete Sugar decorator
            Component withSugar = new ConcreteDecoratorA(coffee);
            Console.WriteLine("************* COFFEE 1***********\n");
            withSugar.operation();

            //Creating concrete Milk decorator
            Component withMilk = new ConcreteDecoratorB(coffee);
            Console.WriteLine("************* COFFEE 2***********\n");
            withMilk.operation();

            //2 sugars without the milk
            withSugar = new ConcreteDecoratorA(withSugar);
            Console.WriteLine("************* COFFEE 3***********\n");
            withSugar.operation();

            // Wait for user
            Console.ReadKey();
        }
    }

}