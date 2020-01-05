#!/bin/bash
sleep 15

wmctrl -r Terminal -t 1; wmctrl -r Terminal -e 0,90,90,800,600
wmctrl -r "Brightness Controller" -t 1; wmctrl -r "Brightness Controller" -e 0,190,190,800,400 

# Explicación de este comando: "wmctrl -r Terminal -t 1"
# Nota: El comando Alarmas lo pongo en vez de poner alarm-clock-applet
# porque aunque siendo este el nombre para lanzar desde la terminal a
# esa aplicación el programa wmctrl no lo reconoce sino al nombre 
# que aparece en la ventana del programa,
# lo mismo sucede con xfce4-terminal es Terminal el nombre correcto.
# Y otro ejemplo sólo por comentarlo, si quisiera mover al 
# espacio de trabajo 2 a Gimp debo poner en la terminal gimp
# y en wmctrl así "Programa de manipulación de imágenes de GNU"

# Explicación de este comando: "wmctrl -r Terminal -e 0,90,90,800,600"
# Ver su explicación en:
# Colocar una aplicación en determinado lugar en la pantalla con wmctrl
# https://facilitarelsoftwarelibre.blogspot.com/2017/06/colocar-una-aplicacion-en-determinado.html


# El siguiente comando es para hacer foco una aplicacion determinada
# sea que esté en cualquier espacio de trabajo
# aquí pongo el ejemplo a Terminal pero lo dejo desabilitado
# porque luego tengo que regresar al espacio de trabajo uno
# solo lo dejo aquí como ejemplo:
#wmctrl -a Terminal



