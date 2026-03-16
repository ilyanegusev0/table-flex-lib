namespace TableFlex.Renderers
{
    /// <summary>
    /// Provides predefined border styles for tables.
    /// </summary>
    public static class BorderPresets
    {
        /// <summary>
        /// Border style without visible lines (all spaces).
        /// </summary>
        public static BorderMap Transparent => new BorderMap
        {
            Horizontal = ' ',
            Vertical = ' ',
            TopLeft = ' ',
            TopRight = ' ',
            BottomLeft = ' ',
            BottomRight = ' ',
            Cross = ' ',
            TopSeparator = ' ',
            BottomSeparator = ' ',
            LeftSeparator = ' ',
            RightSeparator = ' '
        };

        /// <summary>
        /// Classic ASCII style using +, -, and |.
        /// </summary>
        public static BorderMap ASCII => new BorderMap
        {
            Horizontal = '-',
            Vertical = '|',
            TopLeft = '+',
            TopRight = '+',
            BottomLeft = '+',
            BottomRight = '+',
            Cross = '+',
            TopSeparator = '+',
            BottomSeparator = '+',
            LeftSeparator = '+',
            RightSeparator = '+'
        };

        /// <summary>
        /// Unicode single-line style with ┌, ─, ┐ and │.
        /// </summary>
        public static BorderMap Unicode => new BorderMap
        {
            Horizontal = '─',
            Vertical = '│',
            TopLeft = '┌',
            TopRight = '┐',
            BottomLeft = '└',
            BottomRight = '┘',
            Cross = '┼',
            TopSeparator = '┬',
            BottomSeparator = '┴',
            LeftSeparator = '├',
            RightSeparator = '┤'
        };

        /// <summary>
        /// Double-line style with ╔, ═, ╗ and ║.
        /// </summary>
        public static BorderMap DoubleLine => new BorderMap
        {
            Horizontal = '═',
            Vertical = '║',
            TopLeft = '╔',
            TopRight = '╗',
            BottomLeft = '╚',
            BottomRight = '╝',
            Cross = '╬',
            TopSeparator = '╦',
            BottomSeparator = '╩',
            LeftSeparator = '╠',
            RightSeparator = '╣'
        };

        /// <summary>
        /// Dotted style with . and :.
        /// </summary>
        public static BorderMap Dotted => new BorderMap
        {
            Horizontal = '.',
            Vertical = ':',
            TopLeft = '.',
            TopRight = '.',
            BottomLeft = ':',
            BottomRight = ':',
            Cross = ':',
            TopSeparator = '.',
            BottomSeparator = ':',
            LeftSeparator = ':',
            RightSeparator = ':'
        };

    }
}