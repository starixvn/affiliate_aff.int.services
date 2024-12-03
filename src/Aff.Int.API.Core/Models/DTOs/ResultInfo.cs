namespace Aff.Int.API.Core.Models.DTOs
{
    public class ResultInfo
    {
        public int ErrCode { get; set; }

        public string ErrMsg { get; set; }

        public bool IsSuccessful => ErrCode == 0;
    }
}
