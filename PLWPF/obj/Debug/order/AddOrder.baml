   M S B A M L   `   `   `  ????@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.AddOrder   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     ? Title$  AddOrder??5   	   $	??395??6   $	??704??6'    ? 	Resources 5	         RoundCorner ?? 
TargetType ?? Triggers ?? Binding ?? ElementName ?? Path ?? Value ?? Property	 ?? Value
 ?? 
TargetType ?Name ??Name ?? CornerRadius 
? GradientOrigin ?? RelativeTransform ?? CenterX ?? CenterY ?? ScaleX ?? ScaleY T? X T? Y ? Offset ? Color ?? Triggers P? Property P? Value ?? 
TargetName??%v  &	        ?? 5   
   " ??6$    5      ?? 5       6   ?? $ guestRequestComboBox??$
 Text?  6^   .a?5      ??  ? {?	 .  69   5      .?5      ??  ? ??	 5      ?? 5      "
 ??6&   .R?5      ? $
 grid??6   .+?5      ?? $ border??6%   $ 8??65   
??? d ?$??2q?6^   ??5   "   
? 5   &   $ 0.496,1.052&?6:    5   *   V? 5   .   .~?5   2   ?? $	 0.5Q?6A   $	 0.5Q?6O   $	 1.5Q?6]   $	 1.5Q?6j   T? 5   2   $
 0.02Q?6E   $	 0.3Q?6N   5   /   .??5   *   ? $ 1Q?67   $ 	#00000000??6B   ? 5   *   $	 0.3Q?67   $ 	#FFFFFFFF??6D   5    '   ._?5"   "   ?? $??Center=?63   $??Center=?5#   +   5$   #   5%      5'       5(      P? 5)       ? ?? . . ?5*   "   ?? $ border??6?    ? ??	 5+   &   
? 5,   *   $ 0.496,1.052&?6>    5-   .   V? 5.   2   .~?5/   6   ?? $	 0.5Q?6E   $	 0.5Q?6S   $	 1.5Q?6a   $	 1.5Q?6n   T? 50   6   $
 0.02Q?6I   $	 0.3Q?6R   51   3   .??53   .   ? $ 	#00000000??6;   $ 1Q?6M   ? 54   .   $ 	#FF303030??6;   $	 0.3Q?6M   55   +   57   #   58      P? 59       ?@J?IsMouseOver . . ?5:   "   ?? $ border??6@    ? ??
	 ?W?.?6T   5;      P? 5<       ? {? .  . ?5=   "   ?? $
 grid??6<    ?@J?Opacity$
	 0.25Q?6N   5>      5@      5B      5C      5E      .??5F      ? .+?5G   
   ?? -   5         ??Name$ hostingUnitLabel??5G      $??HostingUnit:??6*   $
??Left=?6A   $??	26,41,0,0q?6\   $	??Top=?6o   ?? 5H   
   -   5        $ guestRequestLabel??5H      $??GuestRequest:??6+   $
??Left=?6C   $??	26,96,0,0q?6^   $	??Top=?6q   ?? 5I   
   -   5         ??Name$ hostingUnitComboBox??5I      $
??Left=?61   $??
143,45,0,0q?6L   $	??Top=?6`   $	??120??6x   6?   ?? 5J   
   -   5        $ guestRequestComboBox??5J      $
??Left=?61   $??143,100,0,0q?6L   $	??Top=?6a   $	??120??6y   ??5K      ?? 5L       5M      ?? 5N       6&   ?? $ hostingUnitComboBox??$
 Text?  6e   .a?5O      ??  ? {?	 .  6C   5P      5R      5T      ?? 5U   
   -   5         ??Name$ AddOrderButton??5U      $??	add order??6)   $
??Left=?6=   #??[  6X   $??
79,174,0,0q?6}   $	??Top=?6?   $??93??6?   $??37??6?   5W      ? 5Y   
   -   5        $??ShowGuestRequest??5Y      $
??Left=?6'   $	??271??6B   $??
318,40,0,0q?6O   $	??Top=?6c   $	??332??6{   .+?5Z      ?? $??Stretch=?6   $
??auto??69   $??Stretch=?6G   $
??auto??6c   .??5[      ?? -   5         ??Name$ SP??5[      $
??auto??6)   $
??auto??67   5\      5]      ?? 5^   
   -   5        $ optionalGuestRequestLabel??5^      $??Optional guestRequest??63   $
??Left=?6S   $??
403,10,0,0q?6n   $	??Top=?6?   5_      5`      