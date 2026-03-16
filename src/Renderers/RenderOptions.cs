namespace TableFlex.Renderers
{
    /// <summary>
    /// Defines configurable options for rendering tables,
    /// including spacing, borders and separators.
    /// </summary>
    public class RenderOptions
    {
        // FIELDS:

        private int _spacing = 3;

        // PROPERTIES:

        /// <summary>
        /// Gets or sets the spacing between columns.
        /// Value can't be negative.
        /// </summary>
        public int Spacing
        {
            get { return _spacing; }
            set { _spacing = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Indicates whether the outer border of the table should be rendered.
        /// </summary>
        public bool ShowOuterBorder = true;

        /// <summary>
        /// Indicates whether a separator line should be rendered after the header.
        /// </summary>
        public bool ShowHeaderSeparator = true;

        /// <summary>
        /// Indicates whether vertical separators (vertical lines) between columns should be rendered.
        /// </summary>
        public bool ShowColumnSeparators = true;

        /// <summary>
        /// Indicates whether row separators (horizontal lines) should be rendered.
        /// </summary>
        public bool ShowRowSeparators = true;
    }
}