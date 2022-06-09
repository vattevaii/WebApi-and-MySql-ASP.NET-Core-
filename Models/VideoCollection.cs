using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiMySQL.Models;

public class VideoCollection
{
    [Column("video_collection_id")]
   public int Id { get; set; }
    [Column("movie_title")]
   public string? MovieTitle { get; set; }
    [Column("year_released")]
   public int YearReleased { get; set; }
   public float Rating { get; set; }
   public string? Subject { get; set; }
   public int Length { get; set; }
   public string? Note { get; set; }
    [Column("friend_id")]
   public int FriendId { get; set; }
}