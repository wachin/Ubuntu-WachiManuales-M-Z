#!/bin/bash

## SVOX Pico
## Speech Output Engine SDK
## Visto en: http://forum.ubuntu-fr.org/viewtopic.php?id=108430

#	│▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒│
#	│                     SVOX Pico                      │
#	│              écrit par François Fabre              │
#	│      E-Mail: liveusb@gmail.com En Français SVP !   │
#	│▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒│

#License: GNU General Public License (GPL)
#Ce programme est un logiciel libre: vous pouvez le redistribuer
#et/ou le modifier selon les termes de la "GNU General Public
#License", tels que publiés par la "Free Software Foundation"; soit
#la version 2 de cette licence ou (à votre choix) toute version
#ultérieure.
#
#Ce programme est distribué dans l'espoir qu'il sera utile, mais
#SANS AUCUNE GARANTIE, ni explicite ni implicite; sans même les
#garanties de commercialisation ou d'adaptation dans un but spécifique.
#
#Se référer à la "GNU General Public License" pour plus de détails.
#
#Vous devriez avoir reçu une copie de la "GNU General Public License"
#en même temps que ce programme; sinon, écrivez a la "Free Software
#Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA".
#http://www.gnu.org/licenses/gpl-howto.fr.html

## Lisez: http://www.sephidev.net/external/svox/pico_resources/docs/SVOX_Pico_Manual.pdf
## http://www.sephidev.net/external/svox/pico_resources/docs/
## http://www.svox.com/

## Installer dépendances
#sudo apt-get install -y xclip alsa-utils libttspico-utils zenity xsel

## Lancer SVOX Pico dans un terminal en écoute de xclip, faite menu copier ou ctrl/c sur du texte, et il vous parlera...

## Pour arrêter ce script, copiez dans le presse-papier le mot ==> quit

langlist="de-DE
en-GB
en-US
es-ES
fr-FR
it-IT"
selang="$(zenity --list --column History ${langlist})"
[ ! ${selang} ] && selang="fr-FR"
echo ${selang} >/tmp/svox_selang.txt
exec 3> >(zenity --notification --listen --window-icon="info")
echo "message:Démarrage de SVOX Pico lang:$(cat /tmp/svox_selang.txt),\nPour quitter Pico,\ncopiez dans le presse-papier le mot: quit" >&3

while true
do
cd /tmp
var="$(xclip -o -sel clip | sed 's/^[ \t]*//;s/[ \t]*$//')"
[ ! -f "/tmp/svox_mforme.txt" ] && echo -e "${var}" >/tmp/svox_mforme.txt
if [ "${var}" != "$(cat /tmp/svox_mforme.txt)" ]; then
echo -e "${var}" >/tmp/svox_mforme.txt
pico2wave -l $(cat /tmp/svox_selang.txt) -w test.wav "$(cat /tmp/svox_mforme.txt)"
aplay test.wav
else
echo r.a.s $(cat /tmp/svox_selang.txt)
fi
if [ "${var}" = "quit" ]; then
pico2wave -l $(cat /tmp/svox_selang.txt) -w test.wav "Quitter SVOX Pico"
aplay test.wav
#Purger presse papier avec xsel...
xsel -c -b
rm /tmp/svox_mforme.txt
break
fi
sleep 1
done

echo "message:Arrêt de SVOX Pico..." >&3
exec 3>&-

exit 0
