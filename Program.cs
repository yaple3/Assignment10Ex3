using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Assignment10Ex4
{
    // These classes are intentionally empty for the purpose of this example.
    internal class Alarm { }
    internal class Teeth { }
    internal class Shower { }
    internal class Dress { }
    internal class Drive { }

    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Stopwatch sw = Stopwatch.StartNew();
                TurnOffAlarm();
                Console.WriteLine("Out of bed and ready to go");

                BrushTeeth();
                Console.WriteLine("Teeth are clean");

                Shower shower = await TakeAShowerAsync();
                Console.WriteLine("Showering is done");

                GetDressed();
                Console.WriteLine("Dressed and ready to go");

                Drive drive = await DriveToWorkAsync(10);
                Console.WriteLine("Walking into work.");

                Console.WriteLine("Ready to begin");
                sw.Stop();
                Console.WriteLine("The program took " + sw.ElapsedMilliseconds + " milliseconds to run");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"An exception has occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void TurnOffAlarm()
        {
            Console.WriteLine("Turned off alarm");
            return;
        }


        private static void BrushTeeth() => Console.WriteLine("Putting paste on the brush... Brushing");


        private static async Task<Shower> TakeAShowerAsync()
        {
            Console.WriteLine("Warming the water...");
            await Task.Delay(1000);
            Console.WriteLine($"Shampoo and condition the hair");
            //Console.WriteLine("Slipped in the shower!!!");
            //throw new InvalidOperationException("Bruised butt");
            Console.WriteLine("Rinse off");
            await Task.Delay(2000);
            Console.WriteLine("Dry off");
            return new Shower();
        }

        private static void GetDressed() => Console.WriteLine("Together and ready to go");

        private static async Task<Drive> DriveToWorkAsync(int time)
        {
            Console.WriteLine("Starting the car...");
            for (int i = 0; i < time; i++)
            {
                Console.WriteLine($"Driving...");
            }
            await Task.Delay(1000);
            Console.WriteLine("Arrived at work");
            return new Drive();
        }
    }
}
/*
2.There are 3 methods you need to convert: DriveToWork, TakeAShower and Main.

a) Add await before all occurrences of Task.Delay() in the 3 methods.

b) Add async to the method signatures

If the signature is returning a class object, then you will need to include the Class as the data type for the Task

Example:

convert

private static Shower TakeAShower()

to

private static async Task<Shower> TakeAShowerAsync()

c) Add await before the method call in Main

Example:

convert

Shower shower = TakeAShower();

to

Shower shower = await TakeAShowerAsync();

3.Run the program.

4.Create and throw an error in either the TakeAShower or the DriveToWork method. Make sure the exception handling is working. Comment out the code you added.
*/