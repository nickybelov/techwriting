using Kontur.Core.Binary.Serialization
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Kontur.Echelon
{
	/// <summary>
	/// A class for creating instances of Echelon retry stategies.
	/// It extends the IBinarySerializable interface.
	/// </summary>
    public class EchelonRetry : IBinarySerializable
    {
		/// <summary>
		/// A constructor that takes EchelonRetryStrategy retryStrategy, int baseDelaySeconds and int attemptsCount as parameters and assinges them to the corresponding field and property of the class.
		/// </summary>
        [JsonConstructor]
        public EchelonRetry(EchelonRetryStrategy retryStrategy, int baseDelaySeconds, int attemptsCount)
        {
            AttemptsCount = attemptsCount;
            RetryStrategy = retryStrategy;
            BaseDelaySeconds = baseDelaySeconds;
        }

		/// <summary>
		///Shows a current echelon retry strategy.
		/// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EchelonRetryStrategy RetryStrategy { get; }

		/// <summary>
		/// Shows a number of attempts.
		/// </summary>
        public int AttemptsCount { get; }

		/// <summary>
		/// Shows a number of delay seconds.
		/// </summary>
        public int BaseDelaySeconds { get; }

		/// <summary>
		/// Creates a public static instance of an Echelon Retry Linear strategy using the base class constructor.
		/// </summary>
        public static EchelonRetry Linear(int baseDelaySeconds = 600, int attemptsCount = 5)
            => new EchelonRetry(EchelonRetryStrategy.Linear, baseDelaySeconds, attemptsCount);

		/// <summary>
		/// Creates a public static instance of an Echelon Retry Linear Backoff strategy using the base class constructor.
		/// </summary>
        public static EchelonRetry LinearBackoff(int baseDelaySeconds = 600, int attemptsCount = 5)
            => new EchelonRetry(EchelonRetryStrategy.LinearBackoff, baseDelaySeconds, attemptsCount);

		/// <summary>
		/// Creates a public static instance of an Echelon Retry Exponential strategy using the base class constructor.
		/// </summary>
        public static EchelonRetry Exponential(int baseDelaySeconds = 600, int attemptsCount = 5)
            => new EchelonRetry(EchelonRetryStrategy.Exponential, baseDelaySeconds, attemptsCount);

      
    }
}
