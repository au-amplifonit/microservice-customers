using Fox.Microservices.Customers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Models;

namespace Fox.Microservices.Customers.Models
{
	public class AttachmentBase : ModelBase
	{
		[FieldMapper(nameof(CM_B_ATTACHMENT.SHOP_CODE), typeof(CM_B_ATTACHMENT))]
		[FieldMapper(nameof(CM_B_ATTACHMENT_ARCHIVE.SHOP_CODE), typeof(CM_B_ATTACHMENT_ARCHIVE))]
		[JsonProperty(Order = -10)]
		public string ShopCode { get; set; }

		[FieldMapper(nameof(CM_B_ATTACHMENT.ATTACHMENT_COUNTER), typeof(CM_B_ATTACHMENT))]
		[FieldMapper(nameof(CM_B_ATTACHMENT_ARCHIVE.ATTACHMENT_COUNTER), typeof(CM_B_ATTACHMENT_ARCHIVE))]
		[JsonProperty(Order = -10)]
		public long AttachmentCounter { get; set; }

		[FieldMapper(nameof(CM_B_ATTACHMENT.REASON_ID), ReadOnly = true)]
		[JsonProperty(Order = -10)]
		public Guid ReasonId { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CM_B_ATTACHMENT.ATTACHMENT_DATE))]
		public DateTime? AttachmentDate { get; set; }

		[FieldMapper(nameof(CM_B_ATTACHMENT.CUSTOMER_CODE))]
		[JsonProperty(Order = -10)]
		public string CustomerCode { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CM_B_ATTACHMENT.ATTACHMENT_TYPE_CODE))]
		public string AttachmentTypeCode { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CM_B_ATTACHMENT.ATTACHMENT_NAME))]
		public string AttachmentName { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CM_B_ATTACHMENT.DT_EXPIRATION))]
		public DateTime? DtExpiration { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CM_B_ATTACHMENT.DOCUMENT_TYPE_CODE))]
		public string DocumentTypeCode { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CM_B_ATTACHMENT.DOCUMENT_NUMBER))]
		public string DocumentNumber { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CM_B_ATTACHMENT.DOCUMENT_DATE))]
		public DateTime? DocumentDate { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CM_B_ATTACHMENT.VERSION))]
		public string Version { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CM_B_ATTACHMENT.REASON_CODE))]
		public string ReasonCode { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CM_B_ATTACHMENT.NOTE))]
		public string Note { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CM_B_ATTACHMENT.STATUS_CODE))]
		public string StatusCode { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CM_B_ATTACHMENT.DT_UPDATE_STATUS))]
		public DateTime? DtUpdateStatus { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CM_B_ATTACHMENT.VALIDATION_STATUS_CODE))]
		public string ValidationStatusCode { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CM_B_ATTACHMENT.DT_UPDATE_VALIDATION_STATUS))]
		public DateTime? DtUpdateValidationStatus { get; set; }

		public AttachmentBase()
		{

		}
	}
}
