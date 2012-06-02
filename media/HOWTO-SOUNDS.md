Origins of Media
================

In an effort to be completely transparent with regards to the source of this
program, here is a step-by-step guide explaining how I made some of the
"opaque" media in this project.

creepy*.wav
-----------

Begin with completely null waveform. Pipe both channels through the
[CAPS](http://quitte.de/dsp/caps.html) 0.4.5 "C* Lorenz" LADSPA plugin
(caps.so) by Tim Goetze <tim@quitte.de> with the parameters set thusly:

h: 0.25
x: 1.0
y: 0.0
z: 0.0
volume: 0.5

(These are the default settings.)

You now have creepy.wav. Repeat for creepy2.wav, and again for creepy3.wav.
