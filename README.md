## Koikatsu x Handy plugin

This plugin sends game data to the [KK Handy server](https://github.com/KarilChan/handy-koikatsu-server) in H scenes.
[![Demo video](https://i.imgur.com/4uDn9eC.png)](https://www.youtube.com/watch?v=w1y0_ElPY-A "Demo video")

## Contents

* [Installation](#installation)
* [Config](#config)

## Installation

* (Included in BetterRepack) [BepInEx](https://github.com/BepInEx/BepInEx) >= v5.4.9
* (Included in BetterRepack) `KKAPI.dll` >= v1.17.0
  from [IllusionModdingAPI](https://github.com/IllusionMods/IllusionModdingAPI)
* Get the [latest release](https://github.com/KarilChan/KKHandyPlugin/releases) of this plugin and RestSharp v105.1.0
    * Both .dll files should be inside `YOUR_KOIKATSU_FOLDER\BepInEx\Plugins` folder
* Set up the [KK Handy server](https://github.com/KarilChan/handy-koikatsu-server)

### Config

* port
    * port number to connect to the server
    * should match the value in server settings (both 42069 by default)