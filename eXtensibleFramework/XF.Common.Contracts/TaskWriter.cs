// <copyright company="eXtensible Solutions LLC" file="TaskWriter.cs">
// Copyright © 2015 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System.Collections.Generic;

    public static class TaskWriter 
    {

        public static void WriteTask(TaskTypeOption option, string taskName, object taskId)
        {
            WriteTask(option, taskName, taskId, null);
        }

        public static void WriteTask(TaskTypeOption option, string taskName, object taskId, IDictionary<string,object> properties)
        {
            WriteTask(option, taskName, taskId, properties);
        }


        public static void WriteTask(TaskTypeOption option, string taskName, object taskId,object masterId)
        {
            WriteTask(option, taskName, taskId, masterId, null, null, null);
        }

        public static void WriteTask(TaskTypeOption option, string taskName, object taskId, object masterId, IDictionary<string,object> properties)
        {
            WriteTask(option, taskName, taskId, masterId, null, null, properties);
        }

        public static void WriteTask(TaskTypeOption option, string taskName, object taskId, string itemName, object itemId)
        {
            WriteTask(option, taskName, taskId, null, itemName, itemId, null);
        }

        public static void WriteTask(TaskTypeOption option, string taskName, object taskId, string itemName, object itemId, IDictionary<string,object> properties)
        {
            WriteTask(option, taskName, taskId, null, itemName, itemId, properties);
        }


        public static void WriteTask(TaskTypeOption option, string taskName, object taskId,object masterId,string itemName, object itemId, IDictionary<string,object> properties)
        {
            var props = Writer.EnsureProperties(properties);
            props.Add(XFConstants.EventWriter.EventType, EventTypeOption.Task);
            props.Add(XFConstants.TaskWriter.TaskType, option);
            props.Add(XFConstants.TaskWriter.TaskName, taskName);
            props.Add(XFConstants.TaskWriter.TaskId,taskId);
            props.Add(XFConstants.TaskWriter.TaskMasterId, masterId);
            props.Add(XFConstants.TaskWriter.TaskItemName,itemName);
            props.Add(XFConstants.TaskWriter.TaskItemId,itemId);
            List<TypedItem> list = Writer.Convert(props);
            EventWriter.Write(EventTypeOption.Task, list);
            
        }




    
    }
}
