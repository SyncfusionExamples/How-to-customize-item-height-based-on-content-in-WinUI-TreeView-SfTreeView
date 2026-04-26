# How to customize item height based on content in WinUI TreeView (SfTreeView)?

The [WinUI TreeView](https://www.syncfusion.com/winui-controls/treeview) (SfTreeView) does not provide built-in support for automatically adjusting row height based on the content of a TextBlock or its text. To meet this requirement, the behavior has been customized using the [QueryNodeSize](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_QueryNodeSize) event. Within this event handler, the height of the content view is manually calculated, and the computed value is then assigned to the [e.Height](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeView.QueryNodeSizeEventArgs.html#Syncfusion_UI_Xaml_TreeView_QueryNodeSizeEventArgs_Height) property.

**XAML**
```
  <treeView:SfTreeView
   x:Name="treeView"
   ItemsSource="{x:Bind ViewModel.GroupedJobDescription, Mode=OneWay}"
   ChildPropertyName="Details"
   AutoExpandMode="AllNodes"
   Indentation="6"
   IsAnimationEnabled="True"
   ItemTemplateDataContextType="Item"
   ItemTemplateSelector="{StaticResource itemTemplateSelectorTreeDesc}"
   HorizontalAlignment="Stretch"
   VerticalAlignment="Stretch"
   ScrollViewer.HorizontalScrollBarVisibility="Auto"
   QueryNodeSize="treeView_QueryNodeSize"/>
```
**C#**
```
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
```

![Customize item height based on content](Customize%20item%20height%20based%20on%20content.gif)

Take a moment to peruse the [WinUI TreeView - Item Height Customization](https://help.syncfusion.com/winui/treeview/item-height-customization) documentation, to learn more about item height customization with example.