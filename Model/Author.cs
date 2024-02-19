using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Newdaynewcode.Model
{
    /// <summary> 
    /// Represents a author entity with essential details
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Primary key for the Author 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the Author 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Foreign key referencing the Tenant to which the Author belongs 
        /// </summary>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? Tenant { get; set; }
        /// <summary>
        /// CreatedOn of the Author 
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Author belongs 
        /// </summary>
        public Guid CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedByUser { get; set; }
        /// <summary>
        /// UpdatedOn of the Author 
        /// </summary>
        public DateTime UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Author belongs 
        /// </summary>
        public Guid UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedByUser { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Books>? Bookss { get; set; }
    }
}