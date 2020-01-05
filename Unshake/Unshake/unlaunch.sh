#!/bin/sh
PATH=${PATH}:/usr/java1.4.0/bin:/usr/j2rel_3_1/bin:/usr/java1.3/bin:/usr/java1.2/bin
export PATH
java -Xmx512m -jar Unshake.jar source/* &
