using System;

namespace Utils
{
	public static class DateTimeExtencions
	{
		public static bool IsBetween(this DateTime now, DateTime from, DateTime to){
			return (now > from && now < to);
		}
	}
}