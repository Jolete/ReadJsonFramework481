namespace EstadosFabricacionIconHandler.Models
{
    public class ImageFileMetadata : IImageFileMetadata
    {
        //public ImageFileMetadata(string fileName, DateTime completedDate, ImageFileStatus status)
        public ImageFileMetadata(string fileName)
        {
            FileName = fileName;
            //CompletedDate = completedDate;
            //Status = status;
        }

        public string FileName { get; set; }
        //public DateTime CompletedDate { get; set; }
        //public ImageFileStatus Status { get; set; }
    }
}