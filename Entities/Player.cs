namespace Entities
{
	public class Player: Entity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int JerseyNumber { get; set; }
		public int? TeamId { get; set; }

		public Player(string firstName, string lastName, int jerseyNumber, int? teamId = null)
		{
			FirstName = firstName;
			LastName = lastName;
			JerseyNumber = jerseyNumber;
			TeamId = teamId;
		}

	}
}
