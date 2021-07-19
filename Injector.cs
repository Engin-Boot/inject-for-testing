using System;

namespace DependencyInjection
{
    interface IManualOutput
    {
        void printALine(string line);
    }
    class ManualOnConsole: IManualOutput
    {
        public void printALine(string line) {
            Console.WriteLine(line);
        }
    }
    class ManualContentGrabber : IManualOutput
    {
        public string heading;
        public string content;
        public void printALine(string line) {
            if (heading == null) {
                heading = line;
            } else {
                content = line;
            }
        }
    }
    class DependencyInjector
    {
        static void PrintManual(IManualOutput destination) {
            destination.printALine("Color-Pair    Number");
            destination.printALine("White-Blue       1  ");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("-------------\n* Printing to console");
            PrintManual(new ManualOnConsole());
            Console.WriteLine("-------------");
            Console.WriteLine("* Testing the content");
            var grabber = new ManualContentGrabber();
            PrintManual(grabber);
            Console.WriteLine("Assert the heading here: " + grabber.heading);
            Console.WriteLine("Assert this content: " + grabber.content);
        }
    }
}
