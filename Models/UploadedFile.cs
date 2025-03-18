using System;

namespace YourNamespace.Models
{
    public class UploadedFile
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }


    public class UploadedFileInfo
    {
        public byte[] FileContent { get; set; }
        public string FileName { get; set; }
        public string Equipo { get; set; }
        public string Archivo { get; set; }
    }

}
