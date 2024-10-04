using EstadosFabricacionIconHandler.Files;
using EstadosFabricacionIconHandler.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EjemploConfiguracion
{
    class Program
    {
        private static string _ProcessedFileFullPath = string.Empty; // Ruta del archivo JSON de procesamiento de ficheros
        private static string _AppSettingsFile = string.Empty; // Ruta del archivo JSON de settings
        private static string _FileFullPath = string.Empty; // Ruta del archivo JSON de procesamiento de ficheros

        static void Main(string[] args)
        {
            _FileFullPath = args[0];

            // Construir un objeto ConfigurationBuilder
            //var builder = new ConfigurationBuilder();

            //// Especificar la ruta al archivo de configuración
            //builder.AddXmlFile("miConfiguracion.config");

            //// Crear el objeto Configuration
            //IConfigurationRoot config = builder.Build();

            //// Leer un valor
            //string valorConexion = config["conexionBD"];
            //Console.WriteLine(valorConexion);

            try
            {
                LoadConfiguration();

                if (CheckFileIslreadyProcessed())
                    MessageBox.Show("EXISTEIX!!!");
                else 
                    MessageBox.Show("NO EXISTEIX!!!");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
#endif
            }
        }
        private static List<ImageFileMetadata> ReadJsonProcessedFile()
        {
            // Initialise the json read provider
            var jsonProcessor = new ReadAndParseJsonFileWithSystemTextJson(_ProcessedFileFullPath);

            // Load the data from json processed files
            List<ImageFileMetadata> data = jsonProcessor.UseFileOpenReadTextWithSystemTextJson();

            return data;  // Return null or a list of processed files
        }

        private static bool CheckFileIslreadyProcessed()
        {
            // Read the json file with processed files
            List<ImageFileMetadata> processedFilesList = ReadJsonProcessedFile();

            if (processedFilesList is null)
            {
                throw new Exception("No encuentra valores en el ficherito!");
            }

            // If the file exist returns true and the icon will change, else return false and the icon will not changed
            if (CheckIfOneFileIsAlreadyProcessed(_FileFullPath, processedFilesList))
                return true;
            else
                return false;
        }

        private static bool CheckIfOneFileIsAlreadyProcessed(string fileName, List<ImageFileMetadata> processedFilesList) =>
          processedFilesList.FirstOrDefault(x => x.FileName == fileName) != null;

        private static void LoadConfiguration()
        {
            _ProcessedFileFullPath = "C:\\Users\\PC\\source\\repos\\EstadoFabricaciónExtension\\EstadoFabricacionExplorer\\bin\\Debug\\net8.0-windows\\FicherosProcesados.json";
        }
    }
}