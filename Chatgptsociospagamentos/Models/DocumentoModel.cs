namespace Chatgptsociospagamentos.Models
{
    public class DocumentoModel
    {
        public int Id { get; set; }

        public string NomeArquivo { get; set; }

        public string CaminhoArquivo { get; set; }

        public DateTime DataUpload { get; set; }
    }
}
