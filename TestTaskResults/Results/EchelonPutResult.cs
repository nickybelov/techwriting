namespace Kontur.Echelon
{
	/// <summary>
	/// An enumeration that lists the six possible outcomes of putting a task result to a queue: Success, ConflictingId, IncorrectArguments, ServiceUnavailable, Unauthenticated, UnknownError.
	/// </summary>
    public enum EchelonPutResult
    {
        Success = 0,
        ConflictingId = 1,
        IncorrectArguments = 2,
        ServiceUnavailable = 3,
        Unauthenticated = 4,
        UnknownError = 5
    }
}