﻿// <copyright file="OrderItem.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Nest;
using OnlineSales.DataAnnotations;

namespace OnlineSales.Entities;

[SupportsElastic]
[SupportsChangeLog]
[Table("order_item")]
public class OrderItem : BaseEntity
{
    /// <summary>
    /// Gets or sets reference to Order table.
    /// </summary>
    [Required]
    public int OrderId { get; set; }

    [Ignore]
    [JsonIgnore]
    [ForeignKey("OrderId")]
    public virtual Order? Order { get; set; }

    /// <summary>
    /// Gets or sets the name of the product as defined by vendor.
    /// </summary>
    [Searchable]
    [Required]
    public string ProductName { get; set; } = string.Empty;

    /// TODO: LicenseCode should be moved away from OnlineSales.Core project as it is product specific property
    /// <summary>
    /// Gets or sets license code generated by the vendor.
    /// </summary>
    [Ignore]
    [Required]   
    public string LicenseCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets total amount converted to a system currency (or payout currency) like USD without TAXes, discounts and commissions (how much will be paid out to vendor).
    /// </summary>
    [Searchable]
    [Required]
    public decimal Total { get; set; } = 0;

    /// <summary>
    /// Gets or sets the currency ISO code for the payment - ISO 4217. Example: "USD".
    /// </summary>
    [Searchable]
    [Required]
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets total amount in the payment currency without TAXes, discounts and commissions.
    /// </summary>
    [Searchable]
    [Required]
    public decimal CurrencyTotal { get; set; } = 0;

    /// <summary>
    /// Gets or sets total amount of all items in the current order.
    /// </summary>
    [Searchable]
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets unit price in the payment currency without TAXes, discounts and commissions.
    /// </summary>
    [Searchable]
    public decimal UnitPrice { get; set; }
}