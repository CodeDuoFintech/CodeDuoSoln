//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeDuo.MobileApi.DataAccess
{
    using System;
    
    public partial class GetTransactionListByUserId_Result
    {
        public int TransactionId { get; set; }
        public int MerchantId { get; set; }
        public int UserId { get; set; }
        public string MerchantReference { get; set; }
        public string FromAccountId { get; set; }
        public string ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IBAN { get; set; }
        public string AccountId { get; set; }
        public string Type { get; set; }
    }
}
