# ZplFlow

ZplFlow is a flow style engine for creating a ZPL file.

Example
```
            var t = new Document(new Size(4*203,6*203));
            t.SetDefaultFont('F', heightInDots: 40)
                .AddLine("John Doe", 100)
                .AddLine("123 Main St.",40);
                t.AddLine("Town, ST 12345", 40);
                t.AddLine(string.Empty, 40);
                t.AddLine("Order #12345", 40);
            t.Save(new FileInfo(Path.GetTempPath() + "test.zpl"));

```
