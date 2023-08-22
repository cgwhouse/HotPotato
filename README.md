# HotPotato

This is a (useless) automation engine built upon Selenium WebDriver and .NET.

## Dependencies

- Recent version of Chrome / Chromium

## Known Issues

- Upon first launch of a ChromeDriver instance, sometimes takes several attempts before localhost starts responding, seems it needs to "warm up"

## Next Steps

- Make an internal install script that builds and zips self-contained distributables for target platforms

## TODOs

- Guarantee a driver.Quit() call at the end
- Consider allowing user to select the browser they want to use
- Any user preferences we would want to persist? Another option on main menu
- Serilog config
