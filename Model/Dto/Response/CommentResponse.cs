namespace tropsly_api.Model.Dto.Response
{
    public class CommentResponse
    {
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public DateTime DateTime { get; set; }
        public int ProductId { get; set; }
    }
}
