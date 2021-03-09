namespace API.DTO
{
	public class PlayerDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int? JerseyNumber { get; set; }
		public int? TeamId { get; set; }
	}
}
