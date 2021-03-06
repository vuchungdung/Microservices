﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Microservice.Services.Interfaces;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                var response = _productService.Items();
                return Ok(response);
            }   
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("item-{id}")]
        public IActionResult Item(int id)
        {
            try
            {
                var response = _productService.Item(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("insert")]
        public IActionResult Insert(ProductViewModel model)
        {
            try
            {
                var response = _productService.Insert(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(ProductViewModel model)
        {
            try
            {
                var response = _productService.Update(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("delete-{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _productService.Delete(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
