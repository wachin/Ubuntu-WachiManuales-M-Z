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


#include <math.h>
#include <glib/gi18n.h>
#include <gdk/gdkkeysyms.h>
#include <stdlib.h>
#include "comic.h"
#include "frame.h"
#include "page.h"
#include "tbo-ui-utils.h"
#include "tbo-tool-selector.h"
#include "tbo-drawing.h"
#include "tbo-object-group.h"
#include "ui-menu.h"
#include "tbo-tooltip.h"
#include "tbo-undo.h"

G_DEFINE_TYPE (TboToolSelector, tbo_tool_selector, TBO_TYPE_TOOL_BASE);

/* Headers */
static void on_move (TboToolBase *tool, GtkWidget *widget, GdkEventMotion *event);
static void on_click (TboToolBase *tool, GtkWidget *widget, GdkEventButton *event);
static void on_release (TboToolBase *tool, GtkWidget *widget, GdkEventButton *event);
static void on_key (TboToolBase *tool, GtkWidget *widget, GdkEventKey *event);
static void drawing (TboToolBase *tool, cairo_t *cr);

static void frame_view_on_move (TboToolBase *tool, GtkWidget *widget, GdkEventMotion *event);
static void page_view_on_move (TboToolBase *tool, GtkWidget *widget, GdkEventMotion *event);
static void frame_view_on_click (TboToolBase *tool, GtkWidget *widget, GdkEventButton *event);
static void page_view_on_click (TboToolBase *tool, GtkWidget *widget, GdkEventButton *event);
static void frame_view_drawing (TboToolBase *tool, cairo_t *cr);
static void page_view_drawing (TboToolBase *tool, cairo_t *cr);
static void frame_view_on_key (TboToolBase *tool, GtkWidget *widget, GdkEventKey *event);

/* Definitions */

/* aux */
static gboolean
update_selected_cb (GtkSpinButton *widget, TboToolSelector *tool)
{
    TboDrawing *drawing = TBO_DRAWING (TBO_TOOL_BASE (tool)->tbo->drawing);
    if (tool->resizing || tool->clicked || tool->selected_frame == NULL || tool->spin_x == NULL)
        return FALSE;

    tool->selected_frame->x = gtk_spin_button_get_value_as_int (GTK_SPIN_BUTTON (tool->spin_x));
    tool->selected_frame->y = gtk_spin_button_get_value_as_int (GTK_SPIN_BUTTON (tool->spin_y));
    tool->selected_frame->width = gtk_spin_button_get_value_as_int (GTK_SPIN_BUTTON (tool->spin_w));
    tool->selected_frame->height = gtk_spin_button_get_value_as_int (GTK_SPIN_BUTTON (tool->spin_h));

    tbo_drawing_update (drawing);
    return FALSE;
}

static gboolean
update_color_cb (GtkColorButton *button, TboToolSelector *tool)
{
    TboDrawing *drawing = TBO_DRAWING (TBO_TOOL_BASE (tool)->tbo->drawing);
    if (tool->resizing || tool->clicked || tool->selected_frame == NULL)
        return FALSE;

    GdkColor color = { 0, 0, 0, 0 };
    gtk_color_button_get_color (button, &color);
    tbo_frame_set_color (tool->selected_frame, &color);
    tbo_drawing_update (drawing);
    return FALSE;
}

static gboolean
update_border_cb (GtkToggleButton *button, TboToolSelector *tool)
{
    TboDrawing *drawing = TBO_DRAWING (TBO_TOOL_BASE (tool)->tbo->drawing);
    if (tool->resizing || tool->clicked || tool->selected_frame == NULL)
        return FALSE;

    tool->selected_frame->border = !tool->selected_frame->border;
    tbo_drawing_update (drawing);
    return FALSE;
}

static void
empty_tool_area (TboToolSelector *self)
{
    tbo_empty_tool_area (TBO_TOOL_BASE (self)->tbo);
    self->spin_x = NULL;
    self->spin_y = NULL;
    self->spin_h = NULL;
    self->spin_w = NULL;
}

