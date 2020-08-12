using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static string CreateLedger(IEnumerable<HDDInfoRow> rows, bool printbarcode)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var excelpath = documents + @"\HDDLedger\Excel\Excel-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".xlsx";

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var sheet = workbook.Worksheets.Add("HDD台帳");

                    sheet.Cell(1, 1).Value = "連番";
                    sheet.Cell(1, 2).Value = "HDD名";
                    sheet.Cell(1, 3).Value = "状態";
                    sheet.Cell(1, 4).Value = "登録日時";
                    sheet.Cell(1, 5).Value = "更新日時";
                    sheet.Cell(1, 6).Value = "確認印";

                    if (printbarcode)
                        sheet.Cell(1, 7).Value = "連番バーコード";

                    for (int i = 0; i < rows.Count(); i++)
                    {
                        sheet.Cell(2 + i, 1).Value = "'" + rows.ElementAt(i).BarcodeRenban;
                        sheet.Cell(2 + i, 2).Value = rows.ElementAt(i).HDDName;
                        sheet.Cell(2 + i, 3).Value = rows.ElementAt(i).StateViewValue;
                        sheet.Cell(2 + i, 4).Value = rows.ElementAt(i).RegisterTimeStr;
                        sheet.Cell(2 + i, 5).Value = rows.ElementAt(i).LatestUpdateTimeStr;

                        sheet.Row(2 + i).Height = 30;

                        if (printbarcode)
                        {
                            var imagepath = documents + @"\HDDLedger\Barcode\Barcode-" + rows.ElementAt(i).BarcodeRenban + ".png";
                            var pic = sheet.AddPicture(imagepath).MoveTo(sheet.Cell(2 + i, 7));
                            pic.Width = 200;
                            pic.Height = 30;
                        }
                    }

                    sheet.ColumnsUsed().AdjustToContents();

                    if (printbarcode)
                    {
                        sheet.Range(sheet.Cell(1, 1), sheet.Cell(1 + rows.Count(), 7)).Style
                                           .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                           .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                           .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                           .Border.SetRightBorder(XLBorderStyleValues.Thin);
                    }
                    else
                    {
                        sheet.Range(sheet.Cell(1, 1), sheet.Cell(1 + rows.Count(), 6)).Style
                                           .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                           .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                           .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                           .Border.SetRightBorder(XLBorderStyleValues.Thin);
                    }

                    sheet.Column(6).Width = 10;

                    if (printbarcode)
                    {
                        sheet.Column(7).Width = 28;
                        //sheet.PageSetup.Margins.Top = 1.91 / 2.54;
                        //sheet.PageSetup.Margins.Bottom = 1.91 / 2.54;
                        //sheet.PageSetup.Margins.Left = 0.64 / 2.54;
                        //sheet.PageSetup.Margins.Right = 0.64 / 2.54;
                        //sheet.PageSetup.Margins.Footer = 0;
                        //sheet.PageSetup.Margins.Header = 0;
                    }

                    sheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;
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
