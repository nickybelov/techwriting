using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kontur.Echelon
{
	/// <summary>
	/// An interface of an Echelon client.
	/// </summary>
    public interface IEchelonClient
    {
		/// <summary>
		/// An asynchronous method for putting a task result to a queue.
		/// </summary>
        Task<EchelonPutResult> PutAsync(IList<EchelonTask> tasks, EchelonTaskOptions options, TimeSpan timeout);

		/// <summary>
		/// An asynchronous method for taking a task result from a queue.
		/// </summary>
        Task<EchelonTakeResult> TakeAsync(int count, IList<string> taskTypes, TimeSpan timeout, bool includeMeta = false);

    }
}
