# TableFlex

<img src="docs/table-flex-logo.svg" alt="TableFlex Logo" width="256"/>

# Description

**TableFlex** is a lightweight C# library for rendering console tables. It provides a simple way to align data into
tables without manual formatting.

# Installation

**Install TableFlex via NuGet:**

```
dotnet add package TableFlex
```

**Or reference it directly in your .csproj:**

```
<PackageReference Include="TableFlex" Version="2.0.0" />
```

# Usage Example

**Usings:**

```csharp
using TableFlex.Core;
using TableFlex.Renderers;
```

## Example #1. Minimal usage:

**Code:**

```csharp
Table table = new Table();
table.SetHeader("ID", "NAME", "AGE");

table.AddRow(1, "Alice", 9);
table.AddRow(2, "Benjamin", 69);
table.AddRow(3, "Bob", 27);

TableRenderer tr = new TableRenderer(BorderPresets.Dotted);

Console.WriteLine(tr.Render(table));
```

**Output:**

```
┌─────┬───────────┬──────┐
│ID   │NAME       │AGE   │
├─────┼───────────┼──────┤
│1    │Alice      │9     │
├─────┼───────────┼──────┤
│2    │Benjamin   │69    │
├─────┼───────────┼──────┤
│3    │Bob        │27    │
└─────┴───────────┴──────┘
```

## Example #2. Advanced usage:

**Code:**

```csharp
Table table = new Table();
table.SetHeader("ID", "NAME", "AGE");

table.AddRow(1, "Alice", 9);
table.AddRow(2, "Benjamin", 69);
table.AddRow(3, "Bob", 27);

BorderMap map = new BorderMap()
{
    Horizontal = '-',
    Cross = '-'
};

RenderOptions options = new RenderOptions()
{
    Spacing = 5,
    ShowOuterBorder = false,
    ShowRowSeparators = false
};

TableRenderer tr = new TableRenderer(map, options);

Console.WriteLine(tr.Render(table));
```

**Output:**

```
ID      NAME          AGE
------------------------------
1       Alice         9
2       Benjamin      69
3       Bob           27
```

# Components:

## Table

Represents a table with optional header and rows.

### Constructors:

- `Table()` - Initializes a new empty table.

### Methods:

- `SetHeader(params string[] headers)` - Defines the header of the table.
- `AddRow(params object[] contents)` - Adds a new row to the table.

## TableRenderer

Renders a table as plain text.

### Constructors:

- `TableRenderer(BorderMap borderMap)` - Initializes a new renderer with default options.
- `TableRenderer(BorderMap borderMap, RenderOptions options)` - Initializes a new renderer with custom options.

### Methods:

- `Render(Table table)` - Produces a string representation of the given table.

## RenderOptions

Defines configurable options for rendering tables, including spacing, borders and separators.

### Properties:

- `Spacing` - Gets or sets the spacing between columns. Value can't be negative. (`3` by default)
- `ShowOuterBorder` - Indicates whether the outer border of the table should be rendered. (`true` by default)
- `ShowHeaderSeparator` - Indicates whether a separator line should be rendered after the header. (`true` by default)
- `ShowColumnSeparators` - Indicates whether vertical separators (vertical lines) between columns should be rendered.
  (`true` by default)
- `ShowRowSeparators` - Indicates whether row separators (horizontal lines) should be rendered. (`true` by default)

## BorderMap

Defines the characters used to render table borders.

### Constructors:

- `BorderMap()` - Empty style with spaces.
- `BorderMap(char symbol)` - Single-symbol style with all characters equal.
- `BorderMap(char horizontal, char vertical)` - Horizontal-vertical style with distinct line characters.

### Properties (`' '` by default):

- `Horizontal` - Horizontal line character used for table borders.
- `Vertical` - Vertical line character used for table borders.
- `TopLeft` - Top-left corner character.
- `TopRight` - Top-right corner character.
- `BottomLeft` - Bottom-left corner character.
- `BottomRight` - Bottom-right corner character.
- `Cross` - Intersection character used where horizontal and vertical lines cross.
- `TopSeparator` - Separator character used at intersections along the top border.
- `BottomSeparator` - Separator character used at intersections along the bottom border.
- `LeftSeparator` - Separator character used at intersections along the left border.
- `RightSeparator` - Separator character used at intersections along the right border.

## BorderPresets

Provides predefined border styles for tables.

### Properties:

- `Transparent` - Border style without visible lines (all spaces).

  ```

   ID    NAME        AGE

   1     Alice       9

   2     Benjamin    69

   3     Bob         27

  ```

- `ASCII` - Classic ASCII style using +, -, and |.
  ```
  +-----+-----------+------+
  |ID   |NAME       |AGE   |
  +-----+-----------+------+
  |1    |Alice      |9     |
  +-----+-----------+------+
  |2    |Benjamin   |69    |
  +-----+-----------+------+
  |3    |Bob        |27    |
  +-----+-----------+------+
  ```
- `Unicode` - Unicode single-line style with ┌, ─, ┐ and │.

  ```
  ┌─────┬───────────┬──────┐
  │ID   │NAME       │AGE   │
  ├─────┼───────────┼──────┤
  │1    │Alice      │9     │
  ├─────┼───────────┼──────┤
  │2    │Benjamin   │69    │
  ├─────┼───────────┼──────┤
  │3    │Bob        │27    │
  └─────┴───────────┴──────┘
  ```

- `DoubleLine` - Double-line style with ╔, ═, ╗ and ║.

  ```
  ╔═════╦═══════════╦══════╗
  ║ID   ║NAME       ║AGE   ║
  ╠═════╬═══════════╬══════╣
  ║1    ║Alice      ║9     ║
  ╠═════╬═══════════╬══════╣
  ║2    ║Benjamin   ║69    ║
  ╠═════╬═══════════╬══════╣
  ║3    ║Bob        ║27    ║
  ╚═════╩═══════════╩══════╝
  ```

- `Dotted` - Dotted style with . and :.
  ```
  ..........................
  :ID   :NAME       :AGE   :
  :.....:...........:......:
  :1    :Alice      :9     :
  :.....:...........:......:
  :2    :Benjamin   :69    :
  :.....:...........:......:
  :3    :Bob        :27    :
  :.....:...........:......:
  ```

# Supports

- .NET 10.0
- .NET 8.0

# License

TableFlex is licensed under the MIT License.
