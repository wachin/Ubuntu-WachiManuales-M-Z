#! /bin/bash

sudo -u wachin systemctl enable vboxautostart-service.service
sudo -u wachin systemctl enable vboxballoonctrl-service.service
sudo -u wachin systemctl enable vboxdrv.service
sudo -u wachin systemctl enable vboxweb-service.service         

#VER ESTADO DE LOS SERVICIOS ACTIVADOS
#systemctl list-unit-files --type=service | grep enabled

# CONSULTA:
#bash - How can I execute a script as root, execute some commands in it as a specific user and just one command as root - Unix & Linux Stack Exchange
#https://unix.stackexchange.com/questions/264237/how-can-i-execute-a-script-as-root-execute-some-commands-in-it-as-a-specific-us
#Cómo desactivar servicios que no necesite en Linux (Advertencia tener mucho cuidado)
#https://facilitarelsoftwarelibre.blogspot.com/2018/09/como-desactivar-servicios-que-no.html



