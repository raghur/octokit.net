namespace Octokit.Response
{
    public class FileInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods")]
        public string Type { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Sha { get; set; }
        public string Url { get; set; }
    }
}