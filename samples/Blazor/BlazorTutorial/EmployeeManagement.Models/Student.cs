namespace EmployeeManagement.Models;

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
    public string FirstName { get; set; }

    /// <summary>
    /// 名
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
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
    /// 班级
    /// </summary>
    public StudentClass StudentClass { get; set; }

    /// <summary>
    /// 头像地址
    /// </summary>
    public string PhotoPath { get; set; }
}