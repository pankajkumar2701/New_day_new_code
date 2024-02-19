using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Newdaynewcode.Model
{
    /// <summary> 
    /// Represents a user entity with essential details
    /// </summary>
    public class User
    {
        /// <summary>
        /// Primary key for the User 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the User 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Required field EmailId of the User 
        /// </summary>
        [Required]
        public string EmailId { get; set; }

        /// <summary>
        /// Required field DOB of the User 
        /// </summary>
        [Required]
        public DateTime DOB { get; set; }
        /// <summary>
        /// Foreign key referencing the Tenant to which the User belongs 
        /// </summary>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? Tenant { get; set; }
        /// <summary>
        /// CreatedOn of the User 
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// UpdatedOn of the User 
        /// </summary>
        public DateTime UpdatedOn { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<UserRole>? UserRoles { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Author>? Authors { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Books>? Bookss { get; set; }
    }
}