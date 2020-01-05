#! /bin/bash

# Script para Ubuntu 17.04
# Este es el script que yo utilizo para ponerle 75Hz a mi laptop
# Adaptado de "Using xrandr and gtf to add a new mode to your X configuration at runtime" http://www.arunviswanathan.com/node/53

xrandr --newmode "1280x768_75.00"  102.98  1280 1360 1496 1712  768 769 772 802  -HSync +Vsync
xrandr --addmode LVDS-1 1280x768_75.00
xrandr --output LVDS-1 --mode 1280x768_75.00





