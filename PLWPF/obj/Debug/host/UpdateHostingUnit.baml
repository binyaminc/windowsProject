   M S B A M L   `   `   `  ????@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   	       PLWPF.UpdateHostingUnit   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	   +BEclr-namespace:BE;assembly=BE     5   	   -   5          ? 
ResizeMode$  CanMinimize=?5	   	    ? Title$ UpdateHostingUnit??5
   	   $??566.289??6#   $??416.451??64    ? 	Resources 5         hostingUnitViewSource  RoundCorner ?? 
TargetType ?? Property ?? Value ?? 
TargetType ?Name ??Name	 ?? CornerRadius
 
? GradientOrigin ?? RelativeTransform ?? CenterX ?? CenterY ?? ScaleX ?? ScaleY T? X T? Y ? Offset ? Color ?? Triggers P? Property P? Value ?? 
TargetName??%  &	        &	      ?? 5   
   6   ?? 5   
   " ??6$   .?5      ??  ? ?? 5      ?? 5      " ??6&   .R?5      ? $
 grid??6   .+?5      ?? $ border??6%   $	 8??65   
??? d ?$??2q?6^   ??5   "   
? 5   &   $
 0.496,1.052&?6:    5   *   V? 5   .   .~?5   2   ?? $	 0.5Q?6A   $	 0.5Q?6O   $	 1.5Q?6]   $	 1.5Q?6j   T? 5   2   $
 0.02Q?6E   $	 0.3Q?6N   5   /   .??5   *   ? $ 1Q?67   $ 	#00000000??6B   ? 5   *   $	 0.3Q?67   $ 	#FFFFFFFF??6D   5   '   ._?5   "   ?? $??Center=?63   $??Center=?5    +   5!   #   5"      5$       5%      P? 5&       ? ?? . . ?5'   "   ?? $ border??6?    ? ?? 5(   &   
? 5)   *   $
 0.496,1.052&?6>    5*   .   V? 5+   2   .~?5,   6   ?? $	 0.5Q?6E   $	 0.5Q?6S   $	 1.5Q?6a   $	 1.5Q?6n   T? 5-   6   $
 0.02Q?6I   $	 0.3Q?6R   5.   3   .??50   .   ? $ 	#00000000??6;   $ 1Q?6M   ? 51   .   $ 	#FF303030??6;   $	 0.3Q?6M   52   +   54   #   55      P? 56       ?@J?IsMouseOver . . ?57   "   ?? $ border??6@    ? ??
 ?W?.?6T   58      P? 59       ? {? .  . ?5:   "   ?? $
 grid??6<    ?@J?Opacity$
 0.25Q?6N   5;      5=      5?      5@      5A      .??5B      ? .+?5C   
   ?? -   5         ??Name$ 
enterLabel??5C      $ ??Enter hosting unit's name:??6$   $
??Left=?6I   $??	32,28,0,0q?6d   $	??Top=?6w   ?? 5D   
   -   5         ??Name$ choiseComboBox??5D      $
??Left=?6+   $??
202,31,0,0q?6F   $	??Top=?6Z   $	??120??6r   6~   ?? 5E   
   -   5         ??Name$ UpdateButton??5E      $??Update??6'   $
??Left=?68   $??164,485,0,0q?6S   #??[ 6h   $	??Top=?6?   $??75??6?   6?   ? 5F   
   -   5        $ grid1??5F       ? DataContext# [  6   $
??Left=?6S   $??
67,101,0,0q?6n   $	??Top=?6?    ? ColumnDefinitions 5G      ?? 5H      $
??Auto ?6#   ?? 5I      $
??Auto ?6#    ? RowDefinitions 5K      ?? 5L      $
??Auto ?6    ?? 5M      $
??Auto ?6    ?? 5N      $
??Auto ?6    ?? 5O      $
??Auto ?6    ?? 5P      $
??Auto ?6    ?? 5Q      $
??Auto ?6    ?? 5R      $
??Auto ?6    ?? 5S      $
??Auto ?6    ?? 5T      $
??Auto ?6    ?? 5U      $
??Auto ?6    .+?5X      ?? -   5        $ addressLabel??5X      $??Address:??6*   $??0??6=   $
??Left=?6M   $??3q?6h   $??3??6s   $??Center=?6?   ?? 5Y      -   5         ??Name$ addressTextBox??5Y      $??1??6.   $
??Left=?6>   $??23??6Y   $??3q?6e   $??3??6p   $??Center=?6?   $	??120??6?   $??2??6  ??6}   ?? *	Address+ ?? Mode$ TwoWay=?  ?? NotifyOnValidationError  . ! ?? ValidatesOnExceptions! . 6  ?? 5[      -   5        $ 	areaLabel??5[      $??Area:??6'   $??0??67   $
??Left=?6G   $??3q?6b   $??1??6m   $??Center=?6z   ?? 5\      -	   5        $ areaComboBox??5\      $??1??6-   $
??Left=?6>   $
??Auto??6Y   $??3q?6g   $??1??6r   $??Center=?6   $	??120??6?   $??0??6?   .@?5]      ?? .??6   North6&   ?? 5^      .??6   South6&   ?? 5_      .??6   Center6'   ?? 5`      .??6   	Jerusalem6*   5a      ?? 5c      -
   5        $ capacityLabel??5c      $??	Capacity:??6+   $??0??6?   $
