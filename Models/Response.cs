using System.ComponentModel.DataAnnotations;

namespace demo.Models;

public class Response<T>
{
    public string code { get; set; }
    public string message { get; set; }
    public List<T> data { get; set; } = null!;
}
