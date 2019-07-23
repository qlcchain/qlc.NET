using Qlc.Net;
using System;

namespace Qlc.Services
{
    public abstract class QlcService
    {
        protected readonly IQlcNetClient netClient;

        public QlcService(IQlcNetClient netClient)
        {
            this.netClient = netClient ?? throw new ArgumentNullException(nameof(netClient));
        }

        private int id = 1;
        protected int GetNextId()
        {
            return id++;
        }
    }
}
