﻿#pragma checksum "..\..\ProcesoVenta.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "72B6DAC20786E2D3A6BF11297FBA71CACD8333FFC606FEF7767184D8E46BA72A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MaipoGrandeApp;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace MaipoGrandeApp {
    
    
    /// <summary>
    /// ProcesoVenta
    /// </summary>
    public partial class ProcesoVenta : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 13 "..\..\ProcesoVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataPedido;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ProcesoVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataDetalle;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\ProcesoVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTablaPedidos;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\ProcesoVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTablaDetalle;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\ProcesoVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbProceso;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\ProcesoVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxEstadoPedido;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\ProcesoVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnIniciarProceso;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\ProcesoVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.Flyout FlyAsignarProductor;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\ProcesoVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataProduccion;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\ProcesoVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEnviarSolicitud;
        
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
            System.Uri resourceLocater = new System.Uri("/MaipoGrandeApp;component/procesoventa.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ProcesoVenta.xaml"
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
            this.dataPedido = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.dataDetalle = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.lbTablaPedidos = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lbTablaDetalle = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lbProceso = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.cbxEstadoPedido = ((System.Windows.Controls.ComboBox)(target));
            
            #line 62 "..\..\ProcesoVenta.xaml"
            this.cbxEstadoPedido.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbxEstadoPedido_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 63 "..\..\ProcesoVenta.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BtnIniciarProceso = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\ProcesoVenta.xaml"
            this.BtnIniciarProceso.Click += new System.Windows.RoutedEventHandler(this.BtnIniciarProceso_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.FlyAsignarProductor = ((MahApps.Metro.Controls.Flyout)(target));
            return;
            case 11:
            this.DataProduccion = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 12:
            this.BtnEnviarSolicitud = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\ProcesoVenta.xaml"
            this.BtnEnviarSolicitud.Click += new System.Windows.RoutedEventHandler(this.BtnEnviarSolicitud_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 53 "..\..\ProcesoVenta.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAsignarProductor_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

