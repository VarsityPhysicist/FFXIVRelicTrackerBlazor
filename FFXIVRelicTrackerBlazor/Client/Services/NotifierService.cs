using FFXIVRelicTrackerBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Services
{
    public class NotifierService
    {
        public event Func<Task> Notify;

        private Character character;
        public Character Character { get=>character; set { character = value; } }

        public async void SetCharacter(Character character)
        {
            this.character = character;
            if (Notify != null)
            {
                await Notify?.Invoke();
            }
        }

        public async void TestNotify()
        {
            if(Notify != null)
            {
                await Notify?.Invoke();
            }
        }
    }
}
