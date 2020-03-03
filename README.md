# VRBike
![alt-text](https://user-images.githubusercontent.com/40506467/75754492-ae4e8580-5ce1-11ea-87ba-f5944c215609.gif)

[Live Demo With Sound](https://www.youtube.com/watch?v=fm-PJcVgxT8&t=1s)
___
## Overview
VRBike is a virtual reality fitness app where you pedal a hardware exercise bike and dodge endless runner style obstacles. The virtual game's speed is grabbed from the bike using a sensor magnet which logs revolutions of the pedals to a raspberry pi which can then calculate the speed from the RPM. The calculated speed is sent to the game as a message using a websocket server hosted by the raspberry pi.
