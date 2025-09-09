using Infrastructure.Models;
using System.Text.Json;

namespace Infrastructure.Services;

public class JsonFileService(string filePath)
{
    private readonly string _filePath = filePath;

}
