using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.IO;
using WaferMapv2.Model;

namespace WaferMapv2.ViewModel
{
    public class DieViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Die> _dies;
        public ObservableCollection<Die> Dies
        {
            get => _dies;
            set { _dies = value; OnPropertyChanged(); }
        }

        public DieViewModel()
        {
            var wafer = LoadWaferFromFile("E:\\c# projects\\WaferMapv2\\WaferMapv2\\waferdata.json");
         
            var diesList = GetDiesFromMap(wafer);
            Dies = new ObservableCollection<Die>(diesList);
        }

        private Wafer LoadWaferFromFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Wafer wafer = JsonSerializer.Deserialize<Wafer>(json, options);
            return wafer;
        }


        private List<Die> GetDiesFromMap(Wafer wafer)
        {
            var dies = new List<Die>();
            int rows = wafer.DieMap.Length;
            int cols = wafer.DieMap[0].Length;
            double radius = wafer.WaferDiameter / 2;

            double centerX = 200;
            double centerY = 200;

            int centerRow = rows / 2;
            int centerCol = cols / 2;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    double x = centerX + (col - centerCol) * wafer.DiePitchX;
                    double y = centerY + (row - centerRow) * wafer.DiePitchY;

                    double distToCenter = Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));
                    if (distToCenter <= radius)
                    {
                        dies.Add(new Die
                        {
                            X = x,
                            Y = y,
                            Status = wafer.DieMap[row][col] == 1 ? "Pass" : "Fail",
                            Size = wafer.DieSize
                        });
                    }
                }
            }

            return dies;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
