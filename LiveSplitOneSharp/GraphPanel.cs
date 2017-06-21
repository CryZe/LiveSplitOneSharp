using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LiveSplitCore;
using System.Drawing.Drawing2D;

namespace LiveSplitOneSharp
{
    public partial class GraphPanel : UserControl
    {
        public GraphComponentState state;

        public GraphPanel()
        {
            InitializeComponent();
            state = null;
        }

        private void GraphPanel_Paint(object sender, PaintEventArgs e)
        {
            var state = this.state;
            if (state != null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                var middle = Height * state.Middle();
                var pointsLen = state.PointsLen();

                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(115, 40, 40)), new RectangleF(new PointF(), new SizeF(Width, middle)));
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 115, 52)), new RectangleF(new PointF(0, middle), new SizeF(Width, Height)));

                var gridLinePen = new Pen(Color.FromArgb(0x40, 0x0, 0x0, 0x0), 2.0f);

                for (long i = 0; i < state.VerticalGridLinesLen(); ++i)
                {
                    var x = Width * state.VerticalGridLine(i);
                    e.Graphics.DrawLine(gridLinePen, x, 0, x, Height);
                }

                for (long i = 0; i < state.HorizontalGridLinesLen(); ++i)
                {
                    var y = Height * state.HorizontalGridLine(i);
                    e.Graphics.DrawLine(gridLinePen, 0, y, Width, y);
                }

                var points = new List<PointF>();

                for (long i = 0; i < pointsLen; ++i)
                {
                    points.Add(new PointF(state.PointX(i) * Width, state.PointY(i) * Height));
                }

                if (state.IsLiveDeltaActive())
                {
                    points.Remove(points.Last());
                }

                if (points.Any())
                {
                    points.Add(new PointF(points.Last().X, middle));
                }

                e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), points.ToArray());

                if (state.IsLiveDeltaActive())
                {
                    var x1 = state.PointX(pointsLen - 2) * Width;
                    var y1 = state.PointY(pointsLen - 2) * Height;
                    var x2 = state.PointX(pointsLen - 1) * Width;
                    var y2 = state.PointY(pointsLen - 1) * Height;

                    e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(50, 255, 255, 255)), new PointF[] {
                        new PointF(x1, middle),
                        new PointF(x1, y1),
                        new PointF(x2, y2),
                        new PointF(x2, middle)
                    });
                }

                for (long i = 1; i < pointsLen; ++i)
                {
                    var px = state.PointX(i - 1) * Width;
                    var py = state.PointY(i - 1) * Height;
                    var x = state.PointX(i) * Width;
                    var y = state.PointY(i) * Height;
                    e.Graphics.DrawLine(new Pen(Color.White, 2.0f), px, py, x, y);
                    if (i != pointsLen - 1 || !state.IsLiveDeltaActive())
                    {
                        e.Graphics.FillEllipse(Brushes.White, new RectangleF(x - 3, y - 3, 6, 6));
                    }
                }
            }
        }
    }
}
