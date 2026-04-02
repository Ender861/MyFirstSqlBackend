using System;
using Microsoft.Data.Sqlite;

Console.WriteLine("Введите минимальную цену: ");
string input = Console.ReadLine();
if (double.TryParse(input, out double minPrice))
{
    //  Путь к базе 
    string dbPath = "shop.db";
    using (var connection = new SqliteConnection($"Data Source={dbPath}"))
    {
        connection.Open();
        var command = connection.CreateCommand();
        
        // Используем параметры - это защита от взлома (SQL-injection)
        command.CommandText = "SELECT Name, Price FROM Products WHERE Price > $price ORDER BY Price DESC;";
        command.Parameters.AddWithValue("$price", minPrice);

        using (var reader = command.ExecuteReader())
        {
            Console.WriteLine("\n--- Результат поиска ---");
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetString(0)}: {reader.GetDouble(1)} руб.");
            }
        }
    }
}
else { Console.WriteLine("Error. Need enter number!"); }