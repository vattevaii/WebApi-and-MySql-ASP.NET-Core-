using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiMySQL.Models;

public class Friend
{
    [Column("friend_id")]
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    [Column("post_code")]
    public string PostCode { get; set; } = string.Empty;
    [Column("home_phone")]
    public string HomePhone { get; set; } = string.Empty;
}
