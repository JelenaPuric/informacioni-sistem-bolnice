﻿#pragma checksum "..\..\..\..\..\Windows\PatientWindows\NotificationsPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DBBDC017E7D42DC3C0944F1A2F9AC9278E960B6B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalApplication.Properties;
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
    /// NotificationsPage
    /// </summary>
    public partial class NotificationsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\..\Windows\PatientWindows\NotificationsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MakeNotification;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\Windows\PatientWindows\NotificationsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Information;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\Windows\PatientWindows\NotificationsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditNotification;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\Windows\PatientWindows\NotificationsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelNotification;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Windows\PatientWindows\NotificationsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvUsers;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\Windows\PatientWindows\NotificationsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TestLabela;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HospitalApplication;component/windows/patientwindows/notificationspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\PatientWindows\NotificationsPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MakeNotification = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\..\Windows\PatientWindows\NotificationsPage.xaml"
            this.MakeNotification.Click += new System.Windows.RoutedEventHandler(this.MakeNotification_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Information = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\..\Windows\PatientWindows\NotificationsPage.xaml"
            this.Information.Click += new System.Windows.RoutedEventHandler(this.Information_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EditNotification = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\..\Windows\PatientWindows\NotificationsPage.xaml"
            this.EditNotification.Click += new System.Windows.RoutedEventHandler(this.EditNotification_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CancelNotification = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\..\Windows\PatientWindows\NotificationsPage.xaml"
            this.CancelNotification.Click += new System.Windows.RoutedEventHandler(this.CancelNotification_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lvUsers = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.TestLabela = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

