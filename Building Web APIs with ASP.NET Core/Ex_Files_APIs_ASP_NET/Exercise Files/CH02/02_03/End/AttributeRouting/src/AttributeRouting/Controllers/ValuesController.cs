using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AttributeRouting.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private List<Value> _values;

        public ValuesController()
        {
            _values = new List<Value>();

            _values.Add(new Value(1, "Apple"));
            _values.Add(new Value(2, "Orange"));
            _values.Add(new Value(3, "Banana"));
            _values.Add(new Value(4, "Peach"));
        }

        [HttpGet]
        public IEnumerable<Value> Get()
        {
            return _values;
        }

        [HttpGet("{id}")]
        public Value Get(int id)
        {
            return _values.Find(item => item.id == id);
        }
    }

    public class Value
    {
        public Value(int id, string name)
        {
            this.id = id;
            this.Name = name;
        }

        public int id { get; set; }
        public string Name { get; set; }
    }
}
