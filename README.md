# Description

**TableFlex** is a lightweight C# library for rendering console tables. It provides a simple way to align data into tables without manual formatting.



# Installation

**Install TableFlex via NuGet:**\
`dotnet add package TableFlex`

**Or reference it directly in your .csproj:**\
`<PackageReference Include="TableFlex" Version="1.0.0" />`



# Usage Example

**Usings:**
```csharp
using TableFlex.Core;
using TableFlex.Renderers;
```

**Code:**
```csharp 
Table table = new Table();
table.SetHeader("ID", "NAME", "SCORE");
table.AddRow(1, "Alice", 95);
table.AddRow(2, "Bob", 87);

TableRenderer tr = new TableRenderer();

Console.WriteLine(tr.Render(table));
```

**Output:**
```
ID     NAME      SCORE
-----------------------
1      Alice     95
2      Bob       87
```


# Components:

## Table

Represents a table with optional header and rows.

### Methods:
- `SetHeader(params string[] headers)` - Defines the header of the table.
- `AddRow(params object[] contents)` - Adds a new row to the table.

## TableRenderer

Renders a table as plain text.

### Properties:
- `Spacing` - Gets or sets the spacing between columns.
- `Symbol` - Gets or sets the symbol used for header separator lines.

### Methods:
- `Render(Table table)` - Produces a string representation of the given table.



# Supports
- .NET 10.0
- .NET 8.0



# License

TableFlex is licensed under the MIT License.
