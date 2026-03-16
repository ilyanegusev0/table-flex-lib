namespace TableFlex.Renderers
{
    /// <summary>
    /// Defines the characters used to render table borders.
    /// </summary>
    public class BorderMap
    {
        // PROPERTIES:

        /// <summary>
        /// Horizontal line character used for table borders.
        /// </summary>
        public char Horizontal = ' ';

        /// <summary>
        /// Vertical line character used for table borders.
        /// </summary>
        public char Vertical = ' ';

        /// <summary>
        /// Top-left corner character.
        /// </summary>
        public char TopLeft = ' ';

        /// <summary>
        /// Top-right corner character.
        /// </summary>
        public char TopRight = ' ';

        /// <summary>
        /// Bottom-left corner character.
        /// </summary>
        public char BottomLeft = ' ';

        /// <summary>
        /// Bottom-right corner character.
        /// </summary>
        public char BottomRight = ' ';

        /// <summary>
        /// Intersection character used where horizontal and vertical lines cross.
        /// </summary>
        public char Cross = ' ';

        /// <summary>
        /// Separator character used at intersections along the top border.
        /// </summary>
        public char TopSeparator = ' ';

        /// <summary>
        /// Separator character used at intersections along the bottom border.
        /// </summary>
        public char BottomSeparator = ' ';

        /// <summary>
        /// Separator character used at intersections along the left border.
        /// </summary>
        public char LeftSeparator = ' ';

        /// <summary>
        /// Separator character used at intersections along the right border.
        /// </summary>
        public char RightSeparator = ' ';

        // CONSTRUCTORS:

        /// <summary>
        /// Empty style with spaces.
        /// </summary>
        public BorderMap() { }

        /// <summary>
        /// Single-symbol style with all characters equal.
        /// </summary>
        public BorderMap(char symbol)
        {
            Horizontal = Vertical = TopLeft = TopRight = BottomLeft = BottomRight = Cross = TopSeparator = BottomSeparator = LeftSeparator = RightSeparator = symbol;
        }

        /// <summary>
        /// Horizontal-vertical style with distinct line characters.
        /// </summary>
        public BorderMap(char horizontal, char vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            TopLeft = TopRight = BottomLeft = BottomRight = vertical;
            Cross = vertical;
            TopSeparator = BottomSeparator = horizontal;
            LeftSeparator = RightSeparator = vertical;
        }
    }
}