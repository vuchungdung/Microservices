using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Microservice.Services.Interfaces;

namespace Order.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        [Route("items")]
        public IActionResult Items()
        {
            try
            {
                var response = _orderService.Items();
                return Ok(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("item-{id}")]
        public IActionResult Item([FromQuery] int id)
        {
            try
            {
                var response = _orderService.Item(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromBody]OrderViewModel model)
        {
            try
            {
                var response = _orderService.Insert(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Items([FromBody] OrderViewModel model)
        {
            try
            {
                var response = _orderService.Update(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("delete-{id}")]
        public IActionResult Items([FromQuery] int id)
        {
            try
            {
                var response = _orderService.Delete(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
