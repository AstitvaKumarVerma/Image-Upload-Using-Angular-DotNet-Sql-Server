using System;
using System.Collections.Generic;

namespace StoreImageApi.Models
{
    public partial class StoreImages3008
    {
        public int Id { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageLocation { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
