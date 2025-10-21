using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025.SOLID.Single_Responsibility_Principle
{

    public class BirdExampleImplementation
    {

        public void Initializer()
        {
            //Here's how the substituion is happening.
            IFlyingBird bird = new Eagle();
            MakeTheBirdFly(bird);

            IFlyingBird bird2 = new Parrot();
            MakeTheBirdFly(bird2);

            Bird bird3 = new Parrot();
            ThisBirdEats(bird3);
        }

        public void MakeTheBirdFly(IFlyingBird bird)
        {
            bird.Fly();
        }

        public void ThisBirdEats(Bird b)
        {
            b.Eat();
        }
    }
    public abstract class Bird
    {
        public abstract void MakeSound();

        public abstract void Eat();
        public abstract void Sleep();
    }

    public interface IFlyingBird
    {
        public void Fly();
    }

    public class Eagle : Bird, IFlyingBird
    {
        public override void Eat()
        {
            Console.WriteLine("Eagle Eats");
        }

        public void Fly()
        {
            Console.WriteLine("Eagle can fly");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Eagle Makes Sound");
        }

        public override void Sleep()
        {
            Console.WriteLine("Eagle Sleeps");
        }
    }

    public class Ostrich: Bird
    {
        public override void Eat()
        {
            Console.WriteLine("Eagle Eats");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Eagle Makes Sound");
        }

        public override void Sleep()
        {
            Console.WriteLine("Eagle Sleeps");
        }
    }

    public class Parrot : Bird, IFlyingBird
    {
        public override void Eat()
        {
            Console.WriteLine("Eagle Eats");
        }

        public void Fly()
        {
            Console.WriteLine("Eagle can fly");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Eagle Makes Sound");
        }

        public override void Sleep()
        {
            Console.WriteLine("Eagle Sleeps");
        }
    }

}
