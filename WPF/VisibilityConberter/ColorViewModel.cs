using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VisibilityConverter {
    public class ColorViewModel {
        public string Name { get; set; }
        public Color Color { get; set; }

        public static ObservableCollection<ColorViewModel> ColorList { get; } = new ObservableCollection<ColorViewModel>
        {
            new ColorViewModel { Name = "Red", Color = Colors.Red },
            new ColorViewModel { Name = "Blue", Color = Colors.Blue },
            new ColorViewModel { Name = "Green", Color = Colors.Green }
        };
    }
}
