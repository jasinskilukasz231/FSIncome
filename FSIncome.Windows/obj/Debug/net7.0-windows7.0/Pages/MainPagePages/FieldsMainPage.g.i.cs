﻿#pragma checksum "..\..\..\..\..\Pages\MainPagePages\FieldsMainPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F751F712ED60C49F0407E319B15A760908FC217D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FSIncome.Windows.Pages.MainPagePages;
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


namespace FSIncome.Windows.Pages.MainPagePages {
    
    
    /// <summary>
    /// FieldsMainPage
    /// </summary>
    public partial class FieldsMainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\Pages\MainPagePages\FieldsMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popup;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Pages\MainPagePages\FieldsMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox deleteTextBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Pages\MainPagePages\FieldsMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\Pages\MainPagePages\FieldsMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame pageFrame;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\Pages\MainPagePages\FieldsMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\..\..\Pages\MainPagePages\FieldsMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton addButton;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\..\Pages\MainPagePages\FieldsMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton removeButton;
        
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
            System.Uri resourceLocater = new System.Uri("/FSIncome.Windows;V1.0.0.0;component/pages/mainpagepages/fieldsmainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\MainPagePages\FieldsMainPage.xaml"
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
            
            #line 30 "..\..\..\..\..\Pages\MainPagePages\FieldsMainPage.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.deleteButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.pageFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 5:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.addButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 138 "..\..\..\..\..\Pages\MainPagePages\FieldsMainPage.xaml"
            this.addButton.Click += new System.Windows.RoutedEventHandler(this.addButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.removeButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

