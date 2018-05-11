using Solid05.DIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid05.DIP.Services
{
    public interface IOrderNotifier
    {
        Task NotifyOrderer(OrdererInfoModel orderer, double amount);
    }
}
