using DPworldTask.BusinessLogic.AppServices.Interface;
using DPworldTask.Common.Helpers.Interface;
using DPworldTask.DataAccess.Repositories.Interface;
using DPworldTask.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using DPworldTask.DataAccess.DTOs;
using AutoMapper;
using System.Data;

namespace DPworldTask.APIs.MainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSVToJsonController : ControllerBase
    {
        #region Props
        private readonly ICSVService _cSVServiceService;
        private readonly IJsonSerializer _JsonSerializer;
        private readonly IMapper _mapper;
        #endregion
        #region CTOR
        public CSVToJsonController(
            ICSVService CSVServiceService,
           IJsonSerializer jsonSerializer,
           IMapper mapper
          )
        {
            _JsonSerializer = jsonSerializer;
            _mapper = mapper;
            _cSVServiceService = CSVServiceService;
        }

        #endregion
        #region Actions

        [HttpGet("ConvertToJson")/*, Authorize(Roles = "Admin")*/]
        public Object ConvertToJson(string filePath)
        {
            DataTable dt = _cSVServiceService.ConvertToDataTable(filePath);

            var json = _JsonSerializer.SerializeObject(dt);
            return json;
        }


        #endregion
    }
}
