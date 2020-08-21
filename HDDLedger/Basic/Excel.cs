using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using ZXing;

namespace HDDLedger
{
    public class Excel
    {
        public static string CreateLabel(HDDInfoRow row)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var imagepath = documents + @"\HDDLedger\Barcode\Barcode-" + row.BarcodeRenban + ".png";

            var excelpath = documents + @"\HDDLedger\Excel\Excel-" + row.BarcodeRenban + ".xlsx";

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var sheet = workbook.Worksheets.Add(row.BarcodeRenban);

                    var bc = new BarcodeWriter();
                    bc.Format = BarcodeFormat.CODE_128;
                    bc.Options.Width = 400;
                    bc.Options.Height = 80;
                    bc.Options.Margin = 30;
                    bc.Options.PureBarcode = false;

                    using (var map = bc.Write(row.BarcodeRenban))
                    {
                        map.Save(imagepath, ImageFormat.Png);
                    }

                    sheet.AddPicture(imagepath).MoveTo(sheet.Cell(5, 2));
                    sheet.Row(5).Height = 60;
                    sheet.Column(2).Width = 56;
                    sheet.Column(1).Width = 2.14;

                    sheet.Cell(2, 2).Value = "HDDName:" + row.HDDName;
                    sheet.Cell(2, 2).Style.Font.FontSize = sheet.Style.Font.FontSize * 2;
                    sheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    sheet.Cell(3, 2).Value = "Code:" + row.BarcodeRenban;
                    sheet.Cell(3, 2).Style.Font.FontSize = sheet.Style.Font.FontSize * 2;
                    sheet.Cell(3, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    sheet.Cell(7, 2).Value = "CreateTime:" + row.RegisterTimeStr;
                    sheet.Cell(7, 2).Style.Font.FontSize = sheet.Style.Font.FontSize * 2;
                    sheet.Cell(7, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    workbook.SaveAs(excelpath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return excelpath;
        }

        public static string CreateLedger(IEnumerable<HDDInfoRow> rows, IEnumerable<ColumnRow> crows, XLPageOrientation orientation)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var excelpath = documents + @"\HDDLedger\Excel\Excel-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".xlsx";

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var sheet = workbook.Worksheets.Add("HDD台帳");

                    for (int l = 0; l < crows.Count(); l++)
                    {
                        sheet.Cell(1, 1 + l).Value = crows.ElementAt(l).ColumnName;

                        for (int i = 0; i < rows.Count(); i++)
                        {
                            string value = null;

                            switch (crows.ElementAt(l).Kbn.Value)
                            {
                                case Enum.PrintColumnKbns.Renban:
                                    value = "'" + rows.ElementAt(i).BarcodeRenban;
                                    break;
                                case Enum.PrintColumnKbns.HDDName:
                                    value = rows.ElementAt(i).HDDName;
                                    break;
                                case Enum.PrintColumnKbns.State:
                                    value = rows.ElementAt(i).StateViewValue;
                                    break;
                                case Enum.PrintColumnKbns.InsertTime:
                                    value = rows.ElementAt(i).RegisterTimeStr;
                                    break;
                                case Enum.PrintColumnKbns.UpdateTime:
                                    value = rows.ElementAt(i).LatestUpdateTimeStr;
                                    break;
                                case Enum.PrintColumnKbns.NextProcess:
                                    value = "廃棄・再利用";
                                    sheet.Cell(2 + i, l + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    sheet.Cell(2 + i, l + 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                    break;
                                case Enum.PrintColumnKbns.Barcode:
                                    var imagepath = documents + @"\HDDLedger\Barcode\Barcode-" + rows.ElementAt(i).BarcodeRenban + ".png";
                                    var pic = sheet.AddPicture(imagepath).MoveTo(sheet.Cell(2 + i, l + 1));
                                    pic.Width = 200;
                                    pic.Height = 30;
                                    break;
                                default:
                                    value = String.Empty;
                                    break;
                            }

                            sheet.Cell(2 + i, l + 1).Value = value;
                            sheet.Cell(2 + i, l + 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            sheet.Row(2 + i).Height = 30;
                        }
                    }

                    sheet.ColumnsUsed().AdjustToContents();

                    for (int l = 0; l < crows.Count(); l++)
                    {
                        if (!crows.ElementAt(l).Kbn.AdjustToContents)
                            sheet.Column(l + 1).Width = crows.ElementAt(l).Kbn.Width;
                    }

                    sheet.Range(sheet.Cell(1, 1), sheet.Cell(1 + rows.Count(), crows.Count())).Style
                                   .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                   .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                   .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                   .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    sheet.PageSetup.PageOrientation = orientation;
                    sheet.PageSetup.SetRowsToRepeatAtTop(1, 1);
                    workbook.SaveAs(excelpath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return excelpath;
        }
    }
}
