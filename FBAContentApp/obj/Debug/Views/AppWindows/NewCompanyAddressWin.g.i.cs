﻿#pragma checksum "..\..\..\..\Views\AppWindows\NewCompanyAddressWin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D0B91996BDFAC7E235041C3F90858C21D4D998B5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FBAContentApp.Views.AppWindows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace FBAContentApp.Views.AppWindows {
    
    
    /// <summary>
    /// NewCompanyAddressWin
    /// </summary>
    public partial class NewCompanyAddressWin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\Views\AppWindows\NewCompanyAddressWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCompName;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Views\AppWindows\NewCompanyAddressWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCompAddress1;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Views\AppWindows\NewCompanyAddressWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCompAddress2;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Views\AppWindows\NewCompanyAddressWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCompAddress3;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Views\AppWindows\NewCompanyAddressWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCompCity;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Views\AppWindows\NewCompanyAddressWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboState;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Views\AppWindows\NewCompanyAddressWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtZip;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FBAContentApp;component/views/appwindows/newcompanyaddresswin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\AppWindows\NewCompanyAddressWin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtCompName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtCompAddress1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtCompAddress2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtCompAddress3 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtCompCity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.comboState = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.txtZip = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 62 "..\..\..\..\Views\AppWindows\NewCompanyAddressWin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Save_Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 63 "..\..\..\..\Views\AppWindows\NewCompanyAddressWin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
