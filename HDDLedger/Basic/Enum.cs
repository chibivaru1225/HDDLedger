using ClosedXML.Excel;
using System;
using Color = System.Drawing.Color;

namespace HDDLedger
{
    public class Enum
    {
        #region HDD状態

        public enum HDDStateTypes
        {
            BeforeErased,
            Erased,
            Abandoned,
            Discard,
            Reuse,
            PhysicalDestruction,
            NONE,
        }

        public class HDDStateType
        {
            private HDDStateTypes type;

            public HDDStateType(HDDStateTypes v)
            {
                this.type = v;
            }

            public HDDStateType(string flag)
            {
                switch (flag)
                {
                    case "1": this.type = HDDStateTypes.BeforeErased; break;
                    case "2": this.type = HDDStateTypes.Erased; break;
                    case "3": this.type = HDDStateTypes.Abandoned; break;
                    case "4": this.type = HDDStateTypes.Discard; break;
                    case "5": this.type = HDDStateTypes.Reuse; break;
                    case "6": this.type = HDDStateTypes.PhysicalDestruction; break;
                    default: this.type = HDDStateTypes.NONE; break;
                }
            }

            public static HDDStateType GetTypeForDBValue(string DBValue)
            {
                switch (DBValue)
                {
                    case "1": return HDDStateTypes.BeforeErased;
                    case "2": return HDDStateTypes.Erased;
                    case "3": return HDDStateTypes.Abandoned;
                    case "4": return HDDStateTypes.Discard;
                    case "5": return HDDStateTypes.Reuse;
                    case "6": return HDDStateTypes.PhysicalDestruction;
                    default: return HDDStateTypes.NONE;
                }
            }

            public string DBValue
            {
                get
                {
                    switch (this.type)
                    {
                        case HDDStateTypes.BeforeErased: return "1";
                        case HDDStateTypes.Erased: return "2";
                        case HDDStateTypes.Abandoned: return "3";
                        case HDDStateTypes.Discard: return "4";
                        case HDDStateTypes.Reuse: return "5";
                        case HDDStateTypes.PhysicalDestruction: return "6";
                        default: return "0";
                    }
                }
            }


            public string ViewValue
            {
                get
                {
                    switch (this.type)
                    {
                        case HDDStateTypes.BeforeErased: return "未消去";
                        case HDDStateTypes.Erased: return "消去済";
                        case HDDStateTypes.Abandoned: return "廃棄待";
                        case HDDStateTypes.Discard: return "廃棄済";
                        case HDDStateTypes.Reuse: return "再利用";
                        case HDDStateTypes.PhysicalDestruction: return "物理破壊待";
                        default: return String.Empty;
                    }
                }
            }

            public Color RowColor
            {
                get
                {
                    switch (this.type)
                    {
                        case HDDStateTypes.BeforeErased: return Color.White;
                        case HDDStateTypes.Erased: return Color.LightGreen;
                        case HDDStateTypes.Abandoned: return Color.Yellow;
                        case HDDStateTypes.Discard: return Color.LightPink;
                        case HDDStateTypes.Reuse: return Color.SkyBlue;
                        case HDDStateTypes.PhysicalDestruction: return Color.Orange;
                        default: return Color.White;
                    }
                }
            }

            public HDDStateTypes Value
            {
                get
                {
                    return this.type;
                }
            }

            /// <summary>
            /// 静的型変換
            /// Class -> Enum
            /// </summary>
            /// <param name="HDDStateType"></param>
            public static implicit operator HDDStateTypes(HDDStateType HDDStateType)
            {
                return HDDStateType.type;
            }

            /// <summary>
            /// 静的型変換
            /// Enum -> Class
            /// </summary>
            /// <param name="HDDStateTypes"></param>
            public static implicit operator HDDStateType(HDDStateTypes HDDStateTypes)
            {
                return new HDDStateType(HDDStateTypes);
            }
        }

        #endregion

        #region HDD台帳列区分

        public enum HDDLedgerColumnTypes
        {
            Chosen,
            Renban,
            HDDName,
            HDDState,
            InsertTime,
            UpdateTime,
            NONE,
        }

        public class HDDLedgerColumnType
        {
            private HDDLedgerColumnTypes type;

