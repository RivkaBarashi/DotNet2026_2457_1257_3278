namespace DalApi;

using System.IO;
using System.Xml.Linq;

static class DalConfig
{
    internal static string s_dalName;
    internal static Dictionary<string, string> s_dalPackages;
    private static readonly string s_configPath =
        Path.Combine(AppContext.BaseDirectory, "xml", "dal-config.xml");

    static DalConfig()
    {
        if (!File.Exists(s_configPath))
            throw new DalConfigException($"dal-config.xml file is not found at '{s_configPath}'");

        XElement dalConfig = XElement.Load(s_configPath);

        s_dalName =
           dalConfig.Element("dal")?.Value ?? throw new DalConfigException("<dal> element is missing");

        var packages = dalConfig.Element("dal-packages")?.Elements() ??
            throw new DalConfigException("<dal-packages> element is missing");
        s_dalPackages = packages.ToDictionary(p => "" + p.Name, p => p.Value);
    }
}

[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}
