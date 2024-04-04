using AmidharaAPI.BusinessLogic;
using AmidharaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmidharaAPI.Controllers
{
    [RoutePrefix("api/village")]
    public class VillageController : ApiController
    {
        [Route("VillageList")]
        [HttpPost]
        public HttpResponseMessage GetVillageList([FromBody] string village)
        {
            try
            {
                List<dynamic> villageViewModels = new VillageManager().GetVillageList(village);
                return villageViewModels.Count == 0
                    ? Request.CreateResponse(HttpStatusCode.NotFound, new
                    {
                        status = "false",
                        message = "Not Found"
                    })
                    : Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        status = "true",
                        message = "Successfull",
                        data = villageViewModels
                    });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    status = "false",
                    message = ex.Message
                });
            }
        }

        [Route("{villageID:long}/StreetList")]
        [HttpPost]
        public HttpResponseMessage GetStreetList(long villageID, [FromBody] string street)
        {
            try
            {
                List<dynamic> villageViewModels = new VillageManager().GetStreetList(villageID, street);
                return villageViewModels.Count == 0
                    ? Request.CreateResponse(HttpStatusCode.NotFound, new
                    {
                        status = "false",
                        message = "Not Found"
                    })
                    : Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        status = "true",
                        message = "Successfull",
                        data = villageViewModels
                    });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    status = "false",
                    message = ex.Message
                });
            }
        }

        [Route("{streetID:long}/FamilyPersonList")]
        [HttpPost]
        public HttpResponseMessage GetFamilyPersonList(long streetID, [FromBody] string personName)
        {
            try
            {
                List<PersonIfoViewModel> personInfoList = new VillageManager().GetFamilyPersonList(streetID, personName);
                return personInfoList.Count == 0
                    ? Request.CreateResponse(HttpStatusCode.NotFound, new
                    {
                        status = "false",
                        message = "Not Found"
                    })
                    : Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        status = "true",
                        message = "Successfull",
                        data = personInfoList
                    });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    status = "false",
                    message = ex.Message
                });
            }
        }
    }
}
