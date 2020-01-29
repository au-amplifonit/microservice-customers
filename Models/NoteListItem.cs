using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fox.Microservices.Customers.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fox.Microservices.Customers.Models
{
	public class NoteListItem: NoteBase
	{
		public string ActivityTypeDescription { get; set; }
		public string EmployeeDescription { get; set; }
		public string DocumentTypeDescription { get; set; }

		public override void LoadData<T>(DbContext context, dynamic entity)
		{
			base.LoadData<T>(context, (T)entity);
			CustomersContext DBContext = (CustomersContext)context;

			if (entity is CU_B_NOTE)
			{
				CU_B_NOTE Item = (CU_B_NOTE)entity;
				ActivityTypeDescription = Item.SY_ACTIVITY_TYPE?.ACTIVITY_TYPE_DESCR;
				if (Item.EMPLOYEE_CODE != null)
					EmployeeDescription = DBContext.CM_S_EMPLOYEE.FirstOrDefault(E => E.EMPLOYEE_CODE == Item.EMPLOYEE_CODE)?.EMPLOYEE_DESCR;
				DocumentTypeDescription = Item.SY_DOCUMENT_TYPE?.DOCUMENT_TYPE_DESCR;
			}
		}
	}
}
