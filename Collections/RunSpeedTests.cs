using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Collections
{
    public static class RunSpeedTests
    {
        public static int maxElements = 75000;

        public static void ArrayIntSpeedTest(List<SpeedTest> speed)
        {
            int TestNumber = 1;
            //-- Create list of 50K integers and then randomly look them up
            Stopwatch timePerParse;

            Random r = new Random();
            int[] intSpeedTest = new int[maxElements];

            //  insert speed test
            timePerParse = Stopwatch.StartNew();
            int rInt = 0;
            for (int i = 0; i < maxElements; ++i)
            {
                rInt = r.Next(0, maxElements);
                intSpeedTest[i] = rInt;
            }
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Insert {maxElements} elements to Array", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            //  index retrieve speed test
            timePerParse = Stopwatch.StartNew();
            for (int i = 0; i < maxElements; ++i)
            {
                rInt = intSpeedTest[i];
            }
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Index retrieve {maxElements} elements from Array", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            //  Enumerate speed test
            timePerParse = Stopwatch.StartNew();
            foreach (int i in intSpeedTest)
            {
                rInt = i;
            }
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Enumerate retrieve {maxElements} elements from Array", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            //  LINQ speed test
            timePerParse = Stopwatch.StartNew();
            List<int> linqValues = (from v in intSpeedTest select v).ToList();
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"LINQ retrieve {maxElements} elements from Array", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            // Find by Key test. NOTE: This is the same as "index" retrieve because the index IS the key
            timePerParse = Stopwatch.StartNew();
            for (int i = 0; i < maxElements; ++i)
            {
                rInt = intSpeedTest[i];
            }
            timePerParse.Stop(); timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Find by key retrieve {maxElements} elements from Array", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });
        }

        public static void ListIntSpeedTest(List<SpeedTest> speed)
        {
            int TestNumber = 1;
            //-- Create list of 50K integers and then randomly look them up
            Stopwatch timePerParse;

            Random r = new Random();
            List<int> intSpeedTest = new List<int>();

            //  insert speed test
            timePerParse = Stopwatch.StartNew();
            int rInt = 0;
            for (int i = 0; i < maxElements; ++i)
            {
                rInt = r.Next(0, maxElements);
                intSpeedTest.Add(rInt);
            }
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Insert {maxElements} elements to List<>", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            //  index retrieve speed test
            timePerParse = Stopwatch.StartNew();
            for (int i = 0; i < maxElements; ++i)
            {
                rInt = intSpeedTest[i];
            }
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Index retrieve {maxElements} elements from List<>", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            //  Enumerate speed test
            timePerParse = Stopwatch.StartNew();
            foreach (int i in intSpeedTest)
            {
                rInt = i;
            }
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Enumerate retrieve {maxElements} elements from List<>", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            //  LINQ speed test
            timePerParse = Stopwatch.StartNew();
            List<int> linqValues = (from v in intSpeedTest select v).ToList();
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"LINQ retrieve {maxElements} elements from List<>", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            // Find by Key test. NOTE: This is the same as "index" retrieve because the index IS the key
            timePerParse = Stopwatch.StartNew();
            for (int i = 0; i < maxElements; ++i)
            {
                rInt = intSpeedTest[i];
            }
            timePerParse.Stop(); timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Find by key retrieve {maxElements} elements from List<>", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

        }

        public static void DictionaryIntSpeedTest(List<SpeedTest> speed)
        {
            int TestNumber = 1;
            //-- Create Dictionary of 50K integers and then randomly look them up
            Stopwatch timePerParse;

            Random r = new Random();
            Dictionary<int, int> intSpeedTest = new Dictionary<int, int>();

            //  insert speed test
            timePerParse = Stopwatch.StartNew();
            int rInt = 0;
            for (int i = 0; i < maxElements; ++i)
            {
                rInt = r.Next(0, maxElements);
                intSpeedTest.Add(i, rInt);
            }
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Insert {maxElements} elements to Dictionary<int, int>", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            //  index retrieve speed test
            timePerParse = Stopwatch.StartNew();
            for (int i = 0; i < maxElements; ++i)
            {
                rInt = intSpeedTest.ElementAt(i).Value;
            }
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Index retrieve {maxElements} elements from Dictionary<int, int>", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            //  Enumerate speed test
            timePerParse = Stopwatch.StartNew();
            foreach (KeyValuePair<int, int> i in intSpeedTest)
            {
                rInt = i.Value;
            }
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Enumerate retrieve {maxElements} elements from Dictionary<int, int>", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            //  LINQ speed test
            timePerParse = Stopwatch.StartNew();
            List<int> linqValues = (from v in intSpeedTest.Values select v).ToList();
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"LINQ retrieve {maxElements} elements from Dictionary<int, int>", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });


            // Find by Key test. 
            timePerParse = Stopwatch.StartNew();
            foreach (int i in intSpeedTest.Keys)
            {
                rInt = intSpeedTest[i];
            }
            timePerParse.Stop(); timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Find by key retrieve {maxElements} elements from Dictionary<int, int>", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

        }

        public static void HashtableIntSpeedTest(List<SpeedTest> speed)
        {
            int TestNumber = 1;
            //-- Create Hashtable of 50K integers and then randomly look them up
            Stopwatch timePerParse;

            Random r = new Random();
            Hashtable intSpeedTest = new Hashtable();

            //  insert speed test
            timePerParse = Stopwatch.StartNew();
            int rInt = 0;
            for (int i = 0; i < maxElements; ++i)
            {
                rInt = r.Next(0, maxElements);
                intSpeedTest.Add(i, rInt);
            }
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Insert {maxElements} elements to Hashtable", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            // index retrieve speed test
            timePerParse = Stopwatch.StartNew();
            for (int i = 0; i < maxElements; ++i)
            {
                rInt = (int)intSpeedTest[i];
            }
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Index retrieve {maxElements} elements from Hashtable", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            //  Enumerate speed test
            timePerParse = Stopwatch.StartNew();
            foreach (DictionaryEntry i in intSpeedTest)
            {
                rInt = (int)i.Value;
            }
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Enumerate retrieve {maxElements} elements from Hashtable", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            //  LINQ speed test
            timePerParse = Stopwatch.StartNew();
            List<int> linqValues = (from v in intSpeedTest.Values.Cast<int>() select v).ToList();
            timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"LINQ retrieve {maxElements} elements from Hashtable", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });

            // Find by Key test. 
            timePerParse = Stopwatch.StartNew();
            foreach (int i in intSpeedTest.Keys)
            {
                rInt = (int)intSpeedTest[i];
            }
            timePerParse.Stop(); timePerParse.Stop();
            speed.Add(new SpeedTest { TestType = $"Find by key retrieve {maxElements} elements from Hashtable", TotalTicks = timePerParse.ElapsedTicks, TestNumber = TestNumber++ });
        }

    }

    public class SpeedTest
    {
        public string TestType { get; set; }
        public int TestNumber { get; set; }
        public long TotalTicks { get; set; }
    }


}
