﻿#pragma checksum "..\..\..\..\Pages\CreateFarmProfilePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F9066FE1755CA44F85ECA481A19F57B52CB84B7E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FSIncome.Windows.Pages;
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


namespace FSIncome.Windows.Pages {
    
    
    /// <summary>
    /// CreateFarmProfilePage
    /// </summary>
    public partial class CreateFarmProfilePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\Pages\CreateFarmProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CurrencyLabel;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Pages\CreateFarmProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTextBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Pages\CreateFarmProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LocalisationTextBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Pages\CreateFarmProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BankAccTextBox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Pages\CreateFarmProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextButton;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Pages\CreateFarmProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Pages\CreateFarmProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame pageFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FSIncome.Windows;component/pages/createfarmprofilepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\CreateFarmProfilePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CurrencyLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.NameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.LocalisationTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.BankAccTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.nextButton = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\Pages\CreateFarmProfilePage.xaml"
            this.nextButton.Click += new System.Windows.RoutedEventHandler(this.nextButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\Pages\CreateFarmProfilePage.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.pageFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

