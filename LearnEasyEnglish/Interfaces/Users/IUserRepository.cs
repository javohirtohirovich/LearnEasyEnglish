using LearnEasyEnglish.Entities_Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Interfaces;

public interface IUsersRepository:IRepository<User>
{
    public Task<int> CountAsync();
}
