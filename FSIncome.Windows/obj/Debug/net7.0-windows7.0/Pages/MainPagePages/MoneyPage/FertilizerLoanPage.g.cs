﻿#pragma checksum "..\..\..\..\..\..\Pages\MainPagePages\MoneyPage\FertilizerLoanPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12907DC2409377C7D7D660AA5F10963C4742200B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FSIncome.Windows.Pages.MainPagePages.MoneyPage;
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


namespace FSIncome.Windows.Pages.MainPagePages.MoneyPage {
    
    
    /// <summary>
    /// FertilizerLoanPage
    /// </summary>
    public partial class FertilizerLoanPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\..\..\Pages\MainPagePages\MoneyPage\FertilizerLoanPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label currencyLabel;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\..\Pages\MainPagePages\MoneyPage\FertilizerLoanPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AmountTextBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\..\Pages\MainPagePages\MoneyPage\FertilizerLoanPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceTextBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\..\Pages\MainPagePages\MoneyPage\FertilizerLoanPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TakeLoanButton;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\..\Pages\MainPagePages\MoneyPage\FertilizerLoanPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
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
            System.Uri resourceLocater = new System.Uri("/FSIncome.Windows;component/pages/mainpagepages/moneypage/fertilizerloanpage.xaml" +
                    "", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Pages\MainPagePages\MoneyPage\FertilizerLoanPage.xaml"
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
            this.currencyLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.AmountTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PriceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TakeLoanButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\..\..\Pages\MainPagePages\MoneyPage\FertilizerLoanPage.xaml"
            this.TakeLoanButton.Click += new System.Windows.RoutedEventHandler(this.TakeLoanButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\..\..\Pages\MainPagePages\MoneyPage\FertilizerLoanPage.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.backButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

