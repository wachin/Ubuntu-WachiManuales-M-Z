

#! /bin/bash

xrandr --output LVDS1 --off
xrandr --newmode "1280x768_75.00"  102.98  1280 1360 1496 1712  768 769 772 802  -HSync +Vsync
xrandr --addmode VGA1 1280x768_75.00
xrandr --output VGA1 --mode 1280x768_75.00