??Left=?6O   $??3q?6j   $??5??6u   $??Center=?6?   ?? 5d      -   5        $ capacityTextBox??5d      $??1??6/   $
??Left=?6?   $??23??6Z   $??3q?6f   $??5??6q   $??Center=?6?   $	??120??6?   $??4??6  ??6~   ?? *
Capacity+$ TwoWay=?  . ! . 6  ?? 5f      -   5        $ childrenAttractionsLabel??5f      $??Childrens Attractions:??66   $??0??6W   $
??Left=?6g   $??3q?6?   $??9??6?   $??Center=?6?   ?? 5g      -   5        " ??Name$"" childrensAttractionsCheckBox??5g      $?? ??6=   $??1??6H   $
??Left=?6X   $??3q?6?   $??9??6?   $??Center=?6?   $??8??6  # d? 	IsChecked# 6s   ?? *ChildrensAttractions+$ TwoWay=?  . ! . 6%  ?? 5i      -   5        $ gardenLabel??5i      $??Garden:??6)   $??0??6;   $
??Left=?6K   $??3q?6f   $??8??6q   $??Center=?6~   ?? 5j      -   5        $" gardenCheckBox??5j      $?? ??6/   $??1??6:   $
??Left=?6J   $??3q?6?   $??8??6?   $??Center=?6?   $??7??6?   # 6e   ?? *Garden+$ TwoWay=?  . ! . 6	  ?? 5l      -   5        $ hostingUnitNameLabel??5l      $??Hosting Unit Name:??62   $??0??6O   $
??Left=?6_   $??3q?6z   $??0??6?   $??Center=?6?   ?? 5m      -   5        $ hostingUnitNameLabel2??5m      $??1??6W   $
??Left=?6g   $??3q?6?   $??0??6?   $??Center=?6?   ??63   ?? *HostingUnitName+6?   ?? 5o      -   5        $ jacuzziLabel??5o      $??Jacuzzi:??6*   $??0??6=   $
??Left=?6M   $??3q?6h   $??7??6s   $??Center=?6?   ?? 5p      -   5        $" jacuzziCheckBox??5p      $?? ??60   $??1??6;   $
??Left=?6K   $??3q?6?   $??7??6?   $??Center=?6?   $??6??6?   # 6f   ?? *	Jacuzzi+$ TwoWay=?  . ! . 6  ?? 5r      -   5        $ 	poolLabel??5r      $??Pool:??6'   $??0??67   $
??Left=?6G   $??3q?6b   $??6??6m   $??Center=?6z   ?? 5s      -   5        $" poolCheckBox??5s      $?? ??6-   $??1??68   $
??Left=?6H   $??3q?6?   $??6??6?   $??Center=?6?   $??5??6?   # 6c   ?? *Pool+$ TwoWay=?  . ! . 6  ?? 5u      -   5        $ subAreaLabel??5u      $??	Sub Area:??6*   $??0??6>   $
??Left=?6N   $??3q?6i   $??2??6t   $??Center=?6?   ?? 5v      -   5        $ subAreaTextBox??5v      $??1??6.   $
??Left=?6>   $??23??6Y   $??3q?6e   $??2??6p   $??Center=?6?   $	??120??6?   $??1??6  ??6}   ?? *	SubArea+$ TwoWay=?  . ! . 6  ?? 5x      -   5        $ 	typeLabel??5x      $??Type:??6'   $??0??67   $
??Left=?6G   $??3q?6b   $??4??6m   $??Center=?6z   ?? 5y      -   5        $ typeComboBox??5y      $??1??6-   $
??Left=?6=   $
??Auto??6X   $??3q?6~   $??4??6?   $??Center=?6?   $	??120??6?   $??3??6?   ??6f   ?? 5z      5{      5}      5~      