static void
update_tool_area (TboToolSelector *self)
{
    TboWindow *tbo = TBO_TOOL_BASE (self)->tbo;
    GtkWidget *toolarea = tbo->toolarea;
    GtkWidget *hpanel;
    GtkWidget *label;
    GtkWidget *color;
    GtkWidget *border;
    GdkColor gdk_color = { 0, 0, 0, 0 };

    if (!self->spin_x)
    {
        empty_tool_area (self);
        self->spin_x = add_spin_with_label (toolarea, "x: ", self->selected_frame->x);
        self->spin_y = add_spin_with_label (toolarea, "y: ", self->selected_frame->y);
        self->spin_w = add_spin_with_label (toolarea, "w: ", self->selected_frame->width);
        self->spin_h = add_spin_with_label (toolarea, "h: ", self->selected_frame->height);

        g_signal_connect (self->spin_x, "value-changed", G_CALLBACK (update_selected_cb), self);
        g_signal_connect (self->spin_y, "value-changed", G_CALLBACK (update_selected_cb), self);
        g_signal_connect (self->spin_w, "value-changed", G_CALLBACK (update_selected_cb), self);
        g_signal_connect (self->spin_h, "value-changed", G_CALLBACK (update_selected_cb), self);

        hpanel = gtk_hbox_new (FALSE, 0);
        label = gtk_label_new (_("Background color: "));
        gtk_misc_set_alignment (GTK_MISC (label), 0, 0);
        color = gtk_color_button_new ();
        gdk_color.red = self->selected_frame->color->r * 65535;
        gdk_color.green = self->selected_frame->color->g * 65535;
        gdk_color.blue = self->selected_frame->color->b * 65535;
        gtk_color_button_set_color (GTK_COLOR_BUTTON (color), &gdk_color);

        gtk_box_pack_start (GTK_BOX (hpanel), label, TRUE, TRUE, 5);
        gtk_box_pack_start (GTK_BOX (hpanel), color, TRUE, TRUE, 5);
        gtk_box_pack_start (GTK_BOX (toolarea), hpanel, FALSE, FALSE, 5);
        g_signal_connect (color, "color-set", G_CALLBACK (update_color_cb), self);

        border = gtk_check_button_new_with_label (_("border"));
        gtk_toggle_button_set_active (GTK_TOGGLE_BUTTON (border), self->selected_frame->border);
        gtk_box_pack_start (GTK_BOX (toolarea), border, FALSE, FALSE, 5);
        g_signal_connect (border, "toggled", G_CALLBACK (update_border_cb), self);

        gtk_widget_show_all (toolarea);
    }

    gtk_spin_button_set_value (GTK_SPIN_BUTTON (self->spin_x), self->selected_frame->x);
    gtk_spin_button_set_value (GTK_SPIN_BUTTON (self->spin_y), self->selected_frame->y);
    gtk_spin_button_set_value (GTK_SPIN_BUTTON (self->spin_w), self->selected_frame->width);
    gtk_spin_button_set_value (GTK_SPIN_BUTTON (self->spin_h), self->selected_frame->height);
}

static gboolean
over_resizer (TboToolSelector *self, Frame *frame, int x, int y)
{
    int rx, ry;
    rx = frame->x + frame->width;
    ry = frame->y + frame->height;

    float r_size;
    r_size = R_SIZE / tbo_drawing_get_zoom (TBO_DRAWING (TBO_TOOL_BASE (self)->tbo->drawing));

    if (((rx-r_size) < x) &&
        ((rx+r_size) > x) &&
        ((ry-r_size) < y) &&
        ((ry+r_size) > y))
    {
        return TRUE;
    }
    else
    {
        return FALSE;
    }
}

