﻿#pragma checksum "..\..\..\Windows\StartingWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C732F679255F03589A94D6FD1ED4C4F86FD00139BA073C582BF7B1067AF7D2CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using TheBestCarShop___Admin;


namespace TheBestCarShop___Admin {
    
    
    /// <summary>
    /// StartingWindow
    /// </summary>
    public partial class StartingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\Windows\StartingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loginButton;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Windows\StartingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clearFieldsButton;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Windows\StartingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox usernameTextBox;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Windows\StartingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox actualPasswordBox;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Windows\StartingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordTextBox;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\Windows\StartingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label githubLabel;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\Windows\StartingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image logoImage;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\Windows\StartingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label infoLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/TheBestCarShop - Admin;component/windows/startingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\StartingWindow.xaml"
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
            this.loginButton = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Windows\StartingWindow.xaml"
            this.loginButton.Click += new System.Windows.RoutedEventHandler(this.loginButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.clearFieldsButton = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\Windows\StartingWindow.xaml"
            this.clearFieldsButton.Click += new System.Windows.RoutedEventHandler(this.clearFieldsButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.usernameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 79 "..\..\..\Windows\StartingWindow.xaml"
            this.usernameTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.usernameTextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 80 "..\..\..\Windows\StartingWindow.xaml"
            this.usernameTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.usernameTextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.actualPasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 94 "..\..\..\Windows\StartingWindow.xaml"
            this.actualPasswordBox.LostFocus += new System.Windows.RoutedEventHandler(this.actualPasswordBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.passwordTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 113 "..\..\..\Windows\StartingWindow.xaml"
            this.passwordTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.passwordTextBox_GotFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.githubLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.logoImage = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.infoLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

