﻿

#pragma checksum "C:\Users\Jessica\Documents\Visual Studio 2013\Projects\UnitConverter\UnitConverter\LengthConverter.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E5E8CE1188E7254CF599F05F32DDDA49"
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
    partial class LengthConverter : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 13 "..\..\LengthConverter.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.clearButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 38 "..\..\LengthConverter.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).LostFocus += this.lengthEntryBox_LostFocus;
                 #line default
                 #line hidden
                #line 38 "..\..\LengthConverter.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).GotFocus += this.lengthEntryBox_GotFocus;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 42 "..\..\LengthConverter.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.toLengthSelector_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 52 "..\..\LengthConverter.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.fromLengthSelector_SelectionChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

