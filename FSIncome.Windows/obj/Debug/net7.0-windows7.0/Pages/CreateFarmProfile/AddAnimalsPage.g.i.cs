﻿#pragma checksum "..\..\..\..\..\Pages\CreateFarmProfile\AddAnimalsPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AE60C838F0626C6764FA5BA7ACA20ACDEB55EA18"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FSIncome.Windows.Pages.CreateFarmProfile;
using ScottPlot;
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


namespace FSIncome.Windows.Pages.CreateFarmProfile {
    
    
    /// <summary>
    /// AddAnimalsPage
    /// </summary>
    public partial class AddAnimalsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\..\Pages\CreateFarmProfile\AddAnimalsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popup;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\Pages\CreateFarmProfile\AddAnimalsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox deleteTextBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\Pages\CreateFarmProfile\AddAnimalsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\Pages\CreateFarmProfile\AddAnimalsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\..\Pages\CreateFarmProfile\AddAnimalsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button finishButton;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\..\Pages\CreateFarmProfile\AddAnimalsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addButton;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\..\Pages\CreateFarmProfile\AddAnimalsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton removeButton;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\..\Pages\CreateFarmProfile\AddAnimalsPage.xaml"
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
            System.Uri resourceLocater = new System.Uri("/FSIncome.Windows;V1.0.0.0;component/pages/createfarmprofile/addanimalspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\CreateFarmProfile\AddAnimalsPage.xaml"
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
            this.popup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 2:
            this.deleteTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\..\Pages\CreateFarmProfile\AddAnimalsPage.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.deleteButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.finishButton = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\..\..\..\Pages\CreateFarmProfile\AddAnimalsPage.xaml"
            this.finishButton.Click += new System.Windows.RoutedEventHandler(this.FinishButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.addButton = ((System.Windows.Controls.Button)(target));
            
            #line 103 "..\..\..\..\..\Pages\CreateFarmProfile\AddAnimalsPage.xaml"
            this.addButton.Click += new System.Windows.RoutedEventHandler(this.addButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.removeButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 8:
            this.pageFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

