namespace TableFlex.Core
{
    /// <summary>
    /// Represents a table with optional header and rows.
    /// </summary>
    public class Table
    {
        // FIELDS:

        private Header? _header;
        private readonly List<Row> _rows;

        // PROPERTIES:

        internal Header? Header => _header;
        internal IReadOnlyList<Row> Rows => _rows;

        // CONSTRUCTORS:

        /// <summary>
        /// Initializes a new empty table.
        /// </summary>
        public Table()
        {
            _rows = new List<Row>();
        }

        // PUBLIC METHODS:

        /// <summary>
        /// Defines the header of the table.
        /// </summary>
        /// <param name="headers">Column names for the header row.</param>
        public void SetHeader(params string[] headers)
        {
            _header = new Header(headers);
        }

        /// <summary>
        /// Adds a new row to the table.
        /// </summary>
        /// <param name="contents">Cell values for the row.</param>
        public void AddRow(params object[] contents)
        {
            Row row = new Row();
            foreach (var content in contents)
                row.AddCell(content?.ToString() ?? string.Empty);
            _rows.Add(row);
        }
    }
}
