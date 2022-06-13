using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiMySQL.Models;

public class Friend
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string PostCode { get; set; } = string.Empty;
    public string HomePhone { get; set; } = string.Empty;
    public IEnumerable<VideoCollection> videoCollections { get; set; }
}

public class FriendDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string PostCode { get; set; } = string.Empty;
    public string HomePhone { get; set; } = string.Empty;
}


