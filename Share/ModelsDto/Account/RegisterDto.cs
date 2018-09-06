namespace paneleo.Share.ModelsDto.Account
{
    public class RegisterDto : DtoBaseModel
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
