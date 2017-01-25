using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LiveSplitOneSharp
{
    class LiveSplitCoreNative
    {
        [DllImport("livesplit-core.dll")]
        public static extern IntPtr Segment_new(string segmentName);

        [DllImport("livesplit-core.dll")]
        public static extern IntPtr SegmentList_new();
        [DllImport("livesplit-core.dll")]
        public static extern void SegmentList_push(IntPtr self, IntPtr segment);

        [DllImport("livesplit-core.dll")]
        public static extern IntPtr Run_new(IntPtr segments);
        [DllImport("livesplit-core.dll")]
        public static extern IntPtr Run_parse(IntPtr data, IntPtr length);
        [DllImport("livesplit-core.dll")]
        public static extern void Run_set_game(IntPtr self, string name);
        [DllImport("livesplit-core.dll")]
        public static extern void Run_set_category(IntPtr self, string name);

        [DllImport("livesplit-core.dll")]
        public static extern IntPtr Timer_new(IntPtr run);
        [DllImport("livesplit-core.dll")]
        public static extern void Timer_drop(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern void Timer_start(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern void Timer_split(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern void Timer_skip_split(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern void Timer_undo_split(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern void Timer_reset(IntPtr self, bool updateSplits);
        [DllImport("livesplit-core.dll")]
        public static extern void Timer_pause(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern byte Timer_current_timing_method(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern void Timer_set_current_timing_method(IntPtr self, byte method);
        [DllImport("livesplit-core.dll")]
        public static extern LSCoreString Timer_current_comparison(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern LSCoreString Timer_switch_to_next_comparison(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern LSCoreString Timer_switch_to_previous_comparison(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern void Timer_print_debug(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern LSCoreString Timer_save_run_as_lss(IntPtr self);

        [DllImport("livesplit-core.dll")]
        public static extern IntPtr TimerComponent_new();
        [DllImport("livesplit-core.dll")]
        public static extern void TimerComponent_drop(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern LSCoreString TimerComponent_state(IntPtr self, IntPtr timer);

        [DllImport("livesplit-core.dll")]
        public static extern IntPtr TitleComponent_new();
        [DllImport("livesplit-core.dll")]
        public static extern void TitleComponent_drop(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern LSCoreString TitleComponent_state(IntPtr self, IntPtr timer);

        [DllImport("livesplit-core.dll")]
        public static extern IntPtr SplitsComponent_new();
        [DllImport("livesplit-core.dll")]
        public static extern void SplitsComponent_drop(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern LSCoreString SplitsComponent_state(IntPtr self, IntPtr timer);
        [DllImport("livesplit-core.dll")]
        public static extern void SplitsComponent_scroll_up(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern void SplitsComponent_scroll_down(IntPtr self);

        [DllImport("livesplit-core.dll")]
        public static extern IntPtr PreviousSegmentComponent_new();
        [DllImport("livesplit-core.dll")]
        public static extern void PreviousSegmentComponent_drop(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern LSCoreString PreviousSegmentComponent_state(IntPtr self, IntPtr timer);

        [DllImport("livesplit-core.dll")]
        public static extern IntPtr SumOfBestComponent_new();
        [DllImport("livesplit-core.dll")]
        public static extern void SumOfBestComponent_drop(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern LSCoreString SumOfBestComponent_state(IntPtr self, IntPtr timer);

        [DllImport("livesplit-core.dll")]
        public static extern IntPtr PossibleTimeSaveComponent_new();
        [DllImport("livesplit-core.dll")]
        public static extern void PossibleTimeSaveComponent_drop(IntPtr self);
        [DllImport("livesplit-core.dll")]
        public static extern LSCoreString PossibleTimeSaveComponent_state(IntPtr self, IntPtr timer);
    }

    internal class LSCoreString : SafeHandle
    {
        public LSCoreString() : base(IntPtr.Zero, false) { }

        public override bool IsInvalid
        {
            get { return false; }
        }

        public string AsString()
        {
            int len = 0;
            while (Marshal.ReadByte(handle, len) != 0) { ++len; }
            byte[] buffer = new byte[len];
            Marshal.Copy(handle, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        protected override bool ReleaseHandle()
        {
            return true;
        }
    }

    class Segment: SafeHandle
    {
        public Segment(string name): base(LiveSplitCoreNative.Segment_new(name), true) { }

        public override bool IsInvalid
        {
            get { return false; }
        }
    
        protected override bool ReleaseHandle()
        {
            return true;
        }
    }

    class SegmentList : SafeHandle
    {
        public SegmentList(): base(LiveSplitCoreNative.SegmentList_new(), true) { }

        public override bool IsInvalid
        {
            get { return false; }
        }

        protected override bool ReleaseHandle()
        {
            return true;
        }

        public void Push(Segment segment)
        {
            LiveSplitCoreNative.SegmentList_push(handle, segment.DangerousGetHandle());
            segment.SetHandleAsInvalid();
        }
    }

    class Run : SafeHandle
    {
        public Run(SegmentList segments) : base(LiveSplitCoreNative.Run_new(segments.DangerousGetHandle()), true) {
            segments.SetHandleAsInvalid();
        }

        private static IntPtr parse(string splits)
        {
            var bytes = Encoding.UTF8.GetBytes(splits);
            IntPtr pnt = Marshal.AllocHGlobal(bytes.Length);
            try
            {
                Marshal.Copy(bytes, 0, pnt, bytes.Length);
                return LiveSplitCoreNative.Run_parse(pnt, (IntPtr)bytes.Length);
            }
            finally
            {
                Marshal.FreeHGlobal(pnt);
            }
        } 

        public Run(string splits) : base(parse(splits), true) { }

        public override bool IsInvalid
        {
            get { return false; }
        }

        protected override bool ReleaseHandle()
        {
            return true;
        }

        public string GameName
        {
            set
            {
                LiveSplitCoreNative.Run_set_game(handle, value);
            }
        }

        public string CategoryName
        {
            set
            {
                LiveSplitCoreNative.Run_set_category(handle, value);
            }
        }
    }

    class Timer : SafeHandle
    {
        public Timer(Run run) : base(LiveSplitCoreNative.Timer_new(run.DangerousGetHandle()), true)
        {
            run.SetHandleAsInvalid();
        }

        public override bool IsInvalid
        {
            get { return false; }
        }

        protected override bool ReleaseHandle()
        {
            LiveSplitCoreNative.Timer_drop(handle);
            return true;
        }

        public void Start()
        {
            LiveSplitCoreNative.Timer_start(handle);
        }

        public void Split()
        {
            LiveSplitCoreNative.Timer_split(handle);
        }

        public void SkipSplit()
        {
            LiveSplitCoreNative.Timer_skip_split(handle);
        }

        public void UndoSplit()
        {
            LiveSplitCoreNative.Timer_undo_split(handle);
        }

        public void Reset(bool updateSplits)
        {
            LiveSplitCoreNative.Timer_reset(handle, updateSplits);
        }

        public void Pause()
        {
            LiveSplitCoreNative.Timer_pause(handle);
        }

        public byte CurrentTimingMethod
        {
            get
            {
                return LiveSplitCoreNative.Timer_current_timing_method(handle);
            }
            set
            {
                LiveSplitCoreNative.Timer_set_current_timing_method(handle, value);
            }
        }

        public string CurrentComparison
        {
            get
            {
                return LiveSplitCoreNative.Timer_current_comparison(handle).AsString();
            }
        }

        public void SwitchToNextComparison()
        {
            LiveSplitCoreNative.Timer_switch_to_next_comparison(handle);
        }

        public void SwitchToPreviousComparison()
        {
            LiveSplitCoreNative.Timer_switch_to_previous_comparison(handle);
        }

        public void PrintDebug()
        {
            LiveSplitCoreNative.Timer_print_debug(handle);
        }

        public string SaveAsLSS()
        {
            return LiveSplitCoreNative.Timer_save_run_as_lss(handle).AsString();
        }
    }

    class TimerComponent : SafeHandle
    {
        public TimerComponent() : base(LiveSplitCoreNative.TimerComponent_new(), true) { }

        public override bool IsInvalid
        {
            get { return false; }
        }

        protected override bool ReleaseHandle()
        {
            LiveSplitCoreNative.TimerComponent_drop(handle);
            return true;
        }

        public string GetState(Timer timer)
        {
            return LiveSplitCoreNative.TimerComponent_state(handle, timer.DangerousGetHandle()).AsString();
        }
    }

    class TitleComponent : SafeHandle
    {
        public TitleComponent() : base(LiveSplitCoreNative.TitleComponent_new(), true) { }

        public override bool IsInvalid
        {
            get { return false; }
        }

        protected override bool ReleaseHandle()
        {
            LiveSplitCoreNative.TitleComponent_drop(handle);
            return true;
        }

        public string GetState(Timer timer)
        {
            return LiveSplitCoreNative.TitleComponent_state(handle, timer.DangerousGetHandle()).AsString();
        }
    }

    class SplitsComponent : SafeHandle
    {
        public SplitsComponent() : base(LiveSplitCoreNative.SplitsComponent_new(), true) { }

        public override bool IsInvalid
        {
            get { return false; }
        }

        protected override bool ReleaseHandle()
        {
            LiveSplitCoreNative.SplitsComponent_drop(handle);
            return true;
        }

        public string GetState(Timer timer)
        {
            return LiveSplitCoreNative.SplitsComponent_state(handle, timer.DangerousGetHandle()).AsString();
        }
    }

    class PreviousSegmentComponent : SafeHandle
    {
        public PreviousSegmentComponent() : base(LiveSplitCoreNative.PreviousSegmentComponent_new(), true) { }

        public override bool IsInvalid
        {
            get { return false; }
        }

        protected override bool ReleaseHandle()
        {
            LiveSplitCoreNative.PreviousSegmentComponent_drop(handle);
            return true;
        }

        public string GetState(Timer timer)
        {
            return LiveSplitCoreNative.PreviousSegmentComponent_state(handle, timer.DangerousGetHandle()).AsString();
        }
    }

    class SumOfBestComponent : SafeHandle
    {
        public SumOfBestComponent() : base(LiveSplitCoreNative.SumOfBestComponent_new(), true) { }

        public override bool IsInvalid
        {
            get { return false; }
        }

        protected override bool ReleaseHandle()
        {
            LiveSplitCoreNative.SumOfBestComponent_drop(handle);
            return true;
        }

        public string GetState(Timer timer)
        {
            return LiveSplitCoreNative.SumOfBestComponent_state(handle, timer.DangerousGetHandle()).AsString();
        }
    }

    class PossibleTimeSaveComponent : SafeHandle
    {
        public PossibleTimeSaveComponent() : base(LiveSplitCoreNative.PossibleTimeSaveComponent_new(), true) { }

        public override bool IsInvalid
        {
            get { return false; }
        }

        protected override bool ReleaseHandle()
        {
            LiveSplitCoreNative.PossibleTimeSaveComponent_drop(handle);
            return true;
        }

        public string GetState(Timer timer)
        {
            return LiveSplitCoreNative.PossibleTimeSaveComponent_state(handle, timer.DangerousGetHandle()).AsString();
        }
    }
}
