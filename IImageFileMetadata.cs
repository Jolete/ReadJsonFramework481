namespace EstadosFabricacionIconHandler.Models
{
    public enum ImageFileStatus
    {
        NoProcesado,
        Procesando,
        Completado,
        Error
    }

    public interface IImageFileMetadata
    {
        //DateTime CompletedDate { get; set; }
        string FileName { get; set; }

        //[JsonConverter(typeof(StringEnumConverter))]
        //ImageFileStatus Status { get; set; }
    }
}