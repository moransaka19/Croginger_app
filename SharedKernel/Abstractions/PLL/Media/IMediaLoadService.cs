using System.Threading.Tasks;

namespace SharedKernel.Abstractions.PLL.Media
{
    public interface IMediaLoadService
    {
        Task<bool> UploadFileAsync(string fullFilePath, string roomUniqName);
        Task<bool> DownloadFileAsync(string mediaName, string blobFileName, string playlistFolderPath, string roomUniqName);
    }
}