using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DevStore.Data.Contexts;
using DevStore.Data.Repositories;
using DevStore.Domain.Entities;
using DevStore.Domain.Repositories;

namespace DevStore.Api.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductRepository _repository = new ProductRepository();

        // GET: api/Products
        public HttpResponseMessage GetProducts()
        {
            var response = new HttpResponseMessage();

            try
            {
                var result = _repository.Get().ToList();
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch 
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Ops, não foi possível listar os produtos!");
            }

            return response;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = _repository.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }


            try
            {
                _repository.Update(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Create(product);

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(string))]
        public IHttpActionResult DeleteProduct(int id)
        {
           
            _repository.Delete(id);
            return Ok("OK");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return _repository.Get().Count(e => e.Id == id) > 0;
        }
    }
}