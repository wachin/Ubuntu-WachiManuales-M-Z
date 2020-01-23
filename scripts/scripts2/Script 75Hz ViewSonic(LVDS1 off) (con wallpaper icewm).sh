#! /bin/bash
# Este es el script que yo utilizo para ponerle 75Hz a mi monitor externo y al mismo
# Adaptado de "Using xrandr and gtf to add a new mode to your X configuration at runtime" http://www.arunviswanathan.com/node/53
# Este script funciona primero apagando el monitor de mi laptop y luego poniendo el nuevo modo al externo y los 75Hz

xrandr --output LVDS1 --off
xrandr --newmode "1280x768_75.00"  102.98  1280 1360 1496 1712  768 769 772 802  -HSync +Vsync
xrandr --addmode VGA1 1280x768_75.00
xrandr --output VGA1 --mode 1280x768_75.00


pcmanfm -d --desktop &
pcmanfm --set-wallpaper=/home/wachin/.icewm/wallpaper/Jesus-inside.jpg --wallpaper-mode=stretch &

#feh --bg-scale /home/wachin/.icewm/wallpaper/Jesus-inside.jpg &
# Para ponerle un wallpaper al escritorio de icewm después que he puesto los 75Hz

#wmctrl -r "Brightness controller" -t 1
# Para enviarlo al segundo espacio de trabajo y que no me reste espacio
