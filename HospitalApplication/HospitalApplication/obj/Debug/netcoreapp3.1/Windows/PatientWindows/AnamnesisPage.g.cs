#pragma checksum "..\..\..\..\..\Windows\PatientWindows\AnamnesisPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3943799C0D99C2ADDAAC25DEF845348EE28F63BF"
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
    /// AnamnesisPage
    /// </summary>
    public partial class AnamnesisPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\..\Windows\PatientWindows\AnamnesisPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AnamneseInformation;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\Windows\PatientWindows\AnamnesisPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvUsers;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\Windows\PatientWindows\AnamnesisPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\Windows\PatientWindows\AnamnesisPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnamnesisComment;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\..\Windows\PatientWindows\AnamnesisPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubmitComment;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\Windows\PatientWindows\AnamnesisPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CustomNotification;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalApplication;component/windows/patientwindows/anamnesispage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\PatientWindows\AnamnesisPage.xaml"
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
            this.AnamneseInformation = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\..\Windows\PatientWindows\AnamnesisPage.xaml"
            this.AnamneseInformation.Click += new System.Windows.RoutedEventHandler(this.AnamneseInformation_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lvUsers = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 46 "..\..\..\..\..\Windows\PatientWindows\AnamnesisPage.xaml"
            this.Search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AnamnesisComment = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.SubmitComment = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\..\Windows\PatientWindows\AnamnesisPage.xaml"
            this.SubmitComment.Click += new System.Windows.RoutedEventHandler(this.SubmitComment_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CustomNotification = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\..\..\Windows\PatientWindows\AnamnesisPage.xaml"
            this.CustomNotification.Click += new System.Windows.RoutedEventHandler(this.CustomNotification_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

