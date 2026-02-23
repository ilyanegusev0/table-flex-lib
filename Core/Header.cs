namespace TableFlex.Core
{
    internal class Header
    {
        // FIELDS:

        private readonly List<Cell> _cells;

        // PROPERTIES:

        public IReadOnlyList<Cell> Cells => _cells;

        // CONSTRUCTORS:

        public Header(params string[] headers)
        {
            _cells = new List<Cell>();

            foreach (var header in headers)
                _cells.Add(new Cell(header));
        }
    }
}
