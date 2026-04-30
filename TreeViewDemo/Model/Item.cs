using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TreeViewDemo
{
    public class Item
    {
        // Header (component)
        public string ComponentNameLong { get; set; }

        // Detail row
        public string Category { get; set; }
        public string Detail { get; set; }
        public string Value { get; set; }
        public string IconGlyph { get; set; }

        // SfTreeView children
        public ObservableCollection<Item> Details { get; set; }
    }
}
