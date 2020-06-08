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


#include <sys/stat.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "tbo-files.h"
#include <glib.h>

char **tbo_files_get_dirs ()
{
    // Possible doodle dirs
    char **possible_dirs = malloc (4*sizeof(char*));
    possible_dirs[0] = malloc (255*sizeof(char*));
    possible_dirs[1] = malloc (255*sizeof(char*));
    possible_dirs[2] = malloc (255*sizeof(char*));
    possible_dirs[3] = NULL;

    strcat (strcpy (possible_dirs[0], getenv("HOME")), "/.tbo/doodle");
    strcat (strcpy (possible_dirs[1], g_get_user_data_dir ()), "/tbo/doodle");
    strcpy (possible_dirs[2], DATA_DIR "/doodle");

    return possible_dirs;
}

int
tbo_files_prefix_len (char *str)
{
    int n, i = 0;
    char **possible_dirs = tbo_files_get_dirs ();
    while (possible_dirs[i])
    {
        if (g_str_has_prefix (str, possible_dirs[i]))
        {
            n = strlen (possible_dirs[i]) + 1;
            break;
        }
        i++;
    }
    tbo_files_free (possible_dirs);
    return n;
}

void
tbo_files_free (char **files)
{
    int i = 0;
    while(files[i])
    {
        free (files[i]);
        i++;
    }
    free (files);
}

void
tbo_files_expand_path (char *source, char *dest)
{
    int st, i = 0;
    char **possible_dirs = tbo_files_get_dirs ();
    struct stat filestat;
    while (possible_dirs[i])
    {
        snprintf (dest, 255, "%s/%s", possible_dirs[i], source);
        st = stat (dest, &filestat);
        if (!st)
            break;
        else
            snprintf (dest, 255, "%s", source);

        i++;
    }

    tbo_files_free (possible_dirs);
}

gboolean
tbo_files_is_svg_file (char *source)
{
    gchar **paths;
    gchar **ext;
    gchar *lower_ext;
    gboolean is_svg = FALSE;

    paths = g_strsplit (source, ".", 0);

    ext = paths;
    while (*ext) ext++;
    ext--;

    lower_ext = g_ascii_strdown (*ext, -1);

    if (strcmp (lower_ext, "svg") == 0) {
        is_svg = TRUE;
    }

    g_strfreev (paths);
    g_free (lower_ext);

    return is_svg;
}
