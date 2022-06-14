using Microsoft.AspNetCore.Http;
using DPworldTask.DataAccess.DTOs;
using DPworldTask.DataAccess.Models;
using System.Data;

namespace DPworldTask.BusinessLogic.AppServices.Interface
{
    public interface ICSVService
    {
        public DataTable ConvertToDataTable(string path);
    }
}