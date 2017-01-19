﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HPlusSportsAPI.Models;
using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Repositories;

namespace HPlusSportsAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerRepository CustomerItems { get; set; }

        public CustomerController(ICustomerRepository customerItems)
        {
            CustomerItems = customerItems;
        }

        [HttpGet]
        public IEnumerable<Customer> GetAll() => CustomerItems.GetAll();

        [HttpGet("{id}", Name ="GetCustomer")]
        public IActionResult Get(int id)
        {
            var Item = CustomerItems.Find(id);
            if (Item == null)
            {
                return NotFound();
            }
            return new ObjectResult(Item);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer value)
        {
            if (value == null)
            {
                return BadRequest();

            }
            TryValidateModel(value);
            if(this.ModelState.IsValid)
            {
                CustomerItems.Add(value);
            }
            else
            {
                return BadRequest();
            }
            
            return CreatedAtRoute("GetCustomer", new { controller = "Customer", id = value.CustomerId }, value);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer value)
        {
            var Customer = CustomerItems.Find(id);
            CustomerItems.Update(value);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CustomerItems.Remove(id);
        }
    }
}
