﻿using EventStore.ClientAPI;
using System.Text;
using System.Text.Json;

namespace EventSourcing.Api.Common.EventStores
{
    public abstract class AbstractStream
    {
        protected readonly LinkedList<IEvent> Events = new();

        private string _streamName { get; }
        private readonly IEventStoreConnection _eventStoreConnection;

        protected AbstractStream(string streamName, IEventStoreConnection eventStoreConnection)
        {
            _streamName = streamName;
            _eventStoreConnection = eventStoreConnection;
        }

        public async Task SaveAsync()
        {
            var newEvents = Events.Select(x => new EventData(Guid.NewGuid(), x.GetType().Name, true, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(x, x.GetType())), Encoding.UTF8.GetBytes(x.GetType().FullName))).ToList();

            await _eventStoreConnection.AppendToStreamAsync(_streamName, ExpectedVersion.Any, newEvents);

            Events.Clear();
        }
    }
}
