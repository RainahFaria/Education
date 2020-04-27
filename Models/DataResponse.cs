namespace Education.Models
{
  public class DataResponse<T>
  {
    /// <summary>
    /// success or error
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Message to be printed at client side
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Data to be manipuled at client side
    /// </summary>
    public T Data { get; set; }
  }
}
