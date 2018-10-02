using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Test.Controllers;
using Test.Models;

namespace NunitTemaTests
{
    [TestClass]
    public class TemaTest
    {
        [TestMethod]
        public void GetbyId()
        {
            ValuesController VC = new ValuesController();

            Perdoruesit P = JsonConvert.DeserializeObject<Perdoruesit>(VC.Get("P"));

            Assert.AreEqual("Test", P.Emer);
            Assert.IsTrue(P.Emer.Contains("Test"));
        }


        [TestMethod]
        public void Get()
        {
            ValuesController VC = new ValuesController();

            List<Perdoruesit> P = JsonConvert.DeserializeObject<List<Perdoruesit>>(VC.Get());
         
            Assert.IsNotNull(P);
            
        }

        [TestMethod]
       public void PostAsync()
        {


            using (HttpClient httpClient = new HttpClient())
            {
                Perdoruesit P = new Perdoruesit()
                {
                      PerdoruesID = "06408b1d-827e-474a-a104-27c7197cc008",
                      Emer = "Another", 
                      Mbiemer = "Test",
                      RoleID = 2,
                      Mosha = 30, 
                      Gjinia = "Mashkull",
                      Email = "kkkk@gmail.com", 
                      Telefon = 062635966
                };

                var stringContent = new StringContent(JsonConvert.SerializeObject(P), Encoding.UTF8, "application/json");
                var result = httpClient.PostAsync("http://localhost:62835/api/values", stringContent).Result.Content.ReadAsStringAsync();

                Assert.IsTrue(result.Result.Contains("06408b1d-827e-474a-a104-27c7197cc008"));
            }
           


        }

        [TestMethod]
        public void Put()
        {
            int count = 0;

            using (HttpClient client = new HttpClient())
            {
                Perdoruesit P = new Perdoruesit()
                {
                    PerdoruesID = "06408b1d-827e-474a-a104-27c7197cc008",
                    Emer = "Another Kristina",
                    Mbiemer = "Testimi123",
                    RoleID = 1,
                    Mosha = 120,
                    Gjinia = "Femer",
                    Email = "ggg@hotmail.com",
                    Telefon = 692461
                };

                var request = new StringContent(content: JsonConvert.SerializeObject(P), encoding: Encoding.UTF8, mediaType: "application/json");

                try
                {
                    var response = client.PutAsync("http://localhost:62835/api/values", request).Result.Content.ReadAsStringAsync();
                    count++;
                }

                catch(Exception ex)
                {

                }

                Assert.AreEqual(count, 1);
            }
        }

        [TestMethod]
        public void Delete()
        {
            int count = 0;

            ValuesController VC = new ValuesController();
            try
            {
                VC.Delete("bbb");
                count++;
            }
            catch
            {
            }

            Assert.AreEqual(count, 1);
            
        }
    }
}
