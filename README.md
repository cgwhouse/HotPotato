# HotPotato

## Dependencies

- .NET runtime (test in VM)
- Recent version of Chrome / Chromium

## TODOs

- Create System Requirements section in README
- Intro section explaining what it is / what it does
- Guarantee a driver.Quit() call at the end
- Start to stub out the CLI interaction
- May want to split out the interaction part as well as the "execute it" part?
- Consider allowing user to select the browser themselves?
- Any user preferences we would want to persist? Maybe we could use a sqllite db under the hood?
- rename the whole thing to something a little less confusing
  - BotWeb = multiple bots? weird
- instead of Toolbox and Scripts, at least make Toolbox more like `Services` so it can be more generic
- Note about how it might take a few mins on first launch (known issues)