static gboolean
over_resizer_obj (TboToolSelector *self, TboObjectBase *obj, int x, int y)
{
    int rx, ry;
    int ox, oy, ow, oh;
    tbo_frame_get_obj_relative (obj, &ox, &oy, &ow, &oh);
    rx = ox + (ow * cos(obj->angle) - oh * sin(obj->angle));
    ry = oy + (oh * cos(obj->angle) + ow * sin(obj->angle));

    float r_size;
    r_size = R_SIZE / tbo_drawing_get_zoom (TBO_DRAWING (TBO_TOOL_BASE (self)->tbo->drawing));

    if (((rx-r_size) < x) &&
        ((rx+r_size) > x) &&
        ((ry-r_size) < y) &&
        ((ry+r_size) > y))
    {
        return TRUE;
    }
    else
    {
        return FALSE;
    }
}

static gboolean
over_rotater_obj (TboToolSelector *self, TboObjectBase *obj, int x, int y)
{
    int rx, ry;
    int ox, oy, ow, oh;
    tbo_frame_get_obj_relative (obj, &ox, &oy, &ow, &oh);
    rx = ox;
    ry = oy;

    float r_size;
    r_size = R_SIZE / tbo_drawing_get_zoom (TBO_DRAWING (TBO_TOOL_BASE (self)->tbo->drawing));

    if (((rx-r_size/2.0) < x) &&
        ((rx+r_size/2.0) > x) &&
        ((ry-r_size/2.0) < y) &&
        ((ry+r_size/2.0) > y))
    {
        return TRUE;
    }
    else
    {
        return FALSE;
    }
}

static gboolean
moved_frame (TboToolSelector *tool)
{
    Frame *obj = tool->selected_frame;
    return (tool->start_m_x != obj->x || tool->start_m_y != obj->y);
}

static gboolean
moved_object (TboToolSelector *tool)
{
    TboObjectBase *obj = tool->selected_object;
    return (tool->start_m_x != obj->x || tool->start_m_y != obj->y);
}

/* tool signal */
static void
on_move (TboToolBase *tool, GtkWidget *widget, GdkEventMotion *event)
{
    TboDrawing *drawing = TBO_DRAWING (tool->tbo->drawing);
    Frame *frame = tbo_drawing_get_current_frame (drawing);
    if (frame)
        frame_view_on_move (tool, widget, event);
    else
        page_view_on_move (tool, widget, event);

    tbo_drawing_update (drawing);
}

static void
on_click (TboToolBase *tool, GtkWidget *widget, GdkEventButton *event)
{
    TboDrawing *drawing = TBO_DRAWING (tool->tbo->drawing);
    Frame *frame = tbo_drawing_get_current_frame (drawing);
    if (frame)
        frame_view_on_click (tool, widget, event);
    else
        page_view_on_click (tool, widget, event);

    tbo_drawing_update (drawing);
}

static void
on_release (TboToolBase *tool, GtkWidget *widget, GdkEventButton *event)
{
    TboToolSelector *self = TBO_TOOL_SELECTOR (tool);
    TboWindow *tbo = tool->tbo;
    // TODO create undo actions for movements / resizing and rotating
    if (self->selected_object && moved_object (self)) {
        tbo_undo_stack_insert (tbo->undo_stack,
                               tbo_action_object_move_new (self->selected_object,
                                                           self->start_m_x,
                                                           self->start_m_y,
                                                           self->selected_object->x,
                                                           self->selected_object->y));
    }
    else if (self->selected_frame && moved_frame (self)) {
        tbo_undo_stack_insert (tbo->undo_stack,
                               tbo_action_frame_move_new (self->selected_frame,
                                                          self->start_m_x,
                                                          self->start_m_y,
                                                          self->selected_frame->x,
                                                          self->selected_frame->y));
    }
    self->start_x = 0;
    self->start_y = 0;
    self->clicked = FALSE;
    self->resizing = FALSE;
    self->rotating = FALSE;
}

static void
on_key (TboToolBase *tool, GtkWidget *widget, GdkEventKey *event)
{
    TboDrawing *drawing = TBO_DRAWING (tool->tbo->drawing);
    Frame *frame = tbo_drawing_get_current_frame (drawing);
    if (frame)
        frame_view_on_key (tool, widget, event);
}

