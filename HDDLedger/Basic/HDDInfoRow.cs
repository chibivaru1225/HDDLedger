﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using static HDDLedger.Enum;

namespace HDDLedger
{
    [JsonObject("HDDInfo")]
    public class HDDInfoRow : INotifyPropertyChanged
    {
        /// <summary>
        /// 連番(自動生成)
        /// </summary>
        [JsonProperty("ID")]
        public int Renban { get; set; }

        [JsonIgnore]
        public string BarcodeRenban
        {
            get
            {
                return String.Format("{0:D8}", Renban);
            }
        }

        [JsonIgnore]
        private string hddname;

        /// <summary>
        /// HDD名(任意)
        /// </summary>
        [JsonProperty("HDDName")]
        public string HDDName
        {
            get
            {
                return hddname;
            }
            set
            {
                hddname = value.ToUpper();
            }
        }

        /// <summary>
        /// 登録日時
        /// </summary>
        [JsonProperty("RegisterTime")]
        public DateTime RegisterTime { get; set; }

        [JsonIgnore]
        public string RegisterTimeStr
        {
            get
            {
                return RegisterTime.ToString("yyyy/MM/dd HH:mm:ss");
            }
        }

        [JsonIgnore]
        private DateTime latestupdatetime;

        /// <summary>
        /// 最終更新日時
        /// </summary>
        [JsonProperty("LatestUpdateTime")]
        public DateTime LatestUpdateTime
        {
            get
            {
                return latestupdatetime;
            }
            set
            {
                latestupdatetime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LatestUpdateTime)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LatestUpdateTimeStr)));
            }
        }

        [JsonIgnore]
        public string LatestUpdateTimeStr
        {
            get
            {
                return LatestUpdateTime.ToString("yyyy/MM/dd HH:mm:ss");
            }
        }

        [JsonIgnore]
        private HDDStateType state;

        /// <summary>
        /// HDD状態
        /// </summary>
        [JsonIgnore]
        public HDDStateType State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StateColor)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StateViewValue)));
            }
        }

        /// <summary>
        /// HDD状態
        /// </summary>
        [JsonIgnore]
        public string StateViewValue
        {
            get
            {
                return state.ViewValue;
            }
        }

        /// <summary>
        /// HDD状態(DB)
        /// </summary>
        [JsonProperty("HDDState")]
        public String StateDBStr
        {
            get
            {
                return state.DBValue;
            }
            set
            {
                state = HDDStateType.GetTypeForDBValue(value);
            }
        }

        [JsonIgnore]
        public System.Drawing.Color StateColor
        {
            get
            {
                return state.RowColor;
            }
        }

        [JsonIgnore]
        private bool choose;

        [JsonIgnore]
        public bool Choose
        {
            get
            {
                return choose;
            }
            set
            {
                choose = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Choose)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public IEnumerable<string> Properties()
        {
            return (from a in GetType().GetProperties()
                    select a.Name);
        }

        [JsonIgnore]
        public object this[string propertyName]
        {
            get
            {
                if (!Properties().Contains(propertyName))
                    throw new IndexOutOfRangeException();

                return GetType().GetProperty(propertyName).GetValue(this);
            }
            set
            {
                if (!Properties().Contains(propertyName))
                    throw new IndexOutOfRangeException();

                GetType().GetProperty(propertyName).SetValue(this, value);
            }
        }
    }
}
