﻿#pragma checksum "..\..\..\..\..\..\Windows\ManagerWindows\Renovations\AddRenovation.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B0D1349CCCB629C2342EE24530740914C069C5F2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalApplication.Windows.Manager.Renovationn;
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


namespace HospitalApplication.Windows.Manager.Renovationn {
    
    
    /// <summary>
    /// AddRenovation
    /// </summary>
    public partial class AddRenovation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\..\Windows\ManagerWindows\Renovations\AddRenovation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockCapacity;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\..\Windows\ManagerWindows\Renovations\AddRenovation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockNumberOfFloors;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\..\Windows\ManagerWindows\Renovations\AddRenovation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockEndDayRenovation;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\..\Windows\ManagerWindows\Renovations\AddRenovation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxRoomId;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\..\Windows\ManagerWindows\Renovations\AddRenovation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker PickStartDate;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\..\Windows\ManagerWindows\Renovations\AddRenovation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker PickEndDate;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\..\Windows\ManagerWindows\Renovations\AddRenovation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Submit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HospitalApplication;component/windows/managerwindows/renovations/addrenovation.x" +
                    "aml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Windows\ManagerWindows\Renovations\AddRenovation.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.textBlockCapacity = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.textBlockNumberOfFloors = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.textBlockEndDayRenovation = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.textBoxRoomId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.PickStartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.PickEndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.Submit = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\..\..\Windows\ManagerWindows\Renovations\AddRenovation.xaml"
            this.Submit.Click += new System.Windows.RoutedEventHandler(this.Submit_Clicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

