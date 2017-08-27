using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NoteManager.Infrastructure.Constants;
using NoteManager.Infrastructure.Objects;
using NoteManager.Infrastructure.Strings;

namespace NoteManager.Infrastructure.Exports
{
    public class CsvExport
    {
        private string _excelString = "";

        #region Retrieve

        public Stream RetrieveFile()
        {
            var bytes = Encoding.Unicode.GetBytes(_excelString);
            var stream = new MemoryStream(bytes);
            return stream;
        }

        public Stream RetrieveError()
        {
            _excelString = string.Empty;
            ConcatRow(0, MessageConstants.ExportWithErrors);
            return RetrieveFile();
        }

        #endregion

        #region Concat

        public void ConcatRows<T>(int spaceNumber, string propertiesCommaSeparated, IEnumerable<T> objects)
        {
            foreach (var objectRetrieved in objects)
                ConcatRow(spaceNumber, propertiesCommaSeparated, objectRetrieved);
        }

        public void ConcatRow<T>(int spaceNumber, string propertiesCommaSeparated, T objectRetrieved)
        {
            var row = string.Empty;
            var propertiesToRetrieve = propertiesCommaSeparated.Split(',').ToList();
            propertiesToRetrieve.ForEach(property =>
            {
                var value = ExtractValue(property, objectRetrieved);
                var comma = row.IsNullOrEmpty() ? string.Empty : ",";
                row += string.Concat(comma, value);
            });

            ConcatRow(spaceNumber, row);
        }

        public void ConcatRow(int spaceNumber, string row)
        {
            var commans = string.Concat(Enumerable.Repeat(",", spaceNumber));
            row = string.Concat(commans, row, "\n");
            _excelString = string.Concat(_excelString, row);
        }

        #endregion

        #region Private Methods

        private static string ExtractValue<T>(string property, T objectRetrieved)
        {
            property = property.Trim();
            var valueRetrieved = objectRetrieved.ExtractProperty(property);
            var valueString = string.Empty;
            
            if (valueRetrieved.IsNotNull())
                valueString = valueRetrieved.ToString();
            if (valueRetrieved is decimal)
                return valueString.Replace(",", ".");

            return valueString.Replace(",", " ");
        }

        #endregion
    }
}