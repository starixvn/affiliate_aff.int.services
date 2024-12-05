using System.Text.Json.Serialization;

namespace Aff.Int.API.Core.Admin.Models.Home
{
    public class GeneralInfoModel
    {
        [JsonPropertyName("PaymentRequestNumber")]
        public int PaymentReqNum { get; set; }

        [JsonPropertyName("BannerNumber")]
        public int BannerNum { get; set; }

        public int PlayerBannerNum { get; set; }

        public int AffiliateBannerNum { get; set; }

        [JsonPropertyName("AllAffiliateNumber")]
        public int AffInProAllNum { get; set; }

        [JsonPropertyName("PendingAffiliateNumber")]
        public int PendingAllNum { get; set; }

        [JsonPropertyName("ApprovedAffiliateNumber")]
        public int ApprovedAllNum { get; set; }

        [JsonPropertyName("DisapprovedAffiliateNumber")]
        public int DisapprovedAllNum { get; set; }

        [JsonPropertyName("SuspendedAffiliateNumber")]
        public int SuspendedAllNum { get; set; }

        [JsonPropertyName("AllMemberDepositNumber")]
        public int DepositMemAllNum { get; set; }

        [JsonPropertyName("AllDepositNumber")]
        public decimal DepositAll { get; set; }

        [JsonPropertyName("AllGgrNumber")]
        public decimal GgrAll { get; set; }

        [JsonPropertyName("AllBonusNumber")]
        public decimal BonusAll { get; set; }

        [JsonPropertyName("AllRebateNumber")]
        public decimal RebateAll { get; set; }

        [JsonPropertyName("AllPSPFeeNumber")]
        public decimal PSPFeeAll { get; set; }

        [JsonPropertyName("AllNetWinlostNumber")]
        public decimal NetWinlostAll { get; set; }

        [JsonPropertyName("AllAffiliateMonthNumber")]
        public int AffInProMonthNum { get; set; }

        [JsonPropertyName("PendingAffiliateMonthNumber")]
        public int PendingMonthNum { get; set; }

        [JsonPropertyName("ApprovedAffiliateMonthNumber")]
        public int ApprovedMonthNum { get; set; }

        [JsonPropertyName("DisapprovedAffiliateMonthNumber")]
        public int DisapprovedMonthNum { get; set; }

        [JsonPropertyName("SuspendedAffiliateMonthNumber")]
        public int SuspendedMonthNum { get; set; }

        [JsonPropertyName("AllMemberDepositMonthNumber")]
        public int DepositMemMonthNum { get; set; }

        [JsonPropertyName("AllDepositMonthNumber")]
        public decimal DepositMonth { get; set; }

        [JsonPropertyName("AllGgrMonthNumber")]
        public decimal GgrMonth { get; set; }

        [JsonPropertyName("AllBonusMonthNumber")]
        public decimal BonusMonth { get; set; }

        [JsonPropertyName("AllRebateMonthNumber")]
        public decimal RebateMonth { get; set; }

        [JsonPropertyName("AllPSPFeeMonthNumber")]
        public decimal PSPFeeMonth { get; set; }

        [JsonPropertyName("AllNetWinlostMonthNumber")]
        public decimal NetWinlostMonth { get; set; }

        public int MemAllNum { get; set; }

        public int NonDepositMemAllNum { get; set; }

        public int MemMonthNum { get; set; }

        public int NonDepositMemMonthNum { get; set; }
    }
}
