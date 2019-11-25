using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WeatherFinder.Models
{
    public sealed class CustomException
    {
        public CustomException() { }

        public CustomException(Exception ex)
        {
            Id = Guid.NewGuid().ToString();
            CustomMessage = ex?.Message ?? String.Empty;
            CustomStackTrace = ex?.StackTrace != null ? PrettifyStackTrace(ex.StackTrace) : String.Empty;
            InnerMessage = ex?.InnerException != null ? ex.InnerException.Message : String.Empty;
            InnerStackTrace = ex?.InnerException != null ? ex.InnerException.StackTrace : String.Empty;
            InnerSource = ex?.InnerException != null ? ex.InnerException.Source : String.Empty;
            DateCreated = DateTime.Now;
        }

        [Key]
        public string Id { get; set; }
        public string CustomMessage { get; set; }
        public string CustomStackTrace { get; set; }
        public string InnerMessage { get; set; }
        public string InnerStackTrace { get; set; }
        public string InnerSource { get; set; }
        public DateTime DateCreated { get; set; }
        public string ClientErrorMessage { get { return CreateClientErrorMessage(); } set { CustomMessage = value; } }

        private string PrettifyStackTrace(string stackTrace)
        {
            return Regex.Replace(stackTrace, @"\t\n\r", Environment.NewLine);
        }

        private string CreateClientErrorMessage()
        {
            return
                $"Unexpected error with Id: {Id} has occured on the server. Message: {(string.IsNullOrEmpty(InnerMessage) ? CustomMessage : InnerMessage)}";
        }
    }
}
