﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
	[Table("tag", Schema = "trip_advisor")]
	public partial class Tag
	{
		public Tag()
		{
			Places = new HashSet<Place>();
		}

		[Key, Column("tag_id")]
		public int TagId { get; set; }
		[Column("type"), DataType(DataType.Text), StringLength(255), Required]
		public string Type { get; set; }

		public virtual ICollection<Place> Places { get; set; }
	}
}
