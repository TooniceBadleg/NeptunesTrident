using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreServiceSOAP.Code
{
    public class ReturnData
    {
        private int _id;
        private bool _hasError;
        private object _data;
        private string _errorMsg;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public bool HasError
        {
            get { return _hasError; }
            set { _hasError = value; }
        }

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { _errorMsg = value; }
        }
    }
}