   M S B A M L   `   `   `  ????@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PLWPF.adminPLWPF.admin  5   	       PLWPF.admin.AdminLogin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PLWPF.admin     5   	     ? 
ResizeMode$  CanMinimize=?5   	    ? Title$ login??5	   	   $??218.679??6   $	??246??6(    ? 	Resources 5
         RoundCorner ?? 
TargetType ?? Property ?? Value ?? 
TargetType ?Name ??Name	 ?? CornerRadius
 
? GradientOrigin ?? RelativeTransform ?? CenterX ?? CenterY ?? ScaleX ?? ScaleY T? X T? Y ? Offset ? Color ?? Triggers P? Property P? Value ?? 
TargetName  goBackLinearGradientBrush??%?  &	        &	 ?    ?? 5   
   " ??6$   .?5      ??  ? ?? 5      ?? 5      " ??6&   .R?5      ? $
 grid??6   .+?5      ?? $ border??6%   $	 8??65   
??? d ?$??2q?6^   ??5   "   
? 5   &   $
 0.496,1.052&?6:    5   *   V? 5   .   .~?5   2   ?? $	 0.5Q?6A   $	 0.5Q?6O   $	 1.5Q?6]   $	 1.5Q?6j   T? 5   2   $
 0.02Q?6E   $	 0.3Q?6N   5   /   .??5   *   ? $ 1Q?67   $ 	#00000000??6B   ? 5   *   $	 0.3Q?67   $ 	#FFFFFFFF??6D   5   '   ._?5   "   ?? $??Center=?63   $??Center=?5   +   5    #   5!      5#       5$      P? 5%       ? ?? . . ?5&   "   ?? $ border??6?    ? ?? 5'   &   
? 5(   *   $
 0.496,1.052&?6>    5)   .   V? 5*   2   .~?5+   6   ?? $	 0.5Q?6E   $	 0.5Q?6S   $	 1.5Q?6a   $	 1.5Q?6n   T? 5,   6   $
 0.02Q?6I   $	 0.3Q?6R   5-   3   .??5/   .   ? $ 	#00000000??6;   $ 1Q?6M   ? 50   .   $ 	#FF303030??6;   $	 0.3Q?6M   51   +   53   #   54      P? 55       ?@J?IsMouseOver . . ?56   "   ?? $ border??6@    ? ??
 ?W?.?6T   57      P? 58       ? {? .  . ?59   "   ?? $
 grid??6<    ?@J?Opacity$
 0.25Q?6N   5:      5<      5>      5?      ?? 5A   
   .??5B      ? $ LightSkyBlue??6   $ 0Q?5C      ? 5D      $ LightSlateGray??6   $	 0.5Q?5E      ? 5F      $ 	LightBlue??6   $ 1Q?5G      5H      5J      .??5K      ? .+?5L   
   ?? -   5         ??Name$ adminLoginLabel??5L      $??Admin login??6)   $
??Left=?6?   $??	82,10,0,0q?6Z   $	??Top=?6m   ?? 5M   
   -   5        $ 	userLabel??5M      $??User:??6#   $
??Left=?63   $??	17,50,0,0q?6N   $	??Top=?6a    J? RenderTransformOrigin$ 0.948,0.529&?6y   ?? 5N   
   -   5        $ passwordLabel??5N      $??	Password:??6'   $
??Left=?6;   $??	17,95,0,0q?6V   $	??Top=?6i   ?? 5O   
   -   5         ??Name$ Username??5O   `   $
??Left=?6   $??23??6-   $??	94,53,0,0q?69    ?? TextWrapping$
 Wrap=?6L   $	??Top=?6r   $	??115??6?   6?   G? 5P   
   -   5         G?Name$ Password??5P      $
??Left=?6(   $??	94,95,0,0q?6C   $	??Top=?6V   $??26??6n   $	??115??6z   6?   ?? 5Q   
   -   5         ??Name$ loginButton??5Q      $??Login??6&   $
??Left=?66   $??
82,145,0,0q?6Q   #??[  6e   $	??Top=?6?   $??75??6?   6?   ?? 5R   
   -   5        $??<??5R      $
??Left=?6    $??
10,160,0,0q?6;   #??[ 6O   $	??Top=?6?   $??32??6?   6?   5S      5T      