# Living Dex Builder for PKHeX

![GitHub release](https://img.shields.io/github/v/release/hexbyt3/LiveDeX)
![GitHub all releases](https://img.shields.io/github/downloads/hexbyt3/LiveDeX/total)
![.NET](https://img.shields.io/badge/.NET-9.0-blue)
![License](https://img.shields.io/github/license/hexbyt3/LiveDeX)

> [!IMPORTANT]
> Now supports **Pokémon Legends: Z-A**!

Generate missing Pokémon for your Living Dex. Supports all games from Gen 1-9 including Legends Z-A.

![Screenshot](https://github.com/user-attachments/assets/02f136a3-df9f-46de-a1a5-cc9fee13ef03)

## Installation

### Option 1: Use PKHeXth (Recommended)

This plugin is already included in [PKHeXth](https://github.com/hexbyt3/PKHeXth) - my fork of PKHeX with built-in enhancements.

Just open **Tools → Data → Living Dex Builder** or press `Ctrl+L`

### Option 2: Manual Installation

1. Download `PKHeX.Plugin.LivingDex.dll` from [Releases](../../releases)
2. Place it in PKHeX's `plugins` folder
3. Restart PKHeX
4. Open with **Tools → Data → Living Dex Builder** or press `Ctrl+L`

## Usage

1. Load your save file
2. Open the plugin and configure options:
   - **Shiny** - Generate shiny versions
   - **Min Level** - Use lowest encounter level (off = level 100)
   - **All Forms** - Include alternate forms
   - **Both Genders** - Generate male and female
   - **Paired Version** - Include version exclusives
   - **Mystery Gifts** - Allow event Pokémon
   - **Legal Only** - Skip illegal combinations
3. Click **Generate** then **Import to Boxes**

The plugin automatically skips Pokémon you already own.

## Building

```bash
git clone <repo>
dotnet build -c Release
```

Requires .NET 9 SDK and `PKHeX.Core.dll` in the `Deps` folder.

## Credits

By hexbyt3. Licensed same as PKHeX.
