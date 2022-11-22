using Microsoft.AspNetCore.Mvc;
using XBCAD_WebApp.Models;

namespace XBCAD_WebApp.Controllers
{
    public class PDFController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PDFDisplay()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async IActionResult PDFUpload( PDF_Model pdf)
        {
            if (ModelState.IsValid)
            {
                if (pdf.pdf_upload != null)
                {
                    string folder = "PDF/pdf/";
                    //pdf.pdf_uploadUrl = await.
                }
                //pdf.pdf_upload(objcustInfo);
                return RedirectToActionPermanent("Index");
            }

            return View();
        }


    }
}
