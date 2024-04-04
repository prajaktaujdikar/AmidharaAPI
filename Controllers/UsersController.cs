using AmidharaAPI.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmidharaAPI.Controllers
{
    [RoutePrefix("api/user")]
    public class UsersController : ApiController
    {
        [Route("{contactNo}/UserLogin")]
        [HttpPost]
        public HttpResponseMessage GetUserLogin(string contactNo, [FromBody] string password)
        {
            try
            {
                List<dynamic> userViewModels = new UserManager().GetUserLogin(contactNo, password);
                return userViewModels.Count == 0
                    ? Request.CreateResponse(HttpStatusCode.NotFound, new
                    {
                        status = "false",
                        message = "Not Found"
                    })
                    : Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        status = "true",
                        message = "Successfull",
                        data = userViewModels
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
