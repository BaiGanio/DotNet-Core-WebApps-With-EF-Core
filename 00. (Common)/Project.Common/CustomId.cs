using System;

namespace Project.Common
{
    public class CustomId
    {
        private readonly Guid _id;

        public CustomId()
        {
            this._id = new Guid();
        }

        public CustomId(Guid guid)
        {
            this._id = guid;
        }

        public override string ToString()
        {
            return this._id.ToString();
        }

        public string ToString(string format)
        {
            return this._id.ToString(format);
        }

    }
}