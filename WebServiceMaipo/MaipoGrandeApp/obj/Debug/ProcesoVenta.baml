   M S B A M L   `   `   `  ����I  EMaipoGrandeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MaipoGrandeAppMaipoGrandeApp  5      !    MaipoGrandeApp.ProcesoVenta   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      H DMahApps.Metro, Version=1.6.1.4, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      (localclr-namespace:MaipoGrandeApp  5        N� Title$  ProcesoVenta��5
      .��5      � 
�������.+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dataPedido��5      $
��Left=�6'   $	��157��6B   $��
44,127,0,0q�6O   $	��Top=�6c   $	��722��6{      AutoGenerateColumns .     
IsReadOnly .  � ToolTip$$ Seleccione pedido para revisar��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
IdPedido+6P     5      $ Fecha inicio��6%    6;   �� *FechaPedido+6]     5      $ Fecha Entrega��6%    6<   �� *FechaEntrega+6_     5      $ 	Direccion��6%    68   �� *	Direccion+6X     5      $ Cliente��6%    66   �� *Cliente.Nombre+6[     5      $ Estado��6%    65   �� * EstadoPedido.DescripcionEstado+6j     5      $ Ciudad��6%    65   �� *Ciudad+6R     5      $
 Pais��6%    63   �� *Pais+6N   5        5   
   -   5        $ dataDetalle��5       . $
��Left=�6:   $	��151��6U   $��
44,419,0,0q�6b   $	��Top=�6v   $	��722��6�    .   5        5      $ Id��6%    61   �� *IdItemPedido+6T     5      $ Nombre producto��6%    6>   �� *Producto.NombreProducto+6l     5      $ Cantidad (Kg)��6%    6<   �� *
Cantidad+6[     5      $ Precio��6%    65   �� *Precio+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Productor Asignado��6)      CellTemplate 5       �� 5!      .R�5"      �� ��5#   "   �� 5$   &   	 �� 
TargetType"	 ��6,   .�5%   *   �� 
 �� Property
 � �� �� Value 6A   �� *Productor.Nombre+ �� Triggers 5&   *   �� 5'   .    �� Binding 6:   �� *Productor.Nombre+ �� Value  6_   .a�5(   2   �� 
 � ��$ No Asignado��6I   5)   /   5+   '   5-      5.      50        51      $ Estado��6%    65   �� *Estado+6R     52       53      �� 54      .R�55      ��  ��Name$ BtnAsignarProductor��6%   -   5        $��Asignar��55   d      AccentedSquareButtonStyle#��[  6v   6�   56      58      5:      �� 5;   
   -   5         ��Name$ lbTablaPedidos��5;      $��Revisión de Pedidos��6(   $
��Left=�6F   $��	44,91,0,0q�6a   $	��Top=�6t   $��16(�6�   �� 5<   
   -   5        $ lbTablaDetalle��5<      $��Detalle del Pedido��6(   $
��Left=�6E   $��
44,383,0,0q�6`   $	��Top=�6t   $��16(�6�   �� 5=   
   -   5        $ 	lbProceso��5=      $��Proceso de Venta��6#   $
��Left=�6>   $��	44,10,0,0q�6Y   $	��Top=�6l   $��22(�6�   �� 5>   
   -   5         ��Name$ cbxEstadoPedido��5>      $
��Left=�6,   $��
199,96,0,0q�6G   $	��Top=�6[   $	��120��6s   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Filtro Pedido��6�   �� 5?   
   -   5        $��Revisar��5?      $
��Left=�6#   $��
70,289,0,0q�6>   $	��Top=�6R   $��74��6j   6u   �� 5@   
   -	   5        $ BtnIniciarProceso��5@   "   {�. $��Iniciar Proceso��6=   $
��Left=�6W   $��184,289,0,0q�6r   $	��Top=�6�   $	��110��6�    J� RenderTransformOrigin$ -0.695,-0.983&�6�   +  %MahApps.Metro.Controls.FlyoutsControl  5C   
   .@�5D      #  MahApps.Metro.Controls.Flyout  -
   5          Name$ FlyAsignarProductor��5D      $	��724��6;   ���	#FFF7955C J� Opacity$	 0.8Q�6^   $��Asignar Productor��6l   $��79,0,-11,214q�6�   $��Right=�6�   $��RightToLeft=�6�   .��5E      �� $
��Left=�6   $	��315��64   $	��724��6A   .+�5F        -   5        $ DataProduccion��5F       .  .   �� Left$	 108��6f    5G        5H      $ Nombre��61    6A   �� *Productor.Nombre+6h     5I      $ Producto��61    6C   �� *Producto.NombreProducto+6q     5J      $ Precio Lower��61    6G   �� *PrecioLower+6i     5K      $ Precio Estandar��61    6J   �� *PrecioEstandar+6o     5L      $ Precio Premium��61    6I   �� *PrecioPremium+6m   5N      �� 5O      -   5        $ BtnEnviarSolicitud��5O      $��Asignar Productor��69   $	 414��6U   
 �� Top$	 232��6g   $	��144��6x   $��37��6�   6�   5P      5R      5U      5W      5X      