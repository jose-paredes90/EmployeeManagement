namespace Employee.Register.Middleware.Exceptions
{
    public class ServerErrorModel
    {
        //public Exception? InnerException { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public ServerErrorModel(Exception exception)
        {
            //InnerException = exception?.InnerException;
            Message = exception?.Message;
            StackTrace = exception?.StackTrace;
        }
    }
}
