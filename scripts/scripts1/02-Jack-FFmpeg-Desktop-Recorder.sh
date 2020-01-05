sleep 7; #!/bin/bash

# ¿Cómo hice este script?
# Probado en UbuntuStudio 12.04, 13.10
# Descargué el deb del script screencapjack
# de: http://bandshed.net/avlinux6-debs/screencapjack/
# Lo instalé, abrí, y vi como funciona he hice esta modificación
# En la cual, uso para la fuente de entrada de audio de FFmpeg, el archivo ".asoundrc"
# Hice un post sobre eso, gracias a las explicaciones de Autostatic
# Titulo: ffmpeg using Jack as an input, lo puede ver en linea en:
# http://ubuntuforums.org/showthread.php?t=1556038&page=3&p=12579362
# Se debe de crear una carpeta llamada "Screencast" para poder usarlo, 
# También hice otras modificaciones, este es el que primero usaba:
# ffmpeg -f alsa -ac 2 -i jackplug -f x11grab -r 25 -s 1280x768 -i :0.0 -acodec pcm_s16le -vcodec libx264 -vpre lossless_ultrafast -threads 0 $HOME/Screencasts/screencast_video_$DATE-$TIME.mkv
# Pero estaba hecho para la resolución de mi monitor externo Viewsonic, entonces vi en
# una página que había una manera de hacer un script que usa el programa xpdyinfo (el cual
# forma parte de x11-utils) y así automáticamente el script ve cuales son las dimensiones
# de la pantalla y lo ajusta para que lo pueda usar FFmpeg
# ORIGINAL DE ESE SCRIPT: ffmpeg -f x11grab -s `xdpyinfo | grep 'dimensions:'|awk '{print $2}'` -r 25 -i :0.0 -sameq ./Desktop/mydesktop.mkv 
# Visto en http://ubuntuforums.org/showthread.php?t=1710642
# como se puede observar, reemplacé "x11grab", con "x11grab -s `xdpyinfo | grep 'dimensions:'|awk '{print $2}'`"
# y ajusté el resto para mi script.
# Por Washington Indacochea Delgado, 2013-10-23
# Licencia GPL 2	
# PARA USARLO debe tener corriendo Jack
# Debe haber creado una carpeta con el nombre Screencasts, en HOME
# Debe haber puesto el archivo .asoundrc en HOME
# Debe haberle puesto permisos de ejecución a este script
# ffmpeg -f alsa -ac 2 -i jackplug -f x11grab -s `xdpyinfo | grep 'dimensions:'|awk '{print $2}'` -r 25 -i :0.0 -acodec pcm_s16le -vcodec libx264 -vpre lossless_ultrafast -threads 0 $HOME/Documentos/Screencasts/screencast_video_$DATE-$TIME.mkv
# El de arriba es un respaldo
# Actualizacion
# A esta fecha 2014-05-08 he instalado UbuntuStudio 14.04 y ya no viene con FFmpeg, 
# pero lo instalé del PPA de Doug McMahon:
# https://bugs.launchpad.net/~mc3man/+archive/trusty-media
# Lo añadí en el Synaptic, instalé el ffmpeg pero luego desactivé el PPA por alguna caso algun problema si vaya a instalar algo después. 
# Visto en: http://askubuntu.com/questions/432542/is-ffmpeg-missing-from-the-official-repositories-in-14-04
# y los comandos antes mencionados no funcionan, ninguno, pero encontré como hacerlo funcionar, con este: -preset ultrafast
# Visto en: https://trac.ffmpeg.org/wiki/EncodingForStreamingSites
# Tambien hay algo interesante aquí sobre el codec x264
# https://trac.ffmpeg.org/wiki/x264EncodingGuide
# Pero ya lo probé y da igual que el otro, con respecto al consumo del CPU.
# Asi que el nuevo Scritp queda así:
# ffmpeg -f alsa -ac 2 -i jackplug -f x11grab -s `xdpyinfo | grep 'dimensions:'|awk '{print $2}'` -r 25 -i :0.0 -preset ultrafast $HOME/Documentos/Screencasts/screencast_video_$DATE-$TIME.mkv
# Ah, he probado con las extensiones .mkv y .mp4 y me doy cuenta con el programa MediaInfo que el mp4 graba con más calidad el audio, pero parece que consume un poquito más el procesador. Creo que me quedaré con mkv 
# (probé también con .mpeg .avi pero graban mala calidad)
# Otra modificación, cambio  el directorio, pues había que crear la carpeta primero para poder usarlo, pero ahora con el cambio que le hago, por defecto se grabará en HOME.
# RESPALDO (además así lo hace Recordmydesktop):
# ffmpeg -f alsa -ac 2 -i jackplug -f x11grab -s `xdpyinfo | grep 'dimensions:'|awk '{print $2}'` -r 25 -i :0.0 -preset ultrafast $HOME/Documentos/Screencasts/screencast_video_$DATE-$TIME.mp4

DATE=`date +%Y%m%d`
TIME=`date +%Hh%M`

# Start screencast

ffmpeg -f alsa -ac 2 -i jackplug -f x11grab -s `xdpyinfo | grep 'dimensions:'|awk '{print $2}'` -r 25 -i :0.0 -preset ultrafast $HOME/screencast_video_$DATE-$TIME.mp4






