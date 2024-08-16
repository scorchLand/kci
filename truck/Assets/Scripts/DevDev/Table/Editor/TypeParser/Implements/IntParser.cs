using System;
using System.Collections.Generic;
using DevDev.Extensions.Editor;
using DevDev.Table.Editor.Meta;
using NPOI.SS.UserModel;

namespace DevDev.Table.Editor.TypeParser.Implements
{
	public class IntParser : ITypeParser<int>
	{
		public Type SerializeType { get; } = typeof(int);
		public int CellRange => 1;
		public string[] TableTypes { get; } =
		{
			"Int"
		};
		
		private readonly List<int> _list = new List<int>();


		public int Parse(Column column, IRow row)
		{
			return row.GetCell(column.CellNum).GetIntValue();
		}

		public int[] ParseArray(Column column, IRow row)
		{
			_list.Clear();
			for (int i = column.CellNum; i < column.CellNum + column.CellRange; i++)
			{
				var cell = row.GetCell(i);
				if (cell.IsNullOrEmpty())
				{
					continue;
				}
				
				_list.Add(cell.GetIntValue());
			}

			return _list.ToArray();
		}

		public string GetParserTypeName()
		{
			return GetType().FullName;
		}
	}
}
