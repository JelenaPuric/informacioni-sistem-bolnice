﻿#pragma checksum "..\..\..\..\..\..\Windows\ManagerWindows\Rooms\WindowRooms.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B216A06DB73C4836249C1781DCAD9575F881E7D4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalApplication.Windows.Manager;
using HospitalApplication.Windows.Manager.Prostorije;
using HospitalApplication.Windows.Manager.Rooms;
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


namespace HospitalApplication.Windows.Manager.Prostorije {
    
    
    /// <summary>
    /// WindowRooms
    /// </summary>
    public partial class WindowRooms : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\..\..\Windows\ManagerWindows\Rooms\WindowRooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button All;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\..\Windows\ManagerWindows\Rooms\WindowRooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\..\Windows\ManagerWindows\Rooms\WindowRooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\..\Windows\ManagerWindows\Rooms\WindowRooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Edit;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\..\Windows\ManagerWindows\Rooms\WindowRooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Find;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalApplication;V1.0.0.0;component/windows/managerwindows/rooms/windowrooms." +
                    "xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Windows\ManagerWindows\Rooms\WindowRooms.xaml"
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
            this.All = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\..\..\Windows\ManagerWindows\Rooms\WindowRooms.xaml"
            this.All.Click += new System.Windows.RoutedEventHandler(this.AllRooms_Clicked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Delete = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\..\..\Windows\ManagerWindows\Rooms\WindowRooms.xaml"
            this.Delete.Click += new System.Windows.RoutedEventHandler(this.Delete_Clicked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\..\..\Windows\ManagerWindows\Rooms\WindowRooms.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Clicked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Edit = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\..\..\Windows\ManagerWindows\Rooms\WindowRooms.xaml"
            this.Edit.Click += new System.Windows.RoutedEventHandler(this.Edit_Clicked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Find = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\..\..\Windows\ManagerWindows\Rooms\WindowRooms.xaml"
            this.Find.Click += new System.Windows.RoutedEventHandler(this.Show_Clicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

