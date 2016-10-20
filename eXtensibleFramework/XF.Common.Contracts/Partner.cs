// <copyright company="eXtensible Solutions LLC" file="Partner.cs">
// Copyright © 2015 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;

    [Serializable]
    public class ServicePartners
    {
        [XmlAttribute("zone")]
        public string Zone { get; set; }

        [XmlElement("Partner")]
        public List<Partner> Partners { get; set; }
    }


    [Serializable]
    public class Partner
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("basicToken")]
        public string BasicToken { get; set; }



    }
}
