# Visto en http://www.commandlinefu.com/commands/view/7938/countdown-clock
# Lo modifique para usarlo según mis necesidades

MIN=1 && for i in $(seq $(($MIN*7)) -1 1); do echo -n "$i, "; sleep 1; done; echo -e "\n\nBOOOM! Time to start."
