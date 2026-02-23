namespace TableFlex.Core
{
    internal class Cell
    {
        // FIELDS:

        private string _content;

        // PROPERTIES:

        public string Content => _content;

        // CONSTRUCTORS:

        public Cell(string content)
        {
            _content = content;
        }
    }
}
