﻿#pragma checksum "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BFEF46E9C20616E34C4CAFB233FDDE811EC210D6"
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
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
    /// AllPatientsWindow
    /// </summary>
    public partial class AllPatientsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuNew;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuOpenMR;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuExit;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuDelete;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuEdit;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuView;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvUsers;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalApplication;component/windows/secretarywindows/allpatientswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
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
            this.menuNew = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
            this.menuNew.Click += new System.Windows.RoutedEventHandler(this.menuNew_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.menuOpenMR = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
            this.menuOpenMR.Click += new System.Windows.RoutedEventHandler(this.menuOpenMR_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.menuExit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 25 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
            this.menuExit.Click += new System.Windows.RoutedEventHandler(this.menuExit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.menuDelete = ((System.Windows.Controls.MenuItem)(target));
            
            #line 30 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
            this.menuDelete.Click += new System.Windows.RoutedEventHandler(this.menuDelete_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.menuEdit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 34 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
            this.menuEdit.Click += new System.Windows.RoutedEventHandler(this.menuEdit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.menuView = ((System.Windows.Controls.MenuItem)(target));
            
            #line 38 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
            this.menuView.Click += new System.Windows.RoutedEventHandler(this.menuView_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 65 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MedicalRecord_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 71 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackHome_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 78 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RegisterPatient_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 84 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeletePatient_Click_1);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 90 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditPatient_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 96 "..\..\..\..\..\Windows\SecretaryWindows\AllPatientsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ViewPatient_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.lvUsers = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

