// <copyright company="eXtensible Solutions, LLC" file="eXEventMover.cs">
// Copyright © 2015 All Right Reserved
// </copyright>

namespace XF.MongoDb
{
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.Linq;
    using XF.Common.MongoDb;

    public class eXEventMover
    {
        public bool IsInitialized { get; set; }

        public eXEventSettings Settings { get; set; }

        public MongoDatabase SourceMongoDb { get; set; }
        public MongoDatabase DestinationMongoDb { get; set; }

        public MongoCollection SourceCollection { get; set; }
        public MongoCollection DestinationCollection { get; set; }

        public eXEventMover(eXEventSettings settings)
        {
            Settings = settings;
        }


        public bool Initialize()
        {
            if (Settings != null)
            {
                if (InitializeDatastores())
                {
                    IsInitialized = true;                 
                }                
            }
            return IsInitialized;
        }

        private bool InitializeDatastores()
        {
            bool b = false;
            var source = ConfigurationManager.ConnectionStrings[Settings.Source];
            var destination = ConfigurationManager.ConnectionStrings[Settings.Destination];
            if (source != null && destination != null)
            {
                XF.Common.MongoConnectionInfo sourceInfo = new XF.Common.MongoConnectionInfo();
                XF.Common.MongoConnectionInfo destinationInfo = new XF.Common.MongoConnectionInfo();
                if (sourceInfo.Initialize(source) && destinationInfo.Initialize(destination))
                {
                    SourceMongoDb = sourceInfo.GetDatabase();
                    DestinationMongoDb = destinationInfo.GetDatabase();

                    SourceCollection = SourceMongoDb.GetCollection<eXEvent>("exevent");
                    DestinationCollection = DestinationMongoDb.GetCollection<eXEvent>("exevent");
                    b = true;
                }
            }

            return b;
        }

        public void ExecutePurge(int year, int month)
        {
            var source = SourceMongoDb.GetCollection("exevent");
            var query = GeneratePurgeQuery(year, month);
            WriteConcernResult result = source.Remove(query);

            string cmd = result.Command.ToString();
            long affected = result.DocumentsAffected;
            string error = result.ErrorMessage;

            int i = 0;
        }


        public void Execute(int year, int month, int day, int hour)
        {
            XF.Common.Day item = new Common.Day() { Year = year, Month = month, Ordinality = day };
            item.Hours.Add(new Common.Hour() { Index = hour });
            Execute(item);

            MongoCollection<XF.Common.Day> process = DestinationMongoDb.GetCollection<XF.Common.Day>("day");
            process.Insert<XF.Common.Day>(item);
        }

        public void Execute(int year, int month, int day)
        {
            Stopwatch sw = new Stopwatch();
            XF.Common.Day item = new Common.Day() { Year = year, Month = month, Ordinality = day };
            for (int i = 0; i < 24; i++)
            {
                item.Hours.Add(new Common.Hour() { Index = i});
            }
            sw.Start();
            Execute(item);
            sw.Stop();
            item.Elapsed = sw.Elapsed.TotalMilliseconds;
            MongoCollection<XF.Common.Day> process = DestinationMongoDb.GetCollection<XF.Common.Day>("day");
            process.Insert<XF.Common.Day>(item);
        }

        private void Execute(Common.Day item)
        {
            
            var source = SourceMongoDb.GetCollection("exevent");
            var destination = DestinationMongoDb.GetCollection("exevent");
           
            item.BeganAt = DateTime.Now.ToString();
            foreach (var hour in item.Hours)
            {
                try
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    IMongoQuery query = GenerateMongoQuery(item.Year, item.Month, item.Ordinality, hour.Index);
                    var cursor = source.Find(query);
                    //var local = cursor.ToList();
                    var pickedup = destination.InsertBatch(cursor);
                    hour.Source = pickedup.Count();
                    WriteConcernResult written = source.Remove(query);
                    hour.Destination = (int)written.DocumentsAffected;
                    sw.Stop();
                    hour.Elapsed = sw.Elapsed.TotalMilliseconds;
                }
                catch (Exception ex)
                {
                    hour.Error = ex.Message;
                }                
            }
            item.EndedAt = DateTime.Now.ToString();


        }

        private IMongoQuery GenerateMongoQuery(int year, int month, int day, int hour)
        {
            List<IMongoQuery> list = new List<IMongoQuery>();
            list.Add(Query.EQ("Year", year));
            list.Add(Query.EQ("Month", month));
            list.Add(Query.EQ("Day", day));
            list.Add(Query.EQ("Hour", hour));
            return Query.And(list);
        }

        private IMongoQuery GeneratePurgeQuery(int year, int month)
        {
            List<IMongoQuery> list = new List<IMongoQuery>();
            list.Add(Query.EQ("Year", year));
            list.Add(Query.EQ("Month", month));
            return Query.And(list);
        }

    }

}
