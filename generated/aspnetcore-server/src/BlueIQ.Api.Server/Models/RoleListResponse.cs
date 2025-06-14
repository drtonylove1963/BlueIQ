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
    public partial class RoleListResponse : IEquatable<RoleListResponse>
    {
        /// <summary>
        /// Gets or Sets Roles
        /// </summary>
        [DataMember(Name="roles", EmitDefaultValue=false)]
        public List<Role> Roles { get; set; }

        /// <summary>
        /// Gets or Sets Pagination
        /// </summary>
        [DataMember(Name="pagination", EmitDefaultValue=false)]
        public Pagination Pagination { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RoleListResponse {\n");
            sb.Append("  Roles: ").Append(Roles).Append("\n");
            sb.Append("  Pagination: ").Append(Pagination).Append("\n");
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
            return obj.GetType() == GetType() && Equals((RoleListResponse)obj);
        }

        /// <summary>
        /// Returns true if RoleListResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of RoleListResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RoleListResponse other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Roles == other.Roles ||
                    Roles != null &&
                    other.Roles != null &&
                    Roles.SequenceEqual(other.Roles)
                ) && 
                (
                    Pagination == other.Pagination ||
                    Pagination != null &&
                    Pagination.Equals(other.Pagination)
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
                    if (Roles != null)
                    hashCode = hashCode * 59 + Roles.GetHashCode();
                    if (Pagination != null)
                    hashCode = hashCode * 59 + Pagination.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(RoleListResponse left, RoleListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RoleListResponse left, RoleListResponse right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