static void
drawing (TboToolBase *tool, cairo_t *cr)
{
    TboDrawing *drawing = TBO_DRAWING (tool->tbo->drawing);
    Frame *frame = tbo_drawing_get_current_frame (drawing);
    if (frame)
        frame_view_drawing (tool, cr);
    else
        page_view_drawing (tool, cr);
}

/* frame view */
static void
frame_view_on_move (TboToolBase *tool, GtkWidget *widget, GdkEventMotion *event)
{
    int x, y, offset_x, offset_y;
    TboToolSelector *self = TBO_TOOL_SELECTOR (tool);

    x = (int)event->x;
    y = (int)event->y;

    self->x = x;
    self->y = y;

    if (self->selected_object != NULL)
    {
        if (self->clicked)
        {
            offset_x = (self->start_x - x) / tbo_frame_get_scale_factor ();
            offset_y = (self->start_y - y) / tbo_frame_get_scale_factor ();

            // resizing object
            if (self->resizing)
            {
                self->selected_object->width = self->start_m_w - offset_x;
                self->selected_object->height = self->start_m_h - offset_y;
            }
            else if (self->rotating)
            {
                self->selected_object->angle = atan2 (offset_y, offset_x);
            }
            // moving object
            else
            {
                self->selected_object->x = self->start_m_x - offset_x;
                self->selected_object->y = self->start_m_y - offset_y;
            }
        }

        // updating group object
        if (TBO_IS_OBJECT_GROUP (self->selected_object))
        {
            tbo_object_group_update_status (TBO_OBJECT_GROUP (self->selected_object));

            self->start_x = x;
            self->start_y = y;
            self->start_m_x = self->selected_object->x;
            self->start_m_y = self->selected_object->y;
            self->start_m_w = self->selected_object->width;
            self->start_m_h = self->selected_object->height;
        }

        tbo_object_group_set_vars (self->selected_object);
        // over resizer
        if (over_resizer_obj (self, self->selected_object, x, y))
        {
            self->over_resizer = TRUE;
        }
        else
        {
            self->over_resizer = FALSE;
        }
        // over rotater
        if (over_rotater_obj (self, self->selected_object, x, y))
        {
            self->over_rotater = TRUE;
        }
        else
        {
            self->over_rotater = FALSE;
        }
        tbo_object_group_unset_vars (self->selected_object);

    }
}

static void
frame_view_on_click (TboToolBase *tool, GtkWidget *widget, GdkEventButton *event)
{
    TboToolSelector *self = TBO_TOOL_SELECTOR (tool);
    int x, y;
    GList *obj_list;
    Frame *frame;
    TboObjectBase *obj, *obj2;
    TboObjectGroup *group;
    TboDrawing *drawing = TBO_DRAWING (tool->tbo->drawing);
    gboolean found = FALSE;

    x = (int)event->x;
    y = (int)event->y;

    // resizing
    tbo_object_group_set_vars (self->selected_object);
    if (self->selected_object && over_resizer_obj (self, self->selected_object, x, y))
    {
        self->resizing = TRUE;
    }
    else if (self->selected_object && over_rotater_obj (self, self->selected_object, x, y))
    {
        self->rotating = TRUE;
    }
    else
    {
        frame = tbo_drawing_get_current_frame (drawing);

        for (obj_list = g_list_first (frame->objects); obj_list; obj_list = obj_list->next)
        {
            obj = TBO_OBJECT_BASE (obj_list->data);
            tbo_object_group_set_vars (obj);
            if (tbo_frame_point_inside_obj (obj, x, y))
            {
                // Selecting last occurrence.
                obj2 = obj;
                found = TRUE;
            }
            tbo_object_group_unset_vars (obj);
        }

        if (!found)
            tbo_tool_selector_set_selected_obj (self, NULL);
        else
        {
            if ((event->state & GDK_SHIFT_MASK) && self->selected_object) {
                if (!TBO_IS_OBJECT_GROUP (self->selected_object))
                {
                    group = TBO_OBJECT_GROUP (tbo_object_group_new ());
                    tbo_frame_add_obj (frame, TBO_OBJECT_BASE (group));
                    tbo_object_group_add (group, self->selected_object);
                }
                else
                    group = TBO_OBJECT_GROUP (self->selected_object);

                tbo_object_group_add (group, obj2);
                obj2 = TBO_OBJECT_BASE (group);
            }
            tbo_tool_selector_set_selected_obj (self, obj2);
        }
    }
    tbo_object_group_unset_vars (self->selected_object);

    self->start_x = x;
    self->start_y = y;

    if (self->selected_object)
    {
        self->start_m_x = self->selected_object->x;
        self->start_m_y = self->selected_object->y;
        self->start_m_w = self->selected_object->width;
        self->start_m_h = self->selected_object->height;
    }
    self->clicked = TRUE;
}

