﻿#pragma checksum "..\..\..\..\view\EndWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C4EA48AF4EAC0841885F7F3A9DA8E9C1770BE021"
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
    /// EndWindow
    /// </summary>
    public partial class EndWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\view\EndWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRestart;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\view\EndWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnClose;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\view\EndWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label resultGame;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\view\EndWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label knightPV;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\view\EndWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image GUIpv;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\view\EndWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label orkKill;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\view\EndWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image GUIork;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\view\EndWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label treasure;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\view\EndWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image GUIchest;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SAE_Dungeons;component/view/endwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\view\EndWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BtnRestart = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\view\EndWindow.xaml"
            this.BtnRestart.Click += new System.Windows.RoutedEventHandler(this.RelaunchApplication);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnClose = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\view\EndWindow.xaml"
            this.BtnClose.Click += new System.Windows.RoutedEventHandler(this.CloseApplication);
            
            #line default
            #line hidden
            return;
            case 3:
            this.resultGame = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.knightPV = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.GUIpv = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.orkKill = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.GUIork = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.treasure = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.GUIchest = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

