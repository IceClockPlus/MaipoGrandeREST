   M S B A M L   `   `   `  ����I  EMaipoGrandeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MaipoGrandeAppMaipoGrandeApp  5      #    MaipoGrandeApp.AgregarUsuario   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MaipoGrandeApp     5        N� Title$  AgregarUsuario��5	      .��5      � 
�������.+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataPerfiles��5      $
��Left=�6)   $	��195��6D   $��
43,435,0,0q�6Q   $	��Top=�6e   $	��698��6}      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	IdUsuario+6Q     5      $ Nombre Usuario��6%    6=   �� *NombreUsuario+6a     5      $ 
Habilitado��6%    69   �� *IsHabilitado+6\     5      $ Id Rol��6%    65   �� *	rol.IdRol+6U     5      $ Correo��6%    65   �� *Correo+6S   5      �� 5   
   -   5         ��Name$ 
btnAgregar��5      $��Agregar��6%   $
��Left=�67   $��
43,401,0,0q�6R   $	��Top=�6f   $��87��6~   $��Normal"�6�   6�   �� 5   
   -   5        $ btnActualizar��5      $��
Actualizar��6(   $
��Left=�6=   $��163,401,0,0q�6X   $	��Top=�6m   $��87��6�   $��Normal"�6�   �� 5   
   -   5        $ 	btnCargar��5      $��Cargar��6$   $
��Left=�65   $��395,401,0,0q�6P   $	��Top=�6e   $��87��6}   $��Normal"�6�   �� 5   
   -   5        $ btnEliminar��5      $��Eliminar��6&   $
��Left=�69   $��280,401,0,0q�6T   $	��Top=�6i   $��87��6�   $��Normal"�6�   �� 5   
   -   5         ��Name$ txtAgregarUsuario��5      $
��Left=�6.   $��23��6I   $��
43,192,0,0q�6U    �� TextWrapping$
 Wrap=�6i   $	��Top=�6}   $	��160��6�   �� 5   
   -   5        $ txtAgregarContraseña��5      $
��Left=�60   $��23��6K   $��280,192,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $	��160��6�   	 J� RenderTransformOrigin$	 0.406,0.585&�6�   �� 5   
   -   5        
 ��Name$
 CbRol��5      $
��Left=�6"   $��280,260,0,0q�6=   $	��Top=�6R   $	��160��6j   6v   �� 5   
   -	   5         ��Name$ lbAgregarUsuario��5      $��Usuario��6*   $
��Left=�6<   $��
43,161,0,0q�6W   $	��Top=�6k   �� 5   
   -
   5        $ lbAgregarContraseña��5      $��Contraseña��6-   $
��Left=�6B   $��280,161,0,0q�6]   $	��Top=�6r   �� 5   
   -   5        $ 	txtCorreo��5      $
��Left=�6%   $��23��6@   $��
43,341,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��160��6�   �� 5   
   -   5        $ lbCorreo��5      $��Correo��6"   $
��Left=�63   $��
43,310,0,0q�6N   $	��Top=�6b   �� 5    
   -   5        $ txtHabilitar��5       $
��Left=�6(   $��23��6C   $��
43,260,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��160��6�    �� MaxLines$ 1��6�   �� 5!   
   -   5        $ lbHabilitar��5!      $��	Habilitar��6%   $
��Left=�69   $��
43,234,0,0q�6T   $	��Top=�6h   �� 5"   
   -   5        $ lbRol��5"      $	��Rol��6   $
��Left=�6-   $��280,234,0,0q�6H   $	��Top=�6]   5#      5$      