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
    public partial class Pagination : IEquatable<Pagination>
    {
        /// <summary>
        /// Gets or Sets TotalItems
        /// </summary>
        /* <example>100</example> */
        [DataMember(Name="totalItems", EmitDefaultValue=true)]
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or Sets TotalPages
        /// </summary>
        /* <example>5</example> */
        [DataMember(Name="totalPages", EmitDefaultValue=true)]
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or Sets CurrentPage
        /// </summary>
        /* <example>1</example> */
        [DataMember(Name="currentPage", EmitDefaultValue=true)]
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or Sets PageSize
        /// </summary>
        /* <example>20</example> */
        [DataMember(Name="pageSize", EmitDefaultValue=true)]
        public int PageSize { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Pagination {\n");
            sb.Append("  TotalItems: ").Append(TotalItems).Append("\n");
            sb.Append("  TotalPages: ").Append(TotalPages).Append("\n");
            sb.Append("  CurrentPage: ").Append(CurrentPage).Append("\n");
            sb.Append("  PageSize: ").Append(PageSize).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Pagination)obj);
        }

        /// <summary>
        /// Returns true if Pagination instances are equal
        /// </summary>
        /// <param name="other">Instance of Pagination to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Pagination other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    TotalItems == other.TotalItems ||
                    
                    TotalItems.Equals(other.TotalItems)
                ) && 
                (
                    TotalPages == other.TotalPages ||
                    
                    TotalPages.Equals(other.TotalPages)
                ) && 
                (
                    CurrentPage == other.CurrentPage ||
                    
                    CurrentPage.Equals(other.CurrentPage)
                ) && 
                (
                    PageSize == other.PageSize ||
                    
                    PageSize.Equals(other.PageSize)
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
                    
                    hashCode = hashCode * 59 + TotalItems.GetHashCode();
                    
                    hashCode = hashCode * 59 + TotalPages.GetHashCode();
                    
                    hashCode = hashCode * 59 + CurrentPage.GetHashCode();
                    
                    hashCode = hashCode * 59 + PageSize.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Pagination left, Pagination right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pagination left, Pagination right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
