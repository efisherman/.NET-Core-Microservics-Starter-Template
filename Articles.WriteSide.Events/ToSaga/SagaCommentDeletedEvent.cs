using Articles.WriteSide.Events.ToSaga.Interfaces;
using System;

namespace Articles.WriteSide.Events.ToSaga
{
	public class SagaCommentDeletedEvent : ISagaCommentDeletedEvent
	{
		public Guid AggregateId { get; set; }
	}
}
