namespace Angular2_Core_Vidly.Controllers.ApiModels
{
    public class MembershipTypeApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }        
    }
}