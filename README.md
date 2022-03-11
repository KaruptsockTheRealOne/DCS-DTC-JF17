# DCS DTC

This is a extension of the work of the DCS DTC MOD for the DTC (Data Cartridge) in the F-16.
https://github.com/the-paid-actor/dcs-dtc

Large sections re-written for the JF-17 and some functions removed to be more compatible.
 
This allows you to capture Lat/Long on the F10 and via lua commands use the UFC and punch in all the saved waypoints.
 
The Default is DST 36 - 39 as this the Jf-17's Pre-Planned points for Smart Weapon Deployments.

But you can just change the waypoint numbers in the upload section to any numbers between 01-49

Features:

- Allows uploading to the JF-17 cockpit:
  - Waypoints
  - Enables you to share and receive settings from other people using this mod, either by file or clipboard
  - Allows capturing a waypoint coordinate using the F10 view in DCS, or a "markpoint" by flying over a point in the map.
  - Elevation data removed due to the way the Jeff accepts elevation data.

## Requirements

This application is written using .NET Framework 4.7.2. You may want to download the latest version from the Microsoft website.

## Installation

- Grab the zip file from the Releases tab on Github.
- Unzip it into a folder of your choice.
- Copy the DCSDTC.lua file into `C:\Users\<your user name>\Saved Games\DCS\Scripts`. Substitute `C:` for the drive 
  where your Windows is installed and `DCS` for `DCS.openbeta` if you are on the beta version.
- In that same folder, edit a file named `Export.lua`. If the file does not exists, create it yourself.
- Add the following line to the end of the file, if its not there already:

```lua
local DCSDTClfs=require('lfs'); dofile(DCSDTClfs.writedir()..'Scripts/DCSDTC.lua')
```

## Help

Contact me on Discord (The_Paid_Actor#1368) if you have issues, questions or suggestions.

## Credits

This uses some code and inspiration from DCS The Way mod by Comrade Doge. Link to the repository:
https://github.com/aronCiucu/DCSTheWay
