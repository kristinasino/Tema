using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Test.Models;

namespace Test.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public string Get()

        {   try
            {
                ProjektiMikrotezesEntities db = new ProjektiMikrotezesEntities();
                var perdoruesit = db.Perdoruesits.Include("Rolet").ToList();

                string P = JsonConvert.SerializeObject(perdoruesit, Formatting.Indented, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                return P;
            }
            catch(Exception ex)
            {
                return "Deshtoi";
            }
            
        }

        // GET api/values/5
        [HttpGet]
        public string Get(string id)
        {
            string json;

            using (ProjektiMikrotezesEntities db = new ProjektiMikrotezesEntities())
            {
               
                
                var perdoruesi = db.Perdoruesits.Where(x => x.PerdoruesID == id).FirstOrDefault();
                var rezultati = new { perdoruesi.Emer, perdoruesi.Mbiemer, perdoruesi.Rolet.RoleID, perdoruesi.Mosha, perdoruesi.Gjinia, perdoruesi.Email, perdoruesi.Telefon };

                json = JsonConvert.SerializeObject(rezultati);
               
            }
            return json;

        }

        // POST api/values
        [HttpPost]
        public Guid Post()
        {
            using (ProjektiMikrotezesEntities db = new ProjektiMikrotezesEntities())
            {
                Perdoruesit perdoruesi = new Perdoruesit();

                try
                {
                   
                    HttpContent requestContent = Request.Content;
                    string jsonContent = requestContent.ReadAsStringAsync().Result;
                    perdoruesi = JsonConvert.DeserializeObject<Perdoruesit>(jsonContent);
                    if (perdoruesi.PerdoruesID == null)
                    {
                        perdoruesi.PerdoruesID = Guid.NewGuid().ToString();
                    }

                    db.Perdoruesits.Add(perdoruesi);
                    db.SaveChanges();
                }

                catch (Exception ex)
                {
                }
                
                return new Guid(perdoruesi.PerdoruesID);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public void Put()
        {
            using (ProjektiMikrotezesEntities db = new ProjektiMikrotezesEntities())
            {
                Perdoruesit perdoruesi = new Perdoruesit();

                try
                {
                    HttpContent requestContent = Request.Content;
                    string jsonContent = requestContent.ReadAsStringAsync().Result;
                    perdoruesi = JsonConvert.DeserializeObject<Perdoruesit>(jsonContent);
                    if(perdoruesi.PerdoruesID != string.Empty)
                    {
                        var P = db.Perdoruesits.Where(x => x.PerdoruesID == perdoruesi.PerdoruesID).FirstOrDefault();

                        P.Emer = perdoruesi.Emer;
                        P.Mbiemer = perdoruesi.Mbiemer;
                        P.Mosha = perdoruesi.Mosha;
                        P.Gjinia = perdoruesi.Gjinia;
                        P.Email = perdoruesi.Email;
                        P.RoleID = perdoruesi.RoleID;
                    
                     
                    }
                 db.SaveChanges();

                }  
                catch(Exception ex)
                {
                   
                }
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(string id)
        {
            using (ProjektiMikrotezesEntities db = new ProjektiMikrotezesEntities())
            {
                var P = db.Perdoruesits.Where(x => x.PerdoruesID == id).FirstOrDefault();
                db.Perdoruesits.Remove(P);
                db.SaveChanges();

            }
        }
    }
}
