using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDA_Core.Entities
{
    public partial class TicketContext : DbContext
    {
        public TicketContext(string connectionString)
        {
            
        }
    }
}
