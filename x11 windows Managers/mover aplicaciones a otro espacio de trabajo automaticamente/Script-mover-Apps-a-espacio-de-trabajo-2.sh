#!/bin/bash
sleep 15

wmctrl -r Alarmas -t 1; wmctrl -r Alarmas -e 0,600,400,450,300
wmctrl -r Terminal -t 1; wmctrl -r Terminal -e 0,90,90,800,600

# Explicación de este comando: "wmctrl -r Alarmas -t 1"
# y explicación de este comando: "wmctrl -r Terminal -t 1"
# Nota: El comando Alarmas lo pongo en vez de poner alarm-clock-applet
# porque aunque siendo este el nombre para lanzar desde la terminal a
# esa aplicación el programa wmctrl no lo reconoce sino al nombre 
# que aparece en la ventana del programa,
# lo mismo sucede con xfce4-terminal es Terminal el nombre correcto.
# Y otro ejemplo sólo por comentarlo, si quisiera mover al 
# espacio de trabajo 2 a Gimp debo poner en la terminal gimp
# y en wmctrl así "Programa de manipulación de imágenes de GNU"

# Explicación de este comando: "wmctrl -r Alarmas -e 0,600,400,800,600"
# y explicación de este comando: "wmctrl -r Terminal -e 0,90,90,800,600"
# Ver su explicación en:
# Colocar una aplicación en determinado lugar en la pantalla con wmctrl
# 


# El siguiente comando es para hacer foco una aplicacion determinada
# sea que esté en cualquier espacio de trabajo
# aquí pongo el ejemplo a Terminal pero lo dejo desabilitado
# porque luego tengo que regresar al espacio de trabajo uno
# solo lo dejo aquí como ejemplo:
#wmctrl -a Terminal



