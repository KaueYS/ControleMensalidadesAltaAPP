using System;
namespace Chatgptsociospagamentos.ViewModels
{
    public class DocumentoVm
    {
        public int Id { get; set; }
        public int SocioId { get; set; }
        public string NomeArquivo { get; set; }
        public string Path { get; set; }
        public DateTime UploadData { get; set; }
    }
}
