#! /bin/bash

# Script para Ubuntu 17.04
# Este es el script que yo utilizo para ponerle 75Hz a mi laptop
# Adaptado de "Using xrandr and gtf to add a new mode to your X configuration at runtime" http://www.arunviswanathan.com/node/53

xrandr --newmode "1152x864_75.00"  104.99  1152 1224 1352 1552  864 865 868 902  -HSync +Vsync
xrandr --addmode LVDS-1 1152x864_75.00
xrandr --output LVDS-1 --mode 1152x864_75.00





