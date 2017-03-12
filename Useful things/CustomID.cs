using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public class CustomID
    {
        private readonly Guid _id;

        public CustomID()
        {
            this._id = new Guid();
        }

        public CustomID(Guid guid)
        {
            this._id = guid;
        }       

        public override string ToString()
        {
            return this._id.ToString();
        }
    }
}
