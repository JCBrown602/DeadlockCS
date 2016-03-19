/*
 * Jason Brown 
 * 17 March, 2016
 * OS Theory - Assignment 9 - Deadlock
 * Professor Gordon
 * 
 * This program doesn't cause deadlock due to use of threads for each set of
 * "critical" instructions. Each thread (P0, P1, and P2) uses different resource 
 * objects (A through F). Some overlap but a deadlock is prevented by locking
 * the resource object to that particular thread until the code using it is
 * finished. In this case, it's just a thread timer and console output.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace DeadlockCS
{
    class Program
    {
        // Simulates the thread actually doing something with each resource.
        static int sleepTime = 1000;

        static readonly object resource_A = new Object();
        static readonly object resource_B = new Object();
        static readonly object resource_C = new Object();
        static readonly object resource_D = new Object();
        static readonly object resource_E = new Object();
        static readonly object resource_F = new Object();

        // Thread 1 - labeled P0 in the assignment
        static void P0()
        {
            // Thread serialization
            // Once the "critical code" - Thread.Sleep() - is finished, the
            // resource is released automatically.
            lock (resource_A)
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine("Thread P0, Resource A: " + Environment.TickCount);
            }

            lock (resource_B)
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine("Thread P0, Resource B: " + Environment.TickCount);
            }

            lock (resource_C)
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine("Thread P0, Resource C: " + Environment.TickCount);
            }
        }

        // Thread 2 - labeled P1 in the assignment
        static void P1()
        {
            sleepTime += 100;

            lock (resource_A)
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine("Thread P1, Resource A: " + Environment.TickCount);
            }

            lock (resource_D)
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine("Thread P1, Resource D: " + Environment.TickCount);
            }

            lock (resource_E)
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine("Thread P1, Resource E: " + Environment.TickCount);
            }

            lock (resource_B)
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine("Thread P1, Resource B: " + Environment.TickCount);
            }
        }

        // Thread 3 - labeled P2 in the assignment
        static void P2()
        {
            sleepTime += 200;

            lock (resource_A)
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine("Thread P2, Resource A: " + Environment.TickCount);
            }

            lock (resource_C)
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine("Thread P2, Resource C: " + Environment.TickCount);
            }

            lock (resource_F)
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine("Thread P2, Resource F: " + Environment.TickCount);
            }

            lock (resource_D)
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine("Thread P2, Resource D: " + Environment.TickCount);
            }
        }

        static void Main(string[] args)
        {
            // Create and start the threads
            Thread thread_P0 = new Thread(new ThreadStart(P0));
            Thread thread_P1 = new Thread(new ThreadStart(P1));
            Thread thread_P2 = new Thread(new ThreadStart(P2));

            thread_P0.Start();
            thread_P1.Start();
            thread_P2.Start();

            thread_P0.Join();
            thread_P1.Join();
            thread_P2.Join();
        }
    }
}
