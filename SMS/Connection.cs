using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    public class Connection
    {
        private string _ConnString;
        private string _Path_File;

        public string ConnString
        {
            get
            {
                return _ConnString;
            }
            set
            {
                _ConnString = value;
            }
        }

        public string Path_File
        {
            get
            {
                return _Path_File;
            }
            set
            {
                _Path_File = value;
            }
        }

        public void Open()
        {
            throw new System.NotImplementedException();
        }

        public void Close()
        {
            throw new System.NotImplementedException();
        }
    }
}
