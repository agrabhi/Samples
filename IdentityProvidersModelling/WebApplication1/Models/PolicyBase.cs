using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public abstract class PolicyBase
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the displayName
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyBase"/> class.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="description">Description</param>
        /// <param name="displayName">DisplayName</param>
        protected PolicyBase(string id, string description, String displayName)
        {
            this.Id = id;
            this.Description = description;
            this.DisplayName = displayName;
        }
    }
}