using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace LiveSplitOneSharp
{
    public partial class Form1 : Form
    {
        Timer timer;

        TitleComponent titleComponent;
        SplitsComponent splitsComponent;
        TimerComponent timerComponent;
        PreviousSegmentComponent previousSegComponent;
        SumOfBestComponent sobComponent;
        PossibleTimeSaveComponent ptsComponent;

        public Form1()
        {
            InitializeComponent();

            var splits = File.ReadAllText("D:\\Desktop\\LiveSplit\\Splits\\A Hat in Time - Any%.lss");
            var run = new Run(splits);
            timer = new Timer(run);

            titleComponent = new TitleComponent();
            splitsComponent = new SplitsComponent();
            timerComponent = new TimerComponent();
            previousSegComponent = new PreviousSegmentComponent();
            sobComponent = new SumOfBestComponent();
            ptsComponent = new PossibleTimeSaveComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var stateString = titleComponent.GetState(timer);
            var state = JObject.Parse(stateString);
            lblGame.Text = (string)state["game"];
            lblCategory.Text = (string)state["category"] + "  " + (int)state["attempts"];

            stateString = timerComponent.GetState(timer);
            state = JObject.Parse(stateString);
            lblTimer.Text = state["time"].ToString() + state["fraction"].ToString();

            stateString = splitsComponent.GetState(timer);
            state = JObject.Parse(stateString);
            var splits = (JArray)state["splits"];
            listBox1.Items.Clear();
            foreach (var split in splits)
            {
                var line = "";
                if ((bool)split["is_current_split"])
                {
                    line += "> ";
                } else
                {
                    line += "  ";
                }
                line += (string)split["name"];
                line += "   ";
                line += (string)split["delta"];
                line += "    ";
                line += (string)split["time"];
                listBox1.Items.Add(line);
            }

            stateString = previousSegComponent.GetState(timer);
            state = JObject.Parse(stateString);
            lblPrevSeg.Text = (string)state["text"] + "   " + (string)state["time"];

            stateString = sobComponent.GetState(timer);
            state = JObject.Parse(stateString);
            lblSOB.Text = (string)state["text"] + "   " + (string)state["time"];

            stateString = ptsComponent.GetState(timer);
            state = JObject.Parse(stateString);
            lblPTS.Text = (string)state["text"] + "   " + (string)state["time"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Split();
            timer.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer.UndoSplit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer.SkipSplit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer.Pause();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Reset(true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            File.WriteAllText("splits.lss", timer.SaveAsLSS());
        }
    }
}
