using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Http;
using System.Web.Http;

namespace BloodDonation.Controllers
{
    public class GroupController : ApiController
    {
        [HttpGet]
        [Route("api/groups")]
        public HttpResponseMessage Get()
        {
            var data = GroupService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/groups/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = GroupService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/groups/add")]
        [HttpPost]
        public HttpResponseMessage Post(GroupDTO group)
        {
            var resp = GroupService.Add(group);

            if (resp == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new  { Msg="Inserted",data=resp});
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
