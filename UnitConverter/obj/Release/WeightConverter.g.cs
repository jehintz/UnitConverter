﻿

#pragma checksum "C:\Users\Jessica\documents\visual studio 2013\Projects\UnitConverter\UnitConverter\WeightConverter.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F16915C07A60AFF948EF6D8462BA79DD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnitConverter
{
    partial class WeightConverter : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 12 "..\..\WeightConverter.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.AppBarButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 37 "..\..\WeightConverter.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).LostFocus += this.weightEntryBox_LostFocus;
                 #line default
                 #line hidden
                #line 37 "..\..\WeightConverter.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).GotFocus += this.weightEntryBox_GotFocus;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 41 "..\..\WeightConverter.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.toWeightSelector_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 49 "..\..\WeightConverter.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.fromWeightSelector_SelectionChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


