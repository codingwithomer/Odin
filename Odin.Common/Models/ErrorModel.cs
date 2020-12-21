using System.Collections.Generic;

namespace Odin.Common.Models
{
    public class ErrorModel
    {
        public List<string> Errors { get; set; }
        public string Message { get; set; }

        public ErrorModel(params string[] errors)
        {
            Errors = new List<string>(errors);
        }

        public ErrorModel(List<string> errors)
        {
            Errors = errors;
        }
    }
}
