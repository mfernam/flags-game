﻿#pragma checksum "..\..\..\..\Views\GameView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2E4E56498FA779E76CF04DC37744EB91A27BD6A5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using FlagsGame.GUI.View.Views;
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


namespace FlagsGame.GUI.View.Views {
    
    
    /// <summary>
    /// GameView
    /// </summary>
    public partial class GameView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Views\GameView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button africa;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\Views\GameView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button asia;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Views\GameView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button europe;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Views\GameView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button north_america;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Views\GameView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button south_america;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Views\GameView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button oceania;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Views\GameView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAll;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Views\GameView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FlagsGame.GUI.View;component/views/gameview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\GameView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.africa = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\..\..\Views\GameView.xaml"
            this.africa.Click += new System.Windows.RoutedEventHandler(this.btnContinent_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.asia = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\..\Views\GameView.xaml"
            this.asia.Click += new System.Windows.RoutedEventHandler(this.btnContinent_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.europe = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\Views\GameView.xaml"
            this.europe.Click += new System.Windows.RoutedEventHandler(this.btnContinent_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.north_america = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\..\Views\GameView.xaml"
            this.north_america.Click += new System.Windows.RoutedEventHandler(this.btnContinent_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.south_america = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\Views\GameView.xaml"
            this.south_america.Click += new System.Windows.RoutedEventHandler(this.btnContinent_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.oceania = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\Views\GameView.xaml"
            this.oceania.Click += new System.Windows.RoutedEventHandler(this.btnContinent_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnAll = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\Views\GameView.xaml"
            this.btnAll.Click += new System.Windows.RoutedEventHandler(this.btnAll_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\Views\GameView.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

