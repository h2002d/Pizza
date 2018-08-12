using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaserArt.Models
{
    public class JsonObjects
    {
    }
    public class RegisterResponse
    {
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
        public string orderId { get; set; }
        public string formUrl { get; set; }
    }
    public class ApproveResponse
    {
        public int errorCode { get; set; }
        public string OrderNumber { get; set; }
        public string OrderStatus { get; set; }
    }
}