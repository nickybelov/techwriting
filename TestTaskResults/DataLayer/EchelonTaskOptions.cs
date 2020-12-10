using System;
using Kontur.Core.Binary.Serialization;
using Kontur.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Kontur.Echelon
{
	/// <summary>
	/// A class that describes the options of a task.
	/// It extends the IBinarySerializable interface.
	/// </summary>
    public class EchelonTaskOptions : IBinarySerializable
    {
		/// <summary>
		/// Sets a readonly instance of an exponential retry strategy as a default retry strategy.
		/// </summary>
        private static readonly EchelonRetry[] DefaultRetry = {EchelonRetry.Exponential()};
		
		/// <summary>
		/// Sets a readonly instance of the default task options.
		/// </summary>
        public static readonly EchelonTaskOptions Default = new EchelonTaskOptions();

		/// <summary>
		/// A base public constructor that takes EchelonRetry[] retryStrategies, int maxAttempts, int initialDelaySeconds, int timeToLiveSeconds, int priority as parameters and assigns them to the corresponding field and properties of the class.
		/// If a parameter maxAttemps is not passed to a constructor, it is assigned 5 by default.
		/// If a parameter initialDelaySeconds is not passed to a constructor, it is assigned 0 by default.
		/// If a parameter timeToLiveSeconds is not passed to a constructor, it is assigned -1 by default.
		/// If a parameter priority is not passed to a constructor, it is assigned 0 by default.
		/// If retryStrategies equals null or retryStrategies.Length equals 0 then RetryStrategies is assigned DefaultRetry. Otherwise, it is assigned retryStrategies.
		/// </summary>
        public EchelonTaskOptions(
            EchelonRetry[] retryStrategies,
            int maxAttempts = 5,
            int initialDelaySeconds = 0,
            int timeToLiveSeconds = -1,
            int priority = 0
        )
        {
            RetryStrategies = (retryStrategies == null || retryStrategies.Length == 0) ? DefaultRetry : retryStrategies;
            MaxAttempts = maxAttempts;
            InitialDelaySeconds = initialDelaySeconds;
            TimeToLiveSeconds = timeToLiveSeconds;
            Priority = priority;
        }

		/// <summary>
		/// A public constructor that takes EchelonRetryStrategy retryStrategy, int retryDelaySeconds, int maxAttempts, int initialDelaySeconds, int timeToLiveSeconds, int priority as parameters.
		/// It creates a new Echelon retry[], based on EchelonRetryStrategy retryStrategy, int retryDelaySeconds, int maxAttempts, and passes it along with int maxAttempts, int initialDelaySeconds, int timeToLiveSeconds, int priority to the base constructor.
		/// </summary>
        public EchelonTaskOptions(
            EchelonRetryStrategy retryStrategy,
            int retryDelaySeconds,
            int maxAttempts = 5,
            int initialDelaySeconds = 0,
            int timeToLiveSeconds = -1,
            int priority = 0)
            : this(
                new[] {new EchelonRetry(retryStrategy, retryDelaySeconds, maxAttempts)},
                maxAttempts,
                initialDelaySeconds,
                timeToLiveSeconds,
                priority)
        {
        }
		/// <summary>
		/// A public constructor that calls to the previous constructor and passes DefaultRetry strategy as a retryStrategy and 5 as retryDelaySeconds.
		/// </summary>
        public EchelonTaskOptions()
            : this(DefaultRetry, 5)
        {
        }

		/// <summary>
		/// A private Constructor that takes EchelonRetry[] retryStrategies, EchelonRetryStrategy? retryStrategy, int? retryDelaySeconds, int? maxAttempts, int? initialDelaySeconds, int? timeToLiveSeconds, int? priority as parameters.
		/// Then it checks whether retryStrategies equal null.
		/// If it does, it checks whether retryStrategy, retryDelaySeconds and maxAttemps equal null. If they do, they are assigned EchelonRetryStrategy.Exponential, 600, 5 correspondingly.
		/// This way, a new EchelonRetry is set, with Exponential retry strategy as a retry Strategy, 600 retry delay second and 5 max attempts.
		/// Then the constructor checks whether maxAttempts, initialDelaySeconds, timeToLiveSeconds, priority equal null
		/// If they do equal null, they are assigned 5, 0, -1, 0 correspondingly.
		/// </summary>
        [JsonConstructor]
        private EchelonTaskOptions(
            EchelonRetry[] retryStrategies,
            EchelonRetryStrategy? retryStrategy,
            int? retryDelaySeconds,
            int? maxAttempts,
            int? initialDelaySeconds,
            int? timeToLiveSeconds,
            int? priority)
            : this(
                retryStrategies ?? new[]
                {
                    new EchelonRetry(
                        retryStrategy ?? EchelonRetryStrategy.Exponential,
                        retryDelaySeconds ?? 600,
                        maxAttempts ?? 5)
                },
                maxAttempts ?? 5,
                initialDelaySeconds ?? 0,
                timeToLiveSeconds ?? -1,
                priority ?? 0
            )
        {
        }

		/// <summary>
		/// Returns an initial delay timespan for the current task.
		/// </summary>
        [JsonProperty(PropertyName = "initialDelaySeconds")]
        public int InitialDelaySeconds { get; private set; }

		/// <summary>
		/// Returns an existance timespan for the current task.
		/// </summary>
        [JsonProperty(PropertyName = "ttlSeconds")]
        public int TimeToLiveSeconds { get; private set; }

		///<summary>
		/// Returns a priority of the current task.
		///</summary>
        [JsonProperty(PropertyName = "priority", DefaultValueHandling = DefaultValueHandling.Populate)]
        public int Priority { get; private set; }

		/// <summary>
		/// Returns a max amount of attempts for the current task.
		/// </summary>
        [JsonProperty(PropertyName = "maxAttempts")]
        public int MaxAttempts { get; private set; }

		/// <summary>
		/// Returns the BaseDelaySeconds of the first RetryStrategy in the RetryStrategies array.
		/// </summary>
        [JsonProperty(PropertyName = "retryDelaySeconds")]
        public int RetryDelaySeconds => RetryStrategies[0].BaseDelaySeconds;

		/// <summary>
		/// Returns the first RetryStrategy in the RetryStrategies array.
		/// </summary>
        [JsonProperty(PropertyName = "retryStrategy")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EchelonRetryStrategy RetryStrategy => RetryStrategies[0].RetryStrategy;

		/// <summary>
		/// Returns an array of retry strategies for the current task.
		/// </summary>
        [JsonProperty(PropertyName = "retryStrategies")]
        public EchelonRetry[] RetryStrategies { get; private set; }

 
    }
}
