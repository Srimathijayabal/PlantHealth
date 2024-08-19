using ExcelDataReader;
using Newtonsoft.Json;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace PlantHealth.Page
{
    public class DataComparer
    {
        private readonly ISpecFlowOutputHelper _outputHelper;
        //Method to read data from an Excel file and return it as a dataset

        public DataComparer(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _outputHelper = specFlowOutputHelper;
        }
        public DataSet ReadExcelFile(string path)
        {
            try
            {
                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();

                        // Log success message with basic details
                        _outputHelper.WriteLine($"Excel file '{path}' read successfully.");
                        _outputHelper.WriteLine($"Number of sheets: {result.Tables.Count}");

                        // Optionally, log sheet names and column details
                        foreach (DataTable table in result.Tables)
                        {
                            _outputHelper.WriteLine($"Sheet name: {table.TableName}, Rows: {table.Rows.Count}, Columns: {table.Columns.Count}");

                            // Log column names
                            _outputHelper.WriteLine("Columns:");
                            foreach (DataColumn column in table.Columns)
                            {
                                _outputHelper.WriteLine(column.ColumnName);
                            }

                            // Log each row's values
                            _outputHelper.WriteLine("Rows:");
                            foreach (DataRow row in table.Rows)
                            {
                                foreach (DataColumn column in table.Columns)
                                {
                                    _outputHelper.WriteLine($"{column.ColumnName}: {row[column]}");
                                }
                                _outputHelper.WriteLine("===="); // Empty line between rows for clarity
                            }
                        }

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception details if reading fails
                _outputHelper.WriteLine($"Failed to read Excel file '{path}': {ex.Message}");
                return null; // Return null or throw exception based on your error handling strategy
            }
        }

        public async Task<DataModel> FetchJsonFromApi(string url, Dictionary<string, string> parameters)
        {
            using (HttpClient client = new HttpClient())
            {
                // Serialize the parameters to a JSON string
                var jsonContent = JsonConvert.SerializeObject(parameters);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Send a POST request to the API
                var response = await client.PostAsync(url, content);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read the response content as a string
                var responseString = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response
                var data = JsonConvert.DeserializeObject<DataModel>(responseString);

                _outputHelper.WriteLine(data.ToString());

                // Return the deserialized data
                return data;
            }
        }


        // Method to compare data from a DataTable with data from a JSON API
        public void compareData(DataTable dataTable, DataModel jsonData)
        {
            _outputHelper.WriteLine("Columns in DataTable");

            foreach (DataColumn column in dataTable.Columns)
            {
                _outputHelper.WriteLine(column.ColumnName);
            }

            foreach (DataRow row in dataTable.Rows) // Loop through each row in the DataTable
            {
                string excelLatinName = row["Column0"].ToString(); // Get the Latin name from the Excel row

                foreach (var plantDetail in jsonData.plant_detail) // Loop through each plant detail in the JSON data
                {
                    foreach (var result in plantDetail.results) // Loop through each result in the plant detail
                    {
                        foreach (var plantName in result.plantName) // Loop through each plant name in the result
                        {
                            if (plantName.NAME.ToString().Equals(excelLatinName, StringComparison.OrdinalIgnoreCase)) // Compare the plant name with the Latin name from Excel
                            {
                                Console.WriteLine("Matching record found:");
                                Console.WriteLine($"Plant ID: {plantDetail.id}");
                                Console.WriteLine($"EPPO Code: {result.eppoCode}, Host Ref: {result.hostRef}");
                                Console.WriteLine($"Plant Name Type: {plantName.type}, Name: {plantName.NAME}");

                                foreach (DataColumn column in dataTable.Columns) // Print each column name and value of the matching row
                                {
                                    Console.WriteLine($"{column.ColumnName}: {row[column]}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

     
