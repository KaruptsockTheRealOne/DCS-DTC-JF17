# DCS DTC

https://github.com/the-paid-actor/dcs-dtc

This is a mod for DCS that works as a DTC (Data Cartridge) for the F-16.
Large sections re-written for the JF-17 and some functions removed to be more compatible.

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
