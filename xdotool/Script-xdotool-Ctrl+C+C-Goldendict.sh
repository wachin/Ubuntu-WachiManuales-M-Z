#!/bin/bash
# el programa se baja de http://technet.microsoft.com/en-us/sysinternals/bb897434.aspx
# ¿CÓMO LOGRÉ HACER QUE FUNCIONE EN WINE?
# Busqué en el "Monitor de Sistema" de Gnome (instálelo en el synaptic o en el Centro de
# Software de Ubuntu buscado este nombre "gnome-system-monitor")
# y allí encontré que el programa se llama "ZoomIt.exe" (claro después de estar abierto)
# así que en "pgrep" le puse "ZoomIt.exe" (es importante el ".exe", sino no funciona)
# y en "--name" le puse "ZoomIt"
# todo esto lo probé primero en la terminal. Esto sucede porque es el nombre de la ventana
# Por cierto, el programa es portable, se lo puede ejecutar desde cualquier lado.
# El atajo de teclado para activarlo es "Ctrl+2" (Si no le gusta puede cambiarlo)

xdotool key --window $( xdotool search --limit 1 --all --pid $( pgrep goldendict ) --name Goldendict ) "ctrl+C+C"
