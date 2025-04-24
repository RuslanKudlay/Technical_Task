using CommonLayer.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IPurchaseService
    {
        Task<bool> DoPurchaseAsync(PurchaseDto purchaseDto);
    }
}
