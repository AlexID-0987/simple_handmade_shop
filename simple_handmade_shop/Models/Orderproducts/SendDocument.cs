using ClosedXML.Excel;
using simple_handmade_shop.Data;
using simple_handmade_shop.Models.Interfaces;

namespace simple_handmade_shop.Models.Orderproducts
{
    public class SendDocument:IGenerateDocument
    {
        public byte[] SendDoc(Order order, ApplicationDbContext _context)
        {
            using var workbook = new XLWorkbook();
            var sheet = workbook.Worksheets.Add("Order Details");

            // ===== IMPORTANT =====


            // ===== COLORS =====
            var titleColor = XLColor.FromHtml("#EAF2F8");
            var headerColor = XLColor.FromHtml("#D4E6F1");
            var infoColor = XLColor.FromHtml("#E8F8F5");
            var totalColor = XLColor.FromHtml("#E9F7EF");
            var borderColor = XLColor.FromHtml("#AAB7B8");
            var textColor = XLColor.FromHtml("#2E4053");

            // ===== PAGE SETUP =====
            sheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            sheet.PageSetup.PaperSize = XLPaperSize.A4Paper;

            // КРИТИЧНО: тільки 1 сторінка
            sheet.PageSetup.PagesWide = 1;
            sheet.PageSetup.PagesTall = 1;

            // Не використовувати Scale разом з FitToPages
            sheet.PageSetup.AdjustTo(70);

            sheet.PageSetup.CenterHorizontally = true;
            sheet.PageSetup.CenterVertically = true;

            // Поля
            sheet.PageSetup.Margins.Top = 0.15;
            sheet.PageSetup.Margins.Bottom = 0.15;
            sheet.PageSetup.Margins.Left = 0.15;
            sheet.PageSetup.Margins.Right = 0.15;

            // ===== TITLE =====
            sheet.Range("A1:F2").Merge();
            sheet.Cell("A1").Value = "NEW ORDER DETAILS";

            var titleRange = sheet.Range("A1:F2");
            titleRange.Style.Fill.BackgroundColor = titleColor;
            titleRange.Style.Font.Bold = true;
            titleRange.Style.Font.FontSize = 22;
            titleRange.Style.Font.FontColor = textColor;
            titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            titleRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            titleRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;

            // ===== INFO =====
            sheet.Cell("A4").Value = "Order ID:";
            sheet.Cell("B4").Value = order.Id;
            sheet.Cell("C4").Value = "Phone:";
            sheet.Cell("D4").Value = order.PhoneNumber;
            sheet.Cell("E4").Value = "Date:";
            sheet.Cell("F4").Value = DateTime.Now.ToString("dd.MM.yyyy");

            var infoRange = sheet.Range("A4:F4");
            infoRange.Style.Fill.BackgroundColor = infoColor;
            infoRange.Style.Font.Bold = true;
            infoRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            infoRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            infoRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            // ===== HEADERS =====
            sheet.Cell("A6").Value = "#";
            sheet.Cell("B6").Value = "Product Name";
            sheet.Cell("C6").Value = "Qty";
            sheet.Cell("D6").Value = "Unit Price";
            sheet.Cell("E6").Value = "Total";
            sheet.Cell("F6").Value = "Status";

            var headerRange = sheet.Range("A6:F6");
            headerRange.Style.Fill.BackgroundColor = headerColor;
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            // ===== DATA =====
            int row = 7;
            int index = 1;
            decimal grandTotal = 0;

            foreach (var item in order.OrderItems)
            {
                item.Product = _context.Products.FirstOrDefault(p => p.Id == item.ProductId)!;

                decimal total = item.Quantity * item.UnitPrice;

                sheet.Cell(row, 1).Value = index;
                sheet.Cell(row, 2).Value = item.Product.Name;
                sheet.Cell(row, 3).Value = item.Quantity;
                sheet.Cell(row, 4).Value = item.UnitPrice;
                sheet.Cell(row, 5).Value = total;
                sheet.Cell(row, 6).Value = "Confirmed";

                sheet.Cell(row, 4).Style.NumberFormat.Format = "#,##0.00";
                sheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00";

                var dataRange = sheet.Range(row, 1, row, 6);
                dataRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                sheet.Cell(row, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                if (row % 2 == 0)
                {
                    dataRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#FAFCFC");
                }

                grandTotal += total;
                row++;
                index++;
            }

            // ===== TOTAL =====
            sheet.Range($"A{row + 1}:C{row + 1}").Merge();
            sheet.Cell($"A{row + 1}").Value = "GRAND TOTAL";

            sheet.Cell($"D{row + 1}").Value = "";
            sheet.Cell($"E{row + 1}").Value = grandTotal;
            sheet.Cell($"F{row + 1}").Value = "Ми з Вами зв'яжемось!";

            var totalRange = sheet.Range($"A{row + 1}:F{row + 1}");
            totalRange.Style.Fill.BackgroundColor = totalColor;
            totalRange.Style.Font.Bold = true;
            totalRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            totalRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;

            sheet.Cell($"E{row + 1}").Style.NumberFormat.Format = "#,##0.00";

            // ===== WIDTH =====
            sheet.Column("A").Width = 6;
            sheet.Column("B").Width = 34;
            sheet.Column("C").Width = 8;
            sheet.Column("D").Width = 14;
            sheet.Column("E").Width = 14;
            sheet.Column("F").Width = 24;

            // ===== HEIGHT =====
            for (int i = 1; i <= row + 1; i++)
            {
                sheet.Row(i).Height = 22;
            }

            // ===== PRINT AREA =====
            sheet.PageSetup.PrintAreas.Clear();
            sheet.PageSetup.PrintAreas.Add($"A1:F{row + 1}");

            // ===== CENTER CONTENT =====
            sheet.RangeUsed().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // ===== REMOVE EMPTY SPACE =====
            sheet.RowsUsed().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return stream.ToArray();
        }

    }
}
