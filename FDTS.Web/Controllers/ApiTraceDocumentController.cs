using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Http;
using FDTS.Models.Repository;
using Microsoft.AspNet.Identity;

namespace FDTS.Web.Controllers
{

    public class ApiTraceDocumentController : ApiController
    {
        private string UserId => User.Identity.GetUserId();
        private int? DepartmentId => User.Identity.GetDepartmentId();

        private UnitOfWork unitOfWork = new UnitOfWork();
        [Route("api/trace-document/{id}")]
        public IHttpActionResult Get(int? Id)
        {
            var res = unitOfWork.TraceTransactionsRepo.Fetch().OrderBy(m => m.Id).FirstOrDefault(m => m.TraceDocumentId == Id && m.ReceivingDepartmentId == DepartmentId);


            return Ok(res);
        }
        [Route("api/trace-document/receive/{id}")]
 public IHttpActionResult Receive(int? Id)
        {
            var res = unitOfWork.TraceTransactionsRepo.Fetch().OrderBy(m => m.Id).FirstOrDefault(m => m.TraceDocumentId == Id && m.ReceivingDepartmentId == DepartmentId);
            try
            {
              
                if (res != null)
                {
                    res.ReceivingPersonnelId = UserId;
                    res.isReceived = true;
                    unitOfWork.Save();
                }
            }
            catch (Exception e)
            {
                return Ok(new
                {
                    isReceiveSuccess = false
                });
            }


            return Ok(new
            {
                isReceiveSuccess = true
            });
        }


    }
}
