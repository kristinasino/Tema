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
       public async System.Threading.Tasks.Task PostAsync()
        { 
         
           
            HttpClient httpClient = new HttpClient();
            string content = "{\"PerdoruesID\": \"06408b1d - 827e-474a - a104 - 27c7197cc008\"\"Emer\":\"Another\",\"Mbiemer\":\"Test\",\"RoleID\":2,\"Mosha\":30,\"Gjinia\":\"Mashkull\",\"Email\":\"kkkk@gmail.cm\",\"Telefon\":62635966}";
            HttpMethod httpMethod = HttpMethod.Post;

            var stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            var request =  await httpClient.PostAsync("http://localhost:62835/api/values", stringContent);
            var result = request.Content;

            Assert.IsTrue(result.ToString().Contains("06408b1d - 827e-474a - a104 - 27c7197cc008"));
           


        }
    }
}
