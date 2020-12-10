namespace Kontur.Echelon
{
	/// <summary>
	/// An enumeration that lists the three echelon retry strategies: Linear, Exponential and LinearBackoff.
	/// </summary>
	public enum EchelonRetryStrategy : byte
	{
		Linear = 0,
		Exponential = 1,
        LinearBackoff = 2
	}
}