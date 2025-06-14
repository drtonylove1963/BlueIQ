/*
 * BlueIQ API Gateway
 *
 * This document describes the API for the BlueIQ API Gateway. It serves as the single entry point for all client interactions with the BlueIQ microservices. This specification is designed to be a reference for consumers and a template for similar gateway patterns. 
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: support@example.com
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using BlueIQ.Api.Server.Converters;

namespace BlueIQ.Api.Server.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class User : IEquatable<User>
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        /* <example>d290f1ee-6c54-4b01-90e6-d701748f0851</example> */
        [DataMember(Name="id", EmitDefaultValue=true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        /* <example>johndoe</example> */
        [DataMember(Name="username", EmitDefaultValue=false)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        /* <example>johndoe@example.com</example> */
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        /* <example>John</example> */
        [DataMember(Name="firstName", EmitDefaultValue=true)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        /* <example>Doe</example> */
        [DataMember(Name="lastName", EmitDefaultValue=true)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets IsActive
        /// </summary>
        /* <example>true</example> */
        [DataMember(Name="isActive", EmitDefaultValue=true)]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// List of role IDs assigned to the user.
        /// </summary>
        /// <value>List of role IDs assigned to the user.</value>
        /* <example>[&quot;f47ac10b-58cc-4372-a567-0e02b2c3d479&quot;]</example> */
        [DataMember(Name="roleIds", EmitDefaultValue=false)]
        public List<Guid> RoleIds { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        /* <example>2023-01-15T10:30Z</example> */
        [DataMember(Name="createdAt", EmitDefaultValue=true)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        /* <example>2023-01-16T12:45Z</example> */
        [DataMember(Name="updatedAt", EmitDefaultValue=true)]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class User {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  IsActive: ").Append(IsActive).Append("\n");
            sb.Append("  RoleIds: ").Append(RoleIds).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((User)obj);
        }

        /// <summary>
        /// Returns true if User instances are equal
        /// </summary>
        /// <param name="other">Instance of User to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(User other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    
                    Id.Equals(other.Id)
                ) && 
                (
                    Username == other.Username ||
                    Username != null &&
                    Username.Equals(other.Username)
                ) && 
                (
                    Email == other.Email ||
                    Email != null &&
                    Email.Equals(other.Email)
                ) && 
                (
                    FirstName == other.FirstName ||
                    FirstName != null &&
                    FirstName.Equals(other.FirstName)
                ) && 
                (
                    LastName == other.LastName ||
                    LastName != null &&
                    LastName.Equals(other.LastName)
                ) && 
                (
                    IsActive == other.IsActive ||
                    
                    IsActive.Equals(other.IsActive)
                ) && 
                (
                    RoleIds == other.RoleIds ||
                    RoleIds != null &&
                    other.RoleIds != null &&
                    RoleIds.SequenceEqual(other.RoleIds)
                ) && 
                (
                    CreatedAt == other.CreatedAt ||
                    
                    CreatedAt.Equals(other.CreatedAt)
                ) && 
                (
                    UpdatedAt == other.UpdatedAt ||
                    
                    UpdatedAt.Equals(other.UpdatedAt)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Username != null)
                    hashCode = hashCode * 59 + Username.GetHashCode();
                    if (Email != null)
                    hashCode = hashCode * 59 + Email.GetHashCode();
                    if (FirstName != null)
                    hashCode = hashCode * 59 + FirstName.GetHashCode();
                    if (LastName != null)
                    hashCode = hashCode * 59 + LastName.GetHashCode();
                    
                    hashCode = hashCode * 59 + IsActive.GetHashCode();
                    if (RoleIds != null)
                    hashCode = hashCode * 59 + RoleIds.GetHashCode();
                    
                    hashCode = hashCode * 59 + CreatedAt.GetHashCode();
                    
                    hashCode = hashCode * 59 + UpdatedAt.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(User left, User right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(User left, User right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
