using LinqToDB.Mapping;

namespace Linq2db.Web.Api
{
    /// <summary>
    /// The SMS log document
    /// </summary>
    [Table("SmsLogDocument")]
    public class SmsLogDocument
    {
        /// <summary>
        /// Gets or sets the document identifier.
        /// </summary>
        /// <value>
        /// The document identifier.
        /// </value>
        [PrimaryKey, NotNull]
        public string DocumentId { get; set; }

        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        [Column]
        public string To { get; set; }

        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>
        /// The message identifier.
        /// </value>
        [Column]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the request body.
        /// </summary>
        /// <value>
        /// The request body.
        /// </value>
        [Column]
        public string RequestBody { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        [Column]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        [Column]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        [Column]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the created at UTC.
        /// </summary>
        /// <value>
        /// The created at UTC.
        /// </value>
        [PrimaryKey, NotNull]
        public DateTime CreatedAtUtc { get; set; }

        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        [Column]
        public string Provider { get; set; }
    }
}


