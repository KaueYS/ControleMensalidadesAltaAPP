# Refactor Pack — ControleMensalidadesAltaAPP

Este pacote contém **arquivos prontos** para aplicar no seu projeto sem tocar no original.
Inclui Services (Associado, Pagamento, Documento), ViewModels, AutoMapper Profile e Views responsivas.

## Como aplicar
1. Copie as pastas para dentro da raiz do seu projeto, preservando a estrutura.
2. Em `Program.cs`, adicione:
   ```csharp
   using AutoMapper;
   using Chatgptsociospagamentos.Mapping;
   using Chatgptsociospagamentos.Services;

   builder.Services.AddScoped<IAssociadoService, AssociadoService>();
   builder.Services.AddScoped<IPagamentoService, PagamentoService>();
   builder.Services.AddScoped<IDocumentoService, DocumentoService>();
   builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
   ```
3. Ajuste seus Controllers para usarem os services em vez de `_context`.
4. Substitua as 3 Views `Index.cshtml` (Home, Associado, Pagamento) pelas deste pacote.

Se quiser, posso gerar um patch `.diff` baseado no seu repo para aplicar via `git apply`.
