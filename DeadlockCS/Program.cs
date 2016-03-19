/*
 * Jason Brown 
 * 17 March, 2016
 * OS Theory - Assignment 9 - Deadlock
 * Professor Gordon
 * 
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
        static int sleepTime = 1000;

        static readonly object resource_A = new Object();
        static readonly object resource_B = new Object();
        static readonly object resource_C = new Object();
        static readonly object resource_D = new Object();
        static readonly object resource_E = new Object();
        static readonly object resource_F = new Object();

        static void P0()
        {
            // Thread serialization
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
            Console.WriteLine("Hello Kitty!");

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
