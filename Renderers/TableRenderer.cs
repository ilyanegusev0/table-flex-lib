using System.Text;
using TableFlex.Core;

namespace TableFlex.Renderers
{
    /// <summary>
    /// Renders a table as plain text.
    /// </summary>
    public class TableRenderer
    {
        // FIELDS:

        private int _spacing;
        private char _symbol;

        // PROPERTIES:

        /// <summary>
        /// Gets or sets the spacing between columns.
        /// </summary>
        public int Spacing
        {
            get => _spacing;
            set => _spacing = value < 0 ? 0 : value;
        }

        /// <summary>
        /// Gets or sets the symbol used for header separator lines.
        /// </summary>
        public char Symbol
        {
            get => _symbol;
            set => _symbol = value;
        }

        // CONSTURCTORS:

        /// <summary>
        /// Initializes a new renderer with default settings.
        /// </summary>
        public TableRenderer()
        {
            Spacing = 5;
            _symbol = '-';
        }

        // PUBLIC METHODS:

        /// <summary>
        /// Produces a string representation of the given table.
        /// </summary>
        /// <param name="table">The table to render.</param>
        /// <returns>Formatted table as a string.</returns>
        public string Render(Table table)
        {
            if (!table.Rows.Any() && table.Header == null) return string.Empty;

            int columns = Math.Max(
                table.Header?.Cells.Count ?? 0,
                table.Rows.Max(r => r.Cells.Count));

            int[] widths = new int[columns];

            // Headers
            if (table.Header != null)
            {
                for (int i = 0; i < table.Header.Cells.Count; i++)
                {
                    widths[i] = table.Header.Cells[i].Content.Length;
                }
            }

            // Rows
            foreach (var row in table.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                    widths[i] = Math.Max(widths[i], row.Cells[i].Content.Length);
            }

            var sb = new StringBuilder();

            // Render headers
            if (table.Header != null)
            {
                sb.AppendLine(RenderCells(table.Header.Cells, widths));
                sb.AppendLine(new string(_symbol, widths.Sum() + _spacing * (columns - 1) + 1));
            }

            // Render rows
            foreach (var row in table.Rows)
                sb.AppendLine(RenderCells(row.Cells, widths));

            return sb.ToString();
        }

        // PRIVATE METHODS:

        private string RenderCells(IReadOnlyList<Cell> cells, int[] widths)
        {
            List<string> parts = new List<string>();

            for (int i = 0; i < widths.Length; i++)
            {
                string content = i < cells.Count ? cells[i].Content : "";
                parts.Add(content.PadRight(widths[i]));
            }

            return string.Join(new string(' ', _spacing), parts);
        }
    }
}
