using Datumation.Management.Models;

namespace Datumation.ViewModels {
    public class VideoVM {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StreamingCategory Category {get; set;}
    }
}