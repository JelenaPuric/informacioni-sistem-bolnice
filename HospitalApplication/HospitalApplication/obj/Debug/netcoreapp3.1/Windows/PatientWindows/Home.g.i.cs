﻿#pragma checksum "..\..\..\..\..\Windows\PatientWindows\Home.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5550015973EB03787206CCC954F248A77E240474"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalApplication.Windows.PatientWindows;
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


namespace HospitalApplication.Windows.PatientWindows {
    
    
    /// <summary>
    /// Home
    /// </summary>
    public partial class Home : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid panelHeader;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid sidePanel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HamburgerButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem MenuHome;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem MenuNotification;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem MenuSurvey;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem MenuAnamnesis;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem MenuSettings;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame Main;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalApplication;component/windows/patientwindows/home.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
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
            
            #line 12 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
            ((HospitalApplication.Windows.PatientWindows.Home)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.panelHeader = ((System.Windows.Controls.Grid)(target));
            
            #line 15 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
            this.panelHeader.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.panelHeader_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.sidePanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.HamburgerButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
            this.HamburgerButton.Click += new System.Windows.RoutedEventHandler(this.HamburgerButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MenuHome = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 26 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
            this.MenuHome.Selected += new System.Windows.RoutedEventHandler(this.MenuHome_Selected);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MenuNotification = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 32 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
            this.MenuNotification.Selected += new System.Windows.RoutedEventHandler(this.MenuNotification_Selected);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MenuSurvey = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 38 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
            this.MenuSurvey.Selected += new System.Windows.RoutedEventHandler(this.MenuSurvey_Selected);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MenuAnamnesis = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 44 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
            this.MenuAnamnesis.Selected += new System.Windows.RoutedEventHandler(this.MenuAnamnesis_Selected);
            
            #line default
            #line hidden
            return;
            case 9:
            this.MenuSettings = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 50 "..\..\..\..\..\Windows\PatientWindows\Home.xaml"
            this.MenuSettings.Selected += new System.Windows.RoutedEventHandler(this.MenuSettings_Selected);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Main = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

