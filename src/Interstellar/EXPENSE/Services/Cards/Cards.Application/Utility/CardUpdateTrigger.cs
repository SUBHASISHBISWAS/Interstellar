using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.Utility
{
    /// <summary>
    /// Utility class for triggering an event every 24 hours at a specified time of day
    /// </summary>
    public class CardUpdateTrigger : IDisposable
    {
        /// <summary>
        /// Time of day (from 00:00:00) to trigger
        /// </summary>
        TimeSpan TriggerHour { get; }

        /// <summary>
        /// Task cancellation token source to cancel delayed task on disposal
        /// </summary>
        CancellationTokenSource? CancellationToken { get; set; }

        /// <summary>
        /// Reference to the running task
        /// </summary>
        Task? RunningTask { get; set; }

        /// <summary>
        /// Initiator
        /// </summary>
        /// <param name="hour">The hour of the day to trigger</param>
        /// <param name="minute">The minute to trigger</param>
        /// <param name="second">The second to trigger</param>
        public CardUpdateTrigger(string cardId,int hour=0, int minute = 0, int second = 0)
        {
            TriggerHour = new TimeSpan(hour, minute, second);
            CancellationToken = new CancellationTokenSource();
            RunningTask = Task.Run(async () =>
            {
                while (true)
                {
                    var triggerTime = DateTime.Now + TriggerHour - DateTime.Now;
                    if (triggerTime < TimeSpan.Zero)
                        triggerTime = triggerTime.Add(new TimeSpan(24, 0, 0));
                    await Task.Delay(triggerTime, CancellationToken.Token);
                    OnTimeTriggered?.Invoke(cardId);
                }
            }, CancellationToken.Token);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            CancellationToken?.Cancel();
            CancellationToken?.Dispose();
            CancellationToken = null;
            RunningTask?.Dispose();
            RunningTask = null;
        }

        /// <summary>
        /// Triggers once every 24 hours on the specified time
        /// </summary>
        public event Action<string>? OnTimeTriggered;

        /// <summary>
        /// Finalized to ensure Dispose is called when out of scope
        /// </summary>
        ~CardUpdateTrigger() => Dispose();
    }
}
