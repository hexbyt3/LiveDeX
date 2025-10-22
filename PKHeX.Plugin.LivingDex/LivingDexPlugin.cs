using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PKHeX.Core;

namespace PKHeX.Plugin.LivingDex;

public class LivingDexPlugin : IPlugin
{
    public string Name => "Living Dex Builder";
    public int Priority => 1;

    public ISaveFileProvider SaveFileEditor { get; private set; } = null!;
    public IPKMView PKMEditor { get; private set; } = null!;

    public void Initialize(params object[] args)
    {
        Console.WriteLine($"Loading {Name}...");
        SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider)!;
        PKMEditor = (IPKMView)Array.Find(args, z => z is IPKMView)!;
        var menu = (ToolStrip)Array.Find(args, z => z is ToolStrip)!;
        LoadMenuStrip(menu);
    }

    private void LoadMenuStrip(ToolStrip menuStrip)
    {
        var items = menuStrip.Items;
        if (items.Find("Menu_Tools", false)[0] is not ToolStripDropDownItem tools)
            throw new ArgumentException(nameof(menuStrip));

        // Find the Data submenu
        var dataMenu = tools.DropDownItems.Find("Menu_Data", false).FirstOrDefault() as ToolStripDropDownItem;
        if (dataMenu != null)
        {
            AddToDataMenu(dataMenu);
        }
        else
        {
            // Fallback: add to Tools menu directly
            AddPluginControl(tools);
        }
    }

    private void AddToDataMenu(ToolStripDropDownItem dataMenu)
    {
        var menuItem = new ToolStripMenuItem("Living Dex Builder");
        menuItem.Click += (_, _) => OpenLivingDexBuilder();
        menuItem.ShortcutKeys = Keys.Control | Keys.L;
        menuItem.ShowShortcutKeys = false;

        // Add after Batch Editor if it exists
        var batchEditorIndex = -1;
        for (int i = 0; i < dataMenu.DropDownItems.Count; i++)
        {
            var item = dataMenu.DropDownItems[i];
            if (item != null && (item.Name == "Menu_BatchEditor" ||
                item.Text.Contains("Batch Editor")))
            {
                batchEditorIndex = i;
                break;
            }
        }

        if (batchEditorIndex >= 0)
        {
            dataMenu.DropDownItems.Insert(batchEditorIndex + 1, menuItem);
        }
        else
        {
            dataMenu.DropDownItems.Add(menuItem);
        }

        Console.WriteLine($"{Name} added to Data menu.");
    }

    private void AddPluginControl(ToolStripDropDownItem tools)
    {
        var ctrl = new ToolStripMenuItem(Name);
        ctrl.Click += (_, _) => OpenLivingDexBuilder();
        tools.DropDownItems.Add(ctrl);
        Console.WriteLine($"{Name} added to Tools menu.");
    }

    private void OpenLivingDexBuilder()
    {
        var sav = SaveFileEditor.SAV;

        // Create and populate trainer database from TrainerPath
        var db = new TrainerDatabase();
        var dir = GetTrainerPath();

        if (Directory.Exists(dir))
        {
            var files = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories);
            var pk = BoxUtil.GetPKMsFromPaths(files, sav.Context);
            foreach (var f in pk)
                db.RegisterCopy(f);
        }

        using var form = new SAV_LivingDexBuilder(sav, db);
        if (form.ShowDialog() == DialogResult.OK)
        {
            SaveFileEditor.ReloadSlots();
        }
    }

    private string GetTrainerPath()
    {
        // Try to get the TrainerPath from PKHeX settings
        // This is a best-effort attempt; if it fails, we'll just use an empty database
        try
        {
            var settingsType = Type.GetType("PKHeX.WinForms.Main, PKHeX.WinForms");
            if (settingsType != null)
            {
                var trainerPathProperty = settingsType.GetProperty("TrainerPath",
                    System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                if (trainerPathProperty != null)
                {
                    var path = trainerPathProperty.GetValue(null) as string;
                    if (!string.IsNullOrEmpty(path))
                        return path;
                }
            }
        }
        catch
        {
            // Silently fail and return empty string
        }

        return string.Empty;
    }

    public void NotifySaveLoaded()
    {
        Console.WriteLine($"{Name} was notified that a Save File was just loaded.");
    }

    public bool TryLoadFile(string filePath)
    {
        return false; // no action taken
    }
}
