using FreeSql.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace ClickHouseJsonTextIssue
{
    internal class Entity
    {
        [Required]
        [Column(IsIdentity = true)]
        public string Id { get; set; }

        [Column(StringLength = -2)]
        public string Content { get; set; }
    }
}
