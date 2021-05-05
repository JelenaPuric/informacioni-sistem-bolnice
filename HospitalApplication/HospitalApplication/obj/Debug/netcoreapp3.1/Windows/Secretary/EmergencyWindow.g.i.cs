﻿#pragma checksum "..\..\..\..\..\Windows\Secretary\EmergencyWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1EC3BB14192DAFBC8635A2BFEFC1D1B040DAF876"
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
    /// EmergencyWindow
    /// </summary>
    public partial class EmergencyWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\Windows\Secretary\EmergencyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboTypeDoctor;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\Windows\Secretary\EmergencyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboFreeTerms;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\Windows\Secretary\EmergencyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboSheduledTerms;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\Windows\Secretary\EmergencyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboAvailableDoctors;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Windows\Secretary\EmergencyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label debug;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Windows\Secretary\EmergencyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonFilter;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\Windows\Secretary\EmergencyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonOk;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalApplication;component/windows/secretary/emergencywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\Secretary\EmergencyWindow.xaml"
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
            this.ComboTypeDoctor = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.ComboFreeTerms = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.ComboSheduledTerms = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.ComboAvailableDoctors = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.debug = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.ButtonFilter = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\..\Windows\Secretary\EmergencyWindow.xaml"
            this.ButtonFilter.Click += new System.Windows.RoutedEventHandler(this.ButtonFilter_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonOk = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\..\Windows\Secretary\EmergencyWindow.xaml"
            this.ButtonOk.Click += new System.Windows.RoutedEventHandler(this.ButtonOk_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

