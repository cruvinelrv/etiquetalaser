﻿#pragma checksum "..\..\Window1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "721A384C255666DAA82087E2F056A3AF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
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


namespace wpfEtiquetaLaser {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\Window1.xaml"
        internal System.Windows.Controls.Grid grid1;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\Window1.xaml"
        internal System.Windows.Shapes.Rectangle rectangle1;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBox lstbxPesquisaProduto;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button btnPesquisaProduto;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBox txtPesquisaProduto;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\Window1.xaml"
        internal System.Windows.Shapes.Rectangle rectangle2;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Window1.xaml"
        internal System.Windows.Controls.ComboBox cmbGrade;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label lblProduto;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Window1.xaml"
        internal System.Windows.Controls.ComboBox cmbQtd;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button btnJogaGrade;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Window1.xaml"
        internal System.Windows.Shapes.Rectangle rectangle3;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBox lstbxEtiquetas;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button btnImprimir;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label label3;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label label4;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label lblQtdEtiquetas;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button btnLimpar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/wpfEtiquetaLaser;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grid1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.rectangle1 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 3:
            this.lstbxPesquisaProduto = ((System.Windows.Controls.ListBox)(target));
            
            #line 7 "..\..\Window1.xaml"
            this.lstbxPesquisaProduto.KeyDown += new System.Windows.Input.KeyEventHandler(this.lstbxPesquisaProduto_KeyDown);
            
            #line default
            #line hidden
            
            #line 7 "..\..\Window1.xaml"
            this.lstbxPesquisaProduto.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.lstbxPesquisaProduto_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnPesquisaProduto = ((System.Windows.Controls.Button)(target));
            
            #line 8 "..\..\Window1.xaml"
            this.btnPesquisaProduto.Click += new System.Windows.RoutedEventHandler(this.btnPesquisaProduto_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtPesquisaProduto = ((System.Windows.Controls.TextBox)(target));
            
            #line 9 "..\..\Window1.xaml"
            this.txtPesquisaProduto.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtPesquisaProduto_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.rectangle2 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 7:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Window1.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.button1_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cmbGrade = ((System.Windows.Controls.ComboBox)(target));
            
            #line 12 "..\..\Window1.xaml"
            this.cmbGrade.KeyDown += new System.Windows.Input.KeyEventHandler(this.cmbGrade_KeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lblProduto = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.cmbQtd = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\Window1.xaml"
            this.cmbQtd.KeyDown += new System.Windows.Input.KeyEventHandler(this.cmbQtd_KeyDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnJogaGrade = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\Window1.xaml"
            this.btnJogaGrade.Click += new System.Windows.RoutedEventHandler(this.btnJogaGrade_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.rectangle3 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 13:
            this.lstbxEtiquetas = ((System.Windows.Controls.ListBox)(target));
            
            #line 17 "..\..\Window1.xaml"
            this.lstbxEtiquetas.KeyDown += new System.Windows.Input.KeyEventHandler(this.lstbxEtiquetas_KeyDown);
            
            #line default
            #line hidden
            return;
            case 14:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.btnImprimir = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\Window1.xaml"
            this.btnImprimir.Click += new System.Windows.RoutedEventHandler(this.btnImprimir_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 17:
            this.label3 = ((System.Windows.Controls.Label)(target));
            return;
            case 18:
            this.label4 = ((System.Windows.Controls.Label)(target));
            return;
            case 19:
            this.lblQtdEtiquetas = ((System.Windows.Controls.Label)(target));
            return;
            case 20:
            this.btnLimpar = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Window1.xaml"
            this.btnLimpar.Click += new System.Windows.RoutedEventHandler(this.btnLimpar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}