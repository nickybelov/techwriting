namespace Kontur.Echelon
{
	/// <summary>
	/// An enumeration that lists the six possible outcomes of fetching a task status from a queue: Success, NotFound, IncorrectArguments, ServiceUnavailable, Unauthenticated, UnknownError.
	/// </summary>
    public enum EchelonTakeStatus
    {
        Success = 0,
        NotFound = 1,
        IncorrectArguments = 2,
        ServiceUnavailable = 3,
        Unauthenticated = 4,
        UnknownError = 5
    }
}