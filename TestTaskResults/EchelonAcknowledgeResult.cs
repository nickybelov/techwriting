namespace Kontur.Echelon
{
	/// <summary>
	/// An enumeration that lists the four possible outcomes of acknowledging the result of a task: Success, ServiceUnavailable, Unauthenticated, UnknownError.
	/// </summary>
    public enum EchelonAcknowledgeResult
    {
        Success = 0,
        ServiceUnavailable = 1,
        Unauthenticated = 2,
        UnknownError = 3
    }
}