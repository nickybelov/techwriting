using System;
using System.Net;
using Kontur.Core.Binary.Serialization;
using Newtonsoft.Json;

namespace Kontur.Echelon
{
	/// <summary>
	/// A class that provides an additional task information.
	/// It extends the IBinarySerializable interface.
	/// </summary>
	public class EchelonTaskMeta : IBinarySerializable
	{
		/// <summary>
		/// A constructor that takes long creationTimeUtc, long executionTimeUtc, int attemptsUsed, string producerIdentity, IPAddress producerIp, string producerTopology as parameters and assigns them to the corresponding properties of the class.
		/// </summary>
		public EchelonTaskMeta(
            long creationTimeUtc, 
            long executionTimeUtc, 
            int attemptsUsed, 
            string producerIdentity, 
            IPAddress producerIp, 
            string producerTopology)
		{
		    ProducerTopology = producerTopology;
		    CreationTimeUtc = creationTimeUtc;
			ExecutionTimeUtc = executionTimeUtc;
			AttemptsUsed = attemptsUsed;
			ProducerIdentity = producerIdentity;
			ProducerIP = producerIp;
		}

		/// <summary>
		/// Provides the time of task creation, in accordance with the UTC.
		/// </summary>	
		[JsonProperty(PropertyName = "creationTimeUtc", Required = Required.Always)]
		public long CreationTimeUtc { get; private set; }

		/// <summary>
		/// Provides the time of task execution, in accordance with the UTC.
		/// </summary>
		[JsonProperty(PropertyName = "executionTimeUtc", Required = Required.Always)]
		public long ExecutionTimeUtc { get; private set; }

		/// <summary>
		/// Provides the number of attempts, attached to the task.
		/// </summary>
		[JsonProperty(PropertyName = "attemptsUsed", Required = Required.Always)]
		public int AttemptsUsed { get; private set; }

		/// <summary>
		/// Provides the identity of a task producer.
		/// </summary>
		[JsonProperty(PropertyName = "producerIdentity", Required = Required.Always)]
		public string ProducerIdentity { get; private set; }

		/// <summary>
		/// Provides the IP address of a task producer.
		/// </summary>
		[JsonProperty(PropertyName = "producerIP", Required = Required.Always)]
		[JsonConverter(typeof(IPAddressConverter))]
		public IPAddress ProducerIP { get; private set; }

		/// <summary>
		/// Provides the topology of a task producer.
		/// </summary>
        [JsonProperty(PropertyName = "producerTopology", Required = Required.Always)]
        public string ProducerTopology { get; private set; }

	}
}
