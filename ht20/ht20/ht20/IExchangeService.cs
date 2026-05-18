using System;
using System.Collections.Generic;
using System.Text;

namespace ht20
{
    public interface IExchangeService
    {
        decimal GetCurrentPrice(string symbol);
    }
}
