namespace CsvDemo.Services.Base
{
    /// <summary>
    /// Represents the result of a service execution
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// Indicates if the execution was successful
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Indicates the reason why the execution failed
        /// </summary>
        public string? Message { get; set; }
    }

    /// <summary>
    /// Represents the result of a service execution
    /// </summary>
    /// <typeparam name="T">Type of data result</typeparam>
    public class ServiceResult<T> : ServiceResult
    {
        /// <summary>
        /// Result data by service execution
        /// </summary>
        public T? Data { get; set; }
    }
}