static void
frame_view_drawing (TboToolBase *tool, cairo_t *cr)
{
    const double dashes[] = {5, 5};
    Color border = {0.9, 0.9, 0};
    Color white = {1, 1, 1};
    Color black = {0, 0, 0};
    Color *resizer_border;
    Color *resizer_fill;
    Color *rotater_border;
    Color *rotater_fill;
    int x, y;
    float r_size;
    TboToolSelector *self = TBO_TOOL_SELECTOR (tool);
    TboObjectBase *current_obj = self->selected_object;
    TboDrawing *drawing = TBO_DRAWING (tool->tbo->drawing);

    if (current_obj != NULL)
    {
        if (TBO_IS_OBJECT_GROUP (current_obj))
            tbo_object_group_set_vars (current_obj);

        cairo_set_antialias (cr, CAIRO_ANTIALIAS_NONE);
        cairo_set_line_width (cr, 1);
        cairo_set_dash (cr, dashes, G_N_ELEMENTS (dashes), 0);
        cairo_set_source_rgb (cr, border.r, border.g, border.b);
        int ox, oy, ow, oh;
        tbo_frame_get_obj_relative (current_obj, &ox, &oy, &ow, &oh);

        cairo_translate (cr, ox, oy);
        cairo_rotate (cr, current_obj->angle);
        cairo_rectangle (cr, 0, 0, ow, oh);
        cairo_stroke (cr);

        // resizer
        if (self->over_resizer)
        {
            resizer_fill = &black;
            resizer_border = &white;
        }
        else
        {
            resizer_fill = &white;
            resizer_border = &black;
        }

        // rotater
        if (self->over_rotater)
        {
            rotater_fill = &black;
            rotater_border = &white;
        }
        else
        {
            rotater_fill = &white;
            rotater_border = &black;
        }

        cairo_set_line_width (cr, 1);
        cairo_set_dash (cr, dashes, 0, 0);

        x = ow;
        y = oh;

        r_size = R_SIZE / tbo_drawing_get_zoom (drawing);
        cairo_set_line_width (cr, 1/tbo_drawing_get_zoom (drawing));

        cairo_rectangle (cr, x, y, r_size, r_size);
        cairo_set_source_rgb(cr, resizer_fill->r, resizer_fill->g, resizer_fill->b);
        cairo_fill (cr);

        cairo_set_source_rgb(cr, resizer_border->r, resizer_border->g, resizer_border->b);
        cairo_rectangle (cr, x, y, r_size, r_size);
        cairo_stroke (cr);

        // object rotate zone
        cairo_set_source_rgb(cr, rotater_fill->r, rotater_fill->g, rotater_fill->b);
        cairo_arc (cr, 0, 0, r_size / 2., 0, 2 * M_PI);
        cairo_fill (cr);
        cairo_set_source_rgb(cr, rotater_border->r, rotater_border->g, rotater_border->b);
        cairo_arc (cr, 0, 0, r_size / 2., 0, 2 * M_PI);
        cairo_stroke (cr);
        cairo_set_line_width (cr, tbo_drawing_get_zoom (drawing));

        cairo_rotate (cr, -current_obj->angle);
        cairo_translate (cr, -ox, -oy);

        cairo_set_antialias (cr, CAIRO_ANTIALIAS_DEFAULT);

        if (self->rotating)
        {
            cairo_set_source_rgb(cr, 1, 0, 0);
            cairo_move_to (cr, ox, oy);
            cairo_line_to (cr, self->x, self->y);
            cairo_stroke (cr);
        }

        if (TBO_IS_OBJECT_GROUP (current_obj))
            tbo_object_group_unset_vars (current_obj);
    }
}

