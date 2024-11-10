using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace GG
{
    public class DataDisplayModel : PageModel
    {
        private readonly DataAccess _dataAccess;
        public List<DataRow> Data { get; set; }

        public DataDisplayModel(DataAccess dataAccess)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException();
            Data = new List<DataRow>();
        }

        public async Task OnGet()
        {
            string query = "SELECT EmpNo, LastName, PhoneExt, HireDate, Salary FROM Orders";
            DataTable dataTable = await _dataAccess.GetData(query);

            foreach (DataRow row in dataTable.Rows) Data.Add(row);
            
        }
    }
}