using System;
using System.Threading.Tasks;

namespace Kontur.Echelon
{
	/// <summary>
	/// An interface for handling tasks
	/// </summary>
    public interface IEchelonTaskHandle
    {
		/// <summary>
		/// Returns the current Task.
		/// </summary>
        EchelonTask Task { get; }

		/// <summary>
		/// Returns the options of the current Task.
		/// </summary>
        EchelonTaskOptions Options { get; }

		/// <summary>
		/// Returns the meta of the current Task.
		/// </summary>
        EchelonTaskMeta Meta { get; }

		/// <summary>
		/// An asynchronous method that prolongs task execution for a set period of time.
		/// It takes TimeSpan timeout as a parameter and returns a Task of type EchelonAcknowledgeResult, which can be assigned Success, ServiceUnavailable, Unauthenticated, UnknownError.
		/// </summary>
        Task<EchelonAcknowledgeResult> AcknowledgeAsync(TimeSpan timeout);

		/// <summary>
		/// An asynchronous method that prolongs task execution for a set period of time.
		/// It takes TimeSpan duration as a parameter and returns a Task of type EchelonProlongResult, which can be assigned Success, TaskNotFound, TaskIsNotWaiting, ServiceUnavailable, Unauthenticated, UnknownError.
		/// </summary>
        Task<EchelonProlongResult> ProlongExecutionAsync(TimeSpan duration);

		/// <summary>
		/// An asynchronous method that prolongs task execution.
		/// It returns a Task of type EchelonProlongResult, which can be assigned Success, TaskNotFound, TaskIsNotWaiting, ServiceUnavailable, Unauthenticated, UnknownError.
		/// </summary>
        Task<EchelonProlongResult> ProlongExecutionAsync();

		/// <summary>
		/// An asynchronous method that postpones task execution for a set period of time.
		/// It takes TimeSpan duration as a parameter and returns a Task of type EchelonPostponeResult, which can be assigned Success, TaskNotFound, ServiceUnavailable, Unauthenticated, UnknownError.
		/// </summary>
        Task<EchelonPostponeResult> PostponeAsync(TimeSpan duration);

		/// <summary>
		/// An asynchronous method that postpones task execution.
		/// It returns a Task of type EchelonPostponeResult, which can be assigned Success, TaskNotFound, ServiceUnavailable, Unauthenticated, UnknownError
		/// </summary>
        Task<EchelonPostponeResult> PostponeAsync();
    }
}