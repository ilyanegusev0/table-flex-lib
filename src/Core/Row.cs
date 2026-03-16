namespace TableFlex.Core
{
    internal class Row
    {
        // FIELDS:

        private readonly List<Cell> _cells;

        // PROPERTIES:

        public IReadOnlyList<Cell> Cells => _cells;

        // CONSTRUCTORS:

        public Row()
        {
            _cells = new List<Cell>();
        }

        // PUBLIC METHODS:

        public void AddCell(string content)
        {
            _cells.Add(new Cell(content));
        }
    }
}
