using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.TreeView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TreeViewDemo
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; } = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void treeView_QueryNodeSize(object sender, Syncfusion.UI.Xaml.TreeView.QueryNodeSizeEventArgs e)
        {
            if (sender is not SfTreeView treeView)
                return;

            // Access internal properties once
            var eventType = e.GetType();
            var treeViewType = treeView.GetType();

            var treeNodeInfo = eventType
                .GetProperty("TreeNodeInfo", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(e);

            var treeNodeContainer = treeViewType
                .GetProperty("TreeNodeContainer", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(treeView);

            if (treeNodeInfo == null || treeNodeContainer == null)
                return;

            var viewPortSize = treeNodeContainer.GetType()
                .GetProperty("ViewPortSize", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(treeNodeContainer) as Size?;

            var contentView = treeNodeInfo.GetType()
                .GetProperty("ContentView", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(treeNodeInfo) as FrameworkElement;

            if (contentView == null || viewPortSize == null)
                return;

            // Calculate available width
            double indentation = (e.Node.Level * treeView.Indentation) + treeView.ExpanderWidth;
            double availableWidth = viewPortSize.Value.Width - indentation;

            contentView.Measure(new Size(availableWidth, double.PositiveInfinity));

            double desiredHeight = contentView.DesiredSize.Height;
            double finalHeight = desiredHeight > 0
                ? desiredHeight
                : treeView.ItemHeight;

            if (e.Height < finalHeight)
            {
                e.Height = finalHeight;
                e.Handled = true;
            }
        }
    }
}
