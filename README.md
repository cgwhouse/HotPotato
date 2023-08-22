# HotPotato

This is a (useless) automation engine built upon Selenium WebDriver and .NET.

## Dependencies

- .NET SDK
- Recent version of Chrome / Chromium

## Known Issues

- Upon first launch of a ChromeDriver instance, sometimes takes several attempts before localhost starts responding, seems it needs to "warm up"

## Next Steps

- Make a distributable that only requires runtime instead of the SDK + having to build it yourself

## TODOs

- Guarantee a driver.Quit() call at the end
- Start to stub out the CLI interaction
- Consider allowing user to select the browser themselves?
- Any user preferences we would want to persist? Maybe we could use a sqllite db under the hood?
- Serilog config
