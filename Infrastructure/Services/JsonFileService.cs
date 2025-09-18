using Infrastructure.Interfaces;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Infrastructure.Services;

public class JsonFileService(string filePath, JsonSerializerOptions jsonOptions) : IFileService
{
    private readonly string _filePath = filePath;
    public string GetContentFromFile()
    {
        if (!File.Exists(_filePath))
            return string.Empty;

        return File.ReadAllText(_filePath);
    }

    public bool SaveToFile(string content)
    {
        try
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            File.WriteAllText(_filePath, content);
            return true;
        }
        catch 
        { 
            return false; 
        }

        
    }
}
