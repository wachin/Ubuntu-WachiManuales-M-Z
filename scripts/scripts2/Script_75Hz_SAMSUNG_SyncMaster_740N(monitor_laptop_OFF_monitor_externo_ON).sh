#! /bin/bash

# Script hecho especialmente sólo para Ubuntu 17.04
# Este es el script que yo utilizo para ponerle 75Hz a mi monitor externo y al mismo
# Adaptado de "Using xrandr and gtf to add a new mode to your X configuration at runtime" http://www.arunviswanathan.com/node/53
# Este script funciona primero apagando el monitor de mi laptop y luego poniendo el nuevo modo al externo y los 75Hz

xrandr --output LVDS-1 --off
xrandr --newmode "1280x960_75.00"  129.86  1280 1368 1504 1728  960 961 964 1002  -HSync +Vsync
xrandr --addmode VGA-1 1280x960_75.00
xrandr --output VGA-1 --mode 1280x960_75.00


# Nota: Para compartir este script con otras personas, primero hay que probarlo desde la linea tres "--addmode". Esta linea a veces no funciona pues el comando pone el nombre del monitor externo y depende del sistema operativo linux este le dará uno u otro nombre, así por ejemplo, yo usaba UbuntuStudio 16.04 y luego me cambié al nuevo 17.04 y no me funcionaba el script y al poner en la terminal esa linea salió esto:

# wachin@wachin-id:~$ xrandr --addmode VGA1 1280x768_75.00
# xrandr: cannot find output "VGA1"

# así que para que funcione puse en la terminal: xrandr y el nombre del monitor externo estaba diferente(copio aquí una parte):

#   400x300       60.32    56.34  
#   320x240       60.05  
# VGA-1 connected 1366x768+0+0 (normal left inverted right x axis y axis) 410mm x 230mm
#   1366x768      59.79*+
#   1280x1024     75.02    60.02  

# Así que en base a esto actualicé esa linea así:

# xrandr --addmode VGA-1 1280x768_75.00

# e hice lo mismo con la siguiente linea







