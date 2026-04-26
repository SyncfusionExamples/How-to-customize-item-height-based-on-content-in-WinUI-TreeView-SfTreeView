using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TreeViewDemo
{
    public class ItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CompHeaderTemplate { get; set; }
        public DataTemplate DetailTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is Syncfusion.UI.Xaml.TreeView.TreeViewNode node)
            {
                if (node.Level == 0)
                    return CompHeaderTemplate;
                return DetailTemplate;
            }

            return base.SelectTemplateCore(item, container);
        }
    }
}
