# Social Brothers Address API case

Een .NET Core 5 Address API

## Installation

1. Verkrijg een API key van [MapQuest](https://developer.mapquest.com/plan_purchase/steps/business_edition/business_edition_free/register)
2. Plaats uw API key in SBAddressCase\SBCaseAPI\appsettings.json
3. U kunt de API nu starten

## Mogelijke verbeteringen

- Check op de validiteit van een locatie d.m.v. de Geolocation API,
- Een abstractieniveau boven IAddressRepository (IRepository) zou de uitbreidbaarheid van deze API verhogen,
- De entities en context hun eigen project geven zou voor nog betere Separation of Concerns zorgen.

## Tevreden over...
- De GeolocationService is een apart project, wat het makkelijk maakt om later een andere API te gebruiken in plaats van MapQuest,
- Het gebruik van interfaces is een goed begin waar op uitgebreid zou kunnen worden.