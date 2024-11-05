using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace GG
{
    public class DataDisplayModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public List<DataRow> Data { get; set; }

        public DataDisplayModel(IConfiguration configuration)
        {
            _configuration = configuration;
            Data = new List<DataRow>();
        }

        public void OnGet()
        {
            var connectionString = _configuration.GetConnectionString("Default");
            var dataAccess = new DataAccess(connectionString);
            string query = "SELECT EmpNo, LastName, PhoneExt, HireDate, Salary FROM Orders";
            DataTable dataTable = dataAccess.GetData(query);

            foreach (DataRow row in dataTable.Rows)
            {
                Data.Add(row);
            }
        }
    }
}