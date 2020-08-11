﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDDLedger
{
    public class Enum
    {
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
                    case "0": this.YesNoKbns = YesNoKbns.No; break;
                    default: this.YesNoKbns = YesNoKbns.No; break;
                }
            }

            public static YesNoKbn GetKbnForDBValue(string DBValue)
            {
                switch (DBValue)
                {
                    case "1": return YesNoKbns.Yes;
                    case "0": return YesNoKbns.No;
                    default: return YesNoKbns.No;
                }
            }

            public static YesNoKbns GetKbnsForDBValue(string DBValue)
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

        #region HDD状態

        public enum HDDStateTypes
        {
            BeforeErased,
            Discard,
            Reuse,
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
                    case "2": this.type = HDDStateTypes.Discard; break;
                    case "3": this.type = HDDStateTypes.Reuse; break;
                    default: this.type = HDDStateTypes.NONE; break;
                }
            }

            public static HDDStateType GetTypeForDBValue(string DBValue)
            {
                switch (DBValue)
                {
                    case "1": return HDDStateTypes.BeforeErased;
                    case "2": return HDDStateTypes.Discard;
                    case "3": return HDDStateTypes.Reuse;
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
                        case HDDStateTypes.Discard: return "2";
                        case HDDStateTypes.Reuse: return "3";
                        default: return "0";
                    }
                }
            }

            public bool BoolValue
            {
                get
                {
                    switch (this.type)
                    {
                        case HDDStateTypes.BeforeErased: return true;
                        default: return false;
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
                        case HDDStateTypes.Discard: return "廃棄済";
                        case HDDStateTypes.Reuse: return "再利用";
                        default: return String.Empty;
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

        #region 台帳印刷区分

        public enum PrintModeKbns
        {
            All,
            NotDiscard,
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
                    default: this.type = PrintModeKbns.NONE; break;
                }
            }

            public static PrintModeKbn GetTypeForDBValue(string DBValue)
            {
                switch (DBValue)
                {
                    case "1": return PrintModeKbns.All;
                    case "2": return PrintModeKbns.NotDiscard;
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
    }
}
