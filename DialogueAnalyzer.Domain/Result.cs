namespace DialogueAnalyzer.Domain
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }

        public T? Value { get; private set; }

        public string ErrorCode { get; private set; }

        public string ErrorMessage { get; private set; }

        private Result(bool issuccess, T? value, string errorcode, string errormessage)
        {
            IsSuccess = issuccess;
            Value = value;
            ErrorCode = errorcode;
            ErrorMessage = errormessage;
        }

        public static Result<T> Success(T value) //сделать проверку на null 
        {
            return new Result<T>(true, value, null, null);
        }

        public static Result<T> Failure(string errorCode, string errorMessage)
        {
            return new Result<T>(false, default(T), errorCode, errorMessage);
        }
    }
}
