using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiMySQL.Models;

public class VideoCollection
{
    [Column("video_collection_id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("movie_title")]
    [StringLength(45, MinimumLength = 1)]
    public string MovieTitle { get; set; } = string.Empty;
    [Column("year_released")]
    [Range(1600, 2100)]
    public int? YearReleased { get; set; }
    [Range(0.0, 10.0)]
    public float Rating { get; set; }
    [StringLength(45, MinimumLength = 3)]
    public string Subject { get; set; } = string.Empty;
    public int Length { get; set; }
    public string? Note { get; set; }
    [Column("friend_id")]
    [Required]
    public int FriendId { get; set; }
    public virtual Friend Friend { get; set; } = new Friend();
}