static void
frame_view_on_key (TboToolBase *tool, GtkWidget *widget, GdkEventKey *event)
{
    TboToolSelector *self = TBO_TOOL_SELECTOR (tool);
    TboObjectBase *current_obj = self->selected_object;
    TboDrawing *drawing = TBO_DRAWING (tool->tbo->drawing);

    if (self->selected_frame != NULL && event->keyval == GDK_KEY_Escape)
    {
        tbo_tool_selector_set_selected (self, NULL);
        tbo_drawing_set_current_frame (drawing, NULL);
        update_menubar (tool->tbo);
        tbo_toolbar_update (tool->tbo->toolbar);
    }

    if (current_obj != NULL)
    {
        switch (event->keyval)
        {
            case GDK_KEY_less:
                tbo_object_base_resize (current_obj, RESIZE_LESS);
                break;
            case GDK_KEY_greater:
                tbo_object_base_resize (current_obj, RESIZE_GREATER);
                break;
            case GDK_KEY_Up:
                tbo_object_base_move (current_obj, MOVE_UP);
                break;
            case GDK_KEY_Down:
                tbo_object_base_move (current_obj, MOVE_DOWN);
                break;
            case GDK_KEY_Left:
                tbo_object_base_move (current_obj, MOVE_LEFT);
                break;
            case GDK_KEY_Right:
                tbo_object_base_move (current_obj, MOVE_RIGHT);
                break;
            default:
                break;
        }
    }
    tbo_drawing_update (drawing);
}

static void
page_view_drawing (TboToolBase *tool, cairo_t *cr)
{
    const double dashes[] = {5, 5};
    Color border = {0.9, 0.9, 0};
    Color white = {1, 1, 1};
    Color black = {0, 0, 0};
    Color *resizer_border;
    Color *resizer_fill;
    int x, y;
    float r_size;

    TboToolSelector *self = TBO_TOOL_SELECTOR (tool);
    Frame *selected = self->selected_frame;
    TboDrawing *drawing = TBO_DRAWING (tool->tbo->drawing);

    if (selected != NULL)
    {
        cairo_set_antialias (cr, CAIRO_ANTIALIAS_NONE);
        cairo_set_line_width (cr, 1);
        cairo_set_dash (cr, dashes, G_N_ELEMENTS (dashes), 0);
        cairo_set_source_rgb (cr, border.r, border.g, border.b);
        cairo_rectangle (cr, selected->x, selected->y,
                selected->width, selected->height);
        cairo_stroke (cr);

        // resizer
        if (self->over_resizer)
        {
            resizer_fill = &black;
            resizer_border = &white;
        }
        else
        {
            resizer_fill = &white;
            resizer_border = &black;
        }

        cairo_set_line_width (cr, 1);
        cairo_set_dash (cr, dashes, 0, 0);

        x = selected->x + selected->width;
        y = selected->y + selected->height;

        r_size = R_SIZE / tbo_drawing_get_zoom (drawing);
        cairo_set_line_width (cr, 1 / tbo_drawing_get_zoom (drawing));
        cairo_rectangle (cr, x, y, r_size, r_size);
        cairo_set_source_rgb(cr, resizer_fill->r, resizer_fill->g, resizer_fill->b);
        cairo_fill (cr);

        cairo_set_source_rgb(cr, resizer_border->r, resizer_border->g, resizer_border->b);
        cairo_rectangle (cr, x, y, r_size, r_size);
        cairo_stroke (cr);
        cairo_set_line_width (cr, tbo_drawing_get_zoom (drawing));

        cairo_set_antialias (cr, CAIRO_ANTIALIAS_DEFAULT);
    }
}

