using System.Text.Json.Nodes;

namespace Larin.JsonRPC;

/// <summary>
/// Represents a JSON-RPC response error information
/// </summary>
/// <remarks>https://www.jsonrpc.org/specification#error_object</remarks>
public sealed class JrpcError
{
	/// <summary>
	/// The predefined instance for the "Parse error" (-32700)
	/// </summary>
	public static readonly JrpcError ParseError = new(-32700, "Parse error", null);

	/// <summary>
	/// The predefined instance for the "Invalid request" (-32600)
	/// </summary>
	public static readonly JrpcError InvalidRequest = new(-32600, "Invalid request", null);

	/// <summary>
	/// The predefined instance for the "Method not found" (-32601)
	/// </summary>
	public static readonly JrpcError MethodNotFound = new(-32601, "Method not found", null);

	/// <summary>
	/// The predefined instance for the "Invalid params" (-32602)
	/// </summary>
	public static readonly JrpcError InvalidParams = new(-32602, "Invalid params", null);

	/// <summary>
	/// The predefined instance for the "Internal error" (-32700)
	/// </summary>
	public static readonly JrpcError InternalError = new(-32603, "Internal error", null);

	/// <summary>
	/// Instantiates a new <see cref="JrpcError"/>> instance with the specified error infrormation.
	/// </summary>
	/// <param name="code">The error code</param>
	/// <param name="message">The error message</param>
	/// <param name="data">An optional error details</param>
	public JrpcError(int code, string message, JsonNode? data)
	{
		Code = code;
		Message = message;
		Data = data;
	}

	/// <summary>
	/// The error code
	/// </summary>
	public int Code { get; }

	/// <summary>
	/// The error message
	/// </summary>
	public string Message { get; }

	/// <summary>
	/// An optional error details
	/// </summary>
	public JsonNode? Data { get; }

	/// <summary>
	/// Creates a new <see cref="JrpcError"/> instance with the code and the message from this object and with the given error details
	/// </summary>
	/// <param name="data">A new error details</param>
	/// <returns>A newly created <see cref="JrpcError"/> instance</returns>
	public JrpcError CopyWithData(JsonNode? data)
	{
		return new JrpcError(Code, Message, data);
	}

	/// <summary>
	/// Returns a String which represents the object instance.
	/// </summary>
	/// <returns>A string that represents the current object.</returns>
	public override string ToString()
	{
		return $"Code = {Code}, Message = \"{Message}\", Data = { Data ?? "null"}";
	}
}