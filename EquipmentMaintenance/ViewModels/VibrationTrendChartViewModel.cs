﻿using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using Prism.Mvvm;
using System;
using System.Windows.Media;

namespace EquipmentMaintenance
{
    public class VibrationTrendChartViewModel : BindableBase
    {
        public VibrationTrendChartViewModel()
        {
            ChartMapper();
        }

        public void ChartMapper()
        {
            var mapper = Mappers.Xy<MeasureModel>()
                   .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                   .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);
        }

        //lets set how to display the X Labels
        public Func<double, string> DateTimeFormatter { get; set; }
            = value => new DateTime((long)value).ToString("HH:mm");
        public Func<double, string> NumberFormatter { get; set; }
            = value => value.ToString();

        public double AxisXStep = TimeSpan.FromSeconds(60 * 10).Ticks;

        public double AxisYStep = 5000;

        public double MaxY = 30000;

        public double MinY = 12500;

        //the values property will store our values array
        private SeriesCollection _series;
        public SeriesCollection Series
        {
            get
            {
                if (_series == null)
                {
                    _series = new SeriesCollection {
                        new LineSeries {
                            Title = "モータ１振動",
                            Values =  new ChartValues<MeasureModel> {
                                new MeasureModel { Minutes = 1100, Value = 15000 },
                                new MeasureModel { Minutes = 1110, Value = 15500 },
                                new MeasureModel { Minutes = 1120, Value = 15100 },
                                new MeasureModel { Minutes = 1130, Value = 15300 },
                                new MeasureModel { Minutes = 1140, Value = 15200 },
                                new MeasureModel { Minutes = 1150, Value = 14000 },
                                new MeasureModel { Minutes = 1160, Value = 14300 },
                                new MeasureModel { Minutes = 1170, Value = 15000 },
                                new MeasureModel { Minutes = 1180, Value = 15200 },
                                new MeasureModel { Minutes = 1190, Value = 14900 },
                                new MeasureModel { Minutes = 1200, Value = 15000 },
                                new MeasureModel { Minutes = 1210, Value = 15000 },
                                new MeasureModel { Minutes = 1220, Value = 14900 },
                                new MeasureModel { Minutes = 1230, Value = 15100 },
                                new MeasureModel { Minutes = 1240, Value = 15000 },
                                new MeasureModel { Minutes = 1250, Value = 26000 },
                                new MeasureModel { Minutes = 1260, Value = 18500 },
                                new MeasureModel { Minutes = 1270, Value = 15000 },
                                new MeasureModel { Minutes = 1280, Value = 15001 }
                            },
                            Fill = new SolidColorBrush(Colors.Transparent),
                            PointGeometry = DefaultGeometries.Square,
                            LineSmoothness = 0
                        },
                        new LineSeries {
                            Title = "モータ２振動",
                            Values =  new ChartValues<MeasureModel> {
                                new MeasureModel { Minutes = 1100, Value = 20000 },
                                new MeasureModel { Minutes = 1110, Value = 20010 },
                                new MeasureModel { Minutes = 1120, Value = 20100 },
                                new MeasureModel { Minutes = 1130, Value = 19832 },
                                new MeasureModel { Minutes = 1140, Value = 19820 },
                                new MeasureModel { Minutes = 1150, Value = 22000 },
                                new MeasureModel { Minutes = 1160, Value = 19300 },
                                new MeasureModel { Minutes = 1170, Value = 20000 },
                                new MeasureModel { Minutes = 1180, Value = 18300 },
                                new MeasureModel { Minutes = 1190, Value = 23030 },
                                new MeasureModel { Minutes = 1200, Value = 20000 },
                                new MeasureModel { Minutes = 1210, Value = 20001 },
                                new MeasureModel { Minutes = 1220, Value = 20000 },
                                new MeasureModel { Minutes = 1230, Value = 42400 },
                                new MeasureModel { Minutes = 1240, Value = 20001 },
                                new MeasureModel { Minutes = 1250, Value = 20000 },
                                new MeasureModel { Minutes = 1260, Value = 20001 },
                                new MeasureModel { Minutes = 1270, Value = 20000 },
                                new MeasureModel { Minutes = 1280, Value = 20001 }
                            },
                            Fill = new SolidColorBrush(Colors.Transparent),
                            PointGeometry = DefaultGeometries.Circle,
                            LineSmoothness = 0
                        }
                    };
                }
                return _series;
            }
            set { SetProperty(ref _series, value); }
        }
    }
}
