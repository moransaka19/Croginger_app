using SharedKernel.Abstractions.DAL.Models;
using System.Collections.Generic;

namespace SharedKernel.Abstractions.PLL.Media
{
	public interface IMediaService
    {
        IMedia GetMedia(string fullPath);
        IEnumerable<IMedia> GetMedia(params string[] fullPaths);
    }
}