using System;

namespace ConcatTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n**** THIS PROGRAM CONCATENTATES .TXT FILES ****\n");
                
            Console.WriteLine("\nPlease enter the path of the source directory: ");

            string path = Console.ReadLine();

            Play play = new Play();
            play.Go(path);

            
            Console.WriteLine("\n\n**** PROGRAM COMPLETE. PRESS ENTER TO FINISH. ****");
            Console.ReadLine();


        }
    }
}
