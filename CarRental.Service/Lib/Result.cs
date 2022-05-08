namespace CarRental.Service.Lib
{
    public class Result
    {
        public string message { get; set; }

        public object result { get; set; }

        public string code { get; set; }

        public static Result GetResult(object result = null, string message = null)
        {
            Result oResult = new Result()
            {
                code = "0",
                message = message == null ? "success" : message,
                result = result
            };
            return oResult;
        }
    }
}