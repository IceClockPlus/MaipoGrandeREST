   M S B A M L   `   `   `  ����I  EMaipoGrandeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MaipoGrandeAppMaipoGrandeApp  5      '    !MaipoGrandeApp.DocumentoVentaView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      H DMahApps.Metro, Version=1.6.1.4, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      (localclr-namespace:MaipoGrandeApp  5        N� Title$  DocumentoVentaView��5
      .��5      � 
�������.+�5   
   �� $��18(�6   $��Documentos de Venta��6   $
��Left=�6<   $��	10,42,0,0q�6W   $	��Top=�6j   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataDocumento��5         AutoGenerateColumns .     
IsReadOnly . $
��Left=�6X   $	��184��6s   $��
10,108,0,0q�6�   $	��Top=�6�   $	��780��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID Documento��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *IdDocumento+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Fecha Emisión��6)      CellTemplate 5      �� 5      .R�5      �� ��5   "   �� 5   &    �� 
TargetType" ��6,   .�5   *   �� 	 �� Property	 � ��
 �� Value
 6A   �� *FechaEmision+ �� Triggers 5   *   �� 5   .    �� Binding 6:   �� *FechaEmision+ �� Value 6[   Z� .a�5   2   �� 	 � ��$
 
No Emitido��6I   5   /   5   '   5      5       5"        5#      $ Precio Productos��6%    6?   �� *PrecioProducto+  5$      $ Precio Transporte��6%    6@   �� *PrecioTransporte+  5%      $ Subtotal��6%    67   �� *
Subtotal+  5&      $ Total��6%    64   �� *Total+  5'      $ Estado��6%    65   �� *EstadoDocumento.Descripcion+  5(      $ 	Id Pedido��6%    68   �� *Pedido.IdPedido+5*      �� 5+   
   $
��Left=�6   $��43��6/   $��
10,342,0,0q�6;   $	��Top=�6O   $	��780��6g    J� RenderTransformOrigin$ 
0.51,1.393&�6s   � 5,   
   -   5         �Name$ 
gridPedido��5,      $
��Left=�6$   $	��230��6?   $��
10,374,0,0q�6L   $	��Top=�6`   $	��780��6x    � ColumnDefinitions 5-      �� 5.      $	��32* �6#   �� 5/      $	��23* �6#   �� 50      $
��205* �6#   .+�52      �� $��15(�6   $��Resumen de Pedido��6"   $
��Left=�6>   $��10,0,0,0q�6Y   $	��Top=�6k   $��2��6�   �� 53      $��13(�6   $��
Id Pedido:��6"   $
��Left=�67   $��	10,62,0,0q�6R   $	��Top=�6e   $
��Bold"�6}   �� 54      $��13(�6   $��Cliente:��6"   $
��Left=�65   $��	58,62,0,0q�6P   $	��Top=�6c   $ 0.596,0.462&�6{   $
��Bold"�6�   $��1��6�   $��2��6�   �� 55      $��13(�6   $��Dirección:��6"   $
��Left=�67   $��
10,107,0,0q�6R   $	��Top=�6f   $
��Bold"�6~     56      -   5        $ dataDetalle��56       .   . $
��Bold"�6Z   $
��Left=�6l   $	��132��6�   $��
212,10,0,0q�6�   $	��Top=�6�   $	��393��6�   $��2��6�    57        58      $ Producto��6)    6;   �� *Producto.NombreProducto+  59      $ Cantidad��6)    6;   �� *
Cantidad+  5:      $ Calidad��6)    6:   �� *	Calidad+  5;      $ Precio��6)    69   �� *Precio+5=      �� 5>      $��13(�6   $��Ciudad:��6"   $
��Bold"�64   $
��Left=�6F   $��
10,151,0,0q�6a   $	��Top=�6u   �� 5?      $��13(�6   $��Pais:��6"   $
��Left=�62   $
��Bold"�6M   $��
10,194,0,0q�6_   $	��Top=�6s   �� 5@      $��13(�6   $��Estado:��6"   $
��Left=�64   $
��Bold"�6O   $��
58,194,0,0q�6a   $	��Top=�6u   $ 0.596,0.462&�6�   $��1��6�   $��2��6�   �� 5A      -   5         ��Name$ txtIdPedido��5A      $�� ��6)   $
��Left=�64   $��	75,62,0,0q�6O   $	��Top=�6b   $��36��6z   $��2��6�   �� 5B      -   5        $ txtDireccion��5B      $�� ��6*   $
��Left=�65   $��
75,107,0,0q�6P   $	��Top=�6d   $	��133��6|   $��3��6�   �� 5C      -   5        $ 	txtCiudad��5C      $�� ��6'   $
��Left=�62   $��
75,151,0,0q�6M   $	��Top=�6a   $	��116��6y   $��3��6�   �� 5D      -   5        $ txtPais��5D      $�� ��6%   $
��Left=�60   $��
45,194,0,0q�6K   $	��Top=�6_   $��94��6w   $ 
-1.9,0.462&�6�   $��2��6�   �� 5E      -   5        $ 
txtCliente��5E      $�� ��6(   $
��Left=�63   $��	41,62,0,0q�6N   $	��Top=�6a   $��62��6y   $��2��6�   �� 5F      -	   5        $ 	txtEstado��5F      $�� ��6'   $
��Left=�62   $��
41,194,0,0q�6M   $	��Top=�6a   $	��105��6y   $ 	0.3,4.115&�6�   $��2��6�   5H      �� 5I   
   -
   5         ��Name$ 
BtnRevisar��5I      $��Revisar��6%   $
��Left=�67   $��
28,297,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5J   
   -   5        $ BtnHabilitarPago��5J      $��Habilitar Pago��6+   $
��Left=�6D   $��155,297,0,0q�6_   $	��Top=�6t   $	��111��6�   6�   5L      5M      