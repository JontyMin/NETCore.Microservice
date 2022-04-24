using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace StudentManagement.Models;

/// <summary>
/// 学生
/// </summary>
public class Student
{
    /// <summary>
    /// 学生Id
    /// </summary>
    public int StudentId { get; set; }

    /// <summary>
    /// 姓
    /// </summary>
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; set; }

    /// <summary>
    /// 名
    /// </summary>
    [Required]
    public string LastName { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [Required]
    public string Email { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    public DateTime DateOfBrith { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// 班级Id
    /// </summary>
    public int ClassId { get; set; }

    /// <summary>
    /// 班级
    /// </summary>
    public StudentClass Class { get; set; }

    /// <summary>
    /// 头像地址
    /// </summary>
    public string PhotoPath { get; set; }
}