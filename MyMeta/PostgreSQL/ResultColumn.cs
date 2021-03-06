using System;
using System.Data;
using System.Data.OleDb;

namespace MyMeta.PostgreSQL
{

	using System.Runtime.InteropServices;
	[ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual), ComDefaultInterface(typeof(IResultColumn))]

	public class PostgreSQLResultColumn : ResultColumn
	{
		public PostgreSQLResultColumn()
		{

		}

		#region Properties

		override public string Name
		{
			get
			{
				return this._column.ColumnName;
			}
		}

		override public string DataTypeName
		{
			get
			{
				return _column.DataType.ToString();
			}
		}

		override public System.Int32 Ordinal
		{
			get
			{
				return this._column.Ordinal;
			}
		}

		#endregion

		internal DataColumn _column = null;
	}
}
