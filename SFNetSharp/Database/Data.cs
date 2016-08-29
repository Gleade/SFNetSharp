using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFNetSharp.Database
{
    class Data
    {
        public object CellData { get; set; }
        
        /// <summary>
        /// Get the data of the cell.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>()
        {
            T data = (T)CellData;
            return data;
        }
    }
}
