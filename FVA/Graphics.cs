using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FVA
{
    public partial class Graphics : Plantilla
    {
        public Graphics()
        {
            InitializeComponent();
        }

        private void Graphics_Load(object sender, EventArgs e)
        {
            PointF[] pointer = new PointF[2] { new PointF(1, (float)FVA.fva.Lp1.GetObjectiveValue()), new PointF(1, (float)FVA.fva.Lp2.GetObjectiveValue()) };

            chart1.Series.Clear();
            chart1.Series.Add("RNA");
            chart1.Series["RNA"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            for (int i = 0; i < pointer.Length; i++)
            {
                double x = (double)pointer[i].X;
                double y = (double)pointer[i].Y;

                chart1.Series["RNA"].Points.AddXY(x, y);
            }
            chart1.Series["RNA"].ChartArea = "ChartArea1";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void typeofgraphics_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (typeofgraphics.Text)
            {
                case "Pie":
                    {
                        chart1.Update();
                        PointF[] pointer = new PointF[2] { new PointF(1, (float)FVA.fva.Lp1.GetObjectiveValue()), new PointF(1, (float)FVA.fva.Lp2.GetObjectiveValue()) };
                        chart1.Series.Clear();
                        chart1.Series.Add("RNA");
                        chart1.Series["RNA"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                        for (int i = 0; i < pointer.Length; i++)
                        {
                            double x = (double)pointer[i].X;
                            double y = (double)pointer[i].Y;

                            chart1.Series["RNA"].Points.AddXY(x, y);
                        }
                        chart1.Series["RNA"].ChartArea = "ChartArea1";
                        break;
                    }
                case "Area":
                    {

                        chart1.Update();
                        PointF[] pointer = new PointF[2] { new PointF(1, (float)FVA.fva.Lp1.GetObjectiveValue()), new PointF(1, (float)FVA.fva.Lp2.GetObjectiveValue()) };
                        chart1.Series.Clear();
                        chart1.Series.Add("RNA");
                        chart1.Series["RNA"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                        for (int i = 0; i < pointer.Length; i++)
                        {
                            double x = (double)pointer[i].X;
                            double y = (double)pointer[i].Y;

                            chart1.Series["RNA"].Points.AddXY(x, y);
                        }
                        chart1.Series["RNA"].ChartArea = "ChartArea1";
                        break;
                    }
                case "Bar":
                    {

                        chart1.Update();
                        PointF[] pointer = new PointF[2] { new PointF(1, (float)FVA.fva.Lp1.GetObjectiveValue()), new PointF(1, (float)FVA.fva.Lp2.GetObjectiveValue()) };
                        chart1.Series.Clear();
                        chart1.Series.Add("RNA");
                        chart1.Series["RNA"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
                        for (int i = 0; i < pointer.Length; i++)
                        {
                            double x = (double)pointer[i].X;
                            double y = (double)pointer[i].Y;

                            chart1.Series["RNA"].Points.AddXY(x, y);
                        }
                        chart1.Series["RNA"].ChartArea = "ChartArea1";
                        break;
                    }
                case "Buble":
                    {

                        chart1.Update();
                        PointF[] pointer = new PointF[2] { new PointF(1, (float)FVA.fva.Lp1.GetObjectiveValue()), new PointF(1, (float)FVA.fva.Lp2.GetObjectiveValue()) };
                        chart1.Series.Clear();
                        chart1.Series.Add("RNA");
                        chart1.Series["RNA"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
                        for (int i = 0; i < pointer.Length; i++)
                        {
                            double x = (double)pointer[i].X;
                            double y = (double)pointer[i].Y;

                            chart1.Series["RNA"].Points.AddXY(x, y);
                        }
                        chart1.Series["RNA"].ChartArea = "ChartArea1";
                        break;
                    }
                case "Candlestick":
                    {

                        chart1.Update();
                        PointF[] pointer = new PointF[2] { new PointF(1, (float)FVA.fva.Lp1.GetObjectiveValue()), new PointF(1, (float)FVA.fva.Lp2.GetObjectiveValue()) };
                        chart1.Series.Clear();
                        chart1.Series.Add("RNA");
                        chart1.Series["RNA"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
                        for (int i = 0; i < pointer.Length; i++)
                        {
                            double x = (double)pointer[i].X;
                            double y = (double)pointer[i].Y;

                            chart1.Series["RNA"].Points.AddXY(x, y);
                        }
                        chart1.Series["RNA"].ChartArea = "ChartArea1";
                        break;
                    }
                case "FastPoint":
                    {

                        chart1.Update();
                        PointF[] pointer = new PointF[2] { new PointF(1, (float)FVA.fva.Lp1.GetObjectiveValue()), new PointF(1, (float)FVA.fva.Lp2.GetObjectiveValue()) };
                        chart1.Series.Clear();
                        chart1.Series.Add("RNA");
                        chart1.Series["RNA"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
                        for (int i = 0; i < pointer.Length; i++)
                        {
                            double x = (double)pointer[i].X;
                            double y = (double)pointer[i].Y;

                            chart1.Series["RNA"].Points.AddXY(x, y);
                        }
                        chart1.Series["RNA"].ChartArea = "ChartArea1";
                        break;
                    }
                case "Line":
                    {

                        chart1.Update();
                        PointF[] pointer = new PointF[2] { new PointF(1, (float)FVA.fva.Lp1.GetObjectiveValue()), new PointF(1, (float)FVA.fva.Lp2.GetObjectiveValue()) };
                        chart1.Series.Clear();
                        chart1.Series.Add("RNA");
                        chart1.Series["RNA"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        for (int i = 0; i < pointer.Length; i++)
                        {
                            double x = (double)pointer[i].X;
                            double y = (double)pointer[i].Y;

                            chart1.Series["RNA"].Points.AddXY(x, y);
                        }
                        chart1.Series["RNA"].ChartArea = "ChartArea1";
                        break;
                    }
                case "Funnel":
                    {

                        chart1.Update();
                        PointF[] pointer = new PointF[2] { new PointF(1, (float)FVA.fva.Lp1.GetObjectiveValue()), new PointF(1, (float)FVA.fva.Lp2.GetObjectiveValue()) };
                        chart1.Series.Clear();
                        chart1.Series.Add("RNA");
                        chart1.Series["RNA"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Funnel;
                        for (int i = 0; i < pointer.Length; i++)
                        {
                            double x = (double)pointer[i].X;
                            double y = (double)pointer[i].Y;

                            chart1.Series["RNA"].Points.AddXY(x, y);
                        }
                        chart1.Series["RNA"].ChartArea = "ChartArea1";
                        break;
                    }
            }
        }
    }
}
