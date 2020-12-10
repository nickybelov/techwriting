namespace Kontur.Echelon
{
	/// <summary>
	/// An enumeration that lists the six possible outcomes of attempting to prolong the task result's staying in the queue: Success, TaskNotFound, TaskIsNotWaiting, ServiceUnavailable, Unauthenticated, UnknownError.
	/// </summary>
    public enum EchelonProlongResult
    {
        Success = 0,
        TaskNotFound = 1,
        TaskIsNotWaiting = 2,
        ServiceUnavailable = 3,
        Unauthenticated = 4,
        UnknownError = 5
    }
}