            public HDDLedgerColumnType(HDDLedgerColumnTypes v)
            {
                this.type = v;
            }

            public HDDLedgerColumnType(string v)
            {
                this.type = GetTypeForDataColumnName(v);
            }

            public String SortColumnName
            {
                get
                {
                    return GetSortColumnName(this.type);
                }
            }

            public static String GetSortColumnName(HDDLedgerColumnTypes v)
            {
                switch (v)
                {
                    case HDDLedgerColumnTypes.Chosen: return nameof(HDDInfoRow.Choose);
                    case HDDLedgerColumnTypes.Renban: return nameof(HDDInfoRow.Renban);
                    case HDDLedgerColumnTypes.HDDName: return nameof(HDDInfoRow.HDDName);
                    case HDDLedgerColumnTypes.HDDState: return nameof(HDDInfoRow.StateDBStr);
                    case HDDLedgerColumnTypes.InsertTime: return nameof(HDDInfoRow.RegisterTime);
                    case HDDLedgerColumnTypes.UpdateTime: return nameof(HDDInfoRow.LatestUpdateTime);
                    default: return String.Empty;
                }
            }

            public static HDDLedgerColumnType GetTypeForDataColumnName(string datacolumnname)
            {
                switch (datacolumnname)
                {
                    case nameof(HDDInfoRow.Choose): return HDDLedgerColumnTypes.Chosen;
                    case nameof(HDDInfoRow.Renban): return HDDLedgerColumnTypes.Renban;
                    case nameof(HDDInfoRow.HDDName): return HDDLedgerColumnTypes.HDDName;
                    case nameof(HDDInfoRow.StateViewValue): return HDDLedgerColumnTypes.HDDState;
                    case nameof(HDDInfoRow.RegisterTimeStr): return HDDLedgerColumnTypes.InsertTime;
                    case nameof(HDDInfoRow.LatestUpdateTimeStr): return HDDLedgerColumnTypes.UpdateTime;
                    default: return HDDLedgerColumnTypes.NONE;
                }
            }

            public HDDLedgerColumnTypes Value
            {
                get
                {
                    return this.type;
                }
            }

            /// <summary>
            /// 静的型変換
            /// Class -> Enum
            /// </summary>
            /// <param name="HDDLedgerColumnType"></param>
            public static implicit operator HDDLedgerColumnTypes(HDDLedgerColumnType HDDLedgerColumnType)
            {
                return HDDLedgerColumnType.type;
            }

            /// <summary>
            /// 静的型変換
            /// Enum -> Class
            /// </summary>
            /// <param name="HDDLedgerColumnTypes"></param>
            public static implicit operator HDDLedgerColumnType(HDDLedgerColumnTypes HDDLedgerColumnTypes)
            {
                return new HDDLedgerColumnType(HDDLedgerColumnTypes);
            }
        }

        #endregion

        #region 台帳印刷区分

        public enum PrintModeKbns
        {
            All,
            NotDiscard,
            SelectRow,
            NONE,
        }

        public class PrintModeKbn
        {
            private PrintModeKbns type;

            public PrintModeKbn(PrintModeKbns v)
            {
                this.type = v;
            }

            public PrintModeKbn(string flag)
            {
                switch (flag)
                {
                    case "1": this.type = PrintModeKbns.All; break;
                    case "2": this.type = PrintModeKbns.NotDiscard; break;
                    case "3": this.type = PrintModeKbns.SelectRow; break;
                    default: this.type = PrintModeKbns.NONE; break;
                }
            }

            public static PrintModeKbn GetTypeForDBValue(string DBValue)
            {
                switch (DBValue)
                {
                    case "1": return PrintModeKbns.All;
                    case "2": return PrintModeKbns.NotDiscard;
                    case "3": return PrintModeKbns.SelectRow;
                    default: return PrintModeKbns.NONE;
                }
            }

            public string DBValue
            {
                get
                {
                    switch (this.type)
                    {
                        case PrintModeKbns.All: return "1";
                        case PrintModeKbns.NotDiscard: return "2";
                        case PrintModeKbns.SelectRow: return "3";
                        default: return "0";
                    }
                }
            }

