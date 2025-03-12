using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("user")] 
public class User
{
    [Key]
    [Column("id_user")] 
    public int IdUser { get; set; }

    [Required]
    [Column("username")]
    public string? Username { get; set; }

    [Required]
    [Column("passwordhash")]
    public string? PasswordHash { get; set; }

    [Column("fullname")]
    public string? FullName { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("phone")]
    public int? Phone { get; set; }

    [Column("id_role")]
    public int IdRole { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("createdate")]
    public DateTime? CreateDate { get; set; }

    [Column("last_logindate")]
    public DateTime? LastLoginDate { get; set; }

    [Column("profileimage")]
    public string? ProfileImage { get; set; }

    [Column("accesstoken")]
    public string? AccessToken { get; set; }

    [Column("refreshtoken")]
    public string? RefreshToken { get; set; }

    [Column("email_value")]
    public bool? EmailValue { get; set; }
}
