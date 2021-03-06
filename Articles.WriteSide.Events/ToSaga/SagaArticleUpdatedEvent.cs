using Articles.WriteSide.Events.ToSaga.Interfaces;
using System; 

namespace Articles.WriteSide.Events.ToSaga
{
	public class SagaArticleUpdatedEvent : ISagaArticleUpdatedEvent
	{
		public Guid AggregateId { get; set; }
		public Guid CategoryId { get; set; }
		public string Title { get; set; }
		public string Abstract { get; set; }
		public string Body { get; set; }
		public string Country { get; set; }
		public string State { get; set; }
		public string City { get; set; }
		public DateTime ReleaseDate { get; set; }
		public DateTime ExpireDate { get; set; }
		public bool Approved { get; set; }
		public bool Listed { get; set; }
		public bool CommentsEnabled { get; set; }
		public bool OnlyForMembers { get; set; }
	}
}
