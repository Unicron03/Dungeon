﻿#pragma checksum "..\..\..\..\view\PathWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FFEFC2C1F9D74EF0D4C6D6BB2302806548011206"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using SAE_Dungeons.view;
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


namespace SAE_Dungeons.view {
    
    
    /// <summary>
    /// PathWindow
    /// </summary>
    public partial class PathWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\view\PathWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Xcoord;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\view\PathWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Ycoord;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SAE_Dungeons;component/view/pathwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\view\PathWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Xcoord = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\..\view\PathWindow.xaml"
            this.Xcoord.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.coord_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\..\view\PathWindow.xaml"
            this.Xcoord.LostFocus += new System.Windows.RoutedEventHandler(this.coord_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Ycoord = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\..\view\PathWindow.xaml"
            this.Ycoord.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.coord_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\..\view\PathWindow.xaml"
            this.Ycoord.LostFocus += new System.Windows.RoutedEventHandler(this.coord_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 33 "..\..\..\..\view\PathWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DrawShortestPath);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 34 "..\..\..\..\view\PathWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CleanShortestPath);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 42 "..\..\..\..\view\PathWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DrawShortestPath);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 43 "..\..\..\..\view\PathWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DrawShortestPath);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 44 "..\..\..\..\view\PathWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DrawShortestPath);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 45 "..\..\..\..\view\PathWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DrawShortestPath);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

