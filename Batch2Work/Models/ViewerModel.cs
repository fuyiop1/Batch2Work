namespace Batch2Work.Models
{
    public class ViewerModel
    {
        public ViewerModel(string fileUrl)
        {
            FileUrl = fileUrl;
        }

        public string FileUrl { get; set; } 
    }
}