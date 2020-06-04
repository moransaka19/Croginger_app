using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Helpers
{
	public static class HashPasswordHelper
	{
		public static string GetPasswordHash(string password)
		{
			return SHA256.Create()
				.ComputeHash(Encoding.UTF8.GetBytes(password))
				.Aggregate(new StringBuilder(), (builder, b) => builder.Append(b.ToString("X2")))
				.ToString();
		}
	}
}
