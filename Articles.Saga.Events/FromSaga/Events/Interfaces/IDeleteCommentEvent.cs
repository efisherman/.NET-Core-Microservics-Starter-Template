using System;

namespace Articles.Saga.Events.FromSaga.Events.Interfaces
{
    public interface IDeleteCommentEvent
    {
        Guid CorrelationId { get; }
    }
}