static void
page_view_on_click (TboToolBase *tool, GtkWidget *widget, GdkEventButton *event)
{
    int x, y;
    GList *frame_list;
    Page *page;
    Frame *frame;
    gboolean found = FALSE;

    TboWindow *tbo = tool->tbo;
    TboToolSelector *self = TBO_TOOL_SELECTOR (tool);
    Frame *selected;
    TboDrawing *drawing = TBO_DRAWING (tool->tbo->drawing);

    x = (int)event->x;
    y = (int)event->y;


    page = tbo_comic_get_current_page (tbo->comic);
    for (frame_list = tbo_page_get_frames (page); frame_list; frame_list = frame_list->next)
    {
        frame = (Frame *)frame_list->data;
        if (tbo_frame_point_inside (frame, x, y))
        {
            // Selecting last occurrence.
            tbo_tool_selector_set_selected (self, frame);
            found = TRUE;
        }
    }
    selected = self->selected_frame;

    // resizing
    if (selected && over_resizer (self, selected, x, y))
    {
        self->resizing = TRUE;
    }
    else if (!found)
        tbo_tool_selector_set_selected (self, NULL);

    // double click, frame view
    if (selected && event->type == GDK_2BUTTON_PRESS)
    {
        tbo_drawing_set_current_frame (drawing, selected);
        empty_tool_area (self);
        tbo_tooltip_set (NULL, 0, 0, tbo);
        // TODO add tooltip_notify
        tbo_tooltip_set_center_timeout (_("press esc to go back"), 3000, tbo);
        update_menubar (tbo);
        tbo_toolbar_update (tbo->toolbar);
    }

    self->start_x = x;
    self->start_y = y;

    if (selected)
    {
        self->start_m_x = selected->x;
        self->start_m_y = selected->y;
        self->start_m_w = selected->width;
        self->start_m_h = selected->height;
        tbo_page_set_current_frame (page, selected);
    }
    self->clicked = TRUE;
}

static void
page_view_on_move (TboToolBase *tool, GtkWidget *widget, GdkEventMotion *event)
{
    int x, y, offset_x, offset_y;
    TboWindow *tbo = tool->tbo;
    TboToolSelector *self = TBO_TOOL_SELECTOR (tool);
    Frame *selected = self->selected_frame;

    x = (int)event->x;
    y = (int)event->y;

    if (selected != NULL)
    {
        if (self->clicked)
        {
            offset_x = (self->start_x - x);
            offset_y = (self->start_y - y);

            // resizing frame
            if (self->resizing)
            {
                selected->width = abs (self->start_m_w - offset_x);
                selected->height = abs (self->start_m_h - offset_y);

                update_tool_area (self);
            }
            // moving frame
            else
            {
                selected->x = self->start_m_x - offset_x;
                selected->y = self->start_m_y - offset_y;

                update_tool_area (self);
            }
        }

        // over resizer
        if (over_resizer (self, selected, x, y))
        {
            self->over_resizer = TRUE;
        }
        else
        {
            self->over_resizer = FALSE;
        }
    }

    GList *frame_list;
    Frame *frame;
    Page *page = tbo_comic_get_current_page (tbo->comic);
    gboolean found = FALSE;
    int x1, y1;

    for (frame_list = tbo_page_get_frames (page); frame_list && !found; frame_list = frame_list->next)
    {
        if (tbo_frame_point_inside ((Frame*)frame_list->data, x, y))
        {
            frame = (Frame*)frame_list->data;
            x1 = frame->x + (frame->width / 2);
            y1 = frame->y + (frame->height / 2);
            tbo_tooltip_set (_("double click here"), x1, y1, tbo);
            found = TRUE;
        }
    }
    if (!found)
        tbo_tooltip_set(NULL, 0, 0, tbo);
}

/* init methods */

