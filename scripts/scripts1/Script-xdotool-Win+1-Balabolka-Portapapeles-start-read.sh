#!/bin/bash
# http://www.howtogeek.com/125664/how-to-bind-global-hotkeys-to-a-wine-program-under-linux/
# Create a script called “start_read.sh” with the following content:
# xdotool key --window $( xdotool search --limit 1 --all --pid $( pgrep balabolka ) --name Balabolka ) "ctrl+alt+F9"

xdotool key --window $( xdotool search --limit 1 --all --pid $( pgrep balabolka ) --name Balabolka ) "ctrl+alt+F9"
