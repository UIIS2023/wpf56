﻿#pragma checksum "..\..\..\Forme\Navijac.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3B246D3CE6EC52DE1B5D1233F8D820F86ACE02608221F20846ED879624FCE79A"
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
using WpfKosarkaskiKlub.Forme;


namespace WpfKosarkaskiKlub.Forme {
    
    
    /// <summary>
    /// Navijac
    /// </summary>
    public partial class Navijac : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Forme\Navijac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIme;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Forme\Navijac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrezime;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Forme\Navijac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBrojSezonskeKarte;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Forme\Navijac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBrojGodina;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Forme\Navijac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Forme\Navijac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOtkazi;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Forme\Navijac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbKosarkaskiKlub;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfKosarkaskiKlub;component/forme/navijac.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forme\Navijac.xaml"
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
            this.txtIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtPrezime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtBrojSezonskeKarte = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtBrojGodina = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Forme\Navijac.xaml"
            this.btnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.btnSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnOtkazi = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Forme\Navijac.xaml"
            this.btnOtkazi.Click += new System.Windows.RoutedEventHandler(this.btnOtkazi_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cbKosarkaskiKlub = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

