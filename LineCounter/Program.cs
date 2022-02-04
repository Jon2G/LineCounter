// See https://aka.ms/new-console-template for more information

using LineCounter;

Console.WriteLine("[===============Contador de lineas===============]");
Console.Write("Ruta:");
string? path = Console.ReadLine();
if (string.IsNullOrEmpty(path))
{
    Console.Write("\r\nDebe especificar una ruta");
    return;
}
Console.Write("Patrón de extensión. Ej: '*.java':");
string? pattern = Console.ReadLine();
DirectoryInfo directory = new DirectoryInfo(path);
if (!directory.Exists)
{
    Console.WriteLine($"\r\nNo se encontró el directorio:'{directory.FullName}'");
    return;
}
Console.WriteLine($"[===============[COMENZANDO LECTURA]===============]");
DirectoryInfo? lastDirectory = null;
IEnumerable<FileInfo>? files = FilesLookUp.Search(directory, pattern);
if (files is null)
{
    Console.WriteLine("FATAL ERROR");
    return;
}

int lines = 0;
Console.Clear();
foreach (FileInfo file in files)
{
    if (lastDirectory != file.Directory)
    {
        lastDirectory = file.Directory;
        Console.WriteLine($"[D] {{{lastDirectory?.FullName}}}");
    }
    Console.Write($"[F] {{{file.FullName}}} => ");
    int fileLines = LinesCounter.CountLines(file);
    Console.Write($"{fileLines:D5}\r\n");
    lines += fileLines;
}
Console.WriteLine($"LINEAS TOTALES:{lines}");
