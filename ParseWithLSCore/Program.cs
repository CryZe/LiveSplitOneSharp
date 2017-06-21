using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using static System.Console;
using System.Diagnostics;
using LiveSplitCore;

namespace ParseWithLSCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var segments = new SegmentList();

            segments.Push(new Segment("Hi"));
            segments.Push(new Segment("Okok"));

            var run = new Run(segments);

            run.SetGameName("Breath of the Wild");
            run.SetCategoryName("Any%");

            var timer = new Timer(run);

            timer.Split();

            System.Threading.Thread.Sleep(500);

            timer.Split();

            System.Threading.Thread.Sleep(500);

            timer.Split();
            timer.Reset(true);

            File.WriteAllText("splits.lss", timer.GetRun().SaveAsLss());
        }
    }
}
