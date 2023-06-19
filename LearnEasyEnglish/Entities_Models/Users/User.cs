using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Entities_Models.Users;

public sealed class User:Auditable
{
    [MaxLength(50)]
    public string First_Name { get; set; } = String.Empty;
    [MaxLength(50)]
    public string Last_Name { get; set; } = String.Empty;
    [MaxLength(64)]
    public string Email { get; set; } = String.Empty;
    [MaxLength(15)]
    public string Phone_Number { get; set; } = String.Empty;
    [MaxLength(50)]
    public string Username { get; set; } = String.Empty;
    public string Password_hash { get; set; } = String.Empty;
    public string Salt { get; set; } = String.Empty;      
}
