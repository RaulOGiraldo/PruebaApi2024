using PostgresSql.Data;
using Prueba.Core.DTOs;
using Prueba.Core.Entities;
using Prueba.Core.Interfaces;

namespace Prueba.Core.Helpers
{
    public class AutoMapperData : IAutoMapperData
    {
        public List<UsersInRolesDTO> MapearUsersInRoles(List<User> listadoUsers)
        {
            var resultado = new List<UsersInRolesDTO>();
            if (listadoUsers != null)
            {
                foreach (var users in listadoUsers)
                {
                    resultado.Add(new UsersInRolesDTO()
                    {
                        UseId = users.UseId,
                        UseName = users.UseName,
                        UseDocument = users.UseDocument,
                        Roles = MapearRoles(users.UsersInRoles)

                    });
                }
            }
            return resultado;
        }

        public UsersInRolesDTO MapearUserInRol(User user)
        {
            var resultado = new UsersInRolesDTO();
            if (user != null)
            {
                resultado.UseId = user.UseId;
                resultado.UseName = user.UseName;
                resultado.UseDocument = user.UseDocument;
                resultado.Roles = MapearRoles(user.UsersInRoles);
            }
            return resultado;
        }

        public List<RolDTO> MapearRoles(List<UsersInRoles> listadoUserRoles)
        {
            var resultado = new List<RolDTO>();
            if (listadoUserRoles != null)
            {
                foreach (var usersroles in listadoUserRoles)
                {
                    var roles = usersroles.Rol;
                    resultado.Add(new RolDTO()
                    {
                        RolId = roles.RolId,
                        RolName = roles.RolName,    
                    });
                }
            }
            return resultado;

        }

        public User DevolverUsersInRoles(UserCreacionDTO userCreacionDTO)
        {
            User user = new User();
            user.UseId = userCreacionDTO.UseId;
            user.UseName = userCreacionDTO.UseName;
            user.UseDocument = userCreacionDTO.UseDocument;

            var usersInRoles = new List<UsersInRoles>();

            if (userCreacionDTO.Roles != null)
            {
                foreach (var role in userCreacionDTO.Roles)
                {
                    usersInRoles.Add(new UsersInRoles
                    {
                        UsurolUsuId = user.UseId,
                        UsurolRolId = role.RolId
                    });
                }
                user.UsersInRoles = usersInRoles;
            }

            return user;
        }


        public List<TransactionDTO> MapearTransactions(List<Transaction> listTransac)
        {
            var resultado = new List<TransactionDTO>();
            if (listTransac != null)
            {
                foreach (var trans in listTransac)
                {
                    resultado.Add(new TransactionDTO()
                    {

                        TraId = trans.TraId,
                        TraProId = trans.TraProId,
                        TraDate = trans.TraDate,
                        TraUnits = trans.TraUnits,
                        TraIsDeleted = trans.TraIsDeleted,
                        TraUseId = trans.TraId,
                        TraProductos = MapearProducts(trans.TraProductos),
                        User = MapearUserTransctions(trans.User)
                    });
                }
            }
            return resultado;
        }

        public TransactionDTO MapearOneTransaction(Transaction transac)
        {
            var resultado = new TransactionDTO();
            if (transac != null)
            {
                resultado.TraId = transac.TraId;
                resultado.TraProId = transac.TraProId;
                resultado.TraDate = transac.TraDate;
                resultado.TraUnits = transac.TraUnits;
                resultado.TraIsDeleted = transac.TraIsDeleted;
                resultado.TraUseId = transac.TraId;
                resultado.TraProductos = MapearProducts(transac.TraProductos);
                resultado.User = MapearUserTransctions(transac.User);
            }
            return resultado;
        }

        public Transaction ConsultaDataTransaction(TransactionCreacionDTO transacCreacionDTO, Product product, User user)
        {
            Transaction transaction = new Transaction();

            transaction.TraId = transacCreacionDTO.TraId;
            transaction.TraProId = transacCreacionDTO.TraProId;
            transaction.TraDate = transacCreacionDTO.TraDate;
            transaction.TraUnits = transacCreacionDTO.TraUnits;
            transaction.TraIsDeleted = transacCreacionDTO.TraIsDeleted;
            transaction.TraUseId = transacCreacionDTO.TraId;

            transaction.TraProductos = product;
            transaction.User = user;

            return transaction;
        }

        public ProductDTO MapearProducts(Product prod)
        {
            var resultado = new ProductDTO();
            if (prod != null)
            {
                resultado.ProId = prod.ProId;
                resultado.ProName = prod.ProName;
                resultado.ProStock = prod.ProStock; 
                resultado.ProIsdeleted = prod.ProIsdeleted;
            }
            return resultado;
        }

        public TransactionUserDTO MapearUserTransctions(User user)
        {
            var resultado = new TransactionUserDTO();
            if (user != null)
            {
                resultado.UseId = user.UseId;
                resultado.UseName = user.UseName;
                resultado.UseDocument = user.UseDocument;
                resultado.Roles = MapearRoles(user.UsersInRoles);
            }
            return resultado;
        }

        public bool BuscarPermisos(User user, int mode = 0)
        {
            var resp = false;

            if (user != null)
            {
                foreach (var userInRol in user.UsersInRoles)
                {
                    var role = userInRol.Rol;
                    if ((role.RolName.Equals("Admin") || role.RolName.Equals("Cashier")) && mode == 1) // Ingresar
                    {
                        resp = true;    
                    }
                    if ((role.RolName.Equals("Admin") || role.RolName.Equals("Supervisor")) && mode == 3) // Eliminar
                    {
                        resp = true;
                    }

                }
            }
            return resp;
        }

        public decimal ValidarSaldo(Product prod, TransactionCreacionDTO trans)
        {
            var VlrSaldo = prod.ProStock;
            var vlrDesc = trans.TraUnits;
            var saldo = (VlrSaldo - vlrDesc);
            return saldo;
        }

    }
}
