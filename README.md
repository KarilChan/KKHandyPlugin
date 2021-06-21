## Koikatsu x Handy plugin

This plugin sends game data to the [KK Handy server](https://github.com/KarilChan/handy-koikatsu-server) in H scenes.
[![Demo video](https://i.imgur.com/4uDn9eC.png)](https://www.youtube.com/watch?v=w1y0_ElPY-A "Demo video")

## Contents

* [Requirements](#requirements)
* [Installation](#installation)
* [Config](#config)

## Requirements

* (Included in BetterRepack) [BepInEx](https://github.com/BepInEx/BepInEx) >= v5.4.9
* (Included in BetterRepack) `KKAPI.dll` >= v1.17.0
  from [IllusionModdingAPI](https://github.com/IllusionMods/IllusionModdingAPI)
* `RestSharp.dll` from [RestSharp v105.1.0](https://github.com/restsharp/RestSharp/releases/tag/105.1.0)

## Installation

* Get the [latest release](https://github.com/KarilChan/KKHandyPlugin/releases) of this plugin
* Set up the [KK Handy server](https://github.com/KarilChan/handy-koikatsu-server)

### Config

* port
    * port number to connect to the server
    * should match the value in server settings (both 42069 by default)