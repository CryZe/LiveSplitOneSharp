using System;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

namespace LiveSplitCore
{
    public class AttemptRef
    {
        internal IntPtr ptr;
        public int Index()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Attempt_index(this.ptr);
            return result;
        }
        public TimeRef Time()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimeRef(LiveSplitCoreNative.Attempt_time(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal AttemptRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class AttemptRefMut : AttemptRef
    {
        internal AttemptRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class Attempt : AttemptRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                ptr = IntPtr.Zero;
            }
        }
        ~Attempt()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal Attempt(IntPtr ptr) : base(ptr) { }
    }

    public class GraphComponentRef
    {
        internal IntPtr ptr;
        public string StateAsJson(TimerRef timer)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (timer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("timer");
            }
            var result = LiveSplitCoreNative.GraphComponent_state_as_json(this.ptr, timer.ptr).AsString();
            return result;
        }
        public GraphComponentState State(TimerRef timer)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (timer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("timer");
            }
            var result = new GraphComponentState(LiveSplitCoreNative.GraphComponent_state(this.ptr, timer.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal GraphComponentRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class GraphComponentRefMut : GraphComponentRef
    {
        internal GraphComponentRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class GraphComponent : GraphComponentRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.GraphComponent_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~GraphComponent()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        public GraphComponent() : base(IntPtr.Zero)
        {
            this.ptr = LiveSplitCoreNative.GraphComponent_new();
        }
        internal GraphComponent(IntPtr ptr) : base(ptr) { }
    }

    public class GraphComponentStateRef
    {
        internal IntPtr ptr;
        public long PointsLen()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = (long)LiveSplitCoreNative.GraphComponentState_points_len(this.ptr);
            return result;
        }
        public float PointX(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.GraphComponentState_point_x(this.ptr, (UIntPtr)index);
            return result;
        }
        public float PointY(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.GraphComponentState_point_y(this.ptr, (UIntPtr)index);
            return result;
        }
        public long HorizontalGridLinesLen()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = (long)LiveSplitCoreNative.GraphComponentState_horizontal_grid_lines_len(this.ptr);
            return result;
        }
        public float HorizontalGridLine(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.GraphComponentState_horizontal_grid_line(this.ptr, (UIntPtr)index);
            return result;
        }
        public long VerticalGridLinesLen()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = (long)LiveSplitCoreNative.GraphComponentState_vertical_grid_lines_len(this.ptr);
            return result;
        }
        public float VerticalGridLine(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.GraphComponentState_vertical_grid_line(this.ptr, (UIntPtr)index);
            return result;
        }
        public float Middle()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.GraphComponentState_middle(this.ptr);
            return result;
        }
        internal GraphComponentStateRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class GraphComponentStateRefMut : GraphComponentStateRef
    {
        internal GraphComponentStateRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class GraphComponentState : GraphComponentStateRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.GraphComponentState_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~GraphComponentState()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal GraphComponentState(IntPtr ptr) : base(ptr) { }
    }

    public class HotkeySystemRef
    {
        internal IntPtr ptr;
        internal HotkeySystemRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class HotkeySystemRefMut : HotkeySystemRef
    {
        internal HotkeySystemRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class HotkeySystem : HotkeySystemRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.HotkeySystem_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~HotkeySystem()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        public HotkeySystem(SharedTimer sharedTimer) : base(IntPtr.Zero)
        {
            if (sharedTimer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("sharedTimer");
            }
            this.ptr = LiveSplitCoreNative.HotkeySystem_new(sharedTimer.ptr);
            sharedTimer.ptr = IntPtr.Zero;
        }
        internal HotkeySystem(IntPtr ptr) : base(ptr) { }
    }

    public class PossibleTimeSaveComponentRef
    {
        internal IntPtr ptr;
        public string StateAsJson(TimerRef timer)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (timer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("timer");
            }
            var result = LiveSplitCoreNative.PossibleTimeSaveComponent_state_as_json(this.ptr, timer.ptr).AsString();
            return result;
        }
        public PossibleTimeSaveComponentState State(TimerRef timer)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (timer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("timer");
            }
            var result = new PossibleTimeSaveComponentState(LiveSplitCoreNative.PossibleTimeSaveComponent_state(this.ptr, timer.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal PossibleTimeSaveComponentRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class PossibleTimeSaveComponentRefMut : PossibleTimeSaveComponentRef
    {
        internal PossibleTimeSaveComponentRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class PossibleTimeSaveComponent : PossibleTimeSaveComponentRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.PossibleTimeSaveComponent_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~PossibleTimeSaveComponent()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        public PossibleTimeSaveComponent() : base(IntPtr.Zero)
        {
            this.ptr = LiveSplitCoreNative.PossibleTimeSaveComponent_new();
        }
        internal PossibleTimeSaveComponent(IntPtr ptr) : base(ptr) { }
    }

    public class PossibleTimeSaveComponentStateRef
    {
        internal IntPtr ptr;
        public string Text()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.PossibleTimeSaveComponentState_text(this.ptr).AsString();
            return result;
        }
        public string Time()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.PossibleTimeSaveComponentState_time(this.ptr).AsString();
            return result;
        }
        internal PossibleTimeSaveComponentStateRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class PossibleTimeSaveComponentStateRefMut : PossibleTimeSaveComponentStateRef
    {
        internal PossibleTimeSaveComponentStateRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class PossibleTimeSaveComponentState : PossibleTimeSaveComponentStateRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.PossibleTimeSaveComponentState_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~PossibleTimeSaveComponentState()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal PossibleTimeSaveComponentState(IntPtr ptr) : base(ptr) { }
    }

    public class PreviousSegmentComponentRef
    {
        internal IntPtr ptr;
        public string StateAsJson(TimerRef timer)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (timer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("timer");
            }
            var result = LiveSplitCoreNative.PreviousSegmentComponent_state_as_json(this.ptr, timer.ptr).AsString();
            return result;
        }
        public PreviousSegmentComponentState State(TimerRef timer)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (timer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("timer");
            }
            var result = new PreviousSegmentComponentState(LiveSplitCoreNative.PreviousSegmentComponent_state(this.ptr, timer.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal PreviousSegmentComponentRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class PreviousSegmentComponentRefMut : PreviousSegmentComponentRef
    {
        internal PreviousSegmentComponentRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class PreviousSegmentComponent : PreviousSegmentComponentRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.PreviousSegmentComponent_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~PreviousSegmentComponent()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        public PreviousSegmentComponent() : base(IntPtr.Zero)
        {
            this.ptr = LiveSplitCoreNative.PreviousSegmentComponent_new();
        }
        internal PreviousSegmentComponent(IntPtr ptr) : base(ptr) { }
    }

    public class PreviousSegmentComponentStateRef
    {
        internal IntPtr ptr;
        public string Text()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.PreviousSegmentComponentState_text(this.ptr).AsString();
            return result;
        }
        public string Time()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.PreviousSegmentComponentState_time(this.ptr).AsString();
            return result;
        }
        internal PreviousSegmentComponentStateRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class PreviousSegmentComponentStateRefMut : PreviousSegmentComponentStateRef
    {
        internal PreviousSegmentComponentStateRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class PreviousSegmentComponentState : PreviousSegmentComponentStateRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.PreviousSegmentComponentState_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~PreviousSegmentComponentState()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal PreviousSegmentComponentState(IntPtr ptr) : base(ptr) { }
    }

    public class RunRef
    {
        internal IntPtr ptr;
        public string GameName()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Run_game_name(this.ptr).AsString();
            return result;
        }
        public string GameIcon()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Run_game_icon(this.ptr).AsString();
            return result;
        }
        public string CategoryName()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Run_category_name(this.ptr).AsString();
            return result;
        }
        public string ExtendedFileName(bool useExtendedCategoryName)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Run_extended_file_name(this.ptr, useExtendedCategoryName).AsString();
            return result;
        }
        public string ExtendedName(bool useExtendedCategoryName)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Run_extended_name(this.ptr, useExtendedCategoryName).AsString();
            return result;
        }
        public string ExtendedCategoryName(bool showRegion, bool showPlatform, bool showVariables)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Run_extended_category_name(this.ptr, showRegion, showPlatform, showVariables).AsString();
            return result;
        }
        public uint AttemptCount()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Run_attempt_count(this.ptr);
            return result;
        }
        public RunMetadataRef Metadata()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new RunMetadataRef(LiveSplitCoreNative.Run_metadata(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public TimeSpanRef Offset()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimeSpanRef(LiveSplitCoreNative.Run_offset(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public long Len()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = (long)LiveSplitCoreNative.Run_len(this.ptr);
            return result;
        }
        public SegmentRef Segment(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new SegmentRef(LiveSplitCoreNative.Run_segment(this.ptr, (UIntPtr)index));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public long AttemptHistoryLen()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = (long)LiveSplitCoreNative.Run_attempt_history_len(this.ptr);
            return result;
        }
        public AttemptRef AttemptHistoryIndex(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new AttemptRef(LiveSplitCoreNative.Run_attempt_history_index(this.ptr, (UIntPtr)index));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public string SaveAsLss()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Run_save_as_lss(this.ptr).AsString();
            return result;
        }
        internal RunRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class RunRefMut : RunRef
    {
        public void PushSegment(Segment segment)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (segment.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("segment");
            }
            LiveSplitCoreNative.Run_push_segment(this.ptr, segment.ptr);
            segment.ptr = IntPtr.Zero;
        }
        public void SetGameName(string game)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Run_set_game_name(this.ptr, game);
        }
        public void SetCategoryName(string category)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Run_set_category_name(this.ptr, category);
        }
        internal RunRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class Run : RunRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.Run_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~Run()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        public Run() : base(IntPtr.Zero)
        {
            this.ptr = LiveSplitCoreNative.Run_new();
        }
        public static Run Parse(IntPtr data, long length)
        {
            var result = new Run(LiveSplitCoreNative.Run_parse(data, (UIntPtr)length));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public static Run Parse(Stream stream)
        {
            var data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            IntPtr pnt = Marshal.AllocHGlobal(data.Length);
            try
            {
                Marshal.Copy(data, 0, pnt, data.Length);
                return Parse(pnt, data.Length);
            }
            finally
            {
                Marshal.FreeHGlobal(pnt);
            }
        }
        internal Run(IntPtr ptr) : base(ptr) { }
    }

    public class RunEditorRef
    {
        internal IntPtr ptr;
        internal RunEditorRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class RunEditorRefMut : RunEditorRef
    {
        public string StateAsJson()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.RunEditor_state_as_json(this.ptr).AsString();
            return result;
        }
        public void SelectTimingMethod(byte method)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.RunEditor_select_timing_method(this.ptr, method);
        }
        public void Unselect(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.RunEditor_unselect(this.ptr, (UIntPtr)index);
        }
        public void SelectAdditionally(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.RunEditor_select_additionally(this.ptr, (UIntPtr)index);
        }
        public void SelectOnly(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.RunEditor_select_only(this.ptr, (UIntPtr)index);
        }
        public void SetGameName(string game)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.RunEditor_set_game_name(this.ptr, game);
        }
        public void SetCategoryName(string category)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.RunEditor_set_category_name(this.ptr, category);
        }
        public bool ParseAndSetOffset(string offset)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.RunEditor_parse_and_set_offset(this.ptr, offset) != 0;
            return result;
        }
        public bool ParseAndSetAttemptCount(string attempts)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.RunEditor_parse_and_set_attempt_count(this.ptr, attempts) != 0;
            return result;
        }
        public void SetGameIcon(IntPtr data, long length)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.RunEditor_set_game_icon(this.ptr, data, (UIntPtr)length);
        }
        public void InsertSegmentAbove()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.RunEditor_insert_segment_above(this.ptr);
        }
        public void InsertSegmentBelow()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.RunEditor_insert_segment_below(this.ptr);
        }
        public void RemoveSegments()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.RunEditor_remove_segments(this.ptr);
        }
        public void MoveSegmentsUp()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.RunEditor_move_segments_up(this.ptr);
        }
        public void MoveSegmentsDown()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.RunEditor_move_segments_down(this.ptr);
        }
        public void SelectedSetIcon(IntPtr data, long length)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.RunEditor_selected_set_icon(this.ptr, data, (UIntPtr)length);
        }
        public void SelectedSetName(string name)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.RunEditor_selected_set_name(this.ptr, name);
        }
        public bool SelectedParseAndSetSplitTime(string time)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.RunEditor_selected_parse_and_set_split_time(this.ptr, time) != 0;
            return result;
        }
        public bool SelectedParseAndSetSegmentTime(string time)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.RunEditor_selected_parse_and_set_segment_time(this.ptr, time) != 0;
            return result;
        }
        public bool SelectedParseAndSetBestSegmentTime(string time)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.RunEditor_selected_parse_and_set_best_segment_time(this.ptr, time) != 0;
            return result;
        }
        public bool SelectedParseAndSetComparisonTime(string comparison, string time)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.RunEditor_selected_parse_and_set_comparison_time(this.ptr, comparison, time) != 0;
            return result;
        }
        internal RunEditorRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class RunEditor : RunEditorRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                ptr = IntPtr.Zero;
            }
        }
        ~RunEditor()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        public RunEditor(Run run) : base(IntPtr.Zero)
        {
            if (run.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("run");
            }
            this.ptr = LiveSplitCoreNative.RunEditor_new(run.ptr);
            run.ptr = IntPtr.Zero;
        }
        public Run Close()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new Run(LiveSplitCoreNative.RunEditor_close(this.ptr));
            this.ptr = IntPtr.Zero;
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal RunEditor(IntPtr ptr) : base(ptr) { }
    }

    public class RunMetadataRef
    {
        internal IntPtr ptr;
        public string RunId()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.RunMetadata_run_id(this.ptr).AsString();
            return result;
        }
        public string PlatformName()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.RunMetadata_platform_name(this.ptr).AsString();
            return result;
        }
        public bool UsesEmulator()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.RunMetadata_uses_emulator(this.ptr) != 0;
            return result;
        }
        public string RegionName()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.RunMetadata_region_name(this.ptr).AsString();
            return result;
        }
        internal RunMetadataRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class RunMetadataRefMut : RunMetadataRef
    {
        internal RunMetadataRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class RunMetadata : RunMetadataRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                ptr = IntPtr.Zero;
            }
        }
        ~RunMetadata()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal RunMetadata(IntPtr ptr) : base(ptr) { }
    }

    public class SegmentRef
    {
        internal IntPtr ptr;
        public string Name()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Segment_name(this.ptr).AsString();
            return result;
        }
        public string Icon()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Segment_icon(this.ptr).AsString();
            return result;
        }
        public TimeRef Comparison(string comparison)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimeRef(LiveSplitCoreNative.Segment_comparison(this.ptr, comparison));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public TimeRef PersonalBestSplitTime()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimeRef(LiveSplitCoreNative.Segment_personal_best_split_time(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public TimeRef BestSegmentTime()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimeRef(LiveSplitCoreNative.Segment_best_segment_time(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public SegmentHistoryRef SegmentHistory()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new SegmentHistoryRef(LiveSplitCoreNative.Segment_segment_history(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal SegmentRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class SegmentRefMut : SegmentRef
    {
        internal SegmentRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class Segment : SegmentRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.Segment_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~Segment()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        public Segment(string name) : base(IntPtr.Zero)
        {
            this.ptr = LiveSplitCoreNative.Segment_new(name);
        }
        internal Segment(IntPtr ptr) : base(ptr) { }
    }

    public class SegmentHistoryRef
    {
        internal IntPtr ptr;
        public SegmentHistoryIter Iter()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new SegmentHistoryIter(LiveSplitCoreNative.SegmentHistory_iter(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal SegmentHistoryRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class SegmentHistoryRefMut : SegmentHistoryRef
    {
        internal SegmentHistoryRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class SegmentHistory : SegmentHistoryRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                ptr = IntPtr.Zero;
            }
        }
        ~SegmentHistory()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal SegmentHistory(IntPtr ptr) : base(ptr) { }
    }

    public class SegmentHistoryElementRef
    {
        internal IntPtr ptr;
        public int Index()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.SegmentHistoryElement_index(this.ptr);
            return result;
        }
        public TimeRef Time()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimeRef(LiveSplitCoreNative.SegmentHistoryElement_time(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal SegmentHistoryElementRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class SegmentHistoryElementRefMut : SegmentHistoryElementRef
    {
        internal SegmentHistoryElementRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class SegmentHistoryElement : SegmentHistoryElementRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                ptr = IntPtr.Zero;
            }
        }
        ~SegmentHistoryElement()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal SegmentHistoryElement(IntPtr ptr) : base(ptr) { }
    }

    public class SegmentHistoryIterRef
    {
        internal IntPtr ptr;
        internal SegmentHistoryIterRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class SegmentHistoryIterRefMut : SegmentHistoryIterRef
    {
        public SegmentHistoryElementRef Next()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new SegmentHistoryElementRef(LiveSplitCoreNative.SegmentHistoryIter_next(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal SegmentHistoryIterRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class SegmentHistoryIter : SegmentHistoryIterRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.SegmentHistoryIter_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~SegmentHistoryIter()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal SegmentHistoryIter(IntPtr ptr) : base(ptr) { }
    }

    public class SharedTimerRef
    {
        internal IntPtr ptr;
        public SharedTimer Share()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new SharedTimer(LiveSplitCoreNative.SharedTimer_share(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public TimerReadLock Read()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimerReadLock(LiveSplitCoreNative.SharedTimer_read(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public TimerWriteLock Write()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimerWriteLock(LiveSplitCoreNative.SharedTimer_write(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public void ReadWith(Action<TimerRef> action)
        {
            using (var timerLock = Read())
            {
                action(timerLock.Timer());
            }
        }
        public void WriteWith(Action<TimerRefMut> action)
        {
            using (var timerLock = Write())
            {
                action(timerLock.Timer());
            }
        }
        internal SharedTimerRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class SharedTimerRefMut : SharedTimerRef
    {
        internal SharedTimerRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class SharedTimer : SharedTimerRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.SharedTimer_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~SharedTimer()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal SharedTimer(IntPtr ptr) : base(ptr) { }
    }

    public class SplitsComponentRef
    {
        internal IntPtr ptr;
        internal SplitsComponentRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class SplitsComponentRefMut : SplitsComponentRef
    {
        public string StateAsJson(TimerRef timer)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (timer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("timer");
            }
            var result = LiveSplitCoreNative.SplitsComponent_state_as_json(this.ptr, timer.ptr).AsString();
            return result;
        }
        public SplitsComponentState State(TimerRef timer)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (timer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("timer");
            }
            var result = new SplitsComponentState(LiveSplitCoreNative.SplitsComponent_state(this.ptr, timer.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public void ScrollUp()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.SplitsComponent_scroll_up(this.ptr);
        }
        public void ScrollDown()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.SplitsComponent_scroll_down(this.ptr);
        }
        internal SplitsComponentRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class SplitsComponent : SplitsComponentRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.SplitsComponent_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~SplitsComponent()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        public SplitsComponent() : base(IntPtr.Zero)
        {
            this.ptr = LiveSplitCoreNative.SplitsComponent_new();
        }
        internal SplitsComponent(IntPtr ptr) : base(ptr) { }
    }

    public class SplitsComponentStateRef
    {
        internal IntPtr ptr;
        public bool FinalSeparatorShown()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.SplitsComponentState_final_separator_shown(this.ptr) != 0;
            return result;
        }
        public long Len()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = (long)LiveSplitCoreNative.SplitsComponentState_len(this.ptr);
            return result;
        }
        public string IconChange(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.SplitsComponentState_icon_change(this.ptr, (UIntPtr)index).AsString();
            return result;
        }
        public string Name(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.SplitsComponentState_name(this.ptr, (UIntPtr)index).AsString();
            return result;
        }
        public string Delta(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.SplitsComponentState_delta(this.ptr, (UIntPtr)index).AsString();
            return result;
        }
        public string Time(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.SplitsComponentState_time(this.ptr, (UIntPtr)index).AsString();
            return result;
        }
        public string Color(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.SplitsComponentState_color(this.ptr, (UIntPtr)index).AsString();
            return result;
        }
        public bool IsCurrentSplit(long index)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.SplitsComponentState_is_current_split(this.ptr, (UIntPtr)index) != 0;
            return result;
        }
        internal SplitsComponentStateRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class SplitsComponentStateRefMut : SplitsComponentStateRef
    {
        internal SplitsComponentStateRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class SplitsComponentState : SplitsComponentStateRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.SplitsComponentState_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~SplitsComponentState()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal SplitsComponentState(IntPtr ptr) : base(ptr) { }
    }

    public class SumOfBestComponentRef
    {
        internal IntPtr ptr;
        public string StateAsJson(TimerRef timer)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (timer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("timer");
            }
            var result = LiveSplitCoreNative.SumOfBestComponent_state_as_json(this.ptr, timer.ptr).AsString();
            return result;
        }
        public SumOfBestComponentState State(TimerRef timer)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (timer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("timer");
            }
            var result = new SumOfBestComponentState(LiveSplitCoreNative.SumOfBestComponent_state(this.ptr, timer.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal SumOfBestComponentRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class SumOfBestComponentRefMut : SumOfBestComponentRef
    {
        internal SumOfBestComponentRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class SumOfBestComponent : SumOfBestComponentRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.SumOfBestComponent_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~SumOfBestComponent()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        public SumOfBestComponent() : base(IntPtr.Zero)
        {
            this.ptr = LiveSplitCoreNative.SumOfBestComponent_new();
        }
        internal SumOfBestComponent(IntPtr ptr) : base(ptr) { }
    }

    public class SumOfBestComponentStateRef
    {
        internal IntPtr ptr;
        public string Text()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.SumOfBestComponentState_text(this.ptr).AsString();
            return result;
        }
        public string Time()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.SumOfBestComponentState_time(this.ptr).AsString();
            return result;
        }
        internal SumOfBestComponentStateRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class SumOfBestComponentStateRefMut : SumOfBestComponentStateRef
    {
        internal SumOfBestComponentStateRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class SumOfBestComponentState : SumOfBestComponentStateRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.SumOfBestComponentState_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~SumOfBestComponentState()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal SumOfBestComponentState(IntPtr ptr) : base(ptr) { }
    }

    public class TimeRef
    {
        internal IntPtr ptr;
        public Time Clone()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new Time(LiveSplitCoreNative.Time_clone(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public TimeSpanRef RealTime()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimeSpanRef(LiveSplitCoreNative.Time_real_time(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public TimeSpanRef GameTime()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimeSpanRef(LiveSplitCoreNative.Time_game_time(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public TimeSpanRef Index(byte timingMethod)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimeSpanRef(LiveSplitCoreNative.Time_index(this.ptr, timingMethod));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal TimeRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class TimeRefMut : TimeRef
    {
        internal TimeRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class Time : TimeRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.Time_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~Time()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal Time(IntPtr ptr) : base(ptr) { }
    }

    public class TimeSpanRef
    {
        internal IntPtr ptr;
        public TimeSpan Clone()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimeSpan(LiveSplitCoreNative.TimeSpan_clone(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public double TotalSeconds()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.TimeSpan_total_seconds(this.ptr);
            return result;
        }
        internal TimeSpanRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class TimeSpanRefMut : TimeSpanRef
    {
        internal TimeSpanRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class TimeSpan : TimeSpanRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.TimeSpan_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~TimeSpan()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        public static TimeSpan FromSeconds(double seconds)
        {
            var result = new TimeSpan(LiveSplitCoreNative.TimeSpan_from_seconds(seconds));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal TimeSpan(IntPtr ptr) : base(ptr) { }
    }

    public class TimerRef
    {
        internal IntPtr ptr;
        public byte CurrentTimingMethod()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Timer_current_timing_method(this.ptr);
            return result;
        }
        public string CurrentComparison()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Timer_current_comparison(this.ptr).AsString();
            return result;
        }
        public bool IsGameTimeInitialized()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Timer_is_game_time_initialized(this.ptr) != 0;
            return result;
        }
        public bool IsGameTimePaused()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Timer_is_game_time_paused(this.ptr) != 0;
            return result;
        }
        public TimeSpanRef LoadingTimes()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimeSpanRef(LiveSplitCoreNative.Timer_loading_times(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public byte CurrentPhase()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.Timer_current_phase(this.ptr);
            return result;
        }
        public RunRef GetRun()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new RunRef(LiveSplitCoreNative.Timer_get_run(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public Run CloneRun()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new Run(LiveSplitCoreNative.Timer_clone_run(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        public void PrintDebug()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Timer_print_debug(this.ptr);
        }
        internal TimerRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class TimerRefMut : TimerRef
    {
        public void Split()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Timer_split(this.ptr);
        }
        public void SkipSplit()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Timer_skip_split(this.ptr);
        }
        public void UndoSplit()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Timer_undo_split(this.ptr);
        }
        public void Reset(bool updateSplits)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Timer_reset(this.ptr, updateSplits);
        }
        public void Pause()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Timer_pause(this.ptr);
        }
        public void SetCurrentTimingMethod(byte method)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Timer_set_current_timing_method(this.ptr, method);
        }
        public void SwitchToNextComparison()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Timer_switch_to_next_comparison(this.ptr);
        }
        public void SwitchToPreviousComparison()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Timer_switch_to_previous_comparison(this.ptr);
        }
        public void InitializeGameTime()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Timer_initialize_game_time(this.ptr);
        }
        public void UninitializeGameTime()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Timer_uninitialize_game_time(this.ptr);
        }
        public void PauseGameTime()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Timer_pause_game_time(this.ptr);
        }
        public void UnpauseGameTime()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            LiveSplitCoreNative.Timer_unpause_game_time(this.ptr);
        }
        public void SetGameTime(TimeSpanRef time)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (time.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("time");
            }
            LiveSplitCoreNative.Timer_set_game_time(this.ptr, time.ptr);
        }
        public void SetLoadingTimes(TimeSpanRef time)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (time.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("time");
            }
            LiveSplitCoreNative.Timer_set_loading_times(this.ptr, time.ptr);
        }
        internal TimerRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class Timer : TimerRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.Timer_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~Timer()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        public Timer(Run run) : base(IntPtr.Zero)
        {
            if (run.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("run");
            }
            this.ptr = LiveSplitCoreNative.Timer_new(run.ptr);
            run.ptr = IntPtr.Zero;
        }
        public SharedTimer IntoShared()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new SharedTimer(LiveSplitCoreNative.Timer_into_shared(this.ptr));
            this.ptr = IntPtr.Zero;
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal Timer(IntPtr ptr) : base(ptr) { }
    }

    public class TimerComponentRef
    {
        internal IntPtr ptr;
        public string StateAsJson(TimerRef timer)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (timer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("timer");
            }
            var result = LiveSplitCoreNative.TimerComponent_state_as_json(this.ptr, timer.ptr).AsString();
            return result;
        }
        public TimerComponentState State(TimerRef timer)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (timer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("timer");
            }
            var result = new TimerComponentState(LiveSplitCoreNative.TimerComponent_state(this.ptr, timer.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal TimerComponentRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class TimerComponentRefMut : TimerComponentRef
    {
        internal TimerComponentRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class TimerComponent : TimerComponentRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.TimerComponent_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~TimerComponent()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        public TimerComponent() : base(IntPtr.Zero)
        {
            this.ptr = LiveSplitCoreNative.TimerComponent_new();
        }
        internal TimerComponent(IntPtr ptr) : base(ptr) { }
    }

    public class TimerComponentStateRef
    {
        internal IntPtr ptr;
        public string Time()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.TimerComponentState_time(this.ptr).AsString();
            return result;
        }
        public string Fraction()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.TimerComponentState_fraction(this.ptr).AsString();
            return result;
        }
        public string Color()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.TimerComponentState_color(this.ptr).AsString();
            return result;
        }
        internal TimerComponentStateRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class TimerComponentStateRefMut : TimerComponentStateRef
    {
        internal TimerComponentStateRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class TimerComponentState : TimerComponentStateRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.TimerComponentState_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~TimerComponentState()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal TimerComponentState(IntPtr ptr) : base(ptr) { }
    }

    public class TimerReadLockRef
    {
        internal IntPtr ptr;
        public TimerRef Timer()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimerRef(LiveSplitCoreNative.TimerReadLock_timer(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal TimerReadLockRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class TimerReadLockRefMut : TimerReadLockRef
    {
        internal TimerReadLockRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class TimerReadLock : TimerReadLockRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.TimerReadLock_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~TimerReadLock()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal TimerReadLock(IntPtr ptr) : base(ptr) { }
    }

    public class TimerWriteLockRef
    {
        internal IntPtr ptr;
        internal TimerWriteLockRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class TimerWriteLockRefMut : TimerWriteLockRef
    {
        public TimerRefMut Timer()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = new TimerRefMut(LiveSplitCoreNative.TimerWriteLock_timer(this.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal TimerWriteLockRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class TimerWriteLock : TimerWriteLockRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.TimerWriteLock_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~TimerWriteLock()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal TimerWriteLock(IntPtr ptr) : base(ptr) { }
    }

    public class TitleComponentRef
    {
        internal IntPtr ptr;
        internal TitleComponentRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class TitleComponentRefMut : TitleComponentRef
    {
        public string StateAsJson(TimerRef timer)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (timer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("timer");
            }
            var result = LiveSplitCoreNative.TitleComponent_state_as_json(this.ptr, timer.ptr).AsString();
            return result;
        }
        public TitleComponentState State(TimerRef timer)
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            if (timer.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("timer");
            }
            var result = new TitleComponentState(LiveSplitCoreNative.TitleComponent_state(this.ptr, timer.ptr));
            if (result.ptr == IntPtr.Zero)
            {
                return null;
            }
            return result;
        }
        internal TitleComponentRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class TitleComponent : TitleComponentRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.TitleComponent_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~TitleComponent()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        public TitleComponent() : base(IntPtr.Zero)
        {
            this.ptr = LiveSplitCoreNative.TitleComponent_new();
        }
        internal TitleComponent(IntPtr ptr) : base(ptr) { }
    }

    public class TitleComponentStateRef
    {
        internal IntPtr ptr;
        public string IconChange()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.TitleComponentState_icon_change(this.ptr).AsString();
            return result;
        }
        public string Game()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.TitleComponentState_game(this.ptr).AsString();
            return result;
        }
        public string Category()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.TitleComponentState_category(this.ptr).AsString();
            return result;
        }
        public uint Attempts()
        {
            if (this.ptr == IntPtr.Zero)
            {
                throw new ObjectDisposedException("this");
            }
            var result = LiveSplitCoreNative.TitleComponentState_attempts(this.ptr);
            return result;
        }
        internal TitleComponentStateRef(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }

    public class TitleComponentStateRefMut : TitleComponentStateRef
    {
        internal TitleComponentStateRefMut(IntPtr ptr) : base(ptr) { }
    }

    public class TitleComponentState : TitleComponentStateRefMut, IDisposable
    {
        private void Drop()
        {
            if (ptr != IntPtr.Zero)
            {
                LiveSplitCoreNative.TitleComponentState_drop(this.ptr);
                ptr = IntPtr.Zero;
            }
        }
        ~TitleComponentState()
        {
            Drop();
        }
        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }
        internal TitleComponentState(IntPtr ptr) : base(ptr) { }
    }

    public static class LiveSplitCoreNative
    {
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Attempt_index(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Attempt_time(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GraphComponent_new();
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GraphComponent_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString GraphComponent_state_as_json(IntPtr self, IntPtr timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GraphComponent_state(IntPtr self, IntPtr timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GraphComponentState_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr GraphComponentState_points_len(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern float GraphComponentState_point_x(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern float GraphComponentState_point_y(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr GraphComponentState_horizontal_grid_lines_len(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern float GraphComponentState_horizontal_grid_line(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr GraphComponentState_vertical_grid_lines_len(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern float GraphComponentState_vertical_grid_line(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern float GraphComponentState_middle(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr HotkeySystem_new(IntPtr shared_timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void HotkeySystem_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PossibleTimeSaveComponent_new();
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PossibleTimeSaveComponent_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString PossibleTimeSaveComponent_state_as_json(IntPtr self, IntPtr timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PossibleTimeSaveComponent_state(IntPtr self, IntPtr timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PossibleTimeSaveComponentState_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString PossibleTimeSaveComponentState_text(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString PossibleTimeSaveComponentState_time(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PreviousSegmentComponent_new();
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PreviousSegmentComponent_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString PreviousSegmentComponent_state_as_json(IntPtr self, IntPtr timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PreviousSegmentComponent_state(IntPtr self, IntPtr timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PreviousSegmentComponentState_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString PreviousSegmentComponentState_text(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString PreviousSegmentComponentState_time(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Run_new();
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Run_parse(IntPtr data, UIntPtr length);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Run_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString Run_game_name(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString Run_game_icon(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString Run_category_name(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString Run_extended_file_name(IntPtr self, bool use_extended_category_name);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString Run_extended_name(IntPtr self, bool use_extended_category_name);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString Run_extended_category_name(IntPtr self, bool show_region, bool show_platform, bool show_variables);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint Run_attempt_count(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Run_metadata(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Run_offset(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr Run_len(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Run_segment(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr Run_attempt_history_len(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Run_attempt_history_index(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString Run_save_as_lss(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Run_push_segment(IntPtr self, IntPtr segment);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Run_set_game_name(IntPtr self, string game);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Run_set_category_name(IntPtr self, string category);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr RunEditor_new(IntPtr run);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr RunEditor_close(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString RunEditor_state_as_json(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunEditor_select_timing_method(IntPtr self, byte method);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunEditor_unselect(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunEditor_select_additionally(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunEditor_select_only(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunEditor_set_game_name(IntPtr self, string game);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunEditor_set_category_name(IntPtr self, string category);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte RunEditor_parse_and_set_offset(IntPtr self, string offset);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte RunEditor_parse_and_set_attempt_count(IntPtr self, string attempts);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunEditor_set_game_icon(IntPtr self, IntPtr data, UIntPtr length);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunEditor_insert_segment_above(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunEditor_insert_segment_below(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunEditor_remove_segments(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunEditor_move_segments_up(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunEditor_move_segments_down(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunEditor_selected_set_icon(IntPtr self, IntPtr data, UIntPtr length);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunEditor_selected_set_name(IntPtr self, string name);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte RunEditor_selected_parse_and_set_split_time(IntPtr self, string time);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte RunEditor_selected_parse_and_set_segment_time(IntPtr self, string time);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte RunEditor_selected_parse_and_set_best_segment_time(IntPtr self, string time);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte RunEditor_selected_parse_and_set_comparison_time(IntPtr self, string comparison, string time);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString RunMetadata_run_id(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString RunMetadata_platform_name(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte RunMetadata_uses_emulator(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString RunMetadata_region_name(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Segment_new(string name);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Segment_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString Segment_name(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString Segment_icon(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Segment_comparison(IntPtr self, string comparison);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Segment_personal_best_split_time(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Segment_best_segment_time(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Segment_segment_history(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SegmentHistory_iter(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SegmentHistoryElement_index(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SegmentHistoryElement_time(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SegmentHistoryIter_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SegmentHistoryIter_next(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SharedTimer_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SharedTimer_share(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SharedTimer_read(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SharedTimer_write(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SplitsComponent_new();
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SplitsComponent_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString SplitsComponent_state_as_json(IntPtr self, IntPtr timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SplitsComponent_state(IntPtr self, IntPtr timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SplitsComponent_scroll_up(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SplitsComponent_scroll_down(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SplitsComponentState_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SplitsComponentState_final_separator_shown(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr SplitsComponentState_len(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString SplitsComponentState_icon_change(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString SplitsComponentState_name(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString SplitsComponentState_delta(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString SplitsComponentState_time(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString SplitsComponentState_color(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SplitsComponentState_is_current_split(IntPtr self, UIntPtr index);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SumOfBestComponent_new();
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SumOfBestComponent_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString SumOfBestComponent_state_as_json(IntPtr self, IntPtr timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SumOfBestComponent_state(IntPtr self, IntPtr timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SumOfBestComponentState_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString SumOfBestComponentState_text(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString SumOfBestComponentState_time(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Time_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Time_clone(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Time_real_time(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Time_game_time(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Time_index(IntPtr self, byte timing_method);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TimeSpan_from_seconds(double seconds);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TimeSpan_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TimeSpan_clone(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern double TimeSpan_total_seconds(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Timer_new(IntPtr run);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Timer_into_shared(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte Timer_current_timing_method(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString Timer_current_comparison(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte Timer_is_game_time_initialized(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte Timer_is_game_time_paused(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Timer_loading_times(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte Timer_current_phase(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Timer_get_run(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Timer_clone_run(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_print_debug(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_split(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_skip_split(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_undo_split(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_reset(IntPtr self, bool update_splits);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_pause(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_set_current_timing_method(IntPtr self, byte method);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_switch_to_next_comparison(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_switch_to_previous_comparison(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_initialize_game_time(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_uninitialize_game_time(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_pause_game_time(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_unpause_game_time(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_set_game_time(IntPtr self, IntPtr time);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Timer_set_loading_times(IntPtr self, IntPtr time);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TimerComponent_new();
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TimerComponent_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString TimerComponent_state_as_json(IntPtr self, IntPtr timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TimerComponent_state(IntPtr self, IntPtr timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TimerComponentState_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString TimerComponentState_time(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString TimerComponentState_fraction(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString TimerComponentState_color(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TimerReadLock_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TimerReadLock_timer(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TimerWriteLock_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TimerWriteLock_timer(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TitleComponent_new();
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TitleComponent_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString TitleComponent_state_as_json(IntPtr self, IntPtr timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TitleComponent_state(IntPtr self, IntPtr timer);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TitleComponentState_drop(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString TitleComponentState_icon_change(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString TitleComponentState_game(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern LSCoreString TitleComponentState_category(IntPtr self);
        [DllImport("livesplit_core", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint TitleComponentState_attempts(IntPtr self);
    }

    public class LSCoreString : SafeHandle
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
}
