﻿#pragma checksum "..\..\..\..\..\Windows\PatientWindows\Patients.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CBED32AF192F91336309C96A2CED8EF94DEA6E31"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalApplication;
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


namespace HospitalApplication {
    
    
    /// <summary>
    /// WindowPatient
    /// </summary>
    public partial class WindowPatient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ScheduleExamination;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelExamination;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MoveExamination;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Notifications;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditExamination;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RateHospital;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RateDoctor;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvUsers;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TestLabela;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalApplication;component/windows/patientwindows/patients.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
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
            this.ScheduleExamination = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
            this.ScheduleExamination.Click += new System.Windows.RoutedEventHandler(this.ScheduleExamination_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CancelExamination = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
            this.CancelExamination.Click += new System.Windows.RoutedEventHandler(this.CancelExamination_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MoveExamination = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
            this.MoveExamination.Click += new System.Windows.RoutedEventHandler(this.MoveExamination_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Notifications = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
            this.Notifications.Click += new System.Windows.RoutedEventHandler(this.Notifications_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EditExamination = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
            this.EditExamination.Click += new System.Windows.RoutedEventHandler(this.EditExamination_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RateHospital = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
            this.RateHospital.Click += new System.Windows.RoutedEventHandler(this.RateHospital_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RateDoctor = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\..\Windows\PatientWindows\Patients.xaml"
            this.RateDoctor.Click += new System.Windows.RoutedEventHandler(this.RateDoctor_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lvUsers = ((System.Windows.Controls.ListView)(target));
            return;
            case 9:
            this.TestLabela = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

