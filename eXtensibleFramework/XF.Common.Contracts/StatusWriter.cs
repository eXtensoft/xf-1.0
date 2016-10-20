// <copyright company="eXtensible Solutions LLC" file="StatusWriter.cs">
// Copyright © 2015 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    using System.Collections.Generic;

    public static class StatusWriter  
    {


        public static void WriteStatus<T>(object modelId, string modelStatus) where T : class, new()
        {
            WriteStatus<T>(modelId, modelStatus, DateTime.Now);
        }

        public static void WriteStatus<T>(object modelId, string modelStatus, IDictionary<string, object> properties) where T : class, new()
        {
            WriteStatus<T>(modelId, modelStatus, DateTime.Now, properties);
        }

        public static void WriteStatus<T>(object modelId, string modelStatus, DateTimeOffset effective) where T : class, new()
        {
            WriteStatus<T>(modelId, modelStatus, effective, null);
        }

        public static void WriteStatus<T>(object modelId, string modelStatus, DateTimeOffset effective, IDictionary<string, object> properties) where T : class, new()
        {
            string modeltype = Activator.CreateInstance<T>().GetType().FullName;
            WriteStatus(modelId, modeltype, modelStatus, effective, properties);
        }

        public static void WriteStatus(object modelId, string modelType, string modelStatus)
        {
            WriteStatus(modelId, modelType, modelStatus, DateTime.Now);
        }

        public static void WriteStatus(object modelId, string modelType, string modelStatus, IDictionary<string, object> properties)
        {
            WriteStatus(modelId, modelType, modelStatus, DateTime.Now, properties);
        }

        public static void WriteStatus(object modelId, string modelType, string modelStatus, DateTimeOffset effective)
        {
            WriteStatus(modelId, modelType, modelStatus, effective, null);
        }

        public static void WriteStatus(object modelId, string modelType, string modelStatus, DateTimeOffset effective, IDictionary<string, object> properties)
        {
            var props = Writer.EnsureProperties(properties);
            props.Add(XFConstants.EventWriter.EventType, EventTypeOption.Status);
            props.Add(XFConstants.EventWriter.ModelId,modelId);
            props.Add(XFConstants.EventWriter.ModelType, modelType);
            props.Add(XFConstants.EventWriter.ModelStatus,modelStatus);
            props.Add(XFConstants.EventWriter.Effective,effective);
            List<TypedItem> list = Writer.Convert(props);
            EventWriter.Write(EventTypeOption.Status, list);
        }


    }
}
