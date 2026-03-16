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

        private BorderMap _borderMap;
        private RenderOptions _options;

        // CONSTURCTORS:

        /// <summary>
        /// Initializes a new renderer with custom options.
        /// </summary>
        public TableRenderer(BorderMap borderMap, RenderOptions options)
        {
            _borderMap = borderMap;
            _options = options;
        }

        /// <summary>
        /// Initializes a new renderer with default options.
        /// </summary>
        public TableRenderer(BorderMap borderMap) : this(borderMap, new RenderOptions()) { }

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
                    widths[i] = Math.Max(widths[i], table.Header.Cells[i].Content.Length + _options.Spacing);
            }

            // Rows
            foreach (var row in table.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                    widths[i] = Math.Max(widths[i], row.Cells[i].Content.Length + _options.Spacing);
            }

            var sb = new StringBuilder();

            // Render outer top border
            if (_options.ShowOuterBorder)
                sb.AppendLine(RenderHorizontalBorder(widths, _borderMap.TopLeft, _borderMap.TopRight, _borderMap.TopSeparator));

            // Render headers
            if (table.Header != null)
            {
                sb.AppendLine(RenderCells(table.Header.Cells, widths));
                if (_options.ShowHeaderSeparator)
                    sb.AppendLine(RenderHorizontalBorder(widths, _borderMap.LeftSeparator, _borderMap.RightSeparator, _borderMap.Cross));
            }

            // Render rows
            var rows = table.Rows;
            for (int r = 0; r < rows.Count; r++)
            {
                sb.AppendLine(RenderCells(rows[r].Cells, widths));

                if (_options.ShowRowSeparators && r < rows.Count - 1)
                    sb.AppendLine(RenderHorizontalBorder(widths, _borderMap.LeftSeparator, _borderMap.RightSeparator, _borderMap.Cross));
            }

            // Render outer bottom border
            if (_options.ShowOuterBorder)
                sb.AppendLine(RenderHorizontalBorder(widths, _borderMap.BottomLeft, _borderMap.BottomRight, _borderMap.BottomSeparator));

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

            string separator = _options.ShowColumnSeparators ? _borderMap.Vertical.ToString() : string.Empty;
            string rowContent = string.Join(separator, parts);

            if (_options.ShowOuterBorder)
                return _borderMap.Vertical + rowContent + _borderMap.Vertical;
            else
                return rowContent;

        }

        private string RenderHorizontalBorder(int[] widths, char left, char right, char separator)
        {
            var sb = new StringBuilder();

            if (_options.ShowOuterBorder)
                sb.Append(left);

            for (int i = 0; i < widths.Length; i++)
            {
                sb.Append(new string(_borderMap.Horizontal, widths[i]));

                if (i < widths.Length - 1)
                {
                    if (_options.ShowColumnSeparators)
                        sb.Append(separator);
                }
            }

            if (_options.ShowOuterBorder)
                sb.Append(right);

            return sb.ToString();
        }
    }
}