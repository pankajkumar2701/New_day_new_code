using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Newdaynewcode.Model
{
    /// <summary> 
    /// Represents a role entity with essential details
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Primary key for the Role 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the Role 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Foreign key referencing the Tenant to which the Role belongs 
        /// </summary>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? Tenant { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<UserRole>? UserRoles { get; set; }
    }
}