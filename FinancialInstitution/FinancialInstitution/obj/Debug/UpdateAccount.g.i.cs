﻿#pragma checksum "..\..\UpdateAccount.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1C2B00FD5AC3B96437B79958F3964403F86E69AFC06A3641C1430AD859FDC402"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FinancialInstitution;
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


namespace FinancialInstitution {
    
    
    /// <summary>
    /// UpdateAccount
    /// </summary>
    public partial class UpdateAccount : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\UpdateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblCustomerName;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\UpdateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblOpenDate;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\UpdateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CkbChecking;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\UpdateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CkbSaving;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\UpdateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CkbTaxFreeSaving;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\UpdateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CkbCredit;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\UpdateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LvUpdateAccount;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\UpdateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnUpdateAccountCancel;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\UpdateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnUpdateAccountUpdate;
        
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
            System.Uri resourceLocater = new System.Uri("/FinancialInstitution;component/updateaccount.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UpdateAccount.xaml"
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
            this.LblCustomerName = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.LblOpenDate = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.CkbChecking = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.CkbSaving = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.CkbTaxFreeSaving = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.CkbCredit = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.LvUpdateAccount = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.BtnUpdateAccountCancel = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\UpdateAccount.xaml"
            this.BtnUpdateAccountCancel.Click += new System.Windows.RoutedEventHandler(this.BtnUpdateAccountCancel_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BtnUpdateAccountUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\UpdateAccount.xaml"
            this.BtnUpdateAccountUpdate.Click += new System.Windows.RoutedEventHandler(this.BtnUpdateAccountUpdate_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

