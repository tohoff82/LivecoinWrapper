using Newtonsoft.Json;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Withdraw
    {
        [JsonProperty("fault")]
        public string Fault { get; private set; }

        [JsonProperty("userId")]
        public string UserId { get; private set; }

        [JsonProperty("userName")]
        public string UserName { get; private set; }

        [JsonProperty("id")]
        public string WithdrawId { get; private set; }

        [JsonProperty("state")]
        public string State { get; private set; }

        [JsonProperty("createDate")]
        public string CreateDate { get; private set; }

        [JsonProperty("lastModifyDate")]
        public string LastModifyDate { get; private set; }

        [JsonProperty("verificationType")]
        public string VerificationType { get; private set; }

        [JsonProperty("verificationData")]
        public string VerificationData { get; private set; }

        [JsonProperty("comment")]
        public string Comment { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        [JsonProperty("amount")]
        public float Amount { get; private set; }

        [JsonProperty("currency")]
        public string Currency { get; private set; }

        [JsonProperty("accountTo")]
        public string AcountTo { get; private set; }

        [JsonProperty("acceptDate")]
        public string AcceptDate { get; private set; }

        [JsonProperty("valueDate")]
        public string ValueDate { get; private set; }

        [JsonProperty("docDate")]
        public string DocDate { get; private set; }

        [JsonProperty("docNumber")]
        public string DocNumber { get; private set; }

        [JsonProperty("correspondentDetails")]
        public string CorrespondentDetails { get; private set; }

        [JsonProperty("accountFrom")]
        public string AccountFrom { get; private set; }

        [JsonProperty("outcome")]
        public string Outcome { get; private set; }

        [JsonProperty("external")]
        public string External { get; private set; }

        [JsonProperty("externalKey")]
        public string ExternalKey { get; private set; }

        [JsonProperty("externalSystemId")]
        public string ExternalSystemId { get; private set; }

        [JsonProperty("externalServiceId")]
        public string ExternalServiceId { get; private set; }

        [JsonProperty("wallet")]
        public string Wallet { get; private set; }
    }
}
