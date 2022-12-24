using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TMPro;
using UnityEngine;

public class SpreadSheet : MonoBehaviour
{

	public string spreadsheetKey = "1Wj75QfY2F8PkNCTMYvOsL-FxYia2mdGvQITVti1xHMk";

	public event Action OnDataInitialized;

	private DataTable _dataTable = new DataTable();


    private IEnumerator Start()
	{
		WWW webRequest = new WWW("https://docs.google.com/spreadsheet/ccc?key=" + spreadsheetKey + "&usp=sharing&output=csv");
		yield return webRequest;
		var csvData = webRequest.text;

		string[] columns = csvData.Split("," [0]); ;
		string[] rows = csvData.Split("\n"[0]);
       
        FillDataTable(columns, rows);
	}

	public DataTable GetDataTable()
    {
		return _dataTable;
    }

	private void FillDataTable(string[] columns, string[] rows)
    {
		_dataTable.Columns.Add("Id");
		foreach (string columnName in rows[0].Split(','))
		{
			var clearName = new string(columnName.ToCharArray().Where(x => !Char.IsWhiteSpace(x)).ToArray());
			_dataTable.Columns.Add(clearName);
		}

		for (int i = 0; i < rows.Length; i++)
		{
			if (!string.IsNullOrEmpty(rows[i]))
			{
				_dataTable.Rows.Add();
				_dataTable.Rows[_dataTable.Rows.Count - 1][0] = i;
				int count = 1;
				foreach (string FileRec in rows[i].Split(','))
				{
					_dataTable.Rows[_dataTable.Rows.Count - 1][count] = FileRec;
					count++;
				}
			}
		}

		ClearDataTable();

		OnDataInitialized?.Invoke();
	}

	private void ClearDataTable()
    {
		for (int i = _dataTable.Rows.Count - 1; i >= 0; i--)
		{
			DataRow dataRow = _dataTable.Rows[i];
			foreach(DataColumn column in _dataTable.Columns)
            {
				if(dataRow[column.ColumnName].ToString() == column.ColumnName)
                {
					dataRow.Delete();
					break;
                }
            }
		}
		_dataTable.AcceptChanges();
	}
}
