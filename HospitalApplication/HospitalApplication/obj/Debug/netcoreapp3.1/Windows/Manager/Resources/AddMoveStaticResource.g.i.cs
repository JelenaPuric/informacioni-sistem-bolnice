﻿#pragma checksum "..\..\..\..\..\..\Windows\Manager\Resources\AddMoveStaticResource.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53C53303D93A4041301068533845EB5075511E3B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalApplication.Windows.Manager.Resources;
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


namespace HospitalApplication.Windows.Manager.Resources {
    
    
    /// <summary>
    /// AddMoveStaticResource
    /// </summary>
    public partial class AddMoveStaticResource : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\..\Windows\Manager\Resources\AddMoveStaticResource.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockCapacity;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\..\Windows\Manager\Resources\AddMoveStaticResource.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockNumberOfFloors;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\..\Windows\Manager\Resources\AddMoveStaticResource.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockRoomId;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\..\Windows\Manager\Resources\AddMoveStaticResource.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxRoomId;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\..\Windows\Manager\Resources\AddMoveStaticResource.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxManufacturer;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\..\Windows\Manager\Resources\AddMoveStaticResource.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox selectedDate;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\..\Windows\Manager\Resources\AddMoveStaticResource.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker PickDate;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\..\Windows\Manager\Resources\AddMoveStaticResource.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Submit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HospitalApplication;V1.0.0.0;component/windows/manager/resources/addmovestaticre" +
                    "source.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Windows\Manager\Resources\AddMoveStaticResource.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.5.0")]
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
            this.textBlockRoomId = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.textBoxRoomId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.textBoxManufacturer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.selectedDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.PickDate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 20 "..\..\..\..\..\..\Windows\Manager\Resources\AddMoveStaticResource.xaml"
            this.PickDate.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.Kalendar);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Submit = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\..\..\Windows\Manager\Resources\AddMoveStaticResource.xaml"
            this.Submit.Click += new System.Windows.RoutedEventHandler(this.Submit_Clicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

