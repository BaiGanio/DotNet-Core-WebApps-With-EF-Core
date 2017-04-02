using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class AsyncAndAwait
    {
        static void Main()
        {
	    /* Check how much cores are in the processor */
            int processors = Environment.ProcessorCount;
            Console.WriteLine(processors);
			
            Console.WriteLine("This is 'async' and 'await' demo:");

            var worker = new Worker();
            worker.DoSomeWork(); // SayHello(); ConcatenateWords();

            while (!worker.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine("The demo finished with the example!");
            Console.WriteLine("Bye bye ;)");

        }
    }

    public class Worker
    {
        public bool IsCompleted { get; set; }

        public async void DoSomeWork()
        {
            this.IsCompleted = false;

            Console.WriteLine("Start working!");

            await LongDoingWork();

            Console.WriteLine();
            Console.WriteLine("The work is done!");

            this.IsCompleted = true;

        }

        private Task LongDoingWork()
        {
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Still doing some calculations!");
                Thread.Sleep(10000);
            });
        }

    }

}
