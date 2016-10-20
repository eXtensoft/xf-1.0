// <copyright file="ListDataReader.cs" company="eXtensible Solutions, LLC">
// Copyright © 2015 All Right Reserved
// </copyright>



namespace XF.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;


    public class ListDataReader<T> : IDataReader where T : class, new()
    {

        private IEnumerator<T> listEnumerator = null;


        private Func<T, object>[] propertyAccessors = null;


        private IDictionary<string, int> propertyAccessorMaps = null;
        

        public ListDataReader(IEnumerable<T> list)
        {
            listEnumerator = list.GetEnumerator();

            Type t = typeof(T);

            var q = t.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.CanRead)
                .Select((x, i) => new { 
                    Index = i,
                    Property=x, 
                    Accessor=BuildAccessor(x) 
                }).ToArray();
            propertyAccessors = q.Select(x => x.Accessor).ToArray();
            propertyAccessorMaps = q.ToDictionary(x => x.Property.Name, x => x.Index, StringComparer.OrdinalIgnoreCase);
        }

        private Func<T,object> BuildAccessor(PropertyInfo info)
        {
            var parameter = Expression.Parameter(typeof(T), "input");
            var access = Expression.Property(parameter, info.GetGetMethod());
            var toObject = Expression.TypeAs(access, typeof(object));
            var lamda = Expression.Lambda<Func<T, object>>(toObject, parameter);
            return lamda.Compile();
        }



        public void Close()
        {
            Dispose();
        }

        public int Depth
        {
            get { return 1; }
        }

        public DataTable GetSchemaTable()
        {
            return null;
        }

        public bool IsClosed
        {
            get { return listEnumerator == null; }
        }

        public bool NextResult()
        {
            return false;
        }

        public bool Read()
        {
            if (listEnumerator != null)
            {
                return listEnumerator.MoveNext();
            }
            else
            {
                return false;
            }
        }

        public int RecordsAffected
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                if (listEnumerator != null)
                {
                    listEnumerator.Dispose();
                    listEnumerator = null;
                }
            }
        }

        public int FieldCount
        {
            get { return propertyAccessors.Length; }
        }

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public string GetName(int i)
        {
            throw new NotImplementedException();
        }

        public int GetOrdinal(string name)
        {
            int i;
            if (!propertyAccessorMaps.TryGetValue(name,out i))
            {
                throw new InvalidOperationException(String.Format("'{0}' property not found", name));
            }
            return i;
        }

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        public object GetValue(int i)
        {
            if (listEnumerator == null)
            {
                throw new ObjectDisposedException("GenericDataReader");
            }
            return propertyAccessors[i](listEnumerator.Current);
        }

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }

        public object this[string name]
        {
            get { throw new NotImplementedException(); }
        }

        public object this[int i]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
