using System.Data;
using System.Data.OleDb;
using Microsoft.AspNetCore.Mvc;

namespace GG;

public class DataAccess
{
    private readonly string _connectionString;

    public DataAccess(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("Default");
        _connectionString = connectionString ?? throw new ArgumentNullException();

    }

    public async ValueTask<DataTable> GetData(string query)
    {
        using var connection = new OleDbConnection(_connectionString);
        var command = new OleDbCommand(query, connection);
        var adapter = new OleDbDataAdapter(command);
        var dataTable = new DataTable();
        await connection.OpenAsync();
        adapter.Fill(dataTable);
        return dataTable;
    }
}