using Fox.Microservices.Customers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;

namespace Fox.Microservices.Customers.Models
{
	public class Attachment : AttachmentBase
	{
		[FieldMapper(nameof(CM_B_ATTACHMENT_ARCHIVE.ATTACHMENT))]
		public byte[] AttachmentData { get; set; }

		public override void LoadData<T>(DbContext context, dynamic entity)
		{
			base.LoadData<T>(context, (T)entity);
			if (entity is CM_B_ATTACHMENT && context != null)
			{
				CustomersContext DBContext = (CustomersContext)context;

				long counter = entity.ATTACHMENT_COUNTER;
				string shop = entity.SHOP_CODE;
				CM_B_ATTACHMENT_ARCHIVE AttachmentArchive = DBContext.CM_B_ATTACHMENT_ARCHIVE.FirstOrDefault(E => E.ATTACHMENT_COUNTER == counter && E.SHOP_CODE == shop);
				AttachmentData = AttachmentArchive?.ATTACHMENT;
			}
		}

		public override void SaveData<T>(DbContext context, dynamic entity)
		{
			base.SaveData<T>(context, (T)entity);

			CustomersContext DBContext = (CustomersContext)context;

			CM_B_ATTACHMENT_ARCHIVE ItemArchive = EntityMapper.CreateEntity<CM_B_ATTACHMENT_ARCHIVE>();
			EntityMapper.UpdateEntity(this, ItemArchive);
			ItemArchive.ATTACHMENT_COUNTER = entity.ATTACHMENT_COUNTER;
			DBContext.CM_B_ATTACHMENT_ARCHIVE.Add(ItemArchive);
		}
	}
}
