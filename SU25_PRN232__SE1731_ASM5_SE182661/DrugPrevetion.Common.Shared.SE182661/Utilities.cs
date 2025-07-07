using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DrugPrevetion.Common.Shared.SE182661
{
    public static class Utilities
    {
        private static string LoggerFilePath = Directory.GetCurrentDirectory() + @"\DataLog.txt";

        public static string ConvertObjectToJSONString<T>(T entity)
        {
            // /// DuyenCTT | JSON - Serialize: Convert specified generic type (specified object) into a JSON string
            string jsonString = JsonSerializer.Serialize(entity, new JsonSerializerOptions { WriteIndented = false });
            return jsonString;
        }

        // /// VULNS | Write the content to file with append mode
        public static void WriteLoggerFile(string content)
        {
            try
            {
                var path = Directory.GetCurrentDirectory();
                using (var file = File.Open(LoggerFilePath, FileMode.Append, FileAccess.Write))
                using (var writer = new StreamWriter(file))
                {
                    writer.WriteLineAsync(content);
                    writer.FlushAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle exception if needed
            }
        }
    }
}
