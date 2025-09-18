
using System.Globalization;

namespace Infrastructure.Interfaces;

public interface IFileService
{
    public bool SaveToFile(string content);

    public string GetContentFromFile();
}
