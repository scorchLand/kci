using System;
using System.Collections.Generic;
using DevDev.Extensions.Editor;
using DevDev.Table.Editor.Meta;
using NPOI.SS.UserModel;

namespace DevDev.Table.Editor.TypeParser.Implements
{
	public class DateTimeParser : ITypeParser<long>
	{
		public Type SerializeType { get; } = typeof(long);
		public int CellRange => 1;
		public string[] TableTypes { get; } =
		{
			"DateTime"
		};
		
		private readonly List<long> _list = new List<long>();

		
		public string GetParserTypeName()
		{
			return GetType().FullName;
		}
		
		public long Parse(Column column, IRow row)
		{
			return ParseInternal(row.GetCell(column.CellNum));
		}
		
		public long[] ParseArray(Column column, IRow row)
		{
			_list.Clear();
			for (int i = column.CellNum; i < column.CellNum + column.CellRange; i++)
			{
				var cell = row.GetCell(i);
				if (cell.IsNullOrEmpty())
				{
					continue;
				}
                
				_list.Add(ParseInternal(cell));
			}
            
			return _list.ToArray();
		}

		private long ParseInternal(ICell cell)
		{
			if (cell.IsNullOrEmpty())
			{
				return default;
			}
			
			return DateTime.FromOADate(cell.GetDoubleValue()).Ticks;
		}
	}
}
