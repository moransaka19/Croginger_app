using System.Collections;
using System.Collections.Generic;

namespace SharedKernel.Extensions
{
	public static class IsNullOrEmptyExtensions
	{
		public static bool IsNullOrEmpty(this object item) => item == null;

		public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

		public static bool IsNullOrEmpty(this IEnumerable enumerable) => 
			!enumerable?.GetEnumerator().MoveNext() ?? true;
	}
}
