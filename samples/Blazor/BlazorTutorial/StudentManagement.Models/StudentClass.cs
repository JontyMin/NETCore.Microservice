using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models;

/// <summary>
/// 班级
/// </summary>
public class StudentClass
{
    /// <summary>
    /// 班级Id
    /// </summary>
    [Key]
    public int ClassId { get; set; }

    /// <summary>
    /// 班级名称
    /// </summary>
    public string ClassName { get; set; }
}