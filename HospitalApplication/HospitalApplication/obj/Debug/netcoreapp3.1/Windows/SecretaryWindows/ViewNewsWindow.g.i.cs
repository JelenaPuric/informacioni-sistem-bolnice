﻿#pragma checksum "..\..\..\..\..\Windows\SecretaryWindows\ViewNewsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A0081CC12AB939EB1085FAD4FAD6C6242AADB1C3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalApplication.Windows.Secretary;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace HospitalApplication.Windows.Secretary {
    
    
    /// <summary>
    /// ViewNewsWindow
    /// </summary>
    public partial class ViewNewsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\..\Windows\SecretaryWindows\ViewNewsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxTypeNews;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\..\Windows\SecretaryWindows\ViewNewsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxTitle;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\Windows\SecretaryWindows\ViewNewsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxDescription;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\Windows\SecretaryWindows\ViewNewsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxDuration;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\Windows\SecretaryWindows\ViewNewsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockDuration;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\Windows\SecretaryWindows\ViewNewsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockTypeNews;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\Windows\SecretaryWindows\ViewNewsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockTitleNews;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\Windows\SecretaryWindows\ViewNewsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockDescription;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HospitalApplication;component/windows/secretarywindows/viewnewswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\SecretaryWindows\ViewNewsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.textBoxTypeNews = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.textBoxTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.textBoxDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.textBoxDuration = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.textBlockDuration = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.textBlockTypeNews = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.textBlockTitleNews = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.textBlockDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            
            #line 20 "..\..\..\..\..\Windows\SecretaryWindows\ViewNewsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OkButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

