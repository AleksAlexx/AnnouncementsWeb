using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnouncementsWeb.Model;
using System.Text.Json;

namespace AnnouncementsWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CAnnController : ControllerBase
    {
        //ссылка на экземпляр класс контекста
        CAnnContext CAnnDB;
        //ссылка на экземпляр класс 
        CAnnouncement cAnn;
        public CAnnController(CAnnContext cDB)
        {
            this.CAnnDB = cDB;
        }

        [HttpGet]
        public IEnumerable<String> Get()
        {
            var anns = CAnnDB.CAnnouncements.Select(a => $"{a.AnnId} {a.NameOfAnn} {a.DateTimeCreation} {a.Price} {a.Comment}").ToArray();
            
            return anns;
        }

        [HttpGet("{id}")]
        public IEnumerable<String> Get2(int id)
        {
            var anns = CAnnDB.CAnnouncements.Where(n => n.AnnId == id).Select(a => $"{a.AnnId} {a.NameOfAnn} {a.DateTimeCreation} {a.Price} {a.Comment}").ToArray();
            return anns;
        }

        [HttpPost]
        public void Post([FromBody] string[] str)
        {
            cAnn = new CAnnouncement();
            cAnn.Price = Convert.ToInt32(str[0]);
            cAnn.DateTimeCreation = DateTime.Now;
            cAnn.NameOfAnn = str[1];
            cAnn.Comment = str[2];
            CAnnDB.CAnnouncements.Add(cAnn);
            CAnnDB.SaveChanges();
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {
            cAnn = CAnnDB.CAnnouncements.Find(id);
            cAnn.NameOfAnn = name;
            CAnnDB.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put2(int id, [FromBody] string comment)
        {
            cAnn = CAnnDB.CAnnouncements.Find(id);
            cAnn.Comment = comment;
            CAnnDB.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(Int32 id)
        {
            cAnn = CAnnDB.CAnnouncements.Find(id);
            CAnnDB.CAnnouncements.Remove(cAnn);
            CAnnDB.SaveChanges();
        }

    }
}
