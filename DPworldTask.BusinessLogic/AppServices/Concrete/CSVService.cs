using DPworldTask.BusinessLogic.AppServices.Interface;
using DPworldTask.DataAccess.Repositories.Interface;
using DPworldTask.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPworldTask.Common.Helpers.Interface;
using DPworldTask.DataAccess.DTOs;
using AutoMapper;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace DPworldTask.BusinessLogic.AppServices.Concrete
{
    public class CSVService : ICSVService

    {
        #region CTOR
        public CSVService()
        {
        }
        #endregion
        #region Methods
        public DataTable ConvertToDataTable(string filePath)
        {
                 
            string csvData = System.IO.File.ReadAllText(filePath);
            bool firstRow = true;
            DataTable dt = new DataTable();

            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (firstRow)
                        {
                            foreach (string cell in row.Split(','))
                            {
                                dt.Columns.Add(cell.Trim());
                            }
                            firstRow = false;
                        }
                        else
                        {
                            dt.Rows.Add();
                            int i = 0;
                            foreach (string cell in row.Split(','))
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell.Trim();
                                i++;
                            }
                        }
                    }
                }
            }

            return dt;
        }

      

        #endregion
    }
}
