// Updated by XamlIntelliSenseFileGenerator 4/30/2021 12:48:01 PM
#pragma checksum "..\..\..\..\..\Windows\PatientWindows\NotificationEdit.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1B3E65302EF170F0CE034C3639FF06E4C5828151"
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


namespace HospitalApplication.Windows.Patient1
{


    /// <summary>
    /// WindowNotificationEdit
    /// </summary>
    public partial class WindowNotificationEdit : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 19 "..\..\..\..\..\Windows\PatientWindows\NotificationEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date;

#line default
#line hidden


#line 35 "..\..\..\..\..\Windows\PatientWindows\NotificationEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combo;

#line default
#line hidden


#line 102 "..\..\..\..\..\Windows\PatientWindows\NotificationEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Description;

#line default
#line hidden


#line 110 "..\..\..\..\..\Windows\PatientWindows\NotificationEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonOk;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HospitalApplication;component/windows/patientwindows/notificationedit.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\..\Windows\PatientWindows\NotificationEdit.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.Date = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 2:
                    this.Combo = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 3:
                    this.DrugName = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.Description = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.Days = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.ButtonOk = ((System.Windows.Controls.Button)(target));

#line 110 "..\..\..\..\..\Windows\PatientWindows\NotificationEdit.xaml"
                    this.ButtonOk.Click += new System.Windows.RoutedEventHandler(this.ButtonOk_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBox Title;
        internal System.Windows.Controls.TextBox Repeat;
    }
}
