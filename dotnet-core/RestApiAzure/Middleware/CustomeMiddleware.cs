namespace RestApiAzure.Middleware;

public class CustomeMiddleware
{
    private readonly RequestDelegate next;

    public CustomeMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // before processing request

        await next(context);

        // after processing request
    }
}
