using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HDDLedger.Enum;

namespace HDDLedger
{
    public class ColumnRow
    {
        public bool IsPrint { get; set; }

        public PrintColumnKbn Kbn { get; set; }

        public String ColumnName => this.Kbn.ViewValue;

        public int ColumnOrder => this.Kbn.Order;
    }
}
