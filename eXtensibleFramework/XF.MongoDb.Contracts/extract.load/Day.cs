// <copyright company="eXtensible Solutions LLC" file="Day.cs">
// Copyright © 2015 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class Day 
    {

        public int Year { get; set; }
        public int Month { get; set; }
        public int Ordinality { get; set; }

        public string Source { get; set; }
        public string Destination { get; set; }

        public string BeganAt { get; set; }

        public string EndedAt { get; set; }

        public double Elapsed { get; set; }

        #region Hours (List<Hour>)

        private List<Hour> _Hours = new List<Hour>();

        /// <summary>
        /// Gets or sets the List<Hour> value for Hours
        /// </summary>
        /// <value> The List<Hour> value.</value>

        public List<Hour> Hours
        {
            get { return _Hours; }
            set
            {
                if (_Hours != value)
                {
                    _Hours = value;
                }
            }
        }

        #endregion

    }
}
