using System.Text.Json.Serialization;

namespace Employee.Register.Middleware.Exceptions
{
    public class ComponentError
    {
        /// <summary>
        /// Lista de errores
        /// </summary>
        public List<ComponentErrorDetail> Errors { get; set; }

        public ComponentError()
        {
            Errors = new List<ComponentErrorDetail>();
        }

        public void AddModelError(string field, Exception ex, int? errorCode = null, string message = "")
        {
            Errors.Add(new ComponentErrorDetail() { Exception = ex, Field = field, Message = message, ErrorCode = errorCode });
        }

        [JsonIgnore]
        public bool IsValid
        {
            get { return !Errors.Any(); }
        }
    }

    public class ComponentErrorDetail
    {
        private string message = "";

        /// <summary>
        /// Mensaje de error
        /// </summary>
        public string Message
        {
            get
            {
                if (message == "" && Exception != null) return Exception.Message;
                return message;
            }
            set
            {
                message = value;
            }
        }

        [JsonIgnore]
        public Exception Exception { get; set; }

        /// <summary>
        /// Campo que genero el error
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Tipo de error: Validation | Business
        /// </summary>
        public string @Type
        {
            get
            {
                if (Exception == null) return "Validation";
                //if (Exception is BusinessException) return "Business";
                return "Validation";
            }
        }

        /// <summary>
        /// Codigo del error
        /// </summary>
        public int? ErrorCode { get; set; }

        public ComponentErrorDetail()
        {

        }

        public ComponentErrorDetail(string message)
        {
            Message = message;
        }

    }
}
