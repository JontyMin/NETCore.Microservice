using System.ComponentModel.DataAnnotations;
using StudentManagement.Models;
using StudentManagement.Models.CustomValidators;

namespace StudentManagement.Web.Models;

public class EditStudentModel
{

    /// <summary>
    /// 学生Id
    /// </summary>
    public int StudentId { get; set; }

    /// <summary>
    /// 姓
    /// </summary>
    [Required(ErrorMessage = "不能为空")]
    [MinLength(2, ErrorMessage = "长度不能小于2")]
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
    [EmailAddress]
    [EmailDomainValidator(AllowedDomain = "yoyomooc.com", ErrorMessage = "仅支持yoyomooc邮箱")]
    public string Email { get; set; }

    [Compare("Email",ErrorMessage = "邮箱不一致")]
    public string ConfirmEmail { get; set; }

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
    [ValidateComplexType]
    public StudentClass Class { get; set; }

    /// <summary>
    /// 头像地址
    /// </summary>
    public string PhotoPath { get; set; }
}