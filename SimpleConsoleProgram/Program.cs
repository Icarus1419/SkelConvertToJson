using System.Xml;
using Newtonsoft.Json;
using SkelConverter;
using Spine;

namespace SkelConvertToJson
{
    public class Program
    {
        static void Main(string[] args)
        {
            var defaultPath = default(string);
            var atlasFilePath = default(string);
            var skelFilePath = default(string);

            if (args.Any() && Directory.Exists(args[0])) defaultPath = args[0];

            Console.WriteLine("Please Enter the atlas file path or directory:");
            var atlasSearchPath = defaultPath ?? Console.ReadLine();
            if (File.Exists(atlasSearchPath)) atlasFilePath = atlasSearchPath;
            else if (Directory.Exists(atlasSearchPath))
            {
                var filePaths = Directory.EnumerateFiles(atlasSearchPath);
                foreach (var filePath in filePaths)
                {
                    if (filePath.ToLower().EndsWith(".atlas"))
                    {
                        atlasFilePath = filePath;
                        break;
                    }
                }
            }
            if (atlasFilePath == default) throw new ArgumentNullException($"Can't find atlas file in \"{atlasSearchPath}\"");
            else Console.WriteLine($"Using atlas file \"{atlasFilePath}\"");

            Console.WriteLine("Please Enter the skel file path:");
            var skelSearchPath = defaultPath ?? Console.ReadLine();
            if (File.Exists(skelSearchPath)) skelFilePath = skelSearchPath;
            else if (Directory.Exists(skelSearchPath))
            {
                var filePaths = Directory.EnumerateFiles(skelSearchPath);
                foreach (var filePath in filePaths)
                {
                    if (filePath.ToLower().EndsWith(".skel"))
                    {
                        skelFilePath = filePath;
                        break;
                    }
                }
            }
            if (skelFilePath == default) throw new ArgumentNullException($"Can't find skel file in \"{skelSearchPath}\"");
            else Console.WriteLine($"Using skel file \"{skelFilePath}\"");

            Console.Write("Export Skin Part Data?(Y/N):");
            var exportSkin = Console.ReadKey().Key == ConsoleKey.Y;
            Console.WriteLine();
            Console.Write("Export Event Part Data?(Y/N):");
            var exportEvent = Console.ReadKey().Key == ConsoleKey.Y;
            Console.WriteLine();

            var skeletonData = SkelReader.ConvertToJsonSkeletonData(SkelReader.ReadSkelData(atlasFilePath, skelFilePath), exportSkin, exportEvent);

            var jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            string data = JsonConvert.SerializeObject(skeletonData, Newtonsoft.Json.Formatting.Indented, jsonSettings);
            File.WriteAllText($"{skelFilePath}.json", data);

            Console.WriteLine($"Convert Success, File is saved to \"{skelFilePath}.json\".");
        }
    }
}
