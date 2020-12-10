namespace Kontur.Echelon
{
	/// <summary>
	/// An enumeration that lists the five possible outcomes of postponing fetching the task result from the queue: Success, TaskNotFound, ServiceUnavailable, Unauthenticated, UnknownError.
	/// </summary>
    public enum EchelonPostponeResult
    {
        Success = 0,
        TaskNotFound = 1,
        ServiceUnavailable = 2,
        Unauthenticated = 3,
        UnknownError = 4
    }
}