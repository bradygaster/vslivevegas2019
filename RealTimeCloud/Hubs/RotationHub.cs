using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace RealTimeCloud.Hubs
{
    public class RotationHub : Hub
    {
        private readonly ILogger<RotationHub> _logger;

        public RotationHub(ILogger<RotationHub> logger)
        {
            _logger = logger;
        }

        public async Task LockAxis(string axis)
        {
            _logger.LogInformation("LockAxis", axis);
            await Clients.Others.SendAsync("controlLocked", axis);
        }

        public async Task UnlockAxis(string axis)
        {
            _logger.LogInformation("UnlockAxis", axis);
            await Clients.Others.SendAsync("controlUnlocked", axis);
        }

        public async Task RotateOnAxis(string axis, string value)
        {
            _logger.LogInformation("RotateOnAxis", axis);
            await Clients.Others.SendAsync("rotated", axis, value);
        }

        public async Task Rotate(double x, double y, double z)
        {
            await Clients.Others.SendAsync("fullyrotated", x, y, z );
        }
    }
}