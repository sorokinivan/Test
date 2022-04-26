using Microsoft.Extensions.Options;
using OfficeOpenXml;
using WebService1.Models;

namespace WebService1.Repositories
{
    public class TenderRepository : ITenderRepository
    {
        private FileSettings _fileSettings;
        public TenderRepository(IOptions<FileSettings> fileSettings)
        {
            _fileSettings = fileSettings.Value;
        }

        public async Task<IEnumerable<Tender>> GetTendersFromXLS()
        {
            var result = new List<Tender>();
            if (_fileSettings.FileDirectory is not null)
            {
                FileInfo file = new FileInfo(_fileSettings.FileDirectory);
                if (file.Exists)
                {
                    var package = new ExcelPackage(file);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var sheets = package.Workbook.Worksheets;
                    

                    await Task.Run(() =>
                    {
                        foreach (var sheet in sheets)
                        {
                            var noOfCol = sheet.Dimension.End.Column;
                            var noOfRow = sheet.Dimension.End.Row;

                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                var user = new Tender(
                                    tenderName: Convert.ToString(sheet.Cells[rowIterator, 1].Value) ?? String.Empty,
                                    startDate: Convert.ToDateTime(sheet.Cells[rowIterator, 2].Value),
                                    endDate: Convert.ToDateTime(sheet.Cells[rowIterator, 3].Value),
                                    tenderUrl: Convert.ToString(sheet.Cells[rowIterator, 4].Value) ?? String.Empty
                                    );
                                result.Add(user);
                            }
                        }
                    });
                }
            }


            return result;
        }
    }
}
