﻿namespace MyWebApi.Tests.ControllerSetups
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Results;
    using Models;
    using Services;

    internal class WebApiController : ApiController
    {
        private readonly ICollection<ResponseModel> responseModel;

        public WebApiController()
            : this(new InjectedService())
        {
        }

        public WebApiController(IInjectedService injectedService)
        {
            this.InjectedService = injectedService;
            this.responseModel = new List<ResponseModel>
            {
                new ResponseModel { Id = 1, Name = "Test" },
                new ResponseModel { Id = 2, Name = "Another Test" }
            };
        }

        public ICollection<ResponseModel> ResponseModel
        {
            get { return this.responseModel; }
        }

        public IInjectedService InjectedService { get; private set; }

        public IHttpActionResult OkResultAction()
        {
            return this.Ok();
        }

        public IHttpActionResult OkResultActionWithRequestBody(int id, RequestModel model)
        {
            return this.Ok(this.responseModel);
        }

        public IHttpActionResult ModelStateCheck(RequestModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok(model);
            }

            return this.Ok(model);
        }

        public IHttpActionResult OkResultWithResponse()
        {
            return this.Ok(this.responseModel);
        }

        public async Task<OkResult> AsyncOkResultAction()
        {
            return await Task.Run(() => this.Ok());
        }

        public IHttpActionResult BadRequestAction()
        {
            return this.BadRequest();
        }

        public bool GenericStructAction()
        {
            return true;
        }

        public ICollection<ResponseModel> GenericAction()
        {
            return this.responseModel;
        }
    }
}
