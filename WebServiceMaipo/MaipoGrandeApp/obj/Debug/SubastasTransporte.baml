   M S B A M L   `   `   `  ����I  EMaipoGrandeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MaipoGrandeAppMaipoGrandeApp  5      '    !MaipoGrandeApp.SubastasTransporte   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      H DMahApps.Metro, Version=1.6.1.4, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      (localclr-namespace:MaipoGrandeApp  5        N� Title$  SubastasTransporte��5
      .��5      � 
�������.+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dataPedido��5      $
��Left=�6'   $	��141��6B   $��
23,112,0,0q�6O   $	��Top=�6c   $	��748��6{      AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
IdPedido+6P     5      $ Fecha inicio��6%    6;   �� *FechaPedido+6]     5      $ Fecha Entrega��6%    6<   �� *FechaEntrega+6_     5      $ 	Direccion��6%    68   �� *	Direccion+6X     5      $ Cliente��6%    66   �� *Cliente.Nombre+6[     5      $ Estado��6%    65   �� * EstadoPedido.DescripcionEstado+6j     5      $ Ciudad��6%    65   �� *Ciudad+6R     5      $
 Pais��6%    63   �� *Pais+6N   4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5      ��  ��Name$ BtnRevisarSubasta��6%   -   5        $��Ver Subasta��5   @      AccentedSquareButtonStyle#��[  6W   6�   5      5      5      �� 5!   
   $.��(Seleccion de pedido creación de subasta��6   $��16(�6B   $��23,72,462,506q�6P   �� 5"   
   -   5        	 ��Name$	 txtID��5"      *  $MahApps.Metro.Controls.TextBoxHelper
   	Watermark$
 
Id Subasta��6!   $
��Left=�6O   $��29��6j   $��673,403,0,0q�6v    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��118��6�   (  "System.Windows.Controls.DatePicker  5#   
   -   5          Name$ dateFechaInicio��5#      $
��Left=�6.   $��322,306,0,0q�6I   $	��Top=�6^    J� RenderTransformOrigin$ 
0.38,0.607&�6v     5$   
   -   5        $ dateFechaTermino��5$      $
��Left=�6/   $��568,306,0,0q�6J   $	��Top=�6_   �� 5%   
   -   5         ��Name$ lbFechaInicio��5%      $��Fecha de Inicio��6'   $
��Left=�6A   $��322,276,0,0q�6\   $	��Top=�6q   �� 5&   
   -   5        $ lbFechaTermino��5&      $��Fecha de Termino��6(   $
��Left=�6C   $��568,276,0,0q�6^   $	��Top=�6s     5'   
   -   5        $ tablaSubasta��5'       . $
��Left=�6;   $	��155��6V   $��
23,403,0,0q�6c   $	��Top=�6w   $	��637��6�    .   5(        5)      $ Id��6%    61   �� *	IdSubasta+6Q     5*      $ Fecha Inicio��6%    6;   �� *FechaInicio+ �� StringFormat$ {0:dd/MM/yyyy}��6|     5+      $ Fecha Termino��6%    6<   �� *FechaTermino+$ {0:dd/MM/yyyy}��6~     5,      $  Numero Pedido��6%    6=   �� *Pedido.IdPedido+6c     5-      $ Estado Subasta��6%    6=   �� *EstadoSubasta.Descripcion+6m     5.       5/      �� 50      .R�51      �� $ BtnVerOfertas��6%   -	   5        $��Ver Ofertas��51   <   #��[  6n   6�   52      54      56      �� 57   
   -
   5        $ BtnAgregarSubasta��57      $��Agregar��6,   $
��Left=�6>   $��
23,563,0,0q�6Y   $	��Top=�6m   $	��121��6�   6�   �� 58   
   -   5        $ 	btnCargar��58      $��Cargar��6$   $
��Left=�65   $��673,369,0,0q�6P   $	��Top=�6e   $	��122��6}   6�   �� 59   
   -   5        $ btnActualizar��59      $��
Actualizar��6(   $
��Left=�6=   $��201,563,0,0q�6X   $	��Top=�6m   $	��122��6�   6�   �� 5:   
   -   5        $ btnEliminar��5:      $��Eliminar��6&   $
��Left=�69   $��376,563,0,0q�6T   $	��Top=�6i   $	��122��6�   6�   +  %MahApps.Metro.Controls.FlyoutsControl  5<   
   .@�5=      #	  MahApps.Metro.Controls.Flyout	  -   5         	 Name$ flyOfertasTransportista��5=      $	��623��6?   ���	#FFF7955C J� Opacity$	 0.8Q�6b   $��Ofertas Transportistas��6p   $��177,0,0,214q�6�   $��Right=�6�   $��RightToLeft=�6�   .��5>      �� $
��Left=�6   $	��414��64   $	��613��6A   .+�5?      �� -   5        $ BtnAsignarTransportista��5?   /   $��Asignar��6    �� Left$	 254��6P   
 �� Top$	 256��6b   $��46��6s   $��94��6   $ 0.452,1.674&�6�   6�     5@      -   5        $ GridOfertas��5@       .  .     CanUserReorderColumns . $ 10��6   $ 36��6�    5A        5B      $ 	Id Oferta��61    6D   �� *
IdOferta+6c     5C      $ Precio��61    6A   �� *PrecioOferta+6d     5D      $ Fecha Oferta��61    6G   �� *FechaOferta+6i     5E      $ Transportista��61    6H   �� *Transportista.Nombre+6s     5F      $ Tipo Transporte��61    6J   �� *TipoTransporte.Descripcion+6{     5G      $ Seleccionado��65    5H   "   �� 5I   &   .R�5J   *   �� ��5K   .   �� 5L   2    �� 
TargetType" ��68   .�5M   6   ��  �� Property � �� �� Value$ No��6M    �� Triggers 5N   6   �� 5O   :    �� Binding 6F   �� *Seleccionado+ �� Value 16g   .a�5P   >   ��  � ��$ Si��6U   5Q   ;   5S   3   5U   +   5V   '   5X      5Z      5[      5\      	  5_      -   5        $ flyActualizarSubasta��5_      $	��346��6<   ���	#FFF7955C$	 0.8Q�6_   $��Actualizar Subasta��6m   $��457,0,-3,214q�6�   $��Right=�6�   $��RightToLeft=�6�   $y�Hidden=�6�   .��5`      �� $
��Left=�6   $	��414��64   $	��346��6A   .+�5a      �� -   5        $	 txtEstadoActualizar��5a      $��24��6;   $ 10��6G   $
 Wrap=�6X   $
 Estado subasta��6l   $	 104��6�   $	��145��6�   �� 5b      -   5        $	 txtIdPedidoActualizar��5b      $��23��6=   $	 188��6I   $
 Wrap=�6[   $
 	Id Pedido��6o   $	 104��6�   $	��145��6�     5c      -   5        $ dateActualizarInicio��5c   !   $	 188��6?   $	 185��6Q   $	��145��6b   6p     5d      -   5        $ dateActualizarTermino��5d   !   $ 10��6@   $	 185��6Q   $ 0.386,0.654&�6b   6�   �� 5e      -   5        $ lbFechaInicio1��5e      $	 261��64   $��Fecha Inicio��6F   $	 159��6]   6p   �� 5f      -   5        $ lbFechaTermino1��5f      $��Fecha Termino��65   $ 69��6M   $	 159��6^   6q   �� 5g      -   5        $	 txtActualizarID��5g      $��23��67   $	 188��6C   $
 Wrap=�6U   $
 Id��6i   $ 37��6�   $	��146��6�   5h      5i      5k      �� 5l   
   $��20(�6   $��Subastas��6   $
��Left=�61   $��42,0,0,0q�6L   $	��Top=�6^   $ 0.487,-0.308&�6v   $	��103��6�   �� 5m   
   $��16(�6   $��Lista de Subastas��6   $
��Left=�6:   $��
23,367,0,0q�6U   $	��Top=�6i   �� 5n   
   $��14(�6   $2��,Selecciona las fechas para crear una subasta��6   $
��Left=�6U   $��
23,294,0,0q�6p   $	��Top=�6�   �� 5o   
   $
��Left=�6   $��13��6/   $��
23,258,0,0q�6;   $	��Top=�6O   $	��748��6g   �� 5p   
   $
��Left=�6   $��13��6/   $��
23,349,0,0q�6;   $	��Top=�6O   $	��748��6g   5r      5s      