using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMobile.Models
{
	public class ReferenceNumberType
    {
		public string Name { get; set; }
		public bool IsScanRequired { get; set; }
		public bool IsBOL { get; set; }
    }

    public class ReferenceNumber
    {
		public long ReferenceNumberTypeId { get; set; }
		public string ReferenceNumberTypeName { get; set; }
		public string Number { get; set; }
		public bool? IsModified { get; set; }
		public long? OrderId { get; set; }
		public long? OrderMasterId { get; set; }
		public long? InvoiceId { get; set; }
		public string ExternalScanId { get; set; }
		public bool? ExternalScanIsDeliveryDocument { get; set; }
		public ReferenceNumberType ReferanceNumberType { get; set; }

	}
}
