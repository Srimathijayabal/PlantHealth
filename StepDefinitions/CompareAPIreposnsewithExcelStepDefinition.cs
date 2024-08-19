using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PlantHealth.Config;
using PlantHealth.Page;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace PlantHealth.StepDefinitions
{
    [Binding]
    public class CompareAPIreposnsewithExcelStepDifinition
    {
        private readonly ISpecFlowOutputHelper _outputHelper;
        private readonly DataComparer _dataComparer;
        private Dictionary<string, string> _parameters;
        private DataSet _excelData;
        private DataModel _apiResponse;

       


        
        public CompareAPIreposnsewithExcelStepDifinition(ISpecFlowOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _dataComparer = new DataComparer(_outputHelper);
        
        }

        [Given(@"I have the following search parameter")]
        public void GivenIHaveTheFollowingSearchParameter(Table table)
        {
            _parameters = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                _parameters.Add("search", row["search"]);
            }
            _outputHelper.WriteLine("Search parameter added.");
        }

        [Given(@"I have the Excel file ""(.*)"" with the data")]
        public void GivenIHaveTheExcelFileWithTheData(string fileName)
        {
            _excelData = _dataComparer.ReadExcelFile(fileName);
            _outputHelper.WriteLine("Excel data read successfully.");
        }

        [When(@"I send a POST request to ""(.*)"" with these parameters")]
        public async Task WhenISendAPostRequestToWithTheseParameters(string url)
        {
            _apiResponse = await _dataComparer.FetchJsonFromApi(url, _parameters);
            _outputHelper.WriteLine("API response received successfully.");
        }

        [Then(@"the API response should match the data in the Excel file")]
        public void ThenTheApiResponseShouldMatchTheDataInTheExcelFile()
        {
            _dataComparer.compareData(_excelData.Tables[0], _apiResponse);
        }

       
    }
}