using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    public class Users
    {
        private string _FName;
        private string _LName;
        private string _CellPhoneNumber;
        private int _IDGroup;

        public string FName
        {
            get
            {
                return _FName;
            }
            set
            {
                _FName = value;
            }
        }

        public string LName
        {
            get
            {
                return _LName;
            }
            set
            {
                _LName = value;
            }
        }

        public string CellPhoneNumber
        {
            get
            {
                return _CellPhoneNumber;
            }
            set
            {
                _CellPhoneNumber = value;
            }
        }

        public int IDGroup
        {
            get
            {
                return _IDGroup;
            }
            set
            {
                _IDGroup = value;
            }
        } 

        public void Insert()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Select()
        {
            throw new System.NotImplementedException();
        }

        public void Inactivate()
        {
            throw new System.NotImplementedException();
        }
    }
}
