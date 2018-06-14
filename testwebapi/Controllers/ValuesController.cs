using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testwebapi.DAL;
using testwebapi.Infrastructure;
using testwebapi.Models;
using testwebapi.Validation;

namespace testwebapi.Controllers
{
    [ApiValidationFilter]
    [Route("v1/guid")]
    public class ValuesController : Controller
    {
        private IUtils _utils;
        private IData _data;
        public ValuesController(IUtils utils, IData data)
        {
            _utils = utils;
            _data = data;
        }

        // GET
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            ResponseJSON res = await _data.ReadAsync(id);
            if (!string.IsNullOrWhiteSpace(res.status))
            {
                return RedirectToAction("Error", "HandleError");
            }
            return Ok(new ApiOkResponse(res));
        }

        [HttpPost("{id?}")] // id is an optional parameter
        public async Task<IActionResult> Post([FromBody]RequestJSON requestJSON)
        {

            string expire = string.Empty;
            string guid = string.Empty;

            if (RouteData.Values["id"] != null)
            {
                guid = RouteData.Values["id"].ToString();
            }
            else
            {
                guid = _utils.ComputeGuid();
            }
            if (!string.IsNullOrWhiteSpace(requestJSON.expire))
            {
                expire = requestJSON.expire;
            }
            else
            {
                expire = _utils.ComputeExpirationTime();
            }
            RequestJSON request = new RequestJSON
            {
                expire = expire,
                user = requestJSON.user,
                guid = guid
            };

            ResponseJSON res = await _data.CreateUpdateAsync(request);
            if (!string.IsNullOrWhiteSpace(res.status))
            {
                return RedirectToAction("Error", "HandleError");
            }
            return Ok(new ApiOkResponse(res));
        }

        
        /*[HttpPost("{id}")]
        public async Task<IActionResult> Post([FromBody]string expire)
        {
            RequestJSON request = new RequestJSON
            {
                expire = expire
            };

            ResponseJSON res = await _data.UpdateAsync(request);
            if (!string.IsNullOrWhiteSpace(res.status))
            {
                return RedirectToAction("Error", "HandleError");
            }
            return Ok(new ApiOkResponse(res));
        }*/

        // DELETE 
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _data.DeleteAsync(id);
            
        }
    }
}
