/*
 * This file is part of TBO, a gnome comic editor
 * Copyright (C) 2010  Daniel Garcia Moreno <dani@danigm.net>
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */


#ifndef __UI_MENU__
#define __UI_MENU__

#include <gtk/gtk.h>
#include "tbo-window.h"

GtkWidget *generate_menu (TboWindow *window);
void update_menubar (TboWindow *tbo);
void tbo_menu_disable_accel_keys (TboWindow *tbo);
void tbo_menu_enable_accel_keys (TboWindow *tbo);

#endif
