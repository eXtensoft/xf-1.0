// <copyright company="eXtensible Solutions LLC" file="Hour.cs">
// Copyright © 2015 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml.Serialization;

    [Serializable]
    public class Hour
    {
        [DataMember]
        public int Index { get; set; }

        [DataMember]
        public int Source { get; set; }

        [DataMember]
        public int Destination { get; set; }

        [DataMember]
        public string Error { get; set; }

        [DataMember]
        public double Elapsed { get; set; }
        
    }
}
