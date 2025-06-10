//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowWave : IRow<global::System.String>
    {
		public global::System.String Key => _Key;

		public global::System.String Name => _Name;

		public global::System.String Path => _Path;

		public global::System.Single Duration => _Duration;

		public global::System.String StatusKey => _StatusKey;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.String _Name;
		[SerializeAbleField(2)] private global::System.String _Path;
		[SerializeAbleField(3)] private global::System.Single _Duration;
		[SerializeAbleField(4)] private global::System.String _StatusKey;


        public int Index { get; set; }
        
        public RowWave() {}

        public RowWave(global::System.String __Key, global::System.String __Name, global::System.String __Path, global::System.Single __Duration, global::System.String __StatusKey)
        {
			_Key = __Key;
			_Name = __Name;
			_Path = __Path;
			_Duration = __Duration;
			_StatusKey = __StatusKey;

        }
    }

    [SerializeAbleClass]
    public partial class TableWave : Table<RowWave, global::System.String>
    {

    }
}