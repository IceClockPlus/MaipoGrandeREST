   M S B A M L   `   `   `  ����I  EMaipoGrandeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MaipoGrandeAppMaipoGrandeApp  5      '    !MaipoGrandeApp.ControlarContratos   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      H DMahApps.Metro, Version=1.6.1.4, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      (localclr-namespace:MaipoGrandeApp  5        N� Title$  ControlarContratos��5
      .��5      � 
�������.+�5   
   �� -   5         ��Name$ btnAgregarContrato��5      $��Agregar��6-   $
��Left=�6?   $��
49,432,0,0q�6Z   $	��Top=�6n   $	��113��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataContratos��5      $
��Left=�6*   $	��162��6E   $��
49,466,0,0q�6R   $	��Top=�6f   $	��703��6~      
IsReadOnly .    AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6J     5      $ Fecha Inicio��6%    6;   �� *FechaCreacion+ �� StringFormat$ {0:dd/MM/yyyy}��6~     5      $ Fecha Termino��6%    6<   �� *FechaTermino+$ {0:dd/MM/yyyy}��6~     5      $ Porcentaje comision��6%    6B   �� *PorcComision+6e     5      $ Vigencia��6%    67   �� *	Vigente+6U     5      $ Numero productor��6%    6?   �� *Productor.Id+6b   5      (  "System.Windows.Controls.DatePicker  5   
   -   5        	  Name$	 dateFechaInicio��5      $
��Left=�6.   $��
49,287,0,0q�6I   $	��Top=�6]   
 J� RenderTransformOrigin$
 
0.51,0.423&�6u     5   
   -   5        $	 dateFechaTermino��5      $
��Left=�6/   $��241,287,0,0q�6J   $	��Top=�6_   �� 5   
   -   5         ��Name$ lbFechaInicio��5      $��Fecha Inicio��6'   $
��Left=�6>   $��
49,256,0,0q�6Y   $	��Top=�6m   �� 5   
   -   5        $ lbFechaTermino1��5      $��Fecha Termino��6)   $
��Left=�6A   $��241,261,0,0q�6\   $	��Top=�6q   �� 5   
   -   5         ��Name$ txtComision��5      *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Comision��6'   $
��Left=�6S   $��23��6n   $��240,125,0,0q�6z    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��145��6�   �� 5   
   -   5        $ txtIdProductor��5      $
��Left=�6*   $��23��6E   $ Id Productor��6Q   $��240,198,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��145��6�   �� 5   
   -	   5        $ 
txtVigente��5      $
��Left=�6&   $��22��6A   $��
49,198,0,0q�6M   $ Vigencia Contrato��6a   $
 Wrap=�6�   $	��Top=�6�   $	��145��6�   �� 5   
   -
   5        $ btnActualizar��5      $��
Actualizar��6(   $
��Left=�6=   $��182,432,0,0q�6X   $	��Top=�6m   $	��114��6�   6�   �� 5    
   -   5        $ txtIdContrato��5       $ Id��6)   $
��Left=�6O   $��23��6j   $��608,432,0,0q�6v   $
 Wrap=�6�   $	��Top=�6�   $	��144��6�   �� 5!   
   -   5        $ 	btnCargar��5!      $��Cargar��6$   $
��Left=�65   $��459,432,0,0q�6P   $	��Top=�6e   $	��114��6}   6�   �� 5"   
   -   5        $ btnEliminar��5"      $��Eliminar��6&   $
��Left=�69   $��322,432,0,0q�6T   $	��Top=�6i   $	��114��6�   6�   #  MahApps.Metro.Controls.Flyout  5#   
   -   5          Name$ flyActualizarContra��5#      $	��343��67   ���	#FFF7955C J� Opacity$	 0.8Q�6Z   $��Actualizar Contrato��6h   $	��410��6�   $��459,-1,-2,291q�6�   $��Right=�6�   $��RightToLeft=�6�   .��5$      �� $
��Left=�6   $	��335��60   $	��343��6=   .+�5%      �� -   5        $ txtComisionActualizar��5%      $��24��69    �� Left$ 10��6E   $
 Wrap=�6V   $ Comision��6j   
 �� Top$ 54��6�   $	��145��6�   �� 5&      -   5        $ txtVigenciaActualizar��5&      $��23��69   $	 188��6E   $
 Wrap=�6W   $ Vigencia��6k   $	 121��6�   $	��145��6�   �� 5'      -   5        $ txtIdproductorActualizar��5'      $��23��6<   $ 10��6H   $
 Wrap=�6Y   $ Id productor��6m   $	 121��6�   $	��145��6�     5(      -   5        $	 dateActualizarInicio��5(      $	 188��6;   $	 203��6M   $	��145��6^   6l     5)      -   5        $	 dateActualizarTermino��5)      $ 10��6<   $	 203��6M   $
 0.386,0.654&�6^   6�   �� 5*      -   5        $ lbFechaInicio1��5*      $	 261��60   $��Fecha Inicio��6B   $	 177��6Y   6l   �� 5+      -   5        $ lbFechaTermino��5+      $��Fecha Termino��60   $ 69��6H   $	 177��6Y   6l   �� 5,      -   5        $ txtActualizarID��5,      $��23��63   $	 188��6?   $
 Wrap=�6Q   $ Id��6e   $ 54��6�   $	��146��6�   5-      5.      �� 5/   
   -   5        $ 
lbComision��5/      $��Comision��6$   $
��Left=�67   $��
241,94,0,0q�6R   $	��Top=�6f   �� 50   
   -   5        $ lbProductor��50      $��	Productor��6%   $
��Left=�69   $��240,172,0,0q�6T   $	��Top=�6i   �� 51   
   -   5        $ lbVigencia_��51      $��Vigencia Contrato��6%   $
��Left=�6A   $��
49,167,0,0q�6\   $	��Top=�6p   52      53      