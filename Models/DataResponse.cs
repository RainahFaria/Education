namespace Education.Models
{
  public class DataResponse
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
    public object Data { get; set; }
  }
}
