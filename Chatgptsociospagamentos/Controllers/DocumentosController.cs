using Chatgptsociospagamentos.Data;
using Chatgptsociospagamentos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Web;


namespace Chatgptsociospagamentos.Controllers
{
    public class DocumentosController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public DocumentosController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        // GET: Documentos
        public IActionResult Index()
        {
            var docs = _db.Documentos
                .OrderByDescending(d => d.DataUpload)
                .ToList();
            return View(docs);
        }

        // GET: Upload
        public IActionResult Upload()
        {
            return View();
        }

        // POST: Upload
        [HttpPost]
        public IActionResult Upload(IFormFile arquivo)
        {
            if (arquivo != null && arquivo.Length > 0)
            {
                var extensao = Path.GetExtension(arquivo.FileName).ToLower();
                if (extensao == ".pdf" || extensao == ".doc" || extensao == ".docx")
                {
                    var nomeArquivo = Guid.NewGuid().ToString() + extensao;
                    var pastaUploads = Path.Combine(_env.WebRootPath, "Uploads");

                    if (!Directory.Exists(pastaUploads))
                        Directory.CreateDirectory(pastaUploads);

                    var caminho = Path.Combine(pastaUploads, nomeArquivo);

                    using (var stream = new FileStream(caminho, FileMode.Create))
                    {
                        arquivo.CopyTo(stream);
                    }

                    var doc = new DocumentoModel
                    {
                        NomeArquivo = arquivo.FileName,
                        CaminhoArquivo = "/Uploads/" + nomeArquivo,
                        DataUpload = DateTime.Now
                    };

                    _db.Documentos.Add(doc);
                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Apenas arquivos PDF ou Word são permitidos.");
            }
            else
            {
                ModelState.AddModelError("", "Nenhum arquivo selecionado.");
            }

            return View();
        }
    }
}
