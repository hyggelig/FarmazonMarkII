using Farmazon.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmazon.DAL.DataManager
{
    public class UserManager : IDataRepository<Users>
    {
        readonly FarmaContext _usersContext;

        public UserManager(FarmaContext context)
        {
            _usersContext = context;
        }

        public IEnumerable<Users> GetAll()
        {
            return _usersContext.User.ToList();
        }

        public Users Get(long id)
        {
            return _usersContext.User
                  .FirstOrDefault(e => e.userId == id);
        }


        public void Create(Users entity)
        {
            _usersContext.User.Add(entity);
            _usersContext.SaveChanges();
        }

        public void Update(Users user, Users entity)
        {
            user.userId = entity.userId;
            user.userPassword = entity.userPassword;
            user.firstName = entity.firstName;
            user.lastName = entity.lastName;
            user.email = entity.email;
            user.dateOfBirth = entity.dateOfBirth;
            user.phoneNumber = entity.phoneNumber;

            _usersContext.SaveChanges();
        }

        public void Delete(Users user)
        {
            _usersContext.User.Remove(user);
            _usersContext.SaveChanges();
        }

        public IEnumerable<Users> GetUsersProducts(long ownerId, string ownerName, string ownerLastName)
        {
            throw new NotImplementedException();
        }
    }
}

