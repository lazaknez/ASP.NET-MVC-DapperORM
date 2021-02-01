using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ZaposleniController : Controller
    {
        public IActionResult Index()
        {
            return View(DapperORM.VratiListu<ZaposleniModel>("ZaposleniPregledSvih",null));
        }

        // ../Zaposleni/DodajIlIzmeni za insert
        [HttpGet]
        public ActionResult DodajIlIzmeni(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters parametar = new DynamicParameters();
                parametar.Add("@ZaposleniID",id);
                 return View(DapperORM.VratiListu<ZaposleniModel>("ZaposleniPregledPoID",parametar).FirstOrDefault<ZaposleniModel>());

            }
        }
        [HttpPost]
        public ActionResult DodajIlIzmeni(ZaposleniModel zap)
        {
            DynamicParameters parametar = new DynamicParameters();

            parametar.Add("@ZaposleniID",zap.ZaposleniID);
            parametar.Add("@Ime", zap.Ime);
            parametar.Add("@Prezime", zap.Prezime);
            parametar.Add("@Pozicija", zap.Pozicija);
            parametar.Add("@Godine", zap.Godine);
            parametar.Add("@Plata", zap.Plata);

            DapperORM.IzvrsiBezVracanja("ZaposleniDodatiIzmeniti",parametar);

            return RedirectToAction("Index");

        }

        public ActionResult Obrisi(int id) 
        {
            DynamicParameters parametar = new DynamicParameters();
            parametar.Add("@ZaposleniID", id);
            DapperORM.IzvrsiBezVracanja("ZaposleniBrisiPoID",parametar);
            return RedirectToAction("Index");
        }
            

    }
}