static void
tbo_tool_selector_init (TboToolSelector *self)
{
    self->x = 0;
    self->y = 0;
    self->start_x = 0;
    self->start_y = 0;
    self->start_m_x = 0;
    self->start_m_y = 0;
    self->start_m_w = 0;
    self->start_m_h = 0;
    self->clicked = FALSE;
    self->over_resizer = FALSE;
    self->over_rotater = FALSE;
    self->resizing = FALSE;
    self->rotating = FALSE;
    self->spin_w = NULL;
    self->spin_h = NULL;
    self->spin_x = NULL;
    self->spin_y = NULL;

    self->parent_instance.on_move = on_move;
    self->parent_instance.on_click = on_click;
    self->parent_instance.on_release = on_release;
    self->parent_instance.on_key = on_key;
    self->parent_instance.drawing = drawing;
}

static void
tbo_tool_selector_class_init (TboToolSelectorClass *klass)
{
}

/* object functions */

GObject *
tbo_tool_selector_new ()
{
    GObject *tbo_tool;
    tbo_tool = g_object_new (TBO_TYPE_TOOL_SELECTOR, NULL);
    return tbo_tool;
}

GObject *
tbo_tool_selector_new_with_params (TboWindow *tbo)
{
    GObject *tbo_tool;
    TboToolBase *tbo_tool_base;
    tbo_tool = g_object_new (TBO_TYPE_TOOL_SELECTOR, NULL);
    tbo_tool_base = TBO_TOOL_BASE (tbo_tool);
    tbo_tool_base->tbo = tbo;
    return tbo_tool;
}

Frame *
tbo_tool_selector_get_selected_frame (TboToolSelector *self)
{
    return self->selected_frame;
}

TboObjectBase *
tbo_tool_selector_get_selected_obj (TboToolSelector *self)
{
    return self->selected_object;
}

void
tbo_tool_selector_set_selected (TboToolSelector *self, Frame *frame)
{
    self->selected_frame = frame;
    empty_tool_area (self);
    if (self->selected_frame != NULL)
        update_tool_area (self);
    update_menubar (TBO_TOOL_BASE (self)->tbo);
}

void
tbo_tool_selector_set_selected_obj (TboToolSelector *self, TboObjectBase *obj)
{
    if (!obj && TBO_IS_OBJECT_GROUP (self->selected_object))
    {
        TboDrawing *drawing = TBO_DRAWING (TBO_TOOL_BASE (self)->tbo->drawing);
        Frame *frame = tbo_drawing_get_current_frame (drawing);
        tbo_frame_del_obj (frame, self->selected_object);
    }
    self->selected_object = obj;
    update_menubar (TBO_TOOL_BASE (self)->tbo);
}


static void
frame_move_do (TboAction *act)
{
    TboActionFrameMove *action = (TboActionFrameMove*)act;
    action->frame->x = action->x2;
    action->frame->y = action->y2;
}

static void
frame_move_undo (TboAction *act)
{
    TboActionFrameMove *action = (TboActionFrameMove*)act;
    action->frame->x = action->x1;
    action->frame->y = action->y1;
}

TboAction *
tbo_action_frame_move_new (Frame *frame, int x1, int y1, int x2, int y2)
{
    TboActionFrameMove *action = (TboActionFrameMove*)tbo_action_new (TboActionFrameMove);
    action->frame = frame;
    action->x1 = x1;
    action->x2 = x2;
    action->y1 = y1;
    action->y2 = y2;
    action->action_do = frame_move_do;
    action->action_undo = frame_move_undo;
    return (TboAction*)action;
}

static void
obj_move_do (TboAction *act)
{
    TboActionObjMove *action = (TboActionObjMove*)act;
    action->obj->x = action->x2;
    action->obj->y = action->y2;
}

static void
obj_move_undo (TboAction *act)
{
    TboActionObjMove *action = (TboActionObjMove*)act;
    action->obj->x = action->x1;
    action->obj->y = action->y1;
}

TboAction *
tbo_action_object_move_new (TboObjectBase *object, int x1, int y1, int x2, int y2)
{
    TboActionObjMove *action = (TboActionObjMove*)tbo_action_new (TboActionObjMove);
    action->obj = object;
    action->x1 = x1;
    action->x2 = x2;
    action->y1 = y1;
    action->y2 = y2;
    action->action_do = obj_move_do;
    action->action_undo = obj_move_undo;
    return (TboAction*)action;
}
