using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    public class Electronics
    {
        private string _Name;
        private int _Port;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public int Port
        {
            get
            {
                return _Port;
            }
            set
            {
                _Port = value;
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
