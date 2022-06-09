using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiMySQL.Models;

public class Friend
{
    [Column("friend_id")]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    [Column("post_code")]
    public string? PostCode { get; set; }
    [Column("home_phone")]
    public string? HomePhone { get; set; }
}