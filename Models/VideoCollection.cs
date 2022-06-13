using System.ComponentModel.DataAnnotations;

namespace WebApiMySQL.Models;

public class VideoCollection
{
    public int Id { get; set; }
    public string MovieTitle { get; set; } = string.Empty;
    [Range(1600, 2100)]
    public int? YearReleased { get; set; }
    [Range(0.0, 10.0)]
    public double Rating { get; set; }
    public string Subject { get; set; } = string.Empty;
    public double Length { get; set; }
    public string? Note { get; set; }
    public int FriendId { get; set; }
    public Friend Friend { get; set; }
}
public class VideoCollectionDTO
{
    public string MovieTitle { get; set; } = string.Empty;
    [Range(1600, 2100)]
    public int? YearReleased { get; set; }
    [Range(0.0, 10.0)]
    public double Rating { get; set; }
    public string Subject { get; set; } = string.Empty;
    public double Length { get; set; }
    public string? Note { get; set; }
    public int FriendId { get; set; }
}