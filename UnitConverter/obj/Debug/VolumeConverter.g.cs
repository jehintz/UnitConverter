﻿

#pragma checksum "C:\Users\Jessica\Documents\UnitConverter\UnitConverter\VolumeConverter.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "373E6E7AE5F206866AFE572201D6C865"
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
    partial class VolumeConverter : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 13 "..\..\VolumeConverter.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.switchButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 14 "..\..\VolumeConverter.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.clearButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 39 "..\..\VolumeConverter.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).LostFocus += this.volumeEntryBox_LostFocus;
                 #line default
                 #line hidden
                #line 39 "..\..\VolumeConverter.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).GotFocus += this.volumeEntryBox_GotFocus;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 43 "..\..\VolumeConverter.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.toVolumeSelector_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 54 "..\..\VolumeConverter.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.fromVolumeSelector_SelectionChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