            public string ViewValue
            {
                get
                {
                    switch (this.type)
                    {
                        case PrintModeKbns.All: return "全て";
                        case PrintModeKbns.NotDiscard: return "未廃棄";
                        case PrintModeKbns.SelectRow: return "選択中の行";
                        default: return String.Empty;
                    }
                }
            }

            public PrintModeKbns Value
            {
                get
                {
                    return this.type;
                }
            }

            /// <summary>
            /// 静的型変換
            /// Class -> Enum
            /// </summary>
            /// <param name="PrintModeKbn"></param>
            public static implicit operator PrintModeKbns(PrintModeKbn PrintModeKbn)
            {
                return PrintModeKbn.type;
            }

            /// <summary>
            /// 静的型変換
            /// Enum -> Class
            /// </summary>
            /// <param name="PrintModeKbns"></param>
            public static implicit operator PrintModeKbn(PrintModeKbns PrintModeKbns)
            {
                return new PrintModeKbn(PrintModeKbns);
            }
        }

        #endregion

        #region 印刷向き区分

        public class PrintOrientationKbn
        {
            private XLPageOrientation type;

            public PrintOrientationKbn(XLPageOrientation v)
            {
                this.type = v;
            }

            public PrintOrientationKbn(string flag)
            {
                switch (flag)
                {
                    case "1": this.type = XLPageOrientation.Default; break;
                    case "2": this.type = XLPageOrientation.Portrait; break;
                    case "3": this.type = XLPageOrientation.Landscape; break;
                    default: this.type = XLPageOrientation.Default; break;
                }
            }

            public static XLPageOrientation GetTypeForDBValue(string DBValue)
            {
                switch (DBValue)
                {
                    case "1": return XLPageOrientation.Default;
                    case "2": return XLPageOrientation.Portrait;
                    case "3": return XLPageOrientation.Landscape;
                    default: return XLPageOrientation.Default;
                }
            }

            public string DBValue
            {
                get
                {
                    switch (this.type)
                    {
                        case XLPageOrientation.Default: return "1";
                        case XLPageOrientation.Portrait: return "2";
                        case XLPageOrientation.Landscape: return "3";
                        default: return "0";
                    }
                }
            }

            public string ViewValue
            {
                get
                {
                    switch (this.type)
                    {
                        case XLPageOrientation.Default: return "デフォルト";
                        case XLPageOrientation.Portrait: return "縦向き";
                        case XLPageOrientation.Landscape: return "横向き";
                        default: return String.Empty;
                    }
                }
            }

            public XLPageOrientation Value
            {
                get
                {
                    return this.type;
                }
            }

            /// <summary>
            /// 静的型変換
            /// Class -> Enum
            /// </summary>
            /// <param name="PrintOrientationKbn"></param>
            public static implicit operator XLPageOrientation(PrintOrientationKbn kbn)
            {
                return kbn.type;
            }

            /// <summary>
            /// 静的型変換
            /// Enum -> Class
            /// </summary>
            /// <param name="PrintOrientationKbns"></param>
            public static implicit operator PrintOrientationKbn(XLPageOrientation kbns)
            {
                return new PrintOrientationKbn(kbns);
            }
        }

        #endregion

        #region 印刷カラム区分

        public enum PrintColumnKbns
        {
            Renban,
            HDDName,
            State,
            InsertTime,
            UpdateTime,
            DeleteStump,
            Barcode,
            NextProcess,
            ConfirmTime,
            ConfirmStump,
            NONE,
        }

        public class PrintColumnKbn
        {
            private PrintColumnKbns type;

            public PrintColumnKbn(PrintColumnKbns v)
            {
                this.type = v;
            }

            //public PrintColumnKbn(string flag)
            //{
            //    switch (flag)
            //    {
            //        case "1": this.type = PrintColumnKbns.Renban; break;
            //        case "2": this.type = PrintColumnKbns.HDDName; break;
            //        default: this.type = PrintColumnKbns.NONE; break;
            //    }
            //}

            //public static PrintColumnKbn GetTypeForDBValue(string DBValue)
            //{
            //    switch (DBValue)
            //    {
            //        case "1": return PrintColumnKbns.Renban;
            //        case "2": return PrintColumnKbns.HDDName;
            //        default: return PrintColumnKbns.NONE;
            //    }
            //}

