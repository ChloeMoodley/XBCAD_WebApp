using Microsoft.AspNetCore.Mvc;
using XBCAD_WebApp.Models;


namespace XBCAD_WebApp.Controllers
{
    public class PDFController : Controller
    {
        public IFormFile file;
        Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment = null;    


        public PDFController (Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PDFUpload(string fileName = "")
        {

            PDF_Model fileObj = new PDF_Model();
            fileObj.pdf_name = fileName;

            string path = $"{_hostingEnvironment.WebRootPath}\\files\\";

            int nId = 1;

            foreach (string pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
            {
                fileObj.Files.Add(new PDF_Model()
                {
                    pdf_id = nId++,
                    pdf_name = Path.GetFileName(pdfPath),
                    pdf_path = pdfPath
                });
            }
            return View(fileObj);
        }

        [HttpPost]
        public IActionResult PDFUpload(IFormFile file, [FromServices] Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

            return PDFUpload();  

        }

        public IActionResult PDFDisplay(string fileName)
        {

            string path = _hostingEnvironment.WebRootPath + "\\files\\" + fileName;
            return File(System.IO.File.ReadAllBytes(path), "application/pdf");
          
        }

        /* [HttpPost]
         public async Task <IActionResult> PDFUpload(PDF_Model pdf_model)
         {
             if (pdf_model.pdf_upload != null)
             {
                 string folder = "PDF/pdf/";
             }

             return View();
         }*/

        /*        private async Task <string> UploadFile (string folderPath, IFormFile file)
                {
                    folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

                    return
                }*/

    }
}
