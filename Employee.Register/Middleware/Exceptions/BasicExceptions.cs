namespace Employee.Register.Middleware.Exceptions
{
    public class BasicExceptions
    {
        public class ConflictException : ApplicationException
        {
            public ConflictException(string message) : base(message)
            {
            }
        }

        public class NotFoundException : ApplicationException
        {
            public NotFoundException(string message) : base(message)
            {
            }
        }

        public class BadRequestException : ApplicationException
        {
            public List<ComponentErrorDetail> Errors { get; private set; }

            public BadRequestException() : base()
            {
            }

            public BadRequestException(List<ComponentErrorDetail> errors) : base()
            {
                Errors = errors;
            }
        }

        public class ForbiddenException : ApplicationException
        {
            public ForbiddenException(string message) : base(message)
            {
            }
        }

        public class InternalServerErrorException : ApplicationException
        {
            public ServerErrorModel serverError { get; set; }
            public InternalServerErrorException(ServerErrorModel serverError) : base()
            {
                this.serverError = serverError;
            }
        }

        public class UnauthorizedException : ApplicationException
        {
            public UnauthorizedException(string message) : base(message)
            {
            }
        }

        public class PreconditionFailedException : ApplicationException
        {
            public PreconditionFailedException(string message) : base(message)
            {
            }
        }

        public class TimeOutException : ApplicationException
        {
            public TimeOutException(string message) : base(message)
            {

            }
        }

        public class JsonSerializationException : ApplicationException
        {
            public JsonSerializationException() : base()
            {
            }
        }
    }
}
