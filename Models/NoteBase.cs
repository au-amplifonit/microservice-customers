using Fox.Microservices.Customers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Models;

namespace Fox.Microservices.Customers.Models
{
	public class NoteBase: ModelBase
	{
		[FieldMapper(nameof(CU_B_NOTE.CUSTOMER_CODE))]
		public string CustomerCode { get; set; }

		[FieldMapper(nameof(CU_B_NOTE.NOTE_COUNTER))]
		public int	NoteCounter { get; set; }

		[FieldMapper(nameof(CU_B_NOTE.NOTE_DATE))]
		public DateTime Date { get; set; }

		[FieldMapper(nameof(CU_B_NOTE.FLG_RESERVED))]
		public bool IsReserved { get; set; } = false;

		[FieldMapper(nameof(CU_B_NOTE.ACTIVITY_TYPE_CODE))]
		public string ActivityTypeCode { get; set; }

		[FieldMapper(nameof(CU_B_NOTE.APPOINTMENT_ID))]
		public string AppointmentId { get; set; }

		[FieldMapper(nameof(CU_B_NOTE.SUBJECT))]
		public string Subject { get; set; }

		[FieldMapper(nameof(CU_B_NOTE.NOTE))]
		public string Description { get; set; }

		[FieldMapper(nameof(CU_B_NOTE.EMPLOYEE_CODE))]
		public string EmployeeCode { get; set; }

		[FieldMapper(nameof(CU_B_NOTE.DOCUMENT_TYPE_CODE))]
		public string DocumentTypeCode { get; set; }

		[FieldMapper(nameof(CU_B_NOTE.DOCUMENT_NUMBER))]
		public string DocumentNumber { get; set; }

		[FieldMapper(nameof(CU_B_NOTE.DOCUMENT_DATE))]
		public DateTime DocumentDate { get; set; }
	}
}
