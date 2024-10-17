﻿using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace BookInformationService.Models
{
    /// <summary>
    /// Represents the information about a book and maps it to the database.
    /// </summary>
    public class BookInformation
    {
        /// <summary>
        /// Gets or sets the unique identifier of the book information.
        /// </summary>
        /// <example>1</example>
        [Required]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the book information.
        /// </summary>
        /// <example>The Great Gatsby</example>
        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public required string Title { get; set; }

        /// <summary>
        /// Gets or sets the stock of the book information.
        /// </summary>
        /// <example>5</example>
        [Required]
        [Range(0, 100)]
        public int Stock { get; set; }

        /// <summary>
        /// Gets or sets the available stock of the book information.
        /// </summary>
        /// <example>5</example>
        [Required]
        [Range(0, 100)]
        public int Available { get; set; }
    }
}
