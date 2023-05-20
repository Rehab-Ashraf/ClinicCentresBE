
namespace ClinicCentres.Models.Images
{
    public class ImagesModel
    {
        public int Id { get; set; }
        public byte[] ImageBytes { get; set; }
        public int PostId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
