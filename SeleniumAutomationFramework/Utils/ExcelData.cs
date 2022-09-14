using Dapper;
using System.Data.OleDb;


namespace SeleniumAutomationFramework.Utils
{
    internal class ExcelData    
    {
        public static string TestDataFileConnection()
        {
            var fileName = Settings.Default.TestDataSheetPath;
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public static Dictionary<string, string> GetTestData(string keyName)
        {
            using (OleDbConnection connection = new(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select Data from [DataSet$] where key='{0}'", keyName);
                var value = connection.Query<string>(query).FirstOrDefault();

                connection.Close();

                var data = new Dictionary<string, string>();

                string[] arr = value.Split("||");
                foreach (string str in arr)
                {
                    var rowItems = str.Split(":");
                    data.Add(rowItems[0], rowItems[1]);
                }
                return data;
            }
        }

    }
}
