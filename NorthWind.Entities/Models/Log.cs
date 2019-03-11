namespace NorthWind.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public enum LogType
    {
        DeleteCategory
    }
    public class Log
    {
        public int LogId { get; set; }  
        
        [Display(Name = "Date Time")]
        public DateTime DateTime { get; set; }
        public LogType Type { get; set; }
        public string Message { get; set; }
    }
}
