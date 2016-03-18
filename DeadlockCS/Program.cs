/*
 * Jason Brown 
 * 17 March, 2016
 * OS Theory - Assignment 9 - Deadlock
 * Professor Gordon
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DeadlockCS
{
    class Resource
    {
        // Properties
        private static int numUses;
        private static object _lockingObject = new object();

        // Methods
        public void useResource()
        {
            lock (_lockingObject)
            {
                Thread.Sleep(100);
                numUses += 1;
                Console.WriteLine("USING RESOURCE: {0}, NUMBER of USES: {1}", Environment.TickCount, numUses);
            }
        }
    }

    class Program
    {
        static readonly object resource_A = new Object();
        static readonly object resource_B = new Object();

        static void A()
        {
            // Thread serialization
            lock (resource_A)
            {
                Thread.Sleep(100);
                Console.WriteLine("Thread A: " + Environment.TickCount);
            }
        }

        static void B()
        {
            lock (resource_B)
            {
                Thread.Sleep(100);
                Console.WriteLine("Thread B: " + Environment.TickCount);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Kitty!");

            Resource resource_A = new Resource();

            for (int i = 0; i < 10; i++)
            {
                ThreadStart start_A = new ThreadStart(A);

                ThreadStart start_R = new ThreadStart(resource_A.useResource);
                ThreadStart start_S = new ThreadStart(resource_A.useResource);

                new Thread(start_A).Start();

                new Thread(start_R).Start();
                new Thread(start_S).Start();
            }
        }
    }
}
