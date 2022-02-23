using System.Data.SqlClient;

using var con = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True");
await con.OpenAsync();
// Select
using var select = new SqlCommand("SELECT Id,Name from Demo", con);
var reader = await select.ExecuteReaderAsync();
if (reader.HasRows) {
    while (await reader.ReadAsync()) {
        Console.WriteLine("Id -> " + (int)reader[0]);
        Console.WriteLine("Name -> " + reader[1].ToString());
    }
}
else {
    await reader.CloseAsync();
    Console.WriteLine("BBDD vacia. Insertamos");
    using var cmd = new SqlCommand("INSERT INTO Demo VALUES (1, 'Test')", con);
    await cmd.ExecuteNonQueryAsync();
}
