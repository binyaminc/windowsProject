﻿#pragma checksum "..\..\..\admin\AdminLogin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "98FFE35F6F19FEE9F15E8E239B165FB2AE65BB3ECC0D1F6CA2FA1249320CF933"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PLWPF.admin;
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


namespace PLWPF.admin {
    
    
    /// <summary>
    /// AdminLogin
    /// </summary>
    public partial class AdminLogin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 76 "..\..\..\admin\AdminLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label adminLoginLabel;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\admin\AdminLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label userLabel;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\admin\AdminLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label passwordLabel;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\admin\AdminLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Username;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\admin\AdminLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\admin\AdminLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loginButton;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/admin/adminlogin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\admin\AdminLogin.xaml"
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
            this.adminLoginLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.userLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.passwordLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Username = ((System.Windows.Controls.TextBox)(target));
            
            #line 79 "..\..\..\admin\AdminLogin.xaml"
            this.Username.KeyDown += new System.Windows.Input.KeyEventHandler(this.enter_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Password = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 80 "..\..\..\admin\AdminLogin.xaml"
            this.Password.KeyDown += new System.Windows.Input.KeyEventHandler(this.enter_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.loginButton = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\admin\AdminLogin.xaml"
            this.loginButton.Click += new System.Windows.RoutedEventHandler(this.Login_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 82 "..\..\..\admin\AdminLogin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

