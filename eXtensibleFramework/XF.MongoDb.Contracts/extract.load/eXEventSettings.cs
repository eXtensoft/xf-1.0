// <copyright company="eXtensible Solutions, LLC" file="eXEventSettings.cs">
// Copyright © 2015 All Right Reserved
// </copyright>

namespace XF.MongoDb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class eXEventSettings
    {
        public string Source { get; set; }
        public string Destination { get; set; }

        public string Query { get; set; }

        #region IsRemoveSourceDocuments (bool)

        private bool _IsRemoveSourceDocuments = false;

        /// <summary>
        /// Gets or sets the bool value for IsRemoveSourceDocuments
        /// </summary>
        /// <value> The bool value.</value>

        public bool IsRemoveSourceDocuments
        {
            get { return _IsRemoveSourceDocuments; }
            set
            {
                if (_IsRemoveSourceDocuments != value)
                {
                    _IsRemoveSourceDocuments = value;
                }
            }
        }

        #endregion


    }

}
