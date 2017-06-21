using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using LiveSplitCore;
using Newtonsoft.Json.Linq;

namespace LiveSplitOneSharp
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        HotkeySystem hotkeySystem;
        SharedTimer sharedTimer;

        TitleComponent titleComponent;
        SplitsComponent splitsComponent;
        TimerComponent timerComponent;
        PreviousSegmentComponent previousSegComponent;
        SumOfBestComponent sobComponent;
        PossibleTimeSaveComponent ptsComponent;
        GraphComponent graphComponent;
        GraphComponentState graphState;

        public Form1()
        {
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.DoubleBuffer | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();

            using (var splits = File.OpenRead(@"splits.lss"))
            {
                sharedTimer = new Timer(Run.Parse(splits)).IntoShared();
                hotkeySystem = new HotkeySystem(sharedTimer.Share());

                titleComponent = new TitleComponent();
                splitsComponent = new SplitsComponent();
                timerComponent = new TimerComponent();
                previousSegComponent = new PreviousSegmentComponent();
                sobComponent = new SumOfBestComponent();
                ptsComponent = new PossibleTimeSaveComponent();
                graphComponent = new GraphComponent();
                graphState = null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sharedTimer.ReadWith(timer =>
            {
                using (var state = titleComponent.State(timer))
                {
                    lblGame.Text = state.Game();
                    lblCategory.Text = state.Category() + "  " + state.Attempts();
                }

                using (var state = timerComponent.State(timer))
                {
                    lblTimer.Text = state.Time() + state.Fraction();
                }

                using (var state = splitsComponent.State(timer))
                {
                    var len = state.Len();
                    listBox1.Items.Clear();
                    for (var idx = 0; idx < len; ++idx)
                    {
                        var line = "";
                        if (state.IsCurrentSplit(idx))
                        {
                            line += "> ";
                        }
                        else
                        {
                            line += "  ";
                        }
                        line += state.Name(idx);
                        line += "   ";
                        line += state.Delta(idx);
                        line += "    ";
                        line += state.Time(idx);
                        listBox1.Items.Add(line);
                    }
                }

                using (var state = previousSegComponent.State(timer))
                {
                    lblPrevSeg.Text = state.Text() + "   " + state.Time();
                }

                using (var state = sobComponent.State(timer))
                {
                    lblSOB.Text = state.Text() + "   " + state.Time();
                }

                using (var state = ptsComponent.State(timer))
                {
                    lblPTS.Text = state.Text() + "   " + state.Time();
                }

                //graphPanel1.state = graphComponent.State(timer);

                lblComparison.Text = timer.CurrentComparison();
            });

            graphPanel1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sharedTimer.WriteWith(t => t.Split());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sharedTimer.WriteWith(t => t.UndoSplit());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //SharedTimer.Redo(sharedTimer);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sharedTimer.WriteWith(t => t.SkipSplit());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sharedTimer.WriteWith(t => t.Pause());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sharedTimer.WriteWith(t => t.Reset(true));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sharedTimer.ReadWith(t =>
            {
                File.WriteAllText("splits.lss", t.GetRun().SaveAsLss());
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sharedTimer.WriteWith(t => t.UndoAllPauses());
        }
    }
}
