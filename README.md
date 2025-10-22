# 📦 Living Dex Builder Plugin for PKHeX

A powerful PKHeX plugin that helps you complete your Living Dex collection with just a few clicks. Never manually hunt for missing Pokémon again!

## ✨ What does this do?

This plugin analyzes your save file and automatically generates any missing Pokémon needed to complete your Living Dex. Whether you're aiming for a complete National Dex or just filling in some gaps, this tool has you covered.

**Key Features:**
- Scans your save file to identify missing Pokémon species and forms
- Generates legal encounters for all missing entries
- Supports all generations of Pokémon games
- Flexible options for shiny, gender variants, forms, and more
- Imports generated Pokémon directly into your boxes

## 🚀 Installation

1. Download the latest `PKHeX.Plugin.LivingDex.dll` from the [Releases](../../releases) page
2. Place the DLL in your PKHeX `plugins` folder
   - If the folder doesn't exist, create it in the same directory as PKHeX.exe
3. Restart PKHeX

That's it! The Living Dex Builder will now appear in your Tools → Data menu.

## 🎮 How to use

1. Open your save file in PKHeX
2. Go to **Tools → Data → Living Dex Builder** (or press `Ctrl+L`)
3. Configure your preferences:
   - **Generate Shiny**: Make all Pokémon shiny
   - **Minimum Level**: Generate at the lowest possible level (otherwise level 100)
   - **Include All Forms**: Include regional forms, Mega evolutions, etc.
   - **Include Both Genders**: Generate separate entries for gender differences
   - **Include Paired Version**: Include version exclusives from the opposite game
   - **Include Mystery Gifts**: Allow event Pokémon to be generated
   - **Legal Only**: Only generate Pokémon that pass legality checks
4. Click **Generate Pokémon**
5. Review the results, then click **Import to Boxes** to add them to your save

The plugin will automatically skip any Pokémon you already have, so you only get what you're missing.

## 🎯 Options explained

### Generate Shiny
Makes all generated Pokémon shiny. Who doesn't want a shiny Living Dex?

### Minimum Level
When enabled, Pokémon are generated at their minimum obtainable level. When disabled, everything is generated at level 100 for consistency.

### Include All Forms
Includes all available forms of each species (Alolan forms, Galarian forms, Vivillon patterns, etc.). Disable this if you only want the base form of each species.

### Include Both Genders
For species with visible gender differences (like Unfezant or Meowstic), this generates both male and female variants. Disable if you only want one representative per species.

### Include Paired Version
Includes version-exclusive Pokémon from the paired game. For example, if you're playing Violet, this will include Scarlet exclusives so you can complete your full Dex.

### Include Mystery Gifts
Allows the generator to use event-exclusive Pokémon. Disable if you only want naturally obtainable encounters.

### Legal Only
Only generates Pokémon that will pass PKHeX's legality checker. Highly recommended to keep enabled!

## 🛠️ Building from source

If you want to build the plugin yourself:

1. Clone this repository
2. Make sure you have [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) installed
3. Update `Deps/PKHeX.Core.dll` with the version matching your PKHeX installation
4. Run `dotnet build -c Release`
5. The compiled plugin will be in `PKHeX.Plugin.LivingDex/bin/Release/net9.0-windows/`

## 📝 Notes

- The plugin uses the TrainerPath setting from PKHeX (if configured) to provide custom trainer data for generated Pokémon
- Generation respects your game's available Pokémon and won't try to create species that don't exist in your save's generation
- Some special forms (like battle-only forms or temporary transformations) may not be included
- The plugin filters out untradeable encounters to ensure all generated Pokémon can be properly stored

## 🐛 Issues or suggestions?

If you encounter any bugs or have ideas for improvements, please open an issue on the [Issues](../../issues) page.

## 💝 Credits

Created by hexbyt3 for the PKHeX community. Special thanks to the PKHeX development team for creating such an amazing tool!

## 📜 License

This project is licensed under the same terms as PKHeX. Use at your own risk!
