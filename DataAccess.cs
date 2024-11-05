using System.Data;
using System.Data.OleDb;
using Microsoft.AspNetCore.Mvc;

namespace GG;

public class DataAccess
{
    private readonly string _connectionString;

    public DataAccess(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataTable GetData(string query)
    {
        using (var connection = new OleDbConnection(_connectionString))
        {
            var command = new OleDbCommand(query, connection);
            var adapter = new OleDbDataAdapter(command);
            var dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}