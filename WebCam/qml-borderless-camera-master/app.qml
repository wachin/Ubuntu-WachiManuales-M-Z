// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
import QtQuick 2.7
import QtMultimedia 5.6
import QtQuick.Controls 1.4
ApplicationWindow {
	visible: true
	flags: Qt.FramelessWindowHint | Qt.WindowStaysOnTopHint
	width: 640; height: 480
	Item {
		id: item
		anchors.fill: parent
		focus: true
		Keys.onPressed: {
			if (event.key == Qt.Key_M) {
				rot.angle = rot.angle == 0 ? 180 : 0
			}
		}
		Camera { id: cam }
		VideoOutput {
			source: cam
			anchors.fill: parent
			transform: Rotation {
				id: rot
				origin.x: item.width/2;
				axis.x:0; axis.y:1; axis.z:0
				angle: 0
			}
		}
	}
}
