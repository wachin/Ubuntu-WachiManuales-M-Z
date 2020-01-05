#!/bin/bash

# Opcional, para lanzar éste 01-Lanzador-2-scripts-Jack-FFmpeg desde la 
# terminal poner esto: bash 01-Lanzador-2-scripts-Jack-FFmpeg
# O ponerle permisos de ejecución y darle doble clic para lanzarlo
# Dandole clic en "Run" no en abrir en una terminal porque no funciona
# Modo de uso: Para usarlo de manera correcta se deben editar el archivo
# 02-Jack-FFmpeg-Desktop-Recorder.sh y 03-script2-countdown.sh, y ponerles el mismo tiempo 
# para la cuenta regresiva, en el "02" ponerle ejemplo "sleep 17", y a
#  "03" ponerle "(($MIN*17))", esto significa que la grabación se ejecutará
# después de 17 segundos, y la cuenta regresiva desaparecerá después de 
# 17 segundos, con lo cual podré ver el momento exacto de empezar a hacer
# el video. Nota: FFmpeg creará un archivo con un nombre, cada vez a ese 
# script (b) hay que cambiarle el nombre para que no aparezca en la terminal
# un mensaje que pide sobreescribir o no.
# Y también es necesario a gnome-terminal ponerle letras más grandes y 
# personalizarlo a gusto
# 2013-07-05 Att: Washington Indacochea Delgado
# Dejaré un archivo afuera llamado Instrucciones, con más detalles.

roxterm -e "$HOME/02-Jack-FFmpeg-Desktop-Recorder.sh" &
gnome-terminal -e "$HOME/03-script2-countdown.sh" &
