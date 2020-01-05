#! /bin/bash
# Ubuntu 17.04 no funciona la velocidad del cursor (SOLUCIÓN)
# https://facilitarelsoftwarelibre.blogspot.com/2017/11/ubuntu-1704-no-funciona-la-velocidad.html

# Verifica con:
# xinput --list
# cual es el id del dispositivo, pues este puede cambiar si usas un teclado externo el cual usa un USB para conectarse de forma inalambrica, si lo quitas es muy posible que haga que se te cambien los números y ya no te funcione el script, por eso yo tengo dos scripts, uno cuando está puesto el USB y otro para cuando no está puesto.

# Script "si USB".- Es para cuando está puesto el USB del teclado externo Logitech k400

# VELOCIDAD 2.9
#xinput set-prop 10 142 2.900000, 0.000000, 0.000000, 0.000000, 2.900000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 2.8
xinput set-prop 13 142 2.800000, 0.000000, 0.000000, 0.000000, 2.800000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 2.7
#xinput set-prop 13 142 2.700000, 0.000000, 0.000000, 0.000000, 2.700000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 2.6
#xinput set-prop 13 142 2.600000, 0.000000, 0.000000, 0.000000, 2.600000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 2.5
#xinput set-prop 13 142 2.500000, 0.000000, 0.000000, 0.000000, 2.500000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 2.4
# xinput set-prop 13 142 2.400000, 0.000000, 0.000000, 0.000000, 2.400000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 2.3
# xinput set-prop 13 142 2.300000, 0.000000, 0.000000, 0.000000, 2.300000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 2.2
# xinput set-prop 13 142 2.200000, 0.000000, 0.000000, 0.000000, 2.200000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 2.1
# xinput set-prop 13 142 2.100000, 0.000000, 0.000000, 0.000000, 2.100000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 2.0
# xinput set-prop 13 142 2.000000, 0.000000, 0.000000, 0.000000, 2.000000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 1.9
# xinput set-prop 13 142 1.900000, 0.000000, 0.000000, 0.000000, 1.900000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 1.8
# xinput set-prop 13 142 1.800000, 0.000000, 0.000000, 0.000000, 1.800000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 1.7
# xinput set-prop 13 142 1.700000, 0.000000, 0.000000, 0.000000, 1.700000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 1.6
# xinput set-prop 13 142 1.600000, 0.000000, 0.000000, 0.000000, 1.600000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 1.5
# xinput set-prop 13 142 1.500000, 0.000000, 0.000000, 0.000000, 1.500000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 1.4
# xinput set-prop 13 142 1.400000, 0.000000, 0.000000, 0.000000, 1.400000, 0.000000, 0.000000, 0.000000, 1.000000

# VELOCIDAD 1.3
# xinput set-prop 13 142 1.300000, 0.000000, 0.000000, 0.000000, 1.300000, 0.000000, 0.000000, 0.000000, 1.000000


# ADVERTENCIA
# No use el numero 3 (300000), es demasiado rápido y se sale a los extremos el cursor en la pantalla (no sirve para nada), tampoco use 2.9 (2.900000) porque es muy rápido igual. Yo he llegado hasta 2.6


