﻿// <copyright company="eXtensible Solutions LLC" file="ApiModelRequestService.cs">
// Copyright © 2015 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


    public class ApiModelRequestService : ModelRequestService, IModelRequestService
    {

        #region IModelRequestService Members

        IResponse<T> IModelRequestService.Post<T>(T model)
        {
            return Post<T>(model);
        }

        IResponse<T> IModelRequestService.Put<T>(T model, ICriterion criterion)
        {
            return Put<T>(model, criterion);
        }

        IResponse<T> IModelRequestService.Delete<T>(ICriterion criterion)
        {
            return Delete<T>(criterion);
        }

        IResponse<T> IModelRequestService.Get<T>(ICriterion criterion)
        {
            return Get<T>(criterion);
        }

        IResponse<T> IModelRequestService.GetAll<T>(ICriterion criterion)
        {
            return GetAll<T>(criterion);
        }

        IResponse<T> IModelRequestService.GetAllProjections<T>(ICriterion criterion)
        {
            return GetAllProjections<T>(criterion);
        }

        IResponse<T, U> IModelRequestService.ExecuteAction<T, U>(T model, ICriterion criterion)
        {
            return ExecuteAction<T, U>(model, criterion);
        }

        IResponse<T> IModelRequestService.ExecuteCommand<T>(System.Data.DataSet ds, ICriterion criterion)
        {
            return ExecuteCommand<T>(ds, criterion);
        }

        IResponse<T, U> IModelRequestService.ExecuteMany<T, U>(System.Collections.Generic.IEnumerable<T> list, ICriterion criterion)
        {
            throw new NotImplementedException();
        }


        void IModelRequestService.PostAsync<T>(T model, Action<IResponse<T>> callback)
        {
            new Action(async () =>
            {
                IResponse<T> result = await Task.Run<IResponse<T>>(() => PostAsync<T>(model));
                callback.Invoke(result);
            }).Invoke();
        }

        void IModelRequestService.PutAsync<T>(T model, ICriterion criterion, Action<IResponse<T>> callback)
        {
            new Action(async () =>
            {
                IResponse<T> result = await Task.Run<IResponse<T>>(() => PutAsync<T>(model, criterion));
                callback.Invoke(result);
            }).Invoke();
        }

        void IModelRequestService.DeleteAsync<T>(ICriterion criterion, Action<IResponse<T>> callback)
        {
            new Action(async () =>
            {
                IResponse<T> result = await Task.Run<IResponse<T>>(() => DeleteAsync<T>(criterion));
                callback.Invoke(result);
            }).Invoke();
        }

        void IModelRequestService.GetAsync<T>(ICriterion criterion, Action<IResponse<T>> callback)
        {
            new Action(async () =>
            {
                IResponse<T> result = await Task.Run<IResponse<T>>(() => GetAsync<T>(criterion));
                callback.Invoke(result);
            }).Invoke();
        }

        void IModelRequestService.GetAllAsync<T>(ICriterion criterion, Action<IResponse<T>> callback)
        {
            new Action(async () =>
            {
                IResponse<T> result = await Task.Run<IResponse<T>>(() => GetAllAsync<T>(criterion));
                callback.Invoke(result);
            }).Invoke();
        }

        void IModelRequestService.GetAllProjectionsAsync<T>(ICriterion criterion, Action<IResponse<T>> callback)
        {
            new Action(async () =>
            {
                IResponse<T> result = await Task.Run<IResponse<T>>(() => GetAllProjectionsAsync<T>(criterion));
                callback.Invoke(result);
            }).Invoke();
        }

        void IModelRequestService.ExecuteActionAsync<T, U>(T model, ICriterion criterion, Action<IResponse<T, U>> callback)
        {
            new Action(async () =>
            {
                IResponse<T, U> result = await Task.Run<IResponse<T, U>>(() => ExecuteActionAsync<T, U>(model, criterion));
                callback.Invoke(result);
            }).Invoke();
        }

        void IModelRequestService.ExecuteCommand<T>(DataSet ds, ICriterion criterion, Action<IResponse<T>> callback)
        {
            new Action(async () =>
            {
                IResponse<T> result = await Task.Run<IResponse<T>>(() => ExecuteCommand<T>(ds, criterion));
                callback.Invoke(result);
            }).Invoke();
        }

        void IModelRequestService.ExecuteManyAsync<T, U>(System.Collections.Generic.IEnumerable<T> list, ICriterion criterion, Action<IResponse<T, U>> callback)
        {
            new Action(async () =>
            {
                IResponse<T, U> result = await Task.Run<IResponse<T, U>>(() => ExecuteMany<T, U>(list, criterion));
                callback.Invoke(result);
            }).Invoke();            
        }

        #endregion

        #region local implementations

        private IResponse<T> Post<T>(T model)
        {
            throw new NotImplementedException();
        }

        private IResponse<T> Put<T>(T model, ICriterion criterion) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private IResponse<T> Delete<T>(ICriterion criterion) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private IResponse<T> Get<T>(ICriterion criterion) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private IResponse<T> GetAll<T>(ICriterion criterion) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private IResponse<T> GetAllProjections<T>(ICriterion criterion) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private IResponse<T, U> ExecuteAction<T, U>(T model, ICriterion criterion) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private IResponse<T> ExecuteCommand<T>(System.Data.DataSet ds, ICriterion criterion) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private IResponse<T, U> ExecuteMany<T, U>(IEnumerable<T> list, ICriterion criterion) where T : class, new()
        {
            throw new NotImplementedException();
        }



        private void PostAsync<T>(T model, Action<IResponse<T>> callback) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private void PutAsync<T>(T model, ICriterion criterion, Action<IResponse<T>> callback) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private void DeleteAsync<T>(ICriterion criterion, Action<IResponse<T>> callback) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private void GetAsync<T>(ICriterion criterion, Action<IResponse<T>> callback) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private void GetAllAsync<T>(ICriterion criterion, Action<IResponse<T>> callback) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private void GetAllProjectionsAsync<T>(ICriterion criterion, Action<IResponse<T>> callback) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private void ExecuteActionAsync<T, U>(T model, ICriterion criterion, Action<IResponse<T, U>> callback) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private void ExecuteCommand<T>(System.Data.DataSet ds, ICriterion criterion, Action<IResponse<T>> callback) where T : class, new()
        {
            throw new NotImplementedException();
        }

        private void ExecuteManyAsync<T,U>(IEnumerable<T> list, ICriterion criterion, Action<IResponse<T,U>> callback) where T : class, new()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region helper methods


        private Task<IResponse<T>> PostAsync<T>(T t) where T : class, new()
        {
            return Task.Run<IResponse<T>>(() => Post<T>(t));
        }

        private Task<IResponse<T>> PutAsync<T>(T t, ICriterion criterion) where T : class, new()
        {
            return Task.Run<IResponse<T>>(() => Put<T>(t, criterion));
        }

        private Task<IResponse<T>> DeleteAsync<T>(ICriterion criterion) where T : class, new()
        {
            return Task.Run<IResponse<T>>(() => Delete<T>(criterion));
        }

        private Task<IResponse<T>> GetAsync<T>(ICriterion criterion) where T : class, new()
        {
            return Task.Run<IResponse<T>>(() => Get<T>(criterion));
        }

        private Task<IResponse<T>> GetAllAsync<T>(ICriterion criterion) where T : class, new()
        {
            return Task.Run<IResponse<T>>(() => GetAll<T>(criterion));
        }

        private Task<IResponse<T>> GetAllProjectionsAsync<T>(ICriterion criterion) where T : class, new()
        {
            return Task.Run<IResponse<T>>(() => GetAllProjections<T>(criterion));
        }

        private Task<IResponse<T, U>> ExecuteActionAsync<T, U>(T model, ICriterion criterion) where T : class, new()
        {
            return Task.Run<IResponse<T, U>>(() => ExecuteAction<T, U>(model, criterion));
        }

        private Task<IResponse<T>> ExecuteCommandAsync<T>(DataSet ds, ICriterion criterion) where T : class, new()
        {
            return Task.Run<IResponse<T>>(() => ExecuteCommand<T>(ds, criterion));
        }

        private Task<IResponse<T, U>> ExecuteManyAsync<T, U>(IEnumerable<T> list, ICriterion criterion) where T : class, new()
        {
            return Task.Run<IResponse<T, U>>(() => ExecuteMany<T, U>(list, criterion));
        }

        #endregion



    }
}
