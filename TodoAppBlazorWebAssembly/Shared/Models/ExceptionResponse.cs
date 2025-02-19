using System.Net;

namespace TodoAppBlazorWebAssembly.Shared.Models
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}
