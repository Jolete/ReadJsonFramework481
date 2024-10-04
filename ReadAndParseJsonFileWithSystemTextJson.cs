using EstadosFabricacionIconHandler.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace EstadosFabricacionIconHandler.Files
{
    internal class ReadAndParseJsonFileWithSystemTextJson
    {
        private readonly string _jsonFilePath;  // Ruta del archivo JSON

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true // Ignora mayúsculas y minúsculas en los nombres de las propiedades
        };

        public ReadAndParseJsonFileWithSystemTextJson(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        /// <summary>
        /// this is the best method to read json files because is faster than others
        /// </summary>
        /// <returns></returns>
        public List<ImageFileMetadata> UseFileOpenReadTextWithSystemTextJson()
        {
            
            try
            {
                // Open and Read the json processed file 
                var json = File.ReadAllText(_jsonFilePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };
                var data = JsonSerializer.Deserialize<List<ImageFileMetadata>>(json, options);
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}