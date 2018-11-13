using SweetTextV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetTextV2.Services
{
    public interface ISweetMessageService
    {
        IMessage GetNextMessage();
    }
}