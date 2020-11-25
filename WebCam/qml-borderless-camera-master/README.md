QML Borderless Camera
=====================

After seeing https://github.com/grigio/borderless-camera I realized I could easily replicate it without Electron, providing the same functionality with a small fraction of the resources. This could be further improved by shedding the Qt dependencies, but probably not in the 20 minutes it took me to do this with only a little QML knowledge and a search engine.

### Video demo

![Video demo](demo.mp4)

(you may have to download the demo to view it, blame GitLab)

### Dependencies

- Qt 5 with QML support
- QtQuick Controls 1.4+
- QtMultimedia 5.6+

Maybe it works with older versions. Testing would take me far more time than it took developing.

### Installation

Just drop app.qml somewhere.

### Usage

Run the script with the `qml` command, like this:

    qml app.qml

Hit the "M" key with the window focused to mirror the image.

### License

MPLv2, full text included in LICENSE file.

### Donations

Man. This took me 20 minutes to make. Donate to the EFF if you feel like sharing to a good cause!.
