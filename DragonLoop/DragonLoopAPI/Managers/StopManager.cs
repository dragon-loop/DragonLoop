using DragonLoopModels;
using System;

namespace DragonLoopAPI.Managers
{
    public class StopManager
    {
        /// <summary>
        /// Backtracks route segments to find previous stops and check for buses on this route that
        /// have last stopped there
        /// </summary>
        /// <param name="stop">The stop to find the next bus to arrive at</param>
        /// <returns>The next bus to arrive at the given stop</returns>
        public Bus GetNextBus(Stop stop)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Iterates through Schedules to find the next expected arrival time for the given stop
        /// after the given time
        /// </summary>
        /// <param name="stop">The stop to find the next expected time for</param>
        /// <param name="time">The time to start searching for next expected time from</param>
        /// <returns>The next expected time of a bus to the given stop</returns>
        public TimeSpan GetNextExpectedTime(Stop stop, TimeSpan time)
        {
            throw new NotImplementedException();
        }
    }
}
