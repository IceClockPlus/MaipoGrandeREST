   M S B A M L   `   `   `  ����I  EMaipoGrandeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MaipoGrandeAppMaipoGrandeApp  5      #    MaipoGrandeApp.RevisarPedidos   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      H DMahApps.Metro, Version=1.6.1.4, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      (localclr-namespace:MaipoGrandeApp  5        N� Title$  RevisarPedidos��5
      .��5      � 
�������$��	0,0,-44,0q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dataPedido��5      $��223,374,136,20q�6'      AutoGenerateColumns .     
IsReadOnly .  � ToolTip$' !Seleccione un pedido para revisar��6m      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *IdItemPedido+6T     5      $ Producto��6%    67   �� *Producto.NombreProducto+6f     5      $ Cantidad��6%    67   �� *
Cantidad+6V     5      $ Calidad��6%    66   �� *	Calidad+6T     5      $ 	Productor��6%    68   �� *Productor.Nombre+6_   5        5   
   -   5        $ dataProductor��5      $
��Left=�6*   $	��242��6E    .  $��	29,69,0,0q�6n   $	��Top=�6�   $	��395��6�    .  5        5      $ Id��6%    61   �� *Productor.Id+6T     5      $ Nombre��6%    65   �� *Productor.Nombre+6\     5      $ Correo��6%    65   �� *Productor.Correo+6\     5      $ Producto��6%    67   �� *Producto.NombreProducto+6e     5      $ Precio Lower��6%    6;   �� *PrecioLower+6]     5      $ Precio Estandar��6%    6>   �� *PrecioEstandar+6c     5      $ Precio Premium��6%    6=   �� *PrecioPremium+6a   5       �� 5!   
   -   5         ��Name$ 
btnAsignar��5!      $��Asignar��6%   $
��Left=�67   $��
29,393,0,0q�6R   $	��Top=�6f   $	��130��6~   6�     5"   
   -   5        $ dataProducto��5"      $
��Left=�6)   $	��242��6D   $��
451,69,0,0q�6Q   $	��Top=�6e   $	��375��6}    .   .  5#        5$      $ Id��6%    61   �� *IdParticipacion+6W     5%      $ 	Productor��6%    68   �� *Productor.Nombre+6_     5&      $ Pedido��6%    65   �� *
IdPedido+6T     5'      $ Estado��6%    65   �� *EstadoParticipacion+6_   5)      �� 5*   
   -   5        	 ��Name$	 lbTablaProductor��5*      $��Tabla Productor��6*   $
��Left=�6D   $��	10,43,0,0q�6_   $	��Top=�6r   $��16(�6�   �� 5+   
   -   5        $	 lbTablaProductos��5+      $��Tabla Participaciones��6*   $
��Left=�6J   $��
451,43,0,0q�6e   $	��Top=�6y   $��16(�6�   �� 5,   
   -   5        $	 lbTablaDetalle��5,      $��Tabla Detalle��6(   $
��Left=�6@   $��223,343,0,0q�6[   $	��Top=�6p   $��16(�6�   �� 5-   
   -   5        $ btn_Detalle��5-      $
��Test��6&   $
��Left=�65   $��532,316,0,0q�6P   $	��Top=�6e   $��75��6}   6�   5.      5/      