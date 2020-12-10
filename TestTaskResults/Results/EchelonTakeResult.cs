using System.Collections.Generic;

namespace Kontur.Echelon
{
	///<summary>
	/// A class that is used for taking task results from a queue.
	///</summary>
    public class EchelonTakeResult
    {
		/// <summary>
		/// An empty list of handles.
		/// </summary>
        private static readonly IList<IEchelonTaskHandle> emptyHandles = new IEchelonTaskHandle[] {};

		/// <summary>
		/// A list of the task handles.
		/// </summary>
        private readonly IList<IEchelonTaskHandle> taskHandles;

		/// <summary>
		/// A constructor that takes task status and task handles as parameters and assinges them to the corresponding fields and properties of the class.
		/// </summary>
        public EchelonTakeResult(EchelonTakeStatus status, IList<IEchelonTaskHandle> taskHandles)
        {
            Status = status;
            this.taskHandles = taskHandles;
        }

		/// <summary>
		/// Shows the status of fetching the current task.
		/// </summary>
        public EchelonTakeStatus Status { get; }

		/// <summary>
		/// Returns a list of the task handles if Status equals Success, a list of empty handles if Status equals NotFound and throws an exception if Status is of any other type, i.e. IncorrectArguments, ServiceUnavailable, Unauthenticated, UnknownError.
		/// </summary>
        public IList<IEchelonTaskHandle> TaskHandles
        {
            get
            {
                switch (Status)
                {
                    case EchelonTakeStatus.Success:
                        return taskHandles;
                    case EchelonTakeStatus.NotFound:
                        return emptyHandles;
                    default:
                        throw new EchelonException(Status);
                }
            }
        }

		/// <summary>
		/// Checks whether Status equals either Success or NotFound. 
		/// If it does, then IsSuccessful is assigned true. 
		/// </summary>
        public bool IsSuccessful()
        {
            return Status == EchelonTakeStatus.Success || Status == EchelonTakeStatus.NotFound;
        }

		/// <summary>
		/// Checks whether Status equals either Success or NotFound. 
		/// If it doesn't, an Exception is thrown, which can be of four types, depending on an actual Status, i.e. IncorrectArguments, ServiceUnavailable, Unauthenticated, UnknownError.
		/// </summary>
        public EchelonTakeResult EnsureSuccess()
        {
            if (!IsSuccessful())
                throw new EchelonException(Status);
            return this;
        }
    }
}