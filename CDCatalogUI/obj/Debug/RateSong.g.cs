﻿#pragma checksum "..\..\RateSong.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D0DE61777D3283B9E1400ABD446D3D12"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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


namespace CDCatalogUI {
    
    
    /// <summary>
    /// RateSong
    /// </summary>
    public partial class RateSong : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\RateSong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRateSongTitle;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\RateSong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRateSongArtist;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\RateSong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRateSongAlbum;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\RateSong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxRateSongRating;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\RateSong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRateSongGo;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\RateSong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRateSongCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/CDCatalogUI;component/ratesong.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RateSong.xaml"
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
            this.lblRateSongTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblRateSongArtist = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lblRateSongAlbum = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.comboBoxRateSongRating = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.btnRateSongGo = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\RateSong.xaml"
            this.btnRateSongGo.Click += new System.Windows.RoutedEventHandler(this.btnRateSongGo_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnRateSongCancel = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\RateSong.xaml"
            this.btnRateSongCancel.Click += new System.Windows.RoutedEventHandler(this.btnRateSongCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
