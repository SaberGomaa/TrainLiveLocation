using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Payment
    {
        [Column("PaymentId")]
        public int Id { get; set; }
        public string? BankName { get; set; }
        public int CardNumber { get; set; }
        public double Cost { get; set; }


        [ForeignKey(nameof(Ticket))]
        public int TicketId { get; set; }
        public virtual Ticket? Ticket { get; set; }
    }
}
