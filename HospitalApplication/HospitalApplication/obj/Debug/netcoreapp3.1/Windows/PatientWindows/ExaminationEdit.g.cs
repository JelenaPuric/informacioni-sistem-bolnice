﻿#pragma checksum "..\..\..\..\..\Windows\PatientWindows\ExaminationEdit.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39B61AA5ADF638E5DBB2D7EFADD4AE95BAD63E73"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalApplication.Windows.Patient1;
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


namespace HospitalApplication.Windows.Patient1 {
    
    
    /// <summary>
    /// WindowExaminationEdit
    /// </summary>
    public partial class WindowExaminationEdit : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\Windows\PatientWindows\ExaminationEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combo;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\Windows\PatientWindows\ExaminationEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonOk;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\Windows\PatientWindows\ExaminationEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label oldDoctor;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\Windows\PatientWindows\ExaminationEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label newDoctor;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalApplication;component/windows/patientwindows/examinationedit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\PatientWindows\ExaminationEdit.xaml"
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
            this.Combo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.ButtonOk = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\..\Windows\PatientWindows\ExaminationEdit.xaml"
            this.ButtonOk.Click += new System.Windows.RoutedEventHandler(this.ButtonOk_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.oldDoctor = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.newDoctor = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
