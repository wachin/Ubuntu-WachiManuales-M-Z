#! /bin/bash
# https://help.ubuntu.com/community/Webcam#MPlayer

mplayer tv:// -tv driver=v4l2:width=640:height=480:device=/dev/video0
