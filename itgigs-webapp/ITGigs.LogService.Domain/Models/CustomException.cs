using ITGigs.Common.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ITGigs.LogService.Domain.Models
{
    public class CustomException : Exception
    {
        private CustomId _id;

        public CustomException() { }
        public CustomException(Exception ex, CustomId id = null)
        {
            this.CustomMessage = ex.Message;
            this.CustomStackTrace = ex.StackTrace;
            this.CustomInnerMessage = ex.InnerException != null ? ex.InnerException.Message : String.Empty;
            this.CustomInnerStackTrace = ex.InnerException != null ? ex.InnerException.StackTrace : String.Empty;
            this.DateCreated = DateTime.Now;

            this._id = id ?? new CustomId();
        }
        
        [Key]
        public string Id
        {
            get { return this._id.ToString(); }
            private set { this._id = new CustomId(new Guid(value)); }
        }

        public string CustomMessage { get; set; }

        public string CustomStackTrace { get; set; }

        public string CustomInnerMessage { get; set; }

        public string CustomInnerStackTrace { get; set; }

        public DateTime DateCreated { get; set; }

        //public string Serialize()
        //{
        //    return JsonConvert.SerializeObject(this,
        //         Formatting.None,
        //         new JsonSerializerSettings
        //         {
        //             NullValueHandling = NullValueHandling.Ignore,
        //             MissingMemberHandling = MissingMemberHandling.Ignore
        //         });
        //}
    }
}