            //public string DBValue
            //{
            //    get
            //    {
            //        switch (this.type)
            //        {
            //            case PrintColumnKbns.Renban: return "1";
            //            case PrintColumnKbns.HDDName: return "2";
            //            default: return "0";
            //        }
            //    }
            //}

            public string ViewValue
            {
                get
                {
                    switch (this.type)
                    {
                        case PrintColumnKbns.Renban: return "連番";
                        case PrintColumnKbns.HDDName: return "HDD名";
                        case PrintColumnKbns.State: return "状態";
                        case PrintColumnKbns.InsertTime: return "登録日時";
                        case PrintColumnKbns.UpdateTime: return "更新日時";
                        case PrintColumnKbns.Barcode: return "連番バーコード";
                        case PrintColumnKbns.DeleteStump: return "削除日･印";
                        case PrintColumnKbns.NextProcess: return "次工程";
                        case PrintColumnKbns.ConfirmTime: return "実施日";
                        case PrintColumnKbns.ConfirmStump: return "実施印";
                        default: return String.Empty;
                    }
                }
            }

            public int Order
            {
                get
                {
                    switch (this.type)
                    {
                        case PrintColumnKbns.Renban: return 1;
                        case PrintColumnKbns.HDDName: return 2;
                        case PrintColumnKbns.State: return 3;
                        case PrintColumnKbns.InsertTime: return 4;
                        case PrintColumnKbns.UpdateTime: return 5;
                        case PrintColumnKbns.DeleteStump: return 6;
                        case PrintColumnKbns.Barcode: return 7;
                        case PrintColumnKbns.NextProcess: return 8;
                        case PrintColumnKbns.ConfirmTime: return 9;
                        case PrintColumnKbns.ConfirmStump: return 10;
                        default: return 0;
                    }
                }
            }

            public bool DefaultPrint
            {
                get
                {
                    switch (this.type)
                    {
                        case PrintColumnKbns.Renban: return true;
                        case PrintColumnKbns.HDDName: return true;
                        case PrintColumnKbns.State: return false;
                        case PrintColumnKbns.InsertTime: return false;
                        case PrintColumnKbns.UpdateTime: return false;
                        case PrintColumnKbns.DeleteStump: return true;
                        case PrintColumnKbns.Barcode: return false;
                        case PrintColumnKbns.NextProcess: return true;
                        case PrintColumnKbns.ConfirmTime: return true;
                        case PrintColumnKbns.ConfirmStump: return true;
                        default: return false;
                    }
                }
            }

            public bool AdjustToContents
            {
                get
                {
                    switch (this.type)
                    {
                        case PrintColumnKbns.HDDName: return false;
                        case PrintColumnKbns.DeleteStump: return false;
                        case PrintColumnKbns.Barcode: return false;
                        case PrintColumnKbns.NextProcess: return false;
                        case PrintColumnKbns.ConfirmTime: return false;
                        case PrintColumnKbns.ConfirmStump: return false;
                        default: return true;
                    }
                }
            }

            public double Width
            {
                get
                {
                    switch (this.type)
                    {
                        case PrintColumnKbns.HDDName: return 28;
                        case PrintColumnKbns.DeleteStump: return 10;
                        case PrintColumnKbns.Barcode: return 28;
                        case PrintColumnKbns.NextProcess: return 14;
                        case PrintColumnKbns.ConfirmTime: return 10;
                        case PrintColumnKbns.ConfirmStump: return 10;
                        default: return 0;
                    }
                }
            }

            public PrintColumnKbns Value
            {
                get
                {
                    return this.type;
                }
            }

            /// <summary>
            /// 静的型変換
            /// Class -> Enum
            /// </summary>
            /// <param name="PrintColumnKbn"></param>
            public static implicit operator PrintColumnKbns(PrintColumnKbn PrintColumnKbn)
            {
                return PrintColumnKbn.type;
            }

            /// <summary>
            /// 静的型変換
            /// Enum -> Class
            /// </summary>
            /// <param name="PrintColumnKbns"></param>
            public static implicit operator PrintColumnKbn(PrintColumnKbns PrintColumnKbns)
            {
                return new PrintColumnKbn(PrintColumnKbns);
            }
        }

        #endregion

        #region フォーカス区分

        public enum NextFocusKbns
        {
            Renban,
            HDDName,
            NONE,
        }

        public class NextFocusKbn
        {
            private NextFocusKbns type;

            public NextFocusKbn(NextFocusKbns v)
            {
                this.type = v;
            }

            public NextFocusKbn(string flag)
            {
                switch (flag)
                {
                    case "1": this.type = NextFocusKbns.Renban; break;
                    case "2": this.type = NextFocusKbns.HDDName; break;
                    default: this.type = NextFocusKbns.NONE; break;
                }
            }

            public static NextFocusKbn GetTypeForDBValue(string DBValue)
            {
                switch (DBValue)
                {
                    case "1": return NextFocusKbns.Renban;
                    case "2": return NextFocusKbns.HDDName;
                    default: return NextFocusKbns.NONE;
                }
            }

            public string DBValue
            {
                get
                {
                    switch (this.type)
                    {
                        case NextFocusKbns.Renban: return "1";
                        case NextFocusKbns.HDDName: return "2";
                        default: return "0";
                    }
                }
            }

            public string ViewValue
            {
                get
                {
                    switch (this.type)
                    {
                        case NextFocusKbns.Renban: return "連番";
                        case NextFocusKbns.HDDName: return "HDD名";
                        default: return String.Empty;
                    }
                }
            }

            public NextFocusKbns Value
            {
                get
                {
                    return this.type;
                }
            }

            /// <summary>
            /// 静的型変換
            /// Class -> Enum
            /// </summary>
            /// <param name="NextFocusKbn"></param>
            public static implicit operator NextFocusKbns(NextFocusKbn NextFocusKbn)
            {
                return NextFocusKbn.type;
            }

            /// <summary>
            /// 静的型変換
            /// Enum -> Class
            /// </summary>
            /// <param name="NextFocusKbns"></param>
            public static implicit operator NextFocusKbn(NextFocusKbns NextFocusKbns)
            {
                return new NextFocusKbn(NextFocusKbns);
            }
        }

        #endregion

        #region はいいいえ区分

        public enum YesNoKbns
        {
            Yes,
            No,
        }

        public class YesNoKbn
        {
            private YesNoKbns YesNoKbns;

            public YesNoKbn(YesNoKbns v)
            {
                this.YesNoKbns = v;
            }

            public YesNoKbn(string flag)
            {
                switch (flag)
                {
                    case "1": this.YesNoKbns = YesNoKbns.Yes; break;
                    default: this.YesNoKbns = YesNoKbns.No; break;
                }
            }

            public static YesNoKbn GetKbnForDBValue(string DBValue)
            {
                switch (DBValue)
                {
                    case "1": return YesNoKbns.Yes;
                    default: return YesNoKbns.No;
                }
            }

            public string DBValue
            {
                get
                {
                    switch (this.YesNoKbns)
                    {
                        case YesNoKbns.Yes: return "1";
                        default: return "0";
                    }
                }
            }

            public bool BoolValue
            {
                get
                {
                    switch (this.YesNoKbns)
                    {
                        case YesNoKbns.Yes: return true;
                        default: return false;
                    }
                }
            }

            public string ViewValue
            {
                get
                {
                    switch (this.YesNoKbns)
                    {
                        case YesNoKbns.Yes: return "はい";
                        default: return "いいえ";
                    }
                }
            }

            public YesNoKbns Value
            {
                get
                {
                    return this.YesNoKbns;
                }
            }

            /// <summary>
            /// 静的型変換
            /// Class -> Enum
            /// </summary>
            /// <param name="YesNoKbn"></param>
            public static implicit operator YesNoKbns(YesNoKbn YesNoKbn)
            {
                return YesNoKbn.YesNoKbns;
            }

            /// <summary>
            /// 静的型変換
            /// Enum -> Class
            /// </summary>
            /// <param name="YesNoKbns"></param>
            public static implicit operator YesNoKbn(YesNoKbns YesNoKbns)
            {
                return new YesNoKbn(YesNoKbns);
            }
        }

        #endregion
    }
}
