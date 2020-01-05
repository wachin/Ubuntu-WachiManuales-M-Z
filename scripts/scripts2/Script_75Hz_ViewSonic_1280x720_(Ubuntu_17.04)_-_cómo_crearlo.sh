


Cómo crear Script para añadir 75Hz en Monitor Externo en Linux

Primero, según esta página:

http://www.arunviswanathan.com/node/53

Ingresé los datos a la terminal:

wachin@wachin-Inspiron-1750:~$ gtf 1280 720 75

 # 1280x720 @ 75.00 Hz (GTF) hsync: 56.40 kHz; pclk: 95.65 MHz
  Modeline "1280x720_75.00"  95.65  1280 1352 1488 1696  720 721 724 752  -HSync +Vsync

 (Explicación wachín, como se observa en el siguiente script toda esa linea desde 12.... script según la página de arriba)
wachin@wachin-Inspiron-1750:~$ xrandr --newmode "1280x720_75.00"  95.65  1280 1352 1488 1696  720 721 724 752  -HSync +Vsync
wachin@wachin-Inspiron-1750:~$ xrandr --addmode VGA-1 1280x720_75.00
wachin@wachin-Inspiron-1750:~$ xrandr --output VGA-1 --mode 1280x720_75.00
wachin@wachin-Inspiron-1750:~$

Luego de darme cuenta de los valores necesarios para añadir el nuevo modo, esto es lo que pondré en el script:


---------------------------------------------------------
xrandr --newmode "1024x768_75.00"  81.80  1024 1080 1192 1360  768 769 772 802  -HSync +Vsync
xrandr --addmode VGA1 1024x768_75.00
xrandr --output VGA1 --mode 1024x768_75.00
-------------------------------------------------------------

Sistema Operativo: Kbuntu 12.04.2


Siguiendo las instrucciones de:



                   
