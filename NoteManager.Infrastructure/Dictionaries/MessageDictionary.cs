using System.Collections.Generic;
using NoteManager.Infrastructure.Constants;
using NoteManager.Infrastructure.Enums;

namespace NoteManager.Infrastructure.Dictionaries
{
    public static class MessageDictionary
    {
        public static readonly IDictionary<EntityType, string> MessageToEntityType = new Dictionary<EntityType, string>
        {            
            {EntityType.Job, MessageConstants.InactiveJob}
        };
    }
}