using System;
using System.Data;
using System.Data.OleDb;

namespace DimaScript
{
  class Program
  { 
     static private string dimapath = "/app/external/external/NDOW VHA Public Lands DIMA 5.6 as of 2022.09.06_EditedCoords.mdb";
     static void Main(){
      // Program obj = new Program();
      var resultSet = GetDBTables(dimapath);
      Console.WriteLine(resultSet);
    }
    
    
    static public System.Collections.Generic.List<string> GetDBTables(string path)
      {
        System.Collections.Generic.List<string> allTables = new System.Collections.Generic.List<string>();
        String connect = ("Microsoft.JET.OLEDB.4.0;data source=" 
                          + path + ";Persist Security Info=False;");
        System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(connect);
        con.Open();

        System.Data.DataTable tables = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                                    new object[] {null, null, null, "TABLE"});
        int counter = 1;
        foreach (System.Data.DataRow row in tables.Rows)
        {
          allTables.Add(row[2].ToString());
          counter++;
        }
        con.Close();
        return allTables;
      }
  }
}

