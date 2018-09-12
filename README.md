# Measurements
A simple library that provides an easy way to manage multiple units within an application.

This package provides a unit type class for several types of common measurements, and derived classes for each unit within that measurement type. This allows functions to be built to accept the measurement type and be able to be passed a specific units from a user interface or other libraries and the function simply creates a new instance of the derived type it requires, and the library will handle the conversion.

## Pending Changes / Features
+ Add a means to store unit information, which can be used to generate unit instances (useful for storing the users measurement unit preferences and using that to parse input throughout the entire program).
+ Add a means to parse a specified measurement type to any unit, using only user input text.
+ Add a means to parse to any measurement and unit type, using only user input text.
+ Add a means to access the available units within a measurement type (useful for providing preference options to a user, or compatability information to implimentors).
+ Add a means to access the available measurement types within  the library.
+ Add additional measurement types such as:
    + Length
    + Pressure
    + Mass
    + Force
+ Add mechanics for standard scaling factors such as:
    + Micro
    + Milli
    + Kilo
    + Mega
+ Add multi-component expressions:
    + Pressure is returned by an operation of `Force / Area`
    + Work is returned by an operation of `Force * Length`

## Changelog:
### 0.0.0.1:
Reformatted the layout of the project package to separate different measurement types. Fixed a conversion issue with the Kelvin unit and added several alternative temperature units.
+ Fixed: an incorrect conversion in the Kelvin class.
+ Added: namespace TBQ.Measurements.Temperature
+ Added: class TBQ.Measurements.Temperature.Newton
+ Added: class TBQ.Measurements.Temperature.Rankine
+ Added: class TBQ.Measurements.Temperature.Reaumur
+ Added: class TBQ.Measurements.Temperature.Romer
+ Refactored: class TBQ.Measurements.Temperature => class TBQ.Measurements.Temperature.Temperature
+ Refactored: class TBQ.Measurements.Celsius => class TBQ.Measurements.Temperature.Celsius
+ Refactored: class TBQ.Measurements.Kelvin => class TBQ.Measurements.Temperature.Kelvin
+ Refactored: class TBQ.Measurements.Fahrenheit => class TBQ.Measurements.Temperature.Fahrenheit

### 0.0.0.0:
Initial release. Built core mechanisms for highlighting similar measurement types and converting between different units of the same measurement type.
+ Added: namespace TBQ
+ Added: namespace TBQ.Measurements
+ Added: interface TBQ.Measurements.IUnit
+ Added: class TBQ.Measurements.Temperature
+ Added: class TBQ.Measurements.Celsius
+ Added: class TBQ.Measurements.Kelvin
+ Added: class TBQ.Measurements.Fahrenheit
