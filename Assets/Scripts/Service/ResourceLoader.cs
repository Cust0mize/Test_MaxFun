using UnityEngine;
using System.IO;

public class ResourceLoader : GlobalSingleton<ResourceLoader> {
    private const string ConfigsPath = "Configs/";

    public TextAsset GetConfigFile(string path) {
        string fullPath = Path.Combine(ConfigsPath, path);
        return Resources.Load<TextAsset>(fullPath);
    }
}
