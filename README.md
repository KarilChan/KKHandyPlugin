## Koikatsu x Handy plugin

This Node server receives game data from the Koikatsu x Handy plugin and communicates with the Handy API to synchronize
Handy strokes.

## Contents

* [Requirements](#requirements)
* [Installation](#installation)
* [Config](#config)

## Requirements
* (Included in BetterRepack) [Bepinex](https://github.com/BepInEx/BepInEx) >= v5.4.9
* (Included in BetterRepack) `KKAPI.dll` >= v1.17.0 from [IllusionModdingAPI](https://github.com/IllusionMods/IllusionModdingAPI)
* `RestSharp.dll` from [RestSharp v105.1.0](https://github.com/restsharp/RestSharp/releases/tag/105.1.0)
  
## Installation
* Get the [latest release](https://github.com/KarilChan/KKHandyPlugin/releases) of this plugin
* Set up the [KK Handy server](https://github.com/KarilChan/handy-koikatsu-serve)

### Config
* port
    * port number to connect to the server
    * should match the value in server settings (both 42069 by default)