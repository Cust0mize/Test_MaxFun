using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ConfigService : GlobalSingleton<ConfigService> {
    private const string PlanetConfigPath = "PlanetConfigs";
    public PlanetConfig[] PlanetConfigs { get; private set; }

    public ConfigService() {
        LoadPlanetConfig();
    }

    private void LoadPlanetConfig() {
        string filePath = string.Format(PlanetConfigPath);

        TextAsset fileRaw = ResourceLoader.I.GetConfigFile(filePath);

        string[,] fileGrid = CsvParser.SplitCsvGrid(fileRaw.text);

        List<PlanetConfig> configs = new List<PlanetConfig>();
        for (int y = 1; y < fileGrid.GetLength(1); y++) {
            if (string.IsNullOrEmpty(fileGrid[1, y])) {
                continue;
            }

            int MaxPlanet = int.Parse(fileGrid[0, y], CultureInfo.InvariantCulture);
            float MinPlanetSize = float.Parse(fileGrid[1, y], CultureInfo.InvariantCulture);
            float MaxPlanetSize = float.Parse(fileGrid[2, y], CultureInfo.InvariantCulture);

            configs.Add(new PlanetConfig {
                MaxPlanet = MaxPlanet,
                MinPlanetSize = MinPlanetSize,
                MaxPlanetSize = MaxPlanetSize,
            });
        }
        PlanetConfigs = configs.ToArray();
    }
}
