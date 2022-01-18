﻿#pragma checksum "..\..\..\..\Customization\StudentCustomization.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77D99B698487676C0572B5A3AC9D8E6533CC70EE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GPACalculator;
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


namespace GPACalculator {
    
    
    /// <summary>
    /// StudentCustomization
    /// </summary>
    public partial class StudentCustomization : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\Customization\StudentCustomization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border SemesterDisplayBorder;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Customization\StudentCustomization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textGPADisplay;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Customization\StudentCustomization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StudentNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Customization\StudentCustomization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCompleteStudent;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Customization\StudentCustomization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCalculateGPA;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GPACalculator_kmxdm1em_wpftmp;component/customization/studentcustomization.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Customization\StudentCustomization.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SemesterDisplayBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.textGPADisplay = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.StudentNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnCompleteStudent = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Customization\StudentCustomization.xaml"
            this.btnCompleteStudent.Click += new System.Windows.RoutedEventHandler(this.CompleteStudent);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnCalculateGPA = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Customization\StudentCustomization.xaml"
            this.btnCalculateGPA.Click += new System.Windows.RoutedEventHandler(this.CalculateGPA